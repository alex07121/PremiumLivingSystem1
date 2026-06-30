using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcProcessReturn : UserControl
    {
        public UcProcessReturn()
        {
            InitializeComponent();
        }

        private void UcProcessReturn_Load(object sender, EventArgs e)
        {
            dgvReturns.View = View.Details;
            dgvReturns.FullRowSelect = true;
            dgvReturns.GridLines = true;
            dgvReturns.MultiSelect = false;
            dgvReturns.Columns.Add("ReturnID", 120);
            dgvReturns.Columns.Add("OrderID", 120);
            dgvReturns.Columns.Add("ReturnType", 100);
            dgvReturns.Columns.Add("RequestDate", 120);
            dgvReturns.Columns.Add("Status", 100);
            LoadReturnRequests();
        }

        private void LoadReturnRequests()
        {
            string query = @"
                SELECT ReturnID, OrderID, ReturnType, RequestDate, Status 
                FROM ReturnRequest 
                WHERE Status = 'Pending'
                ORDER BY RequestDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    dgvReturns.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ReturnID"].ToString());
                        item.SubItems.Add(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["ReturnType"].ToString());
                        item.SubItems.Add(reader["RequestDate"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        dgvReturns.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dgvReturns_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReturns.SelectedItems.Count > 0)
            {
                string returnId = dgvReturns.SelectedItems[0].Text;
                LoadDetails(returnId);
                LoadReturnImages(returnId);

            }
            else
            {
                ClearDetails();
                ClearImages();
            }
        }

        private void LoadDetails(string returnId)
        {
            string query = "SELECT * FROM ReturnRequest WHERE ReturnID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", returnId);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtReturnID.Text = reader["ReturnID"].ToString();
                        txtOrderID.Text = reader["OrderID"].ToString();
                        txtReturnType.Text = reader["ReturnType"].ToString();
                        txtReason.Text = reader["ReturnReason"].ToString();

                        string status = reader["Status"].ToString();
                        if (cboStatus.Items.Contains(status))
                            cboStatus.SelectedItem = status;

                        txtRefundAmount.Text = reader["RefundAmount"].ToString();
                        txtRemarks.Text = reader["Remarks"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        /// <summary>
        /// Load return images from ReturnImage table and display thumbnails.
        /// </summary>
        private void LoadReturnImages(string returnId)
        {
            ClearImages();

            string query = "SELECT ImageID, ImageData FROM ReturnImage WHERE ReturnID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", returnId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["ImageData"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])reader["ImageData"];
                            string imageId = reader["ImageID"].ToString();
                            AddThumbnailToPanel(imageBytes, imageId);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                return; // No images or error loading images, just skip
            }
        }

        /// <summary>
        /// Add a thumbnail PictureBox to the FlowLayoutPanel.
        /// </summary>
        private void AddThumbnailToPanel(byte[] imageBytes, string imageId)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return;

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


        /// <summary>
        /// Click on a thumbnail to view the image in full size.
        /// </summary>
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
                            Text = "Return Image",
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
                    MessageBox.Show("Error displaying image: " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Clear all thumbnail images from the FlowLayoutPanel.
        /// </summary>
        private void ClearImages()
        {

            foreach (Control ctrl in flowLayoutPanelImages.Controls.Cast<Control>().ToList())
            {
                if (ctrl is PictureBox pb && pb.Image != null)
                {
                    var img = pb.Image;
                    pb.Image = null;
                    img.Dispose();
                }
                ctrl.Dispose();
            }
            flowLayoutPanelImages.Controls.Clear();
        }


        private void ClearDetails()
        {
            txtReturnID.Text = "";
            txtOrderID.Text = "";
            txtReturnType.Text = "";
            txtReason.Text = "";
            cboStatus.SelectedIndex = -1;
            txtRefundAmount.Text = "";
            txtRemarks.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReturnID.Text))
            {
                MessageBox.Show("Please select a return request to process.");
                return;
            }

            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a return status.");
                return;
            }

            decimal? refundAmount = null;
            if (!string.IsNullOrWhiteSpace(txtRefundAmount.Text))
            {
                if (decimal.TryParse(txtRefundAmount.Text, out decimal amt))
                    refundAmount = amt;
                else
                {
                    MessageBox.Show("Invalid refund amount.");
                    return;
                }
            }

            string staffId = UserSession.CurrentStaffId ?? "S-007";
            string newStatus = cboStatus.SelectedItem.ToString();

            string getReturnQuery = @"
        SELECT OrderID, Status
        FROM ReturnRequest
        WHERE ReturnID = @id
        FOR UPDATE";

            string updateReturnQuery = @"
        UPDATE ReturnRequest SET 
        Status = @status, 
        ProcessedByID = @staff, 
        RefundAmount = @refund, 
        Remarks = @remarks 
        WHERE ReturnID = @id";

            string restockProductsQuery = @"
        UPDATE Product p
        JOIN OrderItem oi ON p.ProductID = oi.ProductID
        SET p.Stock = p.Stock + oi.Quantity
        WHERE oi.OrderID = @orderId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string orderId = "";
                            string oldStatus = "";

                            using (MySqlCommand getCmd = new MySqlCommand(getReturnQuery, conn, trans))
                            {
                                getCmd.Parameters.AddWithValue("@id", txtReturnID.Text.Trim());

                                using (MySqlDataReader reader = getCmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                        throw new Exception("Return request not found.");

                                    orderId = reader["OrderID"].ToString();
                                    oldStatus = reader["Status"].ToString();
                                }
                            }

                            using (MySqlCommand updateCmd = new MySqlCommand(updateReturnQuery, conn, trans))
                            {
                                updateCmd.Parameters.AddWithValue("@status", newStatus);
                                updateCmd.Parameters.AddWithValue("@staff", staffId);
                                updateCmd.Parameters.AddWithValue("@refund", refundAmount.HasValue ? (object)refundAmount.Value : DBNull.Value);
                                updateCmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@id", txtReturnID.Text.Trim());
                                updateCmd.ExecuteNonQuery();
                            }

                            int restockedProducts = 0;
                            bool shouldRestock = newStatus == "Completed" && oldStatus != "Completed";

                            if (shouldRestock)
                            {
                                using (MySqlCommand restockCmd = new MySqlCommand(restockProductsQuery, conn, trans))
                                {
                                    restockCmd.Parameters.AddWithValue("@orderId", orderId);
                                    restockedProducts = restockCmd.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();

                            string message = "Return request updated successfully.";
                            if (shouldRestock)
                                message += $"\nProduct stock restored for {restockedProducts} product item(s).";

                            MessageBox.Show(message);
                            LoadReturnRequests();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }
    }
}
