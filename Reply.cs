using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{
    public partial class Reply : MaterialForm
    {
        public Reply()
        {
            InitializeComponent();

            // MaterialSkin theme setup
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Teal800,
                Primary.Teal900,
                Primary.Teal500,
                Accent.Cyan200,
                TextShade.WHITE
            );

            this.StartPosition = FormStartPosition.CenterParent;

            // Enable scrolling — wrap all existing controls in a scrollable panel
            Panel scrollPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMinSize = new Size(this.ClientSize.Width - 20, this.ClientSize.Height)
            };

            // Move all existing controls into the scroll panel
            while (this.Controls.Count > 0)
            {
                Control ctrl = this.Controls[0];
                this.Controls.Remove(ctrl);
                scrollPanel.Controls.Add(ctrl);
            }
            this.Controls.Add(scrollPanel);

            // CRITICAL: pictureBox1 is the background template image.
            // It must be sent to back so it doesn't cover the ListView and other controls.


            // Set up ListView columns for Reply Slip items
            listItem.Columns.Add("Item ID", 100);
            listItem.Columns.Add("Description", 250);
            listItem.Columns.Add("Ordered", 80);
            listItem.Columns.Add("Delivered", 80);
            listItem.Columns.Add("Outstanding", 80);
            listItem.Columns.Add("Status", 120);
        }

        // ================================================================
        // DATA LOADING METHODS
        // ================================================================

        /// <summary>
        /// Loads Reply Slip header data (Order info + Delivery Note info) by OrderID or DNID.
        /// </summary>
        public void LoadDeliveryItem(string orderOrDnId)
        {
            if (string.IsNullOrWhiteSpace(orderOrDnId)) return;

            // Try both OrderID and DNID — whichever matches
            string query = @"
                SELECT 
                    o.OrderDate,
                    o.OrderID,
                    dn.DNID,
                    c.CustomerID,
                    dn.DispatchDate,
                    dn.DeliveryMethod,
                    dn.InvoiceAddress
                FROM `Order` o
                JOIN DeliveryNote dn ON o.OrderID = dn.OrderID
                JOIN Customer c ON o.CustomerID = c.CustomerID
                WHERE o.OrderID = @id OR dn.DNID = @id
                LIMIT 1";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", orderOrDnId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtOrderDate.Text = row["OrderDate"].ToString();
                        txtOrder.Text = row["OrderID"].ToString();
                        txtNote.Text = row["DNID"].ToString();
                        txtCustomerID.Text = row["CustomerID"].ToString();
                        txtDispatch.Text = row["DispatchDate"].ToString();
                        txtMethod.Text = row["DeliveryMethod"].ToString();
                        txtaddress1.Text = row["InvoiceAddress"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        /// <summary>
        /// Loads OrderItem IDs into the ListView (Item ID column only).
        /// </summary>
        public void LoadOrderItems(string orderId)
        {
            string query = "SELECT OrderItemID FROM OrderItem WHERE OrderID = @orderId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderItemID"].ToString());
                        item.SubItems.Add(""); // Description placeholder
                        item.SubItems.Add(""); // Ordered placeholder
                        item.SubItems.Add(""); // Delivered placeholder
                        item.SubItems.Add(""); // Outstanding placeholder
                        item.SubItems.Add(""); // Status placeholder
                        listItem.Items.Add(item);
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
        /// Loads DeliveryNote items (Description, Ordered, Delivered, Outstanding)
        /// into the ListView by DNID. Matches rows by ProductID.
        /// </summary>
        public void LoadDeliveryNoteItems(string dnId)
        {
            string query = @"
                SELECT 
                    dni.ProductID,
                    p.ProductName AS Description,
                    dni.QtyOrdered,
                    dni.QtyDelivered
                FROM DeliveryNoteItem dni
                JOIN Product p ON dni.ProductID = p.ProductID
                WHERE dni.DNID = @dnId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", dnId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listItem.Items.Clear();

                    while (reader.Read())
                    {
                        string productId = reader["ProductID"].ToString();
                        string description = reader["Description"].ToString();
                        int ordered = Convert.ToInt32(reader["QtyOrdered"]);
                        int delivered = Convert.ToInt32(reader["QtyDelivered"]);
                        int outstanding = ordered - delivered;

                        ListViewItem item = new ListViewItem(productId);
                        item.SubItems.Add(description);
                        item.SubItems.Add(ordered.ToString());
                        item.SubItems.Add(delivered.ToString());
                        item.SubItems.Add(outstanding.ToString());
                        item.SubItems.Add(""); // Status (filled by LoadDeliveryNoteStatus)
                        listItem.Items.Add(item);
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
        /// Loads DeliveryNote status into the last column of each ListView row.
        /// </summary>
        public void LoadDeliveryNoteStatus(string dnId)
        {
            string query = "SELECT Status FROM DeliveryNote WHERE DNID = @dnId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", dnId);

                    conn.Open();
                    string status = cmd.ExecuteScalar()?.ToString() ?? "";

                    // Apply status to all rows
                    foreach (ListViewItem item in listItem.Items)
                    {
                        // SubItems[5] is the Status column (0-based: 0=ItemID, 1=Desc, 2=Ordered, 3=Delivered, 4=Outstanding, 5=Status)
                        if (item.SubItems.Count > 5)
                            item.SubItems[5].Text = status;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // PRINT TO PDF
        // ================================================================

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintToPdf();
        }

        private void PrintToPdf()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"ReplySlip_{txtNote.Text}.pdf";
                sfd.DefaultExt = "pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (Bitmap bitmap = CaptureFormToBitmap())
                {
                    try
                    {
                        SaveBitmapAsPdf(bitmap, sfd.FileName);
                        MessageBox.Show("PDF exported successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        string pngPath = Path.ChangeExtension(sfd.FileName, ".png");
                        bitmap.Save(pngPath, ImageFormat.Png);
                        MessageBox.Show(
                            $"PDF export failed: {ex.Message}\n\nSaved as PNG instead:\n{pngPath}",
                            "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Saves a Bitmap as a PDF file using pure C# (no external dependencies).
        /// </summary>
        private void SaveBitmapAsPdf(Bitmap bitmap, string filePath)
        {
            using (MemoryStream jpegStream = new MemoryStream())
            {
                bitmap.Save(jpegStream, ImageFormat.Jpeg);
                byte[] jpegBytes = jpegStream.ToArray();

                int width = bitmap.Width;
                int height = bitmap.Height;
                float pdfWidth = width * 72f / 96f;
                float pdfHeight = height * 72f / 96f;

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    List<long> byteOffsets = new List<long>();
                    Action<string> writeLine = (s) =>
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(s + "\n");
                        fs.Write(bytes, 0, bytes.Length);
                    };

                    byteOffsets.Add(fs.Position);
                    writeLine("%PDF-1.4");

                    byteOffsets.Add(fs.Position);
                    writeLine("1 0 obj");
                    writeLine("<< /Type /Catalog /Pages 2 0 R >>");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("2 0 obj");
                    writeLine("<< /Type /Pages /Kids [3 0 R] /Count 1 >>");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("3 0 obj");
                    writeLine($"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {pdfWidth} {pdfHeight}] /Contents 4 0 R /Resources << /XObject << /Im0 5 0 R >> >> >>");
                    writeLine("endobj");

                    string contentStream = $"q {pdfWidth} 0 0 {pdfHeight} 0 0 cm /Im0 Do Q";
                    byte[] contentBytes = Encoding.ASCII.GetBytes(contentStream);
                    byteOffsets.Add(fs.Position);
                    writeLine("4 0 obj");
                    writeLine($"<< /Length {contentBytes.Length} >>");
                    writeLine("stream");
                    fs.Write(contentBytes, 0, contentBytes.Length);
                    writeLine("");
                    writeLine("endstream");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("5 0 obj");
                    writeLine($"<< /Type /XObject /Subtype /Image /Width {width} /Height {height} /ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode /Length {jpegBytes.Length} >>");
                    writeLine("stream");
                    fs.Write(jpegBytes, 0, jpegBytes.Length);
                    writeLine("");
                    writeLine("endstream");
                    writeLine("endobj");

                    long xrefOffset = fs.Position;
                    writeLine("xref");
                    writeLine("0 6");
                    writeLine("0000000000 65535 f ");
                    for (int i = 1; i < byteOffsets.Count; i++)
                    {
                        writeLine($"{byteOffsets[i]:0000000000} 00000 n ");
                    }

                    writeLine("trailer");
                    writeLine("<< /Size 6 /Root 1 0 R >>");
                    writeLine("startxref");
                    writeLine($"{xrefOffset}");
                    writeLine("%%EOF");

                    fs.Flush();
                }
            }
        }

        private Bitmap CaptureFormToBitmap()
        {
            btnPrint.Visible = false;
            this.Refresh();

            // Calculate total content height (form may be taller than ClientSize)
            int totalHeight = Math.Max(this.ClientSize.Height, this.DisplayRectangle.Height);
            Bitmap bitmap = new Bitmap(this.ClientSize.Width, totalHeight);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);


                // Draw "Reply Slip" title at top center with large font
                using (Font titleFont = new Font("Arial", 20, FontStyle.Bold))
                using (Brush titleBrush = new SolidBrush(Color.Black))
                {
                    string title = "Reply Slip";
                    SizeF titleSize = g.MeasureString(title, titleFont);
                    float titleX = (this.ClientSize.Width - titleSize.Width) / 2;
                    float titleY = 15;
                    g.DrawString(title, titleFont, titleBrush, titleX, titleY);
                }

                // Draw logo
                if (pictureBox2.Image != null)
                    g.DrawImage(pictureBox2.Image, pictureBox2.Bounds);

                // Draw all labels
                DrawLabelContent(g, label3);
                DrawLabelContent(g, label4);
                DrawLabelContent(g, label5);
                DrawLabelContent(g, label6);
                DrawLabelContent(g, label7);
                DrawLabelContent(g, label8);
                DrawLabelContent(g, label9);
                DrawLabelContent(g, label10);
                DrawLabelContent(g, label11);
                DrawLabelContent(g, label12);
                DrawLabelContent(g, label13);

                // Draw textboxes
                DrawTextBoxContent(g, txtOrderDate);
                DrawTextBoxContent(g, txtOrder);
                DrawTextBoxContent(g, txtNote);
                DrawTextBoxContent(g, txtCustomerID);
                DrawTextBoxContent(g, txtDispatch);
                DrawTextBoxContent(g, txtMethod);
                DrawTextBoxContent(g, txtaddress1);
                DrawTextBoxContent(g, txtReceived);
                DrawTextBoxContent(g, textBox2);

                DrawListView(g, listItem);
            }

            btnPrint.Visible = true;
            return bitmap;
        }

        private void DrawLabelContent(Graphics g, Label lbl)
        {
            if (string.IsNullOrEmpty(lbl.Text)) return;

            Font font = lbl.Font;
            using (Brush brush = new SolidBrush(lbl.ForeColor))
            {
                g.DrawString(lbl.Text, font, brush, lbl.Location);
            }
        }

        private void DrawTextBoxContent(Graphics g, TextBox tb)
        {
            // Always draw the border rectangle so the textbox is visible in PDF
            using (Pen borderPen = new Pen(Color.Gray))
            {
                Rectangle r = new Rectangle(tb.Location.X, tb.Location.Y, tb.Width, tb.Height);
                g.DrawRectangle(borderPen, r);
            }

            if (string.IsNullOrEmpty(tb.Text)) return;

            Font font = tb.Font;
            using (Brush brush = new SolidBrush(tb.ForeColor))
            {
                int x = tb.Location.X + 3;
                int y = tb.Location.Y + (tb.Height - font.Height) / 2;
                g.DrawString(tb.Text, font, brush, x, y);
            }
        }

        private void DrawListView(Graphics g, ListView lv)
        {
            if (lv.Items.Count == 0 || lv.Columns.Count == 0) return;

            int origX = lv.Location.X;
            int origY = lv.Location.Y;
            int totalW = lv.ClientSize.Width;
            int rowH = 22;
            int headerH = 24;

            // Calculate column widths proportionally
            int[] colW = new int[lv.Columns.Count];
            for (int c = 0; c < lv.Columns.Count; c++)
                colW[c] = lv.Columns[c].Width;

            using (Font headerFont = new Font(lv.Font, FontStyle.Bold))
            using (Brush headerBg = new SolidBrush(SystemColors.Control))
            using (Brush textBrush = new SolidBrush(lv.ForeColor))
            using (Pen gridPen = new Pen(Color.LightGray))
            {
                Font cellFont = lv.Font;

                // Draw header background
                g.FillRectangle(headerBg, origX, origY, totalW, headerH);

                // Draw header text
                int xPos = origX;
                for (int c = 0; c < lv.Columns.Count; c++)
                {
                    Rectangle r = new Rectangle(xPos, origY, colW[c], headerH);
                    g.DrawRectangle(gridPen, r);
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(lv.Columns[c].Text, headerFont, textBrush, r, sf);
                    xPos += colW[c];
                }

                // Draw rows
                for (int r = 0; r < lv.Items.Count; r++)
                {
                    int rowY = origY + headerH + r * rowH;

                    Color bg = r % 2 == 0 ? Color.White : Color.FromArgb(240, 240, 240);
                    using (Brush rb = new SolidBrush(bg))
                        g.FillRectangle(rb, origX, rowY, totalW, rowH);

                    xPos = origX;
                    ListViewItem lvItem = lv.Items[r];

                    for (int c = 0; c < lv.Columns.Count; c++)
                    {
                        Rectangle cellR = new Rectangle(xPos, rowY, colW[c], rowH);
                        g.DrawRectangle(gridPen, cellR);

                        string txt = c < lvItem.SubItems.Count ? lvItem.SubItems[c].Text : "";
                        var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center,
                            FormatFlags = StringFormatFlags.NoWrap
                        };
                        Rectangle txtR = new Rectangle(xPos + 4, rowY, colW[c] - 8, rowH);
                        g.DrawString(txt, cellFont, textBrush, txtR, sf);
                        xPos += colW[c];
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
