using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class InvoiceForm : Form
    {
        private string currentInvoiceId = "";
        private string currentOrderId = "";

        public InvoiceForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public void LoadInvoiceByOrderID(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                ClearInvoice();
                MessageBox.Show("Please select or enter an Order ID first.");
                return;
            }

            string query = @"
                SELECT
                    i.InvoiceID,
                    i.OrderID,
                    o.OrderDate,
                    o.CustomerID,
                    i.BillingAddress,
                    i.DispatchDate,
                    i.DeliveryMethod,
                    i.SubTotal,
                    i.OtherCharges,
                    i.Total,
                    i.Remarks
                FROM Invoice i
                JOIN `Order` o ON i.OrderID = o.OrderID
                WHERE i.OrderID = @orderId
                LIMIT 1";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId.Trim());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        // No invoice exists yet for this order — create one automatically
                        // using the Order + OrderItem data, then reload.
                        if (!CreateInvoiceFromOrder(orderId.Trim()))
                        {
                            ClearInvoice();
                            return;
                        }

                        // Re-query the freshly created invoice.
                        adapter.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            ClearInvoice();
                            MessageBox.Show("No invoice found for this order.");
                            return;
                        }
                    }

                    DataRow row = dt.Rows[0];
                    currentInvoiceId = row["InvoiceID"].ToString();
                    currentOrderId = row["OrderID"].ToString();

                    txtOrderDate.Text = FormatDate(row["OrderDate"]);
                    txtOrderID.Text = currentOrderId;
                    txtCustomerID.Text = row["CustomerID"].ToString();
                    txtDispatchDate.Text = FormatDate(row["DispatchDate"]);
                    txtDeliveryMethod.Text = row["DeliveryMethod"].ToString();
                    txtBillingAddress.Text = row["BillingAddress"].ToString();
                    txtSubtotal.Text = FormatMoney(row["SubTotal"]);
                    txtOther.Text = FormatMoney(row["OtherCharges"]);
                    txtTotal.Text = FormatMoney(row["Total"]);
                    txtRemarks.Text = row["Remarks"].ToString();
                }

                LoadInvoiceItems(currentInvoiceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoice: " + ex.Message);
            }
        }

        // ================================================================
        // Auto-create an Invoice (header + line items) from an existing
        // Order when none exists yet. The DB triggers trg_invoice_id and
        // trg_invoiceitem_id auto-generate the InvoiceID / InvItemID, so
        // we insert NULL for those columns.
        // ================================================================
        private bool CreateInvoiceFromOrder(string orderId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    conn.Open();

                    // 1. Pull the Order header (OrderDate, CustomerID) and derive a
                    //    billing address from the Customer record (Address).
                    string orderQuery = @"
                        SELECT o.OrderID, o.OrderDate, o.CustomerID,
                               c.Address
                        FROM `Order` o
                        LEFT JOIN Customer c ON o.CustomerID = c.CustomerID
                        WHERE o.OrderID = @orderId
                        LIMIT 1";

                    string orderIdValue = null;
                    DateTime orderDate = DateTime.Today;
                    string customerId = "";
                    string billingAddress = "";

                    using (MySqlCommand cmd = new MySqlCommand(orderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Order not found: " + orderId);
                                return false;
                            }
                            orderIdValue = reader["OrderID"].ToString();
                            if (reader["OrderDate"] != DBNull.Value)
                                orderDate = Convert.ToDateTime(reader["OrderDate"]);
                            customerId = reader["CustomerID"].ToString();
                            billingAddress =
                                reader["Address"] == DBNull.Value
                                    ? ""
                                    : reader["Address"].ToString();
                        }
                    }

                    // 2. Compute SubTotal / Total from OrderItem (UnitPrice * Quantity).
                    //    Discount and OtherCharges default to 0 for the auto-created invoice.
                    decimal subTotal = 0m;
                    var items = new List<Tuple<string, int, decimal>>();

                    string itemsQuery = @"
                        SELECT ProductID, Quantity, UnitPrice
                        FROM OrderItem
                        WHERE OrderID = @orderId";
                    using (MySqlCommand cmd = new MySqlCommand(itemsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderIdValue);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string pid = reader["ProductID"].ToString();
                                int qty = Convert.ToInt32(reader["Quantity"]);
                                decimal unitPrice =
                                    reader["UnitPrice"] == DBNull.Value
                                        ? 0m
                                        : Convert.ToDecimal(reader["UnitPrice"]);
                                decimal lineTotal = unitPrice * qty;
                                subTotal += lineTotal;
                                items.Add(Tuple.Create(pid, qty, unitPrice));
                            }
                        }
                    }

                    decimal otherCharges = 0m;
                    decimal discount = 0m;
                    decimal total = subTotal - discount + otherCharges;

                    // 3. Insert the Invoice header. InvoiceID is auto-generated by trigger.
                    string insertInvoice = @"
                        INSERT INTO Invoice
                            (InvoiceID, OrderID, BillingAddress, DispatchDate,
                             DeliveryMethod, SubTotal, Discount, OtherCharges, Total,
                             Status, IssuedDate, Remarks)
                        VALUES
                            (NULL, @orderId, @billingAddress, NULL,
                             NULL, @subTotal, @discount, @otherCharges, @total,
                             'Issued', @issuedDate, @remarks);";

                    using (MySqlCommand cmd = new MySqlCommand(insertInvoice, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderIdValue);
                        cmd.Parameters.AddWithValue("@billingAddress",
                            string.IsNullOrEmpty(billingAddress) ? (object)DBNull.Value : billingAddress);
                        cmd.Parameters.AddWithValue("@subTotal", subTotal);
                        cmd.Parameters.AddWithValue("@discount", discount);
                        cmd.Parameters.AddWithValue("@otherCharges", otherCharges);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@issuedDate", orderDate);
                        cmd.Parameters.AddWithValue("@remarks", "Auto-generated from order " + orderIdValue);
                        cmd.ExecuteNonQuery();
                    }

                    // InvoiceID is a VARCHAR generated by a BEFORE INSERT trigger,
                    // so LAST_INSERT_ID() does NOT return it. Query it back via OrderID.
                    string newInvoiceId;
                    string getIdQuery = "SELECT InvoiceID FROM Invoice WHERE OrderID = @orderId ORDER BY InvoiceID DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(getIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderIdValue);
                        newInvoiceId = cmd.ExecuteScalar().ToString();
                    }

                    // 4. Insert InvoiceItem rows for each OrderItem.
                    //    InvItemID is auto-generated by trigger.
                    if (items.Count > 0)
                    {
                        string insertItem = @"
                            INSERT INTO InvoiceItem
                                (InvItemID, InvoiceID, ProductID, Quantity, UnitCost, Discount, LineTotal)
                            VALUES
                                (NULL, @invoiceId, @productId, @quantity, @unitCost, 0, @lineTotal)";
                        foreach (var it in items)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(insertItem, conn))
                            {
                                cmd.Parameters.AddWithValue("@invoiceId", newInvoiceId);
                                cmd.Parameters.AddWithValue("@productId", it.Item1);
                                cmd.Parameters.AddWithValue("@quantity", it.Item2);
                                cmd.Parameters.AddWithValue("@unitCost", it.Item3);
                                cmd.Parameters.AddWithValue("@lineTotal", it.Item3 * it.Item2);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating invoice from order: " + ex.Message);
                return false;
            }
        }

        private void LoadInvoiceItems(string invoiceId)
        {
            string query = @"
                SELECT
                    ii.ProductID,
                    p.ProductName AS Description,
                    ii.Quantity,
                    ii.UnitCost,
                    ii.Discount,
                    ii.LineTotal
                FROM InvoiceItem ii
                JOIN Product p ON ii.ProductID = p.ProductID
                WHERE ii.InvoiceID = @invoiceId
                ORDER BY ii.InvItemID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@invoiceId", invoiceId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listViewItems.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["Description"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(FormatMoney(reader["UnitCost"]));
                        item.SubItems.Add(FormatMoney(reader["Discount"]));
                        item.SubItems.Add(FormatMoney(reader["LineTotal"]));
                        listViewItems.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoice items: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintToPdf();
        }

        private void PrintToPdf()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.DefaultExt = "pdf";
                sfd.FileName = "Invoice_" + GetSafeFileName(currentOrderId) + ".pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (Bitmap bitmap = CaptureInvoiceToBitmap())
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
                            "PDF export failed: " + ex.Message + "\n\nSaved as PNG instead:\n" + pngPath,
                            "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private Bitmap CaptureInvoiceToBitmap()
        {
            bool printVisible = btnPrint.Visible;
            btnPrint.Visible = false;
            Refresh();

            Bitmap bitmap = new Bitmap(invoicePanel.Width, invoicePanel.Height);
            invoicePanel.DrawToBitmap(bitmap, new Rectangle(Point.Empty, invoicePanel.Size));

            // Panel.DrawToBitmap skips PictureBox children, so manually composite
            // the company stamp/logo (pictureBox2) onto the bitmap at its location.
            if (pictureBox2.Image != null)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Rectangle dest = new Rectangle(
                        pictureBox2.Left,
                        pictureBox2.Top,
                        pictureBox2.Width,
                        pictureBox2.Height);

                    switch (pictureBox2.SizeMode)
                    {
                        case PictureBoxSizeMode.Normal:
                            g.DrawImage(pictureBox2.Image, dest);
                            break;
                        case PictureBoxSizeMode.StretchImage:
                            g.DrawImage(pictureBox2.Image, dest);
                            break;
                        case PictureBoxSizeMode.CenterImage:
                            int cx = dest.X + (dest.Width - pictureBox2.Image.Width) / 2;
                            int cy = dest.Y + (dest.Height - pictureBox2.Image.Height) / 2;
                            g.DrawImage(pictureBox2.Image, cx, cy);
                            break;
                        case PictureBoxSizeMode.Zoom:
                        default:
                            // Fit image inside dest preserving aspect ratio (Zoom behavior).
                            float scale = Math.Min(
                                (float)dest.Width / pictureBox2.Image.Width,
                                (float)dest.Height / pictureBox2.Image.Height);
                            int w = (int)(pictureBox2.Image.Width * scale);
                            int h = (int)(pictureBox2.Image.Height * scale);
                            int x = dest.X + (dest.Width - w) / 2;
                            int y = dest.Y + (dest.Height - h) / 2;
                            g.DrawImage(pictureBox2.Image, x, y, w, h);
                            break;
                    }
                }
            }

            btnPrint.Visible = printVisible;
            return bitmap;
        }

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
                    writeLine("<< /Type /Page /Parent 2 0 R /MediaBox [0 0 " + pdfWidth + " " + pdfHeight + "] /Contents 4 0 R /Resources << /XObject << /Im0 5 0 R >> >> >>");
                    writeLine("endobj");

                    string contentStream = "q " + pdfWidth + " 0 0 " + pdfHeight + " 0 0 cm /Im0 Do Q";
                    byte[] contentBytes = Encoding.ASCII.GetBytes(contentStream);
                    byteOffsets.Add(fs.Position);
                    writeLine("4 0 obj");
                    writeLine("<< /Length " + contentBytes.Length + " >>");
                    writeLine("stream");
                    fs.Write(contentBytes, 0, contentBytes.Length);
                    writeLine("");
                    writeLine("endstream");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("5 0 obj");
                    writeLine("<< /Type /XObject /Subtype /Image /Width " + width + " /Height " + height + " /ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode /Length " + jpegBytes.Length + " >>");
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
                        writeLine(byteOffsets[i].ToString("0000000000") + " 00000 n ");

                    writeLine("trailer");
                    writeLine("<< /Size 6 /Root 1 0 R >>");
                    writeLine("startxref");
                    writeLine(xrefOffset.ToString());
                    writeLine("%%EOF");

                    fs.Flush();
                }
            }
        }

        private void ClearInvoice()
        {
            currentInvoiceId = "";
            currentOrderId = "";

            txtOrderDate.Clear();
            txtOrderID.Clear();
            txtCustomerID.Clear();
            txtDispatchDate.Clear();
            txtDeliveryMethod.Clear();
            txtBillingAddress.Clear();
            txtSubtotal.Clear();
            txtOther.Clear();
            txtTotal.Clear();
            txtRemarks.Clear();
            listViewItems.Items.Clear();
        }

        private string FormatDate(object value)
        {
            if (value == null || value == DBNull.Value) return "";

            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
                return date.ToString("yyyy-MM-dd");

            return value.ToString();
        }

        private string FormatMoney(object value)
        {
            if (value == null || value == DBNull.Value) return "0.00";

            decimal amount;
            if (decimal.TryParse(value.ToString(), out amount))
                return amount.ToString("0.00");

            return value.ToString();
        }

        private string GetSafeFileName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return "New";

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
                value = value.Replace(invalidChar, '_');

            return value;
        }
    }
}
