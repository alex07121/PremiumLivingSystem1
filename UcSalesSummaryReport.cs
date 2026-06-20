using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcSalesSummaryReport : UserControl
    {
        public UcSalesSummaryReport()
        {
            InitializeComponent();
        }

        // ================================================================
        // LOAD
        // ================================================================
        private void UcSalesSummaryReport_Load(object sender, EventArgs e)
        {
            SetupListViews();
        }

        // ================================================================
        // LISTVIEW SETUP — T3 style: View.Details + FullRowSelect + GridLines
        // ================================================================
        private void SetupListViews()
        {
            // Monthly breakdown: Month | Orders | Revenue | B2B | B2C
            lvMonthly.Columns.Add("Month", "Month", 100);
            lvMonthly.Columns.Add("Orders", "Orders", 70);
            lvMonthly.Columns.Add("Revenue", "Revenue ($)", 130);
            lvMonthly.Columns.Add("B2B", "B2B", 60);
            lvMonthly.Columns.Add("B2C", "B2C", 60);

            // Top products: Rank | ProductID | ProductName | Qty Sold | Revenue
            lvTopProducts.Columns.Add("Rank", "Rank", 50);
            lvTopProducts.Columns.Add("ProductID", "Product ID", 90);
            lvTopProducts.Columns.Add("ProductName", "Product Name", 200);
            lvTopProducts.Columns.Add("QtySold", "Qty Sold", 70);
            lvTopProducts.Columns.Add("Revenue", "Revenue ($)", 120);

            // Status distribution: Status | Count | Percentage
            lvStatus.Columns.Add("Status", "Status", 150);
            lvStatus.Columns.Add("Count", "Count", 100);
            lvStatus.Columns.Add("Percentage", "Percentage", 120);
        }

        // ================================================================
        // GENERATE — runs all 4 queries and populates the report
        // ================================================================
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string dateFrom = dtpFrom.Value.ToString("yyyy-MM-dd");
            string dateTo = dtpTo.Value.ToString("yyyy-MM-dd");

            LoadSummaryKPIs(dateFrom, dateTo);
            LoadMonthlyBreakdown(dateFrom, dateTo);
            LoadTopProducts(dateFrom, dateTo);
            LoadStatusDistribution(dateFrom, dateTo);

            MessageBox.Show("Report generated successfully.", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // 1. SUMMARY KPIs — total orders, revenue, B2B/B2C split, cancelled
        // ================================================================
        private void LoadSummaryKPIs(string dateFrom, string dateTo)
        {
            string query = @"
                SELECT
                    COUNT(*) AS TotalOrders,
                    COALESCE(SUM(oi.Quantity * oi.UnitPrice), 0) AS TotalRevenue,
                    SUM(CASE WHEN c.CustomerType = 'B2B' THEN 1 ELSE 0 END) AS B2BOrders,
                    SUM(CASE WHEN c.CustomerType = 'B2C' THEN 1 ELSE 0 END) AS B2COrders,
                    SUM(CASE WHEN o.Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledOrders
                FROM `Order` o
                JOIN Customer c ON o.CustomerID = c.CustomerID
                LEFT JOIN OrderItem oi ON o.OrderID = oi.OrderID
                WHERE o.OrderDate BETWEEN @from AND @to";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@from", dateFrom);
                    cmd.Parameters.AddWithValue("@to", dateTo);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTotalOrders.Text = reader["TotalOrders"].ToString();
                            txtTotalRevenue.Text = "$" + Convert.ToDecimal(reader["TotalRevenue"]).ToString("N2");
                            txtB2B.Text = reader["B2BOrders"].ToString();
                            txtB2C.Text = reader["B2COrders"].ToString();
                            txtCancelled.Text = reader["CancelledOrders"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message);
            }
        }

        // ================================================================
        // 2. MONTHLY BREAKDOWN — orders + revenue per month
        // ================================================================
        private void LoadMonthlyBreakdown(string dateFrom, string dateTo)
        {
            string query = @"
                SELECT
                    DATE_FORMAT(o.OrderDate, '%Y-%m') AS Month,
                    COUNT(DISTINCT o.OrderID) AS OrderCount,
                    COALESCE(SUM(oi.Quantity * oi.UnitPrice), 0) AS Revenue,
                    SUM(CASE WHEN c.CustomerType = 'B2B' THEN 1 ELSE 0 END) AS B2B,
                    SUM(CASE WHEN c.CustomerType = 'B2C' THEN 1 ELSE 0 END) AS B2C
                FROM `Order` o
                JOIN Customer c ON o.CustomerID = c.CustomerID
                LEFT JOIN OrderItem oi ON o.OrderID = oi.OrderID
                WHERE o.OrderDate BETWEEN @from AND @to
                GROUP BY DATE_FORMAT(o.OrderDate, '%Y-%m')
                ORDER BY Month DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@from", dateFrom);
                    cmd.Parameters.AddWithValue("@to", dateTo);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    lvMonthly.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["Month"].ToString());
                        item.SubItems.Add(row["OrderCount"].ToString());
                        item.SubItems.Add("$" + Convert.ToDecimal(row["Revenue"]).ToString("N2"));
                        item.SubItems.Add(row["B2B"].ToString());
                        item.SubItems.Add(row["B2C"].ToString());
                        lvMonthly.Items.Add(item);
                    }

                    if (lvMonthly.Items.Count == 0)
                    {
                        ListViewItem empty = new ListViewItem("No data");
                        empty.ForeColor = Color.Gray;
                        empty.SubItems.Add("-");
                        empty.SubItems.Add("-");
                        empty.SubItems.Add("-");
                        empty.SubItems.Add("-");
                        lvMonthly.Items.Add(empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading monthly breakdown: " + ex.Message);
            }
        }

        // ================================================================
        // 3. TOP 5 PRODUCTS — best-selling by quantity
        // ================================================================
        private void LoadTopProducts(string dateFrom, string dateTo)
        {
            string query = @"
                SELECT
                    p.ProductID,
                    p.ProductName,
                    SUM(oi.Quantity) AS QtySold,
                    SUM(oi.Quantity * oi.UnitPrice) AS Revenue
                FROM OrderItem oi
                JOIN `Order` o ON oi.OrderID = o.OrderID
                JOIN Product p ON oi.ProductID = p.ProductID
                WHERE o.OrderDate BETWEEN @from AND @to
                    AND o.Status != 'Cancelled'
                GROUP BY p.ProductID, p.ProductName
                ORDER BY QtySold DESC
                LIMIT 5";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@from", dateFrom);
                    cmd.Parameters.AddWithValue("@to", dateTo);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    lvTopProducts.Items.Clear();
                    int rank = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(rank.ToString());
                        item.SubItems.Add(row["ProductID"].ToString());
                        item.SubItems.Add(row["ProductName"].ToString());
                        item.SubItems.Add(row["QtySold"].ToString());
                        item.SubItems.Add("$" + Convert.ToDecimal(row["Revenue"]).ToString("N2"));

                        // Highlight top 3
                        if (rank <= 3)
                            item.SubItems[0].ForeColor = Color.FromArgb(180, 30, 30);

                        lvTopProducts.Items.Add(item);
                        rank++;
                    }

                    if (lvTopProducts.Items.Count == 0)
                    {
                        ListViewItem empty = new ListViewItem("-");
                        empty.ForeColor = Color.Gray;
                        empty.SubItems.Add("No data");
                        empty.SubItems.Add("");
                        empty.SubItems.Add("");
                        empty.SubItems.Add("");
                        lvTopProducts.Items.Add(empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top products: " + ex.Message);
            }
        }

        // ================================================================
        // 4. STATUS DISTRIBUTION — count + percentage per order status
        // ================================================================
        private void LoadStatusDistribution(string dateFrom, string dateTo)
        {
            string query = @"
                SELECT
                    o.Status,
                    COUNT(*) AS StatusCount
                FROM `Order` o
                WHERE o.OrderDate BETWEEN @from AND @to
                GROUP BY o.Status
                ORDER BY StatusCount DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@from", dateFrom);
                    cmd.Parameters.AddWithValue("@to", dateTo);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    // Calculate total for percentage
                    int total = 0;
                    foreach (DataRow row in dt.Rows)
                        total += Convert.ToInt32(row["StatusCount"]);

                    lvStatus.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string status = row["Status"].ToString();
                        int count = Convert.ToInt32(row["StatusCount"]);
                        double pct = total > 0 ? (double)count / total * 100 : 0;

                        ListViewItem item = new ListViewItem(status);
                        item.SubItems.Add(count.ToString());
                        item.SubItems.Add(pct.ToString("F1") + "%");

                        // Color-code by status
                        if (status == "Delivered")
                            item.SubItems[0].ForeColor = Color.FromArgb(56, 142, 60);
                        else if (status == "Cancelled")
                            item.SubItems[0].ForeColor = Color.FromArgb(180, 30, 30);
                        else if (status == "Pending")
                            item.SubItems[0].ForeColor = Color.FromArgb(180, 70, 30);
                        else if (status == "Shipped")
                            item.SubItems[0].ForeColor = Color.FromArgb(33, 102, 172);

                        lvStatus.Items.Add(item);
                    }

                    if (lvStatus.Items.Count == 0)
                    {
                        ListViewItem empty = new ListViewItem("No data");
                        empty.ForeColor = Color.Gray;
                        empty.SubItems.Add("-");
                        empty.SubItems.Add("-");
                        lvStatus.Items.Add(empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading status distribution: " + ex.Message);
            }
        }

        // ================================================================
        // EXPORT PDF — capture control to bitmap, save as PDF
        // ================================================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lvMonthly.Items.Count == 0)
            {
                MessageBox.Show("Please generate the report first.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = "SalesSummaryReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
                sfd.DefaultExt = "pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                // Hide export button during capture
                btnExport.Visible = false;
                btnGenerate.Visible = false;
                this.Refresh();

                try
                {
                    int width = this.DisplayRectangle.Width;
                    int height = this.DisplayRectangle.Height;
                    Bitmap bitmap = new Bitmap(width, height);
                    this.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
                    SaveBitmapAsPdf(bitmap, sfd.FileName);

                    MessageBox.Show("PDF exported successfully:\n" + sfd.FileName,
                        "Export Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string pngPath = Path.ChangeExtension(sfd.FileName, ".png");
                    try
                    {
                        btnExport.Visible = false;
                        btnGenerate.Visible = false;
                        this.Refresh();
                        int width = this.DisplayRectangle.Width;
                        int height = this.DisplayRectangle.Height;
                        Bitmap bitmap = new Bitmap(width, height);
                        this.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
                        bitmap.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show(
                            "PDF export failed: " + ex.Message + "\n\nSaved as PNG instead:\n" + pngPath,
                            "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch
                    {
                        MessageBox.Show("Export failed: " + ex.Message);
                    }
                }
                finally
                {
                    btnExport.Visible = true;
                    btnGenerate.Visible = true;
                }
            }
        }

        /// <summary>
        /// Saves a Bitmap as a PDF file using pure C# (no external dependencies).
        /// Same approach as UcTransfer.PrintToPdf.
        /// </summary>
        private void SaveBitmapAsPdf(Bitmap bitmap, string filePath)
        {
            using (MemoryStream jpegStream = new MemoryStream())
            {
                bitmap.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
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
    }
}
