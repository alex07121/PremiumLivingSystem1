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
            listTransfers.Columns.Add("Status", 90);  // [v5.4 NEW]

            listItems.Columns.Clear();
            listItems.Columns.Add("Item ID", 120);
            listItems.Columns.Add("Description", 280);
            listItems.Columns.Add("Quantity", 80);
            listItems.Columns.Add("Unit", 80);
        }

        private void LoadAllIssued()
        {
            // [v5.4] Show both 'Issued' (awaiting delivery) and 'Delivering' (in transit)
            string query = @"
                SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                       FromLocation, ToLocation, RequestedBy, IssuedBy, Status,
                       DeliveredBy, DeliveringDate
                FROM RawMaterialTransfer
                WHERE Status IN ('Issued', 'Delivering')
                ORDER BY IssuedDate DESC";

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
                        // Store Status in Tag for button enable/disable logic
                        item.Tag = r["Status"].ToString();
                        item.SubItems.Add(r["Status"].ToString());
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
                FromLocation, ToLocation, RequestedBy, IssuedBy, Status
                FROM RawMaterialTransfer WHERE Status IN ('Issued','Delivering') AND TransferID=@tId";

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
                        item.Tag = r["Status"].ToString();
                        item.SubItems.Add(r["Status"].ToString());
                        listTransfers.Items.Add(item);
                    }
                    r.Close();
                    if (!f) MessageBox.Show("No transfer found.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void listTransfers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();

            if (listTransfers.SelectedItems.Count == 0)
            {
                btnStartDelivery.Enabled = false;
                btnReceive.Enabled = false;
                return;
            }

            // Enable buttons based on Status (stored in Tag)
            string status = listTransfers.SelectedItems[0].Tag?.ToString() ?? "";
            btnStartDelivery.Enabled = (status == "Issued");       // Issued → Delivering
            btnReceive.Enabled = (status == "Delivering");         // Delivering → Received
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

            // T3 style: YesNo confirmation
            var confirm = MessageBox.Show(
                "Confirm goods received for Transfer " + tid + "?",
                "Confirm Received", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string query = "UPDATE RawMaterialTransfer SET Status='Received', ReceivedBy=@staff, ReceivedDate=CURDATE() WHERE TransferID=@tId AND Status='Delivering'";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-001");
                    cmd.Parameters.AddWithValue("@tId", tid);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show($"Transfer {tid} received. Goods confirmed.", "Received");
                    else
                        MessageBox.Show("Cannot receive. Transfer must be in 'Delivering' status.");
                }
                LoadAllIssued();
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }

        // ================================================================
        // START DELIVERY — Logistics Staff picks up goods and starts delivery
        // Status: Issued → Delivering
        // ================================================================
        private void btnStartDelivery_Click(object sender, EventArgs e)
        {
            if (listTransfers.SelectedItems.Count == 0) return;
            string tid = listTransfers.SelectedItems[0].Text;

            // T3 style: YesNo confirmation
            var confirm = MessageBox.Show(
                "Start delivery for Transfer " + tid + "?\n\n" +
                "Status will change to 'Delivering'.\n" +
                "DeliveredBy and DeliveringDate will be recorded.",
                "Confirm Start Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string query = @"UPDATE RawMaterialTransfer
                                 SET Status='Delivering',
                                     DeliveredBy=@staff,
                                     DeliveringDate=NOW()
                                 WHERE TransferID=@tId AND Status='Issued'";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-001");
                    cmd.Parameters.AddWithValue("@tId", tid);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show($"Transfer {tid} is now out for delivery.", "Delivering");
                    else
                        MessageBox.Show("Cannot start delivery. Transfer must be in 'Issued' status.");
                }
                LoadAllIssued();
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }
    }
}
