using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcSearchMaterialRequest : UserControl
    {
        // Bound DataTable used to look up details for the selected row
        private DataTable _boundTable = null;

        public UcSearchMaterialRequest()
        {
            InitializeComponent();
        }

        // ================================================================
        // LOAD
        // ================================================================
        private void UcSearchMaterialRequest_Load(object sender, EventArgs e)
        {
            SetupListView();
            cmbStatusFilter.SelectedIndex = 0; // "All"
            LoadAllRequests();
            ClearDetails();
            btnApprove.Enabled = false;
            btnCreateTransfer.Enabled = false;
        }

        // ================================================================
        // LISTVIEW SETUP — matches UcSearchOrder style (T3)
        // ================================================================
        private void SetupListView()
        {
            dgvResults.View = View.Details;
            dgvResults.FullRowSelect = true;
            dgvResults.GridLines = true;
            dgvResults.MultiSelect = false;
            dgvResults.Columns.Add("RequestID", "Request ID", 110);
            dgvResults.Columns.Add("OrderItem", "Order Item", 110);
            dgvResults.Columns.Add("Materials", "Materials (summary)", 280);
            dgvResults.Columns.Add("Items", "Count", 60);
            dgvResults.Columns.Add("Urgency", "Urgency", 90);
            dgvResults.Columns.Add("ReqDate", "Required Date", 120);
            dgvResults.Columns.Add("Status", "Status", 110);
        }

        // ================================================================
        // LOAD ALL REQUESTS — [v5.3] header + GROUP_CONCAT items
        // ================================================================
        private void LoadAllRequests()
        {
            string query = @"
                SELECT mr.RequestID,
                       mr.OrderItemID,
                       mr.UrgencyLevel,
                       mr.RequiredDeliveryDate,
                       mr.RequestedBy,
                       mr.Status,
                       mr.Remarks,
                       CONCAT(s.StaffID, ' - ', s.StaffName) AS RequestedByName,
                       (SELECT GROUP_CONCAT(CONCAT(rm.MaterialName, ' (', mri.Quantity, ' ', mri.Unit, ')') SEPARATOR ', ')
                        FROM MaterialRequestItem mri
                        JOIN RawMaterial rm ON mri.MaterialID = rm.MaterialID
                        WHERE mri.RequestID = mr.RequestID) AS MaterialsSummary,
                       (SELECT COUNT(*) FROM MaterialRequestItem mri WHERE mri.RequestID = mr.RequestID) AS ItemCount
                FROM MaterialRequest mr
                JOIN Staff s ON mr.RequestedBy = s.StaffID
                ORDER BY
                    CASE mr.Status
                        WHEN 'Requested' THEN 0
                        WHEN 'Approved'  THEN 1
                        WHEN 'Fulfilled' THEN 2
                        ELSE 3
                    END,
                    mr.RequestID";

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
                RenderTable(_boundTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void RenderTable(DataTable dt)
        {
            dgvResults.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["RequestID"].ToString());
                item.SubItems.Add(row["OrderItemID"] == DBNull.Value ? "" : row["OrderItemID"].ToString());
                item.SubItems.Add(row["MaterialsSummary"]?.ToString() ?? "(no items)");
                item.SubItems.Add(row["ItemCount"].ToString());
                item.SubItems.Add(row["UrgencyLevel"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["RequiredDeliveryDate"]).ToString("yyyy-MM-dd"));
                item.SubItems.Add(row["Status"].ToString());

                // Color-code status text
                string status = row["Status"].ToString();
                if (status == "Requested")
                    item.SubItems[6].ForeColor = Color.FromArgb(180, 70, 30);
                else if (status == "Approved")
                    item.SubItems[6].ForeColor = Color.FromArgb(33, 102, 172);
                else if (status == "Fulfilled")
                    item.SubItems[6].ForeColor = Color.FromArgb(56, 142, 60);

                // Urgency highlight
                string urgency = row["UrgencyLevel"].ToString();
                if (urgency == "Urgent")
                    item.SubItems[4].ForeColor = Color.FromArgb(180, 30, 30);
                else if (urgency == "High")
                    item.SubItems[4].ForeColor = Color.FromArgb(180, 70, 30);

                dgvResults.Items.Add(item);
            }
        }

        // ================================================================
        // SEARCH — T3 style: parameterized WHERE
        // ================================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string requestID = txtRequestID.Text.Trim();
            string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

            if (string.IsNullOrEmpty(requestID) && statusFilter == "All")
            {
                LoadAllRequests();
                return;
            }

            string query = @"
                SELECT mr.RequestID,
                       mr.OrderItemID,
                       mr.UrgencyLevel,
                       mr.RequiredDeliveryDate,
                       mr.RequestedBy,
                       mr.Status,
                       mr.Remarks,
                       CONCAT(s.StaffID, ' - ', s.StaffName) AS RequestedByName,
                       (SELECT GROUP_CONCAT(CONCAT(rm.MaterialName, ' (', mri.Quantity, ' ', mri.Unit, ')') SEPARATOR ', ')
                        FROM MaterialRequestItem mri
                        JOIN RawMaterial rm ON mri.MaterialID = rm.MaterialID
                        WHERE mri.RequestID = mr.RequestID) AS MaterialsSummary,
                       (SELECT COUNT(*) FROM MaterialRequestItem mri WHERE mri.RequestID = mr.RequestID) AS ItemCount
                FROM MaterialRequest mr
                JOIN Staff s ON mr.RequestedBy = s.StaffID
                WHERE 1=1";

            if (!string.IsNullOrEmpty(requestID))
                query += " AND mr.RequestID = @rid";
            if (statusFilter != "All")
                query += " AND mr.Status = @status";
            query += " ORDER BY mr.RequestID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(requestID))
                        cmd.Parameters.AddWithValue("@rid", requestID);
                    if (statusFilter != "All")
                        cmd.Parameters.AddWithValue("@status", statusFilter);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    _boundTable = new DataTable();
                    conn.Open();
                    da.Fill(_boundTable);
                }
                RenderTable(_boundTable);

                // T3 pattern: show message based on result
                if (dgvResults.Items.Count > 0)
                {
                    MessageBox.Show("Record found!");
                }
                else
                {
                    MessageBox.Show("No record found with that code.");
                    ClearDetails();
                    btnApprove.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtRequestID.Clear();
            cmbStatusFilter.SelectedIndex = 0; // All
            LoadAllRequests();
            ClearDetails();
            btnApprove.Enabled = false;
            btnCreateTransfer.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllRequests();
            ClearDetails();
            btnApprove.Enabled = false;
            btnCreateTransfer.Enabled = false;
        }

        // ================================================================
        // SELECTION → POPULATE DETAILS
        // [v5.3] Details now show summary from bound table + item count
        // ================================================================
        private void dgvResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedItems.Count == 0)
            {
                ClearDetails();
                btnApprove.Enabled = false;
                btnCreateTransfer.Enabled = false;
                return;
            }

            string selectedRequestID = dgvResults.SelectedItems[0].Text;
            if (string.IsNullOrEmpty(selectedRequestID)) return;

            // Find the row in the bound DataTable
            if (_boundTable == null) return;
            DataRow[] matches = _boundTable.Select("RequestID = '" + selectedRequestID.Replace("'", "''") + "'");
            if (matches.Length == 0) return;
            DataRow row = matches[0];

            // Show materials summary in the Material field
            txtMaterialName.Text = row["MaterialsSummary"]?.ToString() ?? "(no items)";
            txtQuantity.Text = row["ItemCount"].ToString() + " item(s)";
            txtUrgency.Text = row["UrgencyLevel"].ToString();
            txtReqDate.Text = Convert.ToDateTime(row["RequiredDeliveryDate"]).ToString("yyyy-MM-dd");
            txtReqBy.Text = row["RequestedByName"].ToString();
            txtCurrentStatus.Text = row["Status"].ToString();
            txtRemarksDet.Text = row["Remarks"]?.ToString() ?? "";

            // Stock field shows item count (stock check is per-item, not per-request)
            txtStockAvail.Text = row["ItemCount"].ToString() + " material(s) in this request";
            txtStockAvail.ForeColor = SystemColors.WindowText;

            // Approve button enabled only for "Requested" status
            // Create Transfer button enabled only for "Approved" status
            string status = row["Status"].ToString();
            btnApprove.Enabled = (status == "Requested");
            btnCreateTransfer.Enabled = (status == "Approved");
        }

        private void ClearDetails()
        {
            txtMaterialName.Clear();
            txtQuantity.Clear();
            txtUrgency.Clear();
            txtReqDate.Clear();
            txtReqBy.Clear();
            txtCurrentStatus.Clear();
            txtRemarksDet.Clear();
            txtStockAvail.Clear();
            txtStockAvail.ForeColor = SystemColors.WindowText;
        }

        // ================================================================
        // APPROVE — Inventory Clerk approves a Requested material request
        // ================================================================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedItems.Count == 0) return;

            string requestID = dgvResults.SelectedItems[0].Text;
            string materials = txtMaterialName.Text;
            string itemCount = txtQuantity.Text;

            // T3 style: YesNo confirmation
            var confirm = MessageBox.Show(
                "Approve this Raw Material Request?\n\n" +
                "Request ID: " + requestID + "\n" +
                "Materials: " + materials + "\n" +
                "Items: " + itemCount + "\n\n" +
                "Status will change to 'Approved' and be ready for fulfillment.",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string approverID = UserSession.CurrentStaffId;

            string updateQuery = @"
                UPDATE MaterialRequest
                SET Status = 'Approved',
                    ApprovedBy = @approver,
                    ApprovedDate = NOW()
                WHERE RequestID = @rid AND Status = 'Requested'";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@approver", approverID);
                    cmd.Parameters.AddWithValue("@rid", requestID);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Request " + requestID + " approved successfully.",
                            "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the list (T3 style: reset after action)
                        LoadAllRequests();
                        ClearDetails();
                        btnApprove.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Approval failed. The request may no longer be in 'Requested' status.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving request: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================================
        // CREATE TRANSFER — opens TransferForm (modal dialog) pre-filled
        // with the approved request's items. Only enabled when Status = 'Approved'.
        // ================================================================
        private void btnCreateTransfer_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedItems.Count == 0) return;

            string requestID = dgvResults.SelectedItems[0].Text;

            // Confirm (T3 style: YesNo dialog)
            var confirm = MessageBox.Show(
                "Create a Raw Material Transfer from this approved request?\n\n" +
                "Request ID: " + requestID + "\n" +
                "Materials: " + txtMaterialName.Text + "\n\n" +
                "The Transfer Form will open with items pre-filled.",
                "Confirm Create Transfer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Open TransferForm as a modal dialog, pre-filled from the request
            using (TransferForm transferForm = new TransferForm())
            {
                transferForm.PrefillFromMaterialRequest(requestID);
                transferForm.ShowDialog();
            }

            // Refresh the list after the transfer dialog closes (T3 style: reset after action)
            LoadAllRequests();
            ClearDetails();
            btnApprove.Enabled = false;
            btnCreateTransfer.Enabled = false;
        }
    }
}
