using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcPendingTransfers : UserControl
    {
        public UcPendingTransfers()
        {
            InitializeComponent();
        }

        private void UcPendingTransfers_Load(object sender, EventArgs e)
        {
            SetupColumns();
            LoadAllPending();
        }

        private void SetupColumns()
        {
            listTransfers.Columns.Clear();
            listTransfers.Columns.Add("Transfer ID", 140);
            listTransfers.Columns.Add("Date", 80);
            listTransfers.Columns.Add("Type", 110);
            listTransfers.Columns.Add("Order ID", 120);
            listTransfers.Columns.Add("Prod ID", 80);
            listTransfers.Columns.Add("From", 120);
            listTransfers.Columns.Add("To", 120);
            listTransfers.Columns.Add("Req By", 70);
            listTransfers.Columns.Add("Remarks", 120);

            listItems.Columns.Clear();
            listItems.Columns.Add("Item ID", 120);
            listItems.Columns.Add("Description", 280);
            listItems.Columns.Add("Quantity", 80);
            listItems.Columns.Add("Unit", 80);
        }

        private void LoadAllPending()
        {
            string query = @"
                SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                       FromLocation, ToLocation, RequestedBy, Remarks
                FROM RawMaterialTransfer
                WHERE Status = 'Pending'
                ORDER BY TransferDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listTransfers.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TransferID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["TransferDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(reader["TransferType"].ToString());
                        item.SubItems.Add(reader["OrderID"]?.ToString() ?? "");
                        item.SubItems.Add(reader["ProductionID"]?.ToString() ?? "");
                        item.SubItems.Add(reader["FromLocation"]?.ToString() ?? "");
                        item.SubItems.Add(reader["ToLocation"]?.ToString() ?? "");
                        item.SubItems.Add(reader["RequestedBy"].ToString());
                        item.SubItems.Add(reader["Remarks"]?.ToString() ?? "");
                        listTransfers.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadAllPending();
                return;
            }

            string query = @"
                SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                       FromLocation, ToLocation, RequestedBy, Remarks
                FROM RawMaterialTransfer
                WHERE Status = 'Pending' AND TransferID = @tId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tId", keyword);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listTransfers.Items.Clear();
                    bool found = false;
                    while (reader.Read())
                    {
                        found = true;
                        ListViewItem item = new ListViewItem(reader["TransferID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["TransferDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(reader["TransferType"].ToString());
                        item.SubItems.Add(reader["OrderID"]?.ToString() ?? "");
                        item.SubItems.Add(reader["ProductionID"]?.ToString() ?? "");
                        item.SubItems.Add(reader["FromLocation"]?.ToString() ?? "");
                        item.SubItems.Add(reader["ToLocation"]?.ToString() ?? "");
                        item.SubItems.Add(reader["RequestedBy"].ToString());
                        item.SubItems.Add(reader["Remarks"]?.ToString() ?? "");
                        listTransfers.Items.Add(item);
                    }
                    reader.Close();
                    if (!found) MessageBox.Show("No pending transfer found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void listTransfers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = listTransfers.SelectedItems.Count > 0;
            btnApprove.Enabled = hasSelection;
            btnCancel.Enabled = hasSelection;
            LoadSelectedItems();
        }

        private void LoadSelectedItems()
        {
            if (listTransfers.SelectedItems.Count == 0)
            {
                listItems.Items.Clear();
                return;
            }

            string transferId = listTransfers.SelectedItems[0].Text;

            string query = @"
                SELECT COALESCE(rti.MaterialID, rti.ProductID) AS ItemID,
                       rti.Description, rti.Quantity, rti.Unit
                FROM RawMaterialTransferItem rti
                WHERE rti.TransferID = @tId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tId", transferId);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listItems.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ItemID"].ToString());
                        item.SubItems.Add(reader["Description"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["Unit"]?.ToString() ?? "");
                        listItems.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadItems error: " + ex.Message);
            }
        }

        private string GetSelectedTransferID()
        {
            if (listTransfers.SelectedItems.Count == 0) return null;
            return listTransfers.SelectedItems[0].Text;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string transferId = GetSelectedTransferID();
            if (string.IsNullOrEmpty(transferId)) return;

            try
            {
                string query = @"UPDATE RawMaterialTransfer
                        SET Status = 'Approved', ApprovedBy = @staff, ApprovedDate = CURDATE()
                        WHERE TransferID = @tId";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-001");
                    cmd.Parameters.AddWithValue("@tId", transferId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show($"Transfer {transferId} approved.", "Approved");
                }
                LoadAllPending();
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string transferId = GetSelectedTransferID();
            if (string.IsNullOrEmpty(transferId)) return;

            if (MessageBox.Show($"Cancel transfer {transferId}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                string query = @"UPDATE RawMaterialTransfer
                        SET Status = 'Cancelled', Remarks = CONCAT(IFNULL(Remarks,''), ' | Cancelled by Supervisor')
                        WHERE TransferID = @tId";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tId", transferId);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show($"Transfer {transferId} cancelled.", "Cancelled");
                }
                LoadAllPending();
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }
    }
}
