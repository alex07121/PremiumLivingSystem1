using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcCreateProcurement : UserControl
    {
        public UcCreateProcurement()
        {
            InitializeComponent();
        }

        // ================================================================
        // LOAD
        // ================================================================
        private void UcCreateProcurement_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCurrentUser();
            LoadSuppliers();
            LoadMaterials();

            // Defaults
            txtPurchaseOrderID.Text = "(auto on save)";
            dtpOrderDate.Value = DateTime.Today;
            dtpExpectedDate.Value = DateTime.Today.AddDays(14);
            cmbPaymentMethod.SelectedIndex = 2; // BankTransfer
            txtSubTotal.Text = "0.00";
            txtTotal.Text = "0.00";

            // Event wiring
            cmbSupplier.SelectedIndexChanged += cmbSupplier_SelectedIndexChanged;
            cmbMaterial.SelectedIndexChanged += cmbMaterial_SelectedIndexChanged;
            nudQuantity.ValueChanged += RecalcPreview;
            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;
            btnSaveDraft.Click += btnSaveDraft_Click;
            btnSubmit.Click += btnSubmit_Click;
            btnClear.Click += btnClear_Click;
        }

        // ================================================================
        // GRID SETUP
        // ================================================================
        private void SetupDataGridView()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("colMaterialID", "Material ID");
            dgvItems.Columns.Add("colMaterialName", "Material Name");
            dgvItems.Columns.Add("colQty", "Quantity");
            dgvItems.Columns.Add("colUnit", "Unit");
            dgvItems.Columns.Add("colUnitPrice", "Unit Price");
            dgvItems.Columns.Add("colLineTotal", "Line Total");
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.Columns["colMaterialID"].Width = 100;
            dgvItems.Columns["colMaterialName"].FillWeight = 250;
            dgvItems.Columns["colQty"].Width = 90;
            dgvItems.Columns["colUnit"].Width = 70;
            dgvItems.Columns["colUnitPrice"].Width = 110;
            dgvItems.Columns["colLineTotal"].Width = 120;
        }

        // ================================================================
        // LOAD CURRENT USER
        // ================================================================
        private void LoadCurrentUser()
        {
            try
            {
                string staffId = UserSession.CurrentStaffId;
                if (string.IsNullOrEmpty(staffId)) return;

                string query = @"
                    SELECT s.StaffID, s.StaffName, j.Job_Title
                    FROM Staff s
                    JOIN Jobs j ON s.Job_ID = j.Job_ID
                    WHERE s.StaffID = @staffId";

                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtReqByID.Text = reader["StaffID"].ToString();
                            txtReqName.Text = reader["StaffName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // LOAD SUPPLIERS
        // ================================================================
        private void LoadSuppliers()
        {
            string query = @"
                SELECT SupplierID,
                       CONCAT(SupplierID, '  |  ', SupplierName, '  (', Phone, ')') AS DisplayText,
                       SupplierName
                FROM Supplier
                ORDER BY SupplierID";

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                }
                cmbSupplier.DataSource = dt;
                cmbSupplier.DisplayMember = "DisplayText";
                cmbSupplier.ValueMember = "SupplierID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        // ================================================================
        // LOAD MATERIALS (filtered by selected supplier)
        // ================================================================
        private void LoadMaterials()
        {
            string supplierID = cmbSupplier.SelectedValue?.ToString();
            string query;

            if (!string.IsNullOrEmpty(supplierID))
            {
                query = @"
                    SELECT MaterialID,
                           MaterialName,
                           Unit,
                           StockQty,
                           ReorderLevel,
                           UnitPurchasePrice,
                           CONCAT(MaterialID, '  |  ', MaterialName, '  [', Unit, ']') AS DisplayText
                    FROM RawMaterial
                    WHERE SupplierID = @sid
                    ORDER BY MaterialID";
            }
            else
            {
                query = @"
                    SELECT MaterialID,
                           MaterialName,
                           Unit,
                           StockQty,
                           ReorderLevel,
                           UnitPurchasePrice,
                           CONCAT(MaterialID, '  |  ', MaterialName, '  [', Unit, ']') AS DisplayText
                    FROM RawMaterial
                    ORDER BY MaterialID";
            }

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(supplierID))
                        cmd.Parameters.AddWithValue("@sid", supplierID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                }
                cmbMaterial.DataSource = dt;
                cmbMaterial.DisplayMember = "DisplayText";
                cmbMaterial.ValueMember = "MaterialID";

                UpdateStockHint();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading materials: " + ex.Message);
            }
        }

        // When supplier changes, reload the material list (filtered)
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        // Show stock + reorder level hint when material changes
        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStockHint();
        }

        private void UpdateStockHint()
        {
            try
            {
                if (cmbMaterial.SelectedItem == null)
                {
                    lblStockHint.Text = "";
                    return;
                }
                DataRowView row = cmbMaterial.SelectedItem as DataRowView;
                if (row == null) return;

                decimal stock = 0m, reorder = 0m;
                if (row["StockQty"] != DBNull.Value) stock = Convert.ToDecimal(row["StockQty"]);
                if (row["ReorderLevel"] != DBNull.Value) reorder = Convert.ToDecimal(row["ReorderLevel"]);

                string unit = row["Unit"].ToString();
                if (stock <= reorder)
                {
                    lblStockHint.ForeColor = Color.FromArgb(180, 30, 30);
                    lblStockHint.Text = $"Stock: {stock} {unit}  (at/below reorder {reorder})";
                }
                else
                {
                    lblStockHint.ForeColor = Color.FromArgb(56, 110, 60);
                    lblStockHint.Text = $"Stock: {stock} {unit}";
                }
            }
            catch
            {
                lblStockHint.Text = "";
            }
        }

        // ================================================================
        // ITEM ROW MANAGEMENT
        // ================================================================
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show("Please select a material.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView row = cmbMaterial.SelectedItem as DataRowView;
            if (row == null) return;

            string materialID = cmbMaterial.SelectedValue.ToString();
            string materialName = row["MaterialName"].ToString();
            string unit = row["Unit"].ToString();
            decimal qty = nudQuantity.Value;

            // Auto-fill unit price from RawMaterial.UnitPurchasePrice (no manual input)
            decimal unitPrice = 0m;
            if (row["UnitPurchasePrice"] != DBNull.Value)
                unitPrice = Convert.ToDecimal(row["UnitPurchasePrice"]);
            decimal lineTotal = qty * unitPrice;

            // Prevent duplicates
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                if (r.Cells["colMaterialID"].Value?.ToString() == materialID)
                {
                    MessageBox.Show("This material is already in the list.",
                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            dgvItems.Rows.Add(materialID, materialName,
                qty.ToString("F2"), unit,
                unitPrice.ToString("F2"),
                lineTotal.ToString("F2"));

            // Reset inputs
            nudQuantity.Value = 1;
            RecalcPreview(null, null);
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItems.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvItems.Rows.Remove(row);
                }
                RecalcPreview(null, null);
            }
        }

        // ================================================================
        // TOTALS RECALC
        // ================================================================
        private void RecalcPreview(object sender, EventArgs e)
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;
                decimal lineTotal = Convert.ToDecimal(row.Cells["colLineTotal"].Value);
                subTotal += lineTotal;
            }
            // No tax — total equals subtotal
            txtSubTotal.Text = subTotal.ToString("F2");
            txtTotal.Text = subTotal.ToString("F2");
        }

        // ================================================================
        // SAVE — shared by Save Draft and Submit
        // ================================================================
        private string SaveProcurement(string status)
        {
            // 1. Validate
            if (cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a supplier.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one item.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (status == "Sent" && dtpExpectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Expected delivery date cannot be in the past for a submitted PO.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // 2. Collect values
            string supplierID = cmbSupplier.SelectedValue.ToString();
            string orderDate = dtpOrderDate.Value.ToString("yyyy-MM-dd");
            string expectedDate = dtpExpectedDate.Value.ToString("yyyy-MM-dd");
            string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            string createdBy = txtReqByID.Text.Trim();
            string remarks = txtRemarks.Text.Trim();

            decimal subTotal = Convert.ToDecimal(txtSubTotal.Text);
            decimal taxAmount = 0;   // no tax field in UI
            decimal totalAmount = subTotal;

            // 3. INSERT header + items (transactional, matches UcTransfer pattern)
            string insertHeader = @"
                INSERT INTO PurchaseOrder
                    (SupplierID, OrderDate, ExpectedDeliveryDate,
                     Status, PaymentStatus, PaymentMethod,
                     SubTotal, TaxAmount, TotalAmount,
                     CreatedBy, CreatedAt, SentDate, Remarks)
                VALUES
                    (@sup, @od, @edd,
                     @status, 'Unpaid', @pm,
                     @sub, @tax, @total,
                     @cb, NOW(), @sentDate, @rem)";

            string insertItem = @"
                INSERT INTO PurchaseOrderItem
                    (PurchaseOrderID, MaterialID, Quantity, Unit, UnitPrice, ReceivedQty, Remarks)
                VALUES
                    (@poid, @mid, @qty, @unit, @price, 0, NULL)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        MySqlCommand cmdHeader = new MySqlCommand(insertHeader, conn, trans);
                        cmdHeader.Parameters.AddWithValue("@sup", supplierID);
                        cmdHeader.Parameters.AddWithValue("@od", orderDate);
                        cmdHeader.Parameters.AddWithValue("@edd", expectedDate);
                        cmdHeader.Parameters.AddWithValue("@status", status);
                        cmdHeader.Parameters.AddWithValue("@pm", paymentMethod);
                        cmdHeader.Parameters.AddWithValue("@sub", subTotal);
                        cmdHeader.Parameters.AddWithValue("@tax", taxAmount);
                        cmdHeader.Parameters.AddWithValue("@total", totalAmount);
                        cmdHeader.Parameters.AddWithValue("@cb", createdBy);
                        // SentDate is NOW() if submitting as Sent, else NULL
                        cmdHeader.Parameters.AddWithValue("@sentDate",
                            (status == "Sent") ? (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : DBNull.Value);
                        cmdHeader.Parameters.AddWithValue("@rem",
                            string.IsNullOrEmpty(remarks) ? (object)DBNull.Value : remarks);

                        cmdHeader.ExecuteNonQuery();

                        // Retrieve the auto-generated PurchaseOrderID (trigger format: PO-YYYYMMDD-NNN)
                        string actualPOID;
                        string getIdQuery = @"
                            SELECT PurchaseOrderID FROM PurchaseOrder
                            WHERE CreatedBy = @cb
                            ORDER BY CreatedAt DESC LIMIT 1";
                        MySqlCommand cmdGetId = new MySqlCommand(getIdQuery, conn, trans);
                        cmdGetId.Parameters.AddWithValue("@cb", createdBy);
                        actualPOID = cmdGetId.ExecuteScalar()?.ToString();
                        if (string.IsNullOrEmpty(actualPOID))
                            throw new Exception("Failed to retrieve generated PurchaseOrderID.");

                        txtPurchaseOrderID.Text = actualPOID;

                        // Insert items
                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string materialID = row.Cells["colMaterialID"].Value?.ToString();
                            decimal qty = Convert.ToDecimal(row.Cells["colQty"].Value);
                            string unit = row.Cells["colUnit"].Value?.ToString();
                            decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);

                            MySqlCommand cmdItem = new MySqlCommand(insertItem, conn, trans);
                            cmdItem.Parameters.AddWithValue("@poid", actualPOID);
                            cmdItem.Parameters.AddWithValue("@mid", materialID);
                            cmdItem.Parameters.AddWithValue("@qty", qty);
                            cmdItem.Parameters.AddWithValue("@unit", unit);
                            cmdItem.Parameters.AddWithValue("@price", unitPrice);
                            cmdItem.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return actualPOID;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ================================================================
        // BUTTON HANDLERS
        // ================================================================
        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            string result = SaveProcurement("Draft");
            if (result != null)
            {
                MessageBox.Show($"Purchase Order saved as Draft.\nPO ID: {result}",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Confirm (T3 style)
            var confirm = MessageBox.Show(
                "Submit this Purchase Order as 'Sent'?\n" +
                "Status will be set to 'Sent' and SentDate recorded as now.\n" +
                "Payment status remains 'Unpaid' until Finance processes it.",
                "Confirm Submit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string result = SaveProcurement("Sent");
            if (result != null)
            {
                MessageBox.Show(
                    $"Purchase Order submitted successfully.\nPO ID: {result}\nStatus: Sent",
                    "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtPurchaseOrderID.Text = "(auto on save)";
            dtpOrderDate.Value = DateTime.Today;
            dtpExpectedDate.Value = DateTime.Today.AddDays(14);
            cmbPaymentMethod.SelectedIndex = 2; // BankTransfer
            txtRemarks.Clear();
            nudQuantity.Value = 1;
            dgvItems.Rows.Clear();
            txtSubTotal.Text = "0.00";
            txtTotal.Text = "0.00";
            if (cmbSupplier.Items.Count > 0) cmbSupplier.SelectedIndex = 0;
        }
    }
}
