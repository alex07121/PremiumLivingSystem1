using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcSearchProcurement : UserControl
    {
        // Bound DataTable — used to look up details for the selected row (like UcSearchOrder)
        private DataTable _boundTable = null;

        public UcSearchProcurement()
        {
            InitializeComponent();
        }

        // ================================================================
        // LOAD — matches UcSearchOrder_Load pattern (T3 SearchForm_Load)
        // ================================================================
        private void UcSearchProcurement_Load(object sender, EventArgs e)
        {
            // Setup ListView columns — T3 pattern: View.Details + FullRowSelect + GridLines
            lvResults.View = View.Details;
            lvResults.FullRowSelect = true;
            lvResults.GridLines = true;
            lvResults.MultiSelect = false;
            lvResults.Columns.Add("PO ID", 160);
            lvResults.Columns.Add("Supplier", 180);
            lvResults.Columns.Add("Order Date", 110);
            lvResults.Columns.Add("Expected", 110);
            lvResults.Columns.Add("Status", 130);
            lvResults.Columns.Add("Payment", 100);
            lvResults.Columns.Add("Total", 130);

            // Default filter = "All"
            cmbStatusFilter.SelectedIndex = 0;

            // Load all records on startup
            LoadAllProcurement();
        }

        // ================================================================
        // LOAD ALL — matches UcSearchOrder.LoadAllOrder pattern
        // ================================================================
        private void LoadAllProcurement()
        {
            string query = @"SELECT po.PurchaseOrderID,
                                    sup.SupplierName,
                                    po.OrderDate,
                                    po.ExpectedDeliveryDate,
                                    po.Status,
                                    po.PaymentStatus,
                                    po.TotalAmount
                             FROM PurchaseOrder po
                             JOIN Supplier sup ON po.SupplierID = sup.SupplierID
                             ORDER BY po.OrderDate DESC, po.PurchaseOrderID DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    _boundTable = new DataTable();
                    conn.Open();
                    da.Fill(_boundTable);
                }
                RenderResults(_boundTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // RENDER — matches UcSearchOrder ListView rendering pattern
        // ================================================================
        private void RenderResults(DataTable dt)
        {
            lvResults.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["PurchaseOrderID"].ToString());
                item.SubItems.Add(row["SupplierName"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["OrderDate"]).ToString("yyyy-MM-dd"));
                item.SubItems.Add(row["ExpectedDeliveryDate"] == DBNull.Value
                    ? "" : Convert.ToDateTime(row["ExpectedDeliveryDate"]).ToString("yyyy-MM-dd"));
                item.SubItems.Add(row["Status"].ToString());
                item.SubItems.Add(row["PaymentStatus"].ToString());
                item.SubItems.Add(Convert.ToDecimal(row["TotalAmount"]).ToString("F2"));

                // Color-code Status (matches UcSearchMaterialRequest pattern)
                string status = row["Status"].ToString();
                if (status == "Draft")
                    item.SubItems[4].ForeColor = Color.FromArgb(120, 120, 120);
                else if (status == "Sent")
                    item.SubItems[4].ForeColor = Color.FromArgb(33, 102, 172);
                else if (status == "PartiallyReceived")
                    item.SubItems[4].ForeColor = Color.FromArgb(180, 70, 30);
                else if (status == "Received")
                    item.SubItems[4].ForeColor = Color.FromArgb(56, 142, 60);
                else if (status == "Cancelled")
                    item.SubItems[4].ForeColor = Color.FromArgb(180, 30, 30);

                lvResults.Items.Add(item);
            }
        }

        // ================================================================
        // SEARCH — matches T3 btnSearch_Click + UcSearchOrder.btnSearch_Click pattern
        // Uses parameterized query (@id, @status) to prevent SQL injection (T3 key concept)
        // ================================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string poID = txtPOID.Text.Trim();
            string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

            // If both filters are empty/All → load all
            if (string.IsNullOrEmpty(poID) && statusFilter == "All")
            {
                LoadAllProcurement();
                return;
            }

            string query = @"SELECT po.PurchaseOrderID,
                                    sup.SupplierName,
                                    po.OrderDate,
                                    po.ExpectedDeliveryDate,
                                    po.Status,
                                    po.PaymentStatus,
                                    po.TotalAmount
                             FROM PurchaseOrder po
                             JOIN Supplier sup ON po.SupplierID = sup.SupplierID
                             WHERE 1=1";

            if (!string.IsNullOrEmpty(poID))
                query += " AND po.PurchaseOrderID = @id";
            if (statusFilter != "All")
                query += " AND po.Status = @status";
            query += " ORDER BY po.OrderDate DESC, po.PurchaseOrderID DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // Parameterized queries (T3 key concept — prevent SQL injection)
                    if (!string.IsNullOrEmpty(poID))
                        cmd.Parameters.AddWithValue("@id", poID);
                    if (statusFilter != "All")
                        cmd.Parameters.AddWithValue("@status", statusFilter);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    _boundTable = new DataTable();
                    conn.Open();
                    da.Fill(_boundTable);
                }
                RenderResults(_boundTable);

                // T3 pattern: show message based on result
                if (lvResults.Items.Count > 0)
                {
                    MessageBox.Show("Record found!");
                }
                else
                {
                    MessageBox.Show("No record found with that code.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // SHOW ALL — reset filters and reload
        // ================================================================
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtPOID.Clear();
            cmbStatusFilter.SelectedIndex = 0; // All
            LoadAllProcurement();
        }

        // ================================================================
        // REFRESH — T3 btnDelete reset pattern: clear text + reload
        // ================================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPOID.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            LoadAllProcurement();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO products (
                Status 
            VALUES (
                @status)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", cboUpdateStatus.SelectedValue.ToString());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Status update successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }

        }
    }
}
