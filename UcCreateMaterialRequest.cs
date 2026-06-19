using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcCreateMaterialRequest : UserControl
    {
        public UcCreateMaterialRequest()
        {
            InitializeComponent();
        }

        // ================================================================
        // LOAD
        // ================================================================
        private void UcCreateMaterialRequest_Load(object sender, EventArgs e)
        {
            // Setup ListView columns — T3 style: View.Details + FullRowSelect + GridLines
            lvMaterials.View = View.Details;
            lvMaterials.FullRowSelect = true;
            lvMaterials.GridLines = true;
            lvMaterials.MultiSelect = false;
            lvMaterials.Columns.Add("MaterialID", "Material ID", 100);
            lvMaterials.Columns.Add("MaterialName", "Material Name", 220);
            lvMaterials.Columns.Add("Qty", "Quantity", 90);
            lvMaterials.Columns.Add("Unit", "Unit", 60);
            lvMaterials.Columns.Add("Stock", "Stock", 100);
            lvMaterials.Columns.Add("Source", "Source", 100);

            // Defaults
            cmbUrgency.SelectedIndex = 1; // Medium
            txtRequestDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            txtRequestID.Text = "(auto on save)";

            LoadCurrentUser();
            LoadOrderFilter();
            LoadOrderItems();
            LoadMaterials();

            // Event wiring
            cmbOrderFilter.SelectedIndexChanged += cmbOrderFilter_SelectedIndexChanged;
            btnAutoFillBOM.Click += btnAutoFillBOM_Click;
            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;
            btnSubmit.Click += btnSubmit_Click;
            btnClear.Click += btnClear_Click;
        }

        // ================================================================
        // LOAD CURRENT USER
        // ================================================================
        private void LoadCurrentUser()
        {
            try
            {
                string staffId = UserSession.CurrentStaffId;
                if (string.IsNullOrEmpty(staffId))
                {
                    txtReqByID.Text = "";
                    txtReqName.Text = "";
                    txtReqPos.Text = "";
                    return;
                }

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
                            txtReqPos.Text = reader["Job_Title"].ToString();
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
        // LOAD ORDER FILTER — populates cmbOrderFilter with all non-cancelled orders
        // First item is "All Orders" for no filtering
        // ================================================================
        private void LoadOrderFilter()
        {
            string query = @"
                SELECT OrderID,
                       CONCAT(OrderID, '  |  ', CustomerID, '  |  ', OrderDate, '  |  ', Status) AS DisplayText
                FROM `Order`
                WHERE Status <> 'Cancelled'
                ORDER BY OrderDate DESC, OrderID DESC";

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

                // Insert "All Orders" as first row
                DataRow allRow = dt.NewRow();
                allRow["OrderID"] = "";
                allRow["DisplayText"] = "All Orders";
                dt.Rows.InsertAt(allRow, 0);

                cmbOrderFilter.DataSource = dt;
                cmbOrderFilter.DisplayMember = "DisplayText";
                cmbOrderFilter.ValueMember = "OrderID";
                cmbOrderFilter.SelectedIndex = 0; // All Orders
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // ORDER FILTER CHANGE → reload OrderItem dropdown filtered by selected Order
        // ================================================================
        private void cmbOrderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderItems();
        }

        // ================================================================
        // LOAD ORDER ITEMS — T3 style: MySqlDataAdapter + DataTable binding
        // [v5.3] Now filtered by cmbOrderFilter selection
        // ================================================================
        private void LoadOrderItems()
        {
            string selectedOrderID = cmbOrderFilter.SelectedValue?.ToString() ?? "";

            string query;
            if (string.IsNullOrEmpty(selectedOrderID))
            {
                // "All Orders" selected — show all non-cancelled OrderItems
                query = @"
                    SELECT oi.OrderItemID,
                           oi.Quantity,
                           p.ProductID,
                           p.ProductName,
                           CONCAT(oi.OrderItemID, '  |  ', o.OrderID,
                                  '  |  ', p.ProductName,
                                  '  (Qty: ', oi.Quantity, ')') AS DisplayText
                    FROM OrderItem oi
                    JOIN `Order` o ON oi.OrderID = o.OrderID
                    JOIN Product p ON oi.ProductID = p.ProductID
                    WHERE o.Status <> 'Cancelled'
                    ORDER BY oi.OrderItemID";
            }
            else
            {
                // Filtered by specific Order
                query = @"
                    SELECT oi.OrderItemID,
                           oi.Quantity,
                           p.ProductID,
                           p.ProductName,
                           CONCAT(oi.OrderItemID, '  |  ', p.ProductName,
                                  '  (Qty: ', oi.Quantity, ')') AS DisplayText
                    FROM OrderItem oi
                    JOIN `Order` o ON oi.OrderID = o.OrderID
                    JOIN Product p ON oi.ProductID = p.ProductID
                    WHERE o.Status <> 'Cancelled'
                      AND o.OrderID = @oid
                    ORDER BY oi.OrderItemID";
            }

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(selectedOrderID))
                        cmd.Parameters.AddWithValue("@oid", selectedOrderID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                }
                cmbOrderItem.DataSource = dt;
                cmbOrderItem.DisplayMember = "DisplayText";
                cmbOrderItem.ValueMember = "OrderItemID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // LOAD MATERIALS (for manual add dropdown)
        // ================================================================
        private void LoadMaterials()
        {
            string query = @"
                SELECT MaterialID,
                       MaterialName,
                       Unit,
                       StockQty,
                       CONCAT(MaterialID, '  |  ', MaterialName, '  [', Unit, ']') AS DisplayText
                FROM RawMaterial
                ORDER BY MaterialID";

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
                cmbMaterial.DataSource = dt;
                cmbMaterial.DisplayMember = "DisplayText";
                cmbMaterial.ValueMember = "MaterialID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // ================================================================
        // AUTO-FILL FROM BOM — queries ProductMaterial for the selected OrderItem's Product
        // Multiplies QuantityPerUnit × OrderItem.Quantity to get total needed
        // ================================================================
        private void btnAutoFillBOM_Click(object sender, EventArgs e)
        {
            if (cmbOrderItem.SelectedValue == null)
            {
                MessageBox.Show("Please select an Order Item first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get OrderItem details (ProductID + Quantity) from the bound DataTable
            DataRowView rv = cmbOrderItem.SelectedItem as DataRowView;
            if (rv == null) return;

            string productID = rv["ProductID"].ToString();
            decimal orderQty = Convert.ToDecimal(rv["Quantity"]);

            // Query BOM: ProductMaterial JOIN RawMaterial
            string query = @"
                SELECT pm.MaterialID,
                       rm.MaterialName,
                       rm.Unit,
                       rm.StockQty,
                       pm.QuantityPerUnit
                FROM ProductMaterial pm
                JOIN RawMaterial rm ON pm.MaterialID = rm.MaterialID
                WHERE pm.ProductID = @pid
                ORDER BY pm.MaterialID";

            try
            {
                DataTable bomTable = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pid", productID);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(bomTable);
                }

                if (bomTable.Rows.Count == 0)
                {
                    MessageBox.Show("No BOM defined for this product. Please add materials manually.",
                        "No BOM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Clear existing list and fill from BOM
                lvMaterials.Items.Clear();

                foreach (DataRow row in bomTable.Rows)
                {
                    string materialID = row["MaterialID"].ToString();
                    string materialName = row["MaterialName"].ToString();
                    string unit = row["Unit"].ToString();
                    decimal qtyPerUnit = Convert.ToDecimal(row["QuantityPerUnit"]);
                    decimal totalQty = qtyPerUnit * orderQty;
                    decimal stock = 0m;
                    if (row["StockQty"] != DBNull.Value)
                        stock = Convert.ToDecimal(row["StockQty"]);

                    ListViewItem item = new ListViewItem(materialID);
                    item.SubItems.Add(materialName);
                    item.SubItems.Add(totalQty.ToString("F2"));
                    item.SubItems.Add(unit);
                    item.SubItems.Add(stock.ToString("F2") + " " + unit);
                    item.SubItems.Add("BOM");

                    // Color-code stock: red if insufficient
                    if (stock < totalQty)
                        item.SubItems[4].ForeColor = Color.FromArgb(180, 30, 30);
                    else
                        item.SubItems[4].ForeColor = Color.FromArgb(56, 110, 60);

                    lvMaterials.Items.Add(item);
                }

                MessageBox.Show($"Loaded {bomTable.Rows.Count} materials from BOM.\n" +
                                $"(QuantityPerUnit × OrderQty {orderQty})",
                    "BOM Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading BOM: " + ex.Message);
            }
        }

        // ================================================================
        // MANUAL ADD ROW
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

            DataRowView rv = cmbMaterial.SelectedItem as DataRowView;
            if (rv == null) return;

            string materialID = cmbMaterial.SelectedValue.ToString();
            string materialName = rv["MaterialName"].ToString();
            string unit = rv["Unit"].ToString();
            decimal qty = nudQuantity.Value;
            decimal stock = 0m;
            if (rv["StockQty"] != DBNull.Value)
                stock = Convert.ToDecimal(rv["StockQty"]);

            // Prevent duplicates
            foreach (ListViewItem existing in lvMaterials.Items)
            {
                if (existing.Text == materialID)
                {
                    MessageBox.Show("This material is already in the list.",
                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            ListViewItem item = new ListViewItem(materialID);
            item.SubItems.Add(materialName);
            item.SubItems.Add(qty.ToString("F2"));
            item.SubItems.Add(unit);
            item.SubItems.Add(stock.ToString("F2") + " " + unit);
            item.SubItems.Add("Manual");

            if (stock < qty)
                item.SubItems[4].ForeColor = Color.FromArgb(180, 30, 30);
            else
                item.SubItems[4].ForeColor = Color.FromArgb(56, 110, 60);

            lvMaterials.Items.Add(item);

            // Reset input
            nudQuantity.Value = 1;
        }

        // ================================================================
        // REMOVE ROW — T3 btnDelete pattern: remove selected
        // ================================================================
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (lvMaterials.SelectedItems.Count > 0)
            {
                lvMaterials.Items.Remove(lvMaterials.SelectedItems[0]);
            }
        }

        // ================================================================
        // SUBMIT ALL — inserts 1 MaterialRequest header + N MaterialRequestItem rows
        // All items share the same Urgency, RequiredDate, RequestedBy, Remarks
        // ================================================================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (lvMaterials.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one material.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbUrgency.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an urgency level.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpRequiredDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Required Delivery Date cannot be in the past.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Get OrderItemID (shared across all rows if selected)
            string orderItemID = cmbOrderItem.SelectedValue?.ToString() ?? "";

            // 3. Confirm (T3 style: YesNo dialog)
            var confirm = MessageBox.Show(
                "Submit " + lvMaterials.Items.Count + " material(s) in one request?\n\n" +
                "Urgency: " + cmbUrgency.SelectedItem + "\n" +
                "Required Date: " + dtpRequiredDate.Value.ToString("yyyy-MM-dd"),
                "Confirm Submit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // 4. Collect common values
            string urgency = cmbUrgency.SelectedItem.ToString();
            string requiredDate = dtpRequiredDate.Value.ToString("yyyy-MM-dd");
            string requestedBy = txtReqByID.Text.Trim();
            string remarks = txtRemarks.Text.Trim();

            // 5. INSERT header + items (transactional — all or nothing)
            string insertHeader = @"
                INSERT INTO MaterialRequest
                    (OrderItemID, UrgencyLevel, RequiredDeliveryDate,
                     RequestedBy, Status, Remarks)
                VALUES
                    (@oi, @urg, @rdd, @rb, 'Requested', @rem)";

            string insertItem = @"
                INSERT INTO MaterialRequestItem
                    (RequestID, MaterialID, Quantity, Unit, Remarks)
                VALUES
                    (@rid, @mid, @qty, @unit, NULL)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        // Step 1: Insert header
                        MySqlCommand cmdHeader = new MySqlCommand(insertHeader, conn, trans);
                        cmdHeader.Parameters.AddWithValue("@oi",
                            string.IsNullOrEmpty(orderItemID) ? (object)DBNull.Value : orderItemID);
                        cmdHeader.Parameters.AddWithValue("@urg", urgency);
                        cmdHeader.Parameters.AddWithValue("@rdd", requiredDate);
                        cmdHeader.Parameters.AddWithValue("@rb", requestedBy);
                        cmdHeader.Parameters.AddWithValue("@rem",
                            string.IsNullOrEmpty(remarks) ? (object)DBNull.Value : remarks);
                        cmdHeader.ExecuteNonQuery();

                        // Step 2: Retrieve auto-generated RequestID (trigger format: MR-NNNN)
                        string actualRequestID;
                        string getIdQuery = @"
                            SELECT RequestID FROM MaterialRequest
                            WHERE RequestedBy = @rb
                            ORDER BY RequestDate DESC LIMIT 1";
                        MySqlCommand cmdGetId = new MySqlCommand(getIdQuery, conn, trans);
                        cmdGetId.Parameters.AddWithValue("@rb", requestedBy);
                        actualRequestID = cmdGetId.ExecuteScalar()?.ToString();
                        if (string.IsNullOrEmpty(actualRequestID))
                            throw new Exception("Failed to retrieve generated RequestID.");

                        txtRequestID.Text = actualRequestID;

                        // Step 3: Insert each item
                        int itemCount = 0;
                        foreach (ListViewItem item in lvMaterials.Items)
                        {
                            string materialID = item.Text;
                            decimal qty = Convert.ToDecimal(item.SubItems[2].Text);
                            string unit = item.SubItems[3].Text;

                            MySqlCommand cmdItem = new MySqlCommand(insertItem, conn, trans);
                            cmdItem.Parameters.AddWithValue("@rid", actualRequestID);
                            cmdItem.Parameters.AddWithValue("@mid", materialID);
                            cmdItem.Parameters.AddWithValue("@qty", qty);
                            cmdItem.Parameters.AddWithValue("@unit", unit);
                            cmdItem.ExecuteNonQuery();
                            itemCount++;
                        }

                        trans.Commit();

                        MessageBox.Show(
                            "Request " + actualRequestID + " submitted with " + itemCount + " material(s).",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form (T3 style: clear after success)
                        ClearForm();
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
            }
        }

        // ================================================================
        // CLEAR — T3 style: reset all fields
        // ================================================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            lvMaterials.Items.Clear();
            txtRemarks.Clear();
            cmbUrgency.SelectedIndex = 1; // Medium
            dtpRequiredDate.Value = DateTime.Today.AddDays(3);
            nudQuantity.Value = 1;
            txtRequestID.Text = "(auto on save)";
            txtRequestDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            if (cmbOrderFilter.Items.Count > 0) cmbOrderFilter.SelectedIndex = 0;
            if (cmbMaterial.Items.Count > 0) cmbMaterial.SelectedIndex = 0;
        }
    }
}
