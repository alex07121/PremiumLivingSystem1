using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcReceivableTransfers : UserControl
    {
        public UcReceivableTransfers() { InitializeComponent(); }

        private void UcReceivableTransfers_Load(object sender, EventArgs e)
        {
            SetupColumns();
            LoadAllIssued();
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
            listTransfers.Columns.Add("Issued By", 80);

            listItems.Columns.Clear();
            listItems.Columns.Add("Item ID", 120);
            listItems.Columns.Add("Description", 280);
            listItems.Columns.Add("Quantity", 80);
            listItems.Columns.Add("Unit", 80);
        }

        private void LoadAllIssued()
        {
            string query = @"
                SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                       FromLocation, ToLocation, RequestedBy, IssuedBy
                FROM RawMaterialTransfer WHERE Status = 'Issued' ORDER BY IssuedDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listTransfers.Items.Clear();
                    while (r.Read())
                    {
                        var item = new ListViewItem(r["TransferID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(r["TransferDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(r["TransferType"].ToString());
                        item.SubItems.Add(r["OrderID"]?.ToString() ?? "");
                        item.SubItems.Add(r["ProductionID"]?.ToString() ?? "");
                        item.SubItems.Add(r["FromLocation"]?.ToString() ?? "");
                        item.SubItems.Add(r["ToLocation"]?.ToString() ?? "");
                        item.SubItems.Add(r["RequestedBy"].ToString());
                        item.SubItems.Add(r["IssuedBy"]?.ToString() ?? "");
                        listTransfers.Items.Add(item);
                    }
                    r.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadAllIssued(); return; }

            string query = @"SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                FromLocation, ToLocation, RequestedBy, IssuedBy
                FROM RawMaterialTransfer WHERE Status='Issued' AND TransferID=@tId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tId", kw);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listTransfers.Items.Clear(); bool f = false;
                    while (r.Read())
                    {
                        f = true;
                        var item = new ListViewItem(r["TransferID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(r["TransferDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(r["TransferType"].ToString());
                        item.SubItems.Add(r["OrderID"]?.ToString() ?? "");
                        item.SubItems.Add(r["ProductionID"]?.ToString() ?? "");
                        item.SubItems.Add(r["FromLocation"]?.ToString() ?? "");
                        item.SubItems.Add(r["ToLocation"]?.ToString() ?? "");
                        item.SubItems.Add(r["RequestedBy"].ToString());
                        item.SubItems.Add(r["IssuedBy"]?.ToString() ?? "");
                        listTransfers.Items.Add(item);
                    }
                    r.Close();
                    if (!f) MessageBox.Show("No issued transfer found.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void listTransfers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReceive.Enabled = listTransfers.SelectedItems.Count > 0;
            LoadItems();
        }

        private void LoadItems()
        {
            if (listTransfers.SelectedItems.Count == 0) { listItems.Items.Clear(); return; }
            string tid = listTransfers.SelectedItems[0].Text;

            try
            {
                string query = @"
                        SELECT COALESCE(rti.MaterialID, rti.ProductID) AS ItemID, rti.Description, rti.Quantity, rti.Unit
                        FROM RawMaterialTransferItem rti WHERE rti.TransferID=@tId";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tId", tid);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listItems.Items.Clear();
                    while (r.Read())
                    {
                        var item = new ListViewItem(r["ItemID"].ToString());
                        item.SubItems.Add(r["Description"]?.ToString() ?? "");
                        item.SubItems.Add(r["Quantity"].ToString());
                        item.SubItems.Add(r["Unit"]?.ToString() ?? "");
                        listItems.Items.Add(item);
                    }
                    r.Close();
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("LoadItems: " + ex.Message); }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (listTransfers.SelectedItems.Count == 0) return;
            string tid = listTransfers.SelectedItems[0].Text;

            try
            {
                string query = "UPDATE RawMaterialTransfer SET Status='Received', ReceivedBy=@staff, ReceivedDate=CURDATE() WHERE TransferID=@tId";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-001");
                    cmd.Parameters.AddWithValue("@tId", tid);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show($"Transfer {tid} received. Goods confirmed.", "Received");
                }
                LoadAllIssued();
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }
    }
}
