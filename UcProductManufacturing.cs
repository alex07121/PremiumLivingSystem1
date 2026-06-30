using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    /// <summary>
    /// Production staff user control for manufacturing.
    /// Workflow: search an order whose Status='InProduction' -> view its
    /// customization spec + customer-uploaded reference images (LONGBLOB).
    ///
    /// IMPORTANT: This control's Designer.cs is hand-written. Do NOT open it
    /// in the Visual Studio Designer view (use F7 / View Code) — opening the
    /// Designer will regenerate Designer.cs and wipe the layout.
    /// </summary>
    public partial class UcProductManufacturing : UserControl
    {
        public UcProductManufacturing()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------
        // Form load — pre-populate the order list so staff see the work queue
        // -------------------------------------------------------------------
        private void UcProductManufacturing_Load(object sender, EventArgs e)
        {
            lvOrders.View = View.Details;
            lvOrders.FullRowSelect = true;
            lvOrders.GridLines = true;
            lvOrders.MultiSelect = false;

            LoadOrders();
        }

        // -------------------------------------------------------------------
        // Search button — refresh ListView filtered by OrderID keyword
        // -------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            string keyword = txtOrderSearch.Text.Trim();

            string query = @"
                SELECT OrderID, CustomerID, OrderDate, RequiredDate, Status
                FROM `Order`
                WHERE Status = 'InProduction'
                  AND (@keyword = '' OR OrderID LIKE CONCAT('%', @keyword, '%'))
                ORDER BY OrderDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", keyword);

                    conn.Open();
                    lvOrders.BeginUpdate();
                    lvOrders.Items.Clear();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                            item.SubItems.Add(SafeDate(reader["OrderDate"]));
                            item.SubItems.Add(SafeDate(reader["RequiredDate"]));
                            item.SubItems.Add(reader["CustomerID"].ToString());
                            item.SubItems.Add(reader["Status"].ToString());
                            lvOrders.Items.Add(item);
                        }
                    }
                    lvOrders.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------
        // ListView selection changed — load custom items list for the order.
        // If the order has 1 custom item, auto-select it. If multiple, the
        // user picks from cboCustomItem; the SelectedIndexChanged handler
        // then loads spec + images for that SPECIFIC OrderItemID.
        // -------------------------------------------------------------------
        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrders.SelectedItems.Count == 0)
            {
                ClearSpec();
                ClearImages();
                cboCustomItem.DataSource = null;
                cboCustomItem.Enabled = false;
                return;
            }

            string selectedOrderId = lvOrders.SelectedItems[0].Text;
            LoadCustomItems(selectedOrderId);
        }

        // -------------------------------------------------------------------
        // [Multi-custom support] Populate cboCustomItem with all custom items
        // in the selected order. DisplayMember = "DisplayText",
        // ValueMember = "OrderItemID".
        // -------------------------------------------------------------------
        private void LoadCustomItems(string orderId)
        {
            string query = @"
                SELECT oi.OrderItemID, oi.ProductID, p.ProductName, oi.Quantity
                FROM OrderItem oi
                JOIN `Order` o ON oi.OrderID = o.OrderID
                LEFT JOIN Product p ON oi.ProductID = p.ProductID
                WHERE o.OrderID = @orderId AND oi.ItemType = 'Custom'
                ORDER BY oi.OrderItemID";

            var items = new System.Collections.Generic.List<CustomItemEntry>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemId = reader["OrderItemID"].ToString();
                            string productId = reader["ProductID"] == DBNull.Value ? "" : reader["ProductID"].ToString();
                            string productName = reader["ProductName"] == DBNull.Value
                                ? productId
                                : reader["ProductName"].ToString();
                            int qty = reader["Quantity"] == DBNull.Value ? 1 : Convert.ToInt32(reader["Quantity"]);

                            items.Add(new CustomItemEntry
                            {
                                OrderItemID = itemId,
                                DisplayText = $"{productName} (x{qty}) — {itemId}"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading custom items: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Detach handler while rebinding so we don't fire spuriously.
            cboCustomItem.SelectedIndexChanged -= cboCustomItem_SelectedIndexChanged;
            cboCustomItem.DataSource = items;
            cboCustomItem.DisplayMember = "DisplayText";
            cboCustomItem.ValueMember = "OrderItemID";
            cboCustomItem.SelectedIndex = -1;
            cboCustomItem.SelectedIndexChanged += cboCustomItem_SelectedIndexChanged;

            cboCustomItem.Enabled = items.Count > 0;

            if (items.Count == 0)
            {
                ClearSpec();
                ClearImages();
                lblDescription.Text = "No custom items for this order.";
                lblNoImages.Visible = true;
                flowLayoutPanelImages.Visible = false;
            }
            else
            {
                // Auto-select first item (works for both single and multi-custom).
                cboCustomItem.SelectedIndex = 0;
            }
        }

        // -------------------------------------------------------------------
        // [Multi-custom support] ComboBox selection changed — load spec +
        // images for the SPECIFIC OrderItemID, not the whole order.
        // -------------------------------------------------------------------
        private void cboCustomItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomItem.SelectedIndex < 0 || cboCustomItem.SelectedValue == null)
                return;

            string orderItemId = cboCustomItem.SelectedValue.ToString();
            LoadCustomizationSpec(orderItemId);
            LoadCustomImages(orderItemId);
        }

        // -------------------------------------------------------------------
        // Load customization spec for a SPECIFIC OrderItemID
        // (changed from orderId -> orderItemId for multi-custom support)
        // -------------------------------------------------------------------
        private void LoadCustomizationSpec(string orderItemId)
        {
            string query = @"
                SELECT oic.DimensionL, oic.DimensionW, oic.DimensionH,
                       oic.Material, oic.Color, oic.FinishType, oic.CustomDescription
                FROM OrderItemCustomization oic
                WHERE oic.OrderItemID = @orderItemId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderItemId", orderItemId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblDimL.Text = SafeDec(reader["DimensionL"]);
                            lblDimW.Text = SafeDec(reader["DimensionW"]);
                            lblDimH.Text = SafeDec(reader["DimensionH"]);
                            lblMaterial.Text = SafeStr(reader["Material"]);
                            lblColor.Text = SafeStr(reader["Color"]);
                            lblFinishType.Text = SafeStr(reader["FinishType"]);
                            lblDescription.Text = SafeStr(reader["CustomDescription"]);
                        }
                        else
                        {
                            ClearSpec();
                            lblDescription.Text = "No customization record for this item.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customization spec: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------
        // Load custom images (LONGBLOB) for a SPECIFIC OrderItemID
        // (changed from orderId -> orderItemId for multi-custom support)
        // -------------------------------------------------------------------
        private void LoadCustomImages(string orderItemId)
        {
            ClearImages();

            string query = @"
                SELECT ci.ImageID, ci.ImageData
                FROM OrderItemCustomization oic
                JOIN CustomizationImage ci ON oic.CustomID = ci.CustomID
                WHERE oic.OrderItemID = @orderItemId";

            int imageCount = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderItemId", orderItemId);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ImageData"] == DBNull.Value) continue;
                            byte[] imageBytes = (byte[])reader["ImageData"];
                            string imageId = reader["ImageID"].ToString();
                            AddThumbnailToPanel(imageBytes, imageId);
                            imageCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading custom images: " + ex.Message);
            }

            lblNoImages.Visible = (imageCount == 0);
            flowLayoutPanelImages.Visible = (imageCount > 0);
        }

        // -------------------------------------------------------------------
        // Add a thumbnail PictureBox to the FlowLayoutPanel
        // (Pattern copied from UcProcessReturn.AddThumbnailToPanel)
        // -------------------------------------------------------------------
        private void AddThumbnailToPanel(byte[] imageBytes, string imageId)
        {
            if (imageBytes == null || imageBytes.Length == 0) return;

            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                using (Image originalImage = Image.FromStream(ms))
                {
                    using (Image thumbnail = originalImage.GetThumbnailImage(100, 100, null, IntPtr.Zero))
                    {
                        PictureBox pb = new PictureBox
                        {
                            Image = new Bitmap(thumbnail),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(100, 100),
                            BorderStyle = BorderStyle.FixedSingle,
                            Cursor = Cursors.Hand,
                            Tag = imageBytes
                        };
                        pb.Click += Thumbnail_Click;
                        flowLayoutPanelImages.Controls.Add(pb);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating thumbnail: " + ex.Message);
            }
        }

        // -------------------------------------------------------------------
        // Click thumbnail -> show full-size image in popup Form
        // (Pattern copied from UcProcessReturn.Thumbnail_Click)
        // -------------------------------------------------------------------
        private void Thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb?.Tag is byte[] imageBytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    using (Image fullImage = Image.FromStream(ms))
                    {
                        Form imageForm = new Form
                        {
                            Text = "Custom Reference Image",
                            StartPosition = FormStartPosition.CenterParent,
                            Size = new Size(600, 600)
                        };

                        PictureBox fullPb = new PictureBox
                        {
                            Image = new Bitmap(fullImage),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Dock = DockStyle.Fill
                        };
                        imageForm.Controls.Add(fullPb);
                        imageForm.ShowDialog();

                        fullPb.Image?.Dispose();
                        fullPb.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying image: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -------------------------------------------------------------------
        // Dispose all thumbnail PictureBoxes before next load
        // (Pattern copied from UcProcessReturn.ClearImages)
        // -------------------------------------------------------------------
        private void ClearImages()
        {
            foreach (Control ctrl in flowLayoutPanelImages.Controls.Cast<Control>().ToList())
            {
                if (ctrl is PictureBox pbox && pbox.Image != null)
                {
                    var img = pbox.Image;
                    pbox.Image = null;
                    img.Dispose();
                }
                ctrl.Dispose();
            }
            flowLayoutPanelImages.Controls.Clear();
        }

        private void ClearSpec()
        {
            lblDimL.Text = "";
            lblDimW.Text = "";
            lblDimH.Text = "";
            lblMaterial.Text = "";
            lblColor.Text = "";
            lblFinishType.Text = "";
            lblDescription.Text = "";
        }

        // -------------------------------------------------------------------
        // Safe column readers
        // -------------------------------------------------------------------
        private static string SafeDate(object value)
        {
            if (value == null || value == DBNull.Value) return "";
            DateTime dt;
            return DateTime.TryParse(value.ToString(), out dt) ? dt.ToString("yyyy-MM-dd") : value.ToString();
        }

        private static string SafeDec(object value)
        {
            if (value == null || value == DBNull.Value) return "";
            return Convert.ToDecimal(value).ToString("0.00");
        }

        private static string SafeStr(object value)
        {
            if (value == null || value == DBNull.Value) return "";
            return value.ToString();
        }
    }

    /// <summary>
    /// [Multi-custom support] Lightweight DTO used as ComboBox DataSource
    /// for the custom-items selector. DisplayMember = "DisplayText",
    /// ValueMember = "OrderItemID".
    /// </summary>
    public class CustomItemEntry
    {
        public string OrderItemID { get; set; }
        public string DisplayText { get; set; }
    }
}
