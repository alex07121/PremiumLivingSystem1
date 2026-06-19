using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class ReceiveTransferForm : Form
    {
        public ReceiveTransferForm()
        {
            InitializeComponent();
        }

        private void ReceiveTransferForm_Load(object sender, EventArgs e)
        {
            dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransfers.ReadOnly = true;
            dgvTransfers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransfers.MultiSelect = false;
            dgvTransfers.AllowUserToAddRows = false;
            dgvTransfers.RowHeadersVisible = false;
            LoadIssuedTransfers();
        }

        private void LoadIssuedTransfers()
        {
            string query = @"
                SELECT TransferID, TransferDate, TransferType, OrderID, ProductionID,
                       FromLocation, ToLocation, RequestedBy, Remarks
                FROM RawMaterialTransfer
                WHERE Status = 'Issued'
                ORDER BY TransferDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTransfers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private string GetSelectedTransferID()
        {
            if (dgvTransfers.SelectedRows.Count == 0) return null;
            return dgvTransfers.SelectedRows[0].Cells["TransferID"].Value?.ToString();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            string transferId = GetSelectedTransferID();
            if (string.IsNullOrEmpty(transferId))
            {
                MessageBox.Show("Please select a transfer first.");
                return;
            }

            string update = @"UPDATE RawMaterialTransfer
                SET Status = 'Received', ReceivedBy = @staff, ReceivedDate = CURDATE()
                WHERE TransferID = @tId";

            try
            {
                int rowsAffected = 0;
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-001");
                    cmd.Parameters.AddWithValue("@tId", transferId);

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Transfer {transferId} received. Goods confirmed.", "Received",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadIssuedTransfers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            string transferId = GetSelectedTransferID();
            if (string.IsNullOrEmpty(transferId)) return;

            string query = @"
                SELECT 
                    COALESCE(rti.MaterialID, rti.ProductID) AS ItemID,
                    rti.Description, rti.Quantity, rti.Unit
                FROM RawMaterialTransferItem rti
                WHERE rti.TransferID = @tId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@tId", transferId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvItems.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
    }
}
