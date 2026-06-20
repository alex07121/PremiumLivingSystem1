using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class EditPruchaseOrder : Form
    {
        public string PurchaseOrderID { get; private set; }

        public EditPruchaseOrder(string poID)
        {
            InitializeComponent();
            PurchaseOrderID = poID;
        }

        private void EditPruchaseOrder_Load(object sender, EventArgs e)
        {
            SetupItemsListView();
            LoadPOData(PurchaseOrderID);
            LoadPOItems(PurchaseOrderID);
            LoadSuppliers();
            LoadMaterials();
        }

        private void SetupItemsListView()
        {
            lvItems.View = View.Details;
            lvItems.FullRowSelect = true;
            lvItems.GridLines = true;
            lvItems.MultiSelect = false;
            lvItems.Columns.Add("PO Item ID", 120);
            lvItems.Columns.Add("Material ID", 120);
            lvItems.Columns.Add("Material Name", 200);
            lvItems.Columns.Add("Quantity", 90);
            lvItems.Columns.Add("Unit", 70);
            lvItems.Columns.Add("Unit Price", 110);
            lvItems.Columns.Add("Line Total", 120);
            lvItems.Columns.Add("Received", 90);
        }

        private void LoadPOData(string poID)
        {
            string query = @"
                SELECT po.*, s.SupplierName
                FROM PurchaseOrder po
                JOIN Supplier s ON po.SupplierID = s.SupplierID
                WHERE po.PurchaseOrderID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", poID);
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtPurchaseOrderID.Text = reader["PurchaseOrderID"].ToString();
                        txtSupplierID.Text = reader["SupplierID"].ToString();
                        txtSupplierName.Text = reader["SupplierName"].ToString();

                        if (DateTime.TryParse(reader["OrderDate"].ToString(), out DateTime orderDate))
                            dtpOrderDate.Value = orderDate;

                        if (reader["ExpectedDeliveryDate"] != DBNull.Value &&
                            DateTime.TryParse(reader["ExpectedDeliveryDate"].ToString(), out DateTime expDate))
                            dtpExpectedDate.Value = expDate;

                        string status = reader["Status"].ToString();
                        if (cmbStatus.Items.Contains(status))
                            cmbStatus.SelectedItem = status;

                        string paymentStatus = reader["PaymentStatus"].ToString();
                        if (cmbPaymentStatus.Items.Contains(paymentStatus))
                            cmbPaymentStatus.SelectedItem = paymentStatus;

                        string paymentMethod = reader["PaymentMethod"] != DBNull.Value ? reader["PaymentMethod"].ToString() : "BankTransfer";
                        if (cmbPaymentMethod.Items.Contains(paymentMethod))
                            cmbPaymentMethod.SelectedItem = paymentMethod;

                        txtSubTotal.Text = Convert.ToDecimal(reader["SubTotal"]).ToString("F2");
                        txtTotal.Text = Convert.ToDecimal(reader["TotalAmount"]).ToString("F2");
                        txtRemarks.Text = reader["Remarks"] != DBNull.Value ? reader["Remarks"].ToString() : "";

                        // Disable editing if status is not Draft
                        if (status != "Draft")
                        {
                            cmbSupplier.Enabled = false;
                            cmbMaterial.Enabled = false;
                            nudQuantity.Enabled = false;
                            btnAddRow.Enabled = false;
                            btnRemoveRow.Enabled = false;
                            btnSave.Enabled = false;
                            btnSubmit.Enabled = false;
                            txtRemarks.ReadOnly = true;
                            dtpExpectedDate.Enabled = false;
                            cmbPaymentMethod.Enabled = false;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading PO data: " + ex.Message);
            }
        }

        private void LoadPOItems(string poID)
        {
            string query = @"
                SELECT poi.POItemID, poi.MaterialID, rm.MaterialName,
                       poi.Quantity, poi.Unit, poi.UnitPrice, poi.LineTotal, poi.ReceivedQty
                FROM PurchaseOrderItem poi
                JOIN RawMaterial rm ON poi.MaterialID = rm.MaterialID
                WHERE poi.PurchaseOrderID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", poID);
                    conn.Open();

                    lvItems.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["POItemID"].ToString());
                        item.SubItems.Add(reader["MaterialID"].ToString());
                        item.SubItems.Add(reader["MaterialName"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["Quantity"]).ToString("F2"));
                        item.SubItems.Add(reader["Unit"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPrice"]).ToString("F2"));
                        item.SubItems.Add(Convert.ToDecimal(reader["LineTotal"]).ToString("F2"));
                        item.SubItems.Add(Convert.ToDecimal(reader["ReceivedQty"]).ToString("F2"));
                        lvItems.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading PO items: " + ex.Message);
            }
        }

        private void LoadSuppliers()
        {
            string query = @"SELECT SupplierID, SupplierName FROM Supplier ORDER BY SupplierID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    cmbSupplier.DataSource = dt;
                    cmbSupplier.DisplayMember = "SupplierName";
                    cmbSupplier.ValueMember = "SupplierID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        private void LoadMaterials()
        {
            string query = @"SELECT MaterialID, MaterialName, Unit, UnitPurchasePrice FROM RawMaterial ORDER BY MaterialID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    cmbMaterial.DataSource = dt;
                    cmbMaterial.DisplayMember = "MaterialName";
                    cmbMaterial.ValueMember = "MaterialID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading materials: " + ex.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show("Please select a material.");
                return;
            }
            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            DataRowView row = cmbMaterial.SelectedItem as DataRowView;
            if (row == null) return;

            string materialID = cmbMaterial.SelectedValue.ToString();
            string materialName = row["MaterialName"].ToString();
            string unit = row["Unit"].ToString();
            decimal qty = nudQuantity.Value;
            decimal unitPrice = row["UnitPurchasePrice"] != DBNull.Value ? Convert.ToDecimal(row["UnitPurchasePrice"]) : 0;
            decimal lineTotal = qty * unitPrice;

            // Check for duplicates
            foreach (ListViewItem item in lvItems.Items)
            {
                if (item.SubItems[1].Text == materialID)
                {
                    MessageBox.Show("This material is already in the list.");
                    return;
                }
            }

            ListViewItem newItem = new ListViewItem("NEW");
            newItem.SubItems.Add(materialID);
            newItem.SubItems.Add(materialName);
            newItem.SubItems.Add(qty.ToString("F2"));
            newItem.SubItems.Add(unit);
            newItem.SubItems.Add(unitPrice.ToString("F2"));
            newItem.SubItems.Add(lineTotal.ToString("F2"));
            newItem.SubItems.Add("0.00");
            lvItems.Items.Add(newItem);

            RecalcTotals();
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                lvItems.Items.Remove(lvItems.SelectedItems[0]);
                RecalcTotals();
            }
        }

        private void RecalcTotals()
        {
            decimal subTotal = 0;
            foreach (ListViewItem item in lvItems.Items)
            {
                if (item.SubItems[6].Text != null)
                    subTotal += Convert.ToDecimal(item.SubItems[6].Text);
            }
            txtSubTotal.Text = subTotal.ToString("F2");
            txtTotal.Text = subTotal.ToString("F2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdatePO("Draft");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Submit this Purchase Order as 'Sent'?", "Confirm Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            UpdatePO("Sent");
        }

        private void UpdatePO(string status)
        {
            string updateHeader = @"
                UPDATE PurchaseOrder SET
                    ExpectedDeliveryDate = @edd,
                    Status = @status,
                    PaymentMethod = @pm,
                    SubTotal = @sub,
                    TaxAmount = 0,
                    TotalAmount = @total,
                    Remarks = @rem,
                    SentDate = @sentDate
                WHERE PurchaseOrderID = @id";

            string deleteItems = @"DELETE FROM PurchaseOrderItem WHERE PurchaseOrderID = @id";

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
                        // Update header
                        MySqlCommand cmdHeader = new MySqlCommand(updateHeader, conn, trans);
                        cmdHeader.Parameters.AddWithValue("@edd", dtpExpectedDate.Value.ToString("yyyy-MM-dd"));
                        cmdHeader.Parameters.AddWithValue("@status", status);
                        cmdHeader.Parameters.AddWithValue("@pm", cmbPaymentMethod.SelectedItem?.ToString() ?? "BankTransfer");
                        cmdHeader.Parameters.AddWithValue("@sub", Convert.ToDecimal(txtSubTotal.Text));
                        cmdHeader.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                        cmdHeader.Parameters.AddWithValue("@rem", string.IsNullOrEmpty(txtRemarks.Text) ? (object)DBNull.Value : txtRemarks.Text.Trim());
                        cmdHeader.Parameters.AddWithValue("@sentDate", status == "Sent" ? (object)DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : DBNull.Value);
                        cmdHeader.Parameters.AddWithValue("@id", PurchaseOrderID);
                        cmdHeader.ExecuteNonQuery();

                        // Delete existing items
                        MySqlCommand cmdDelete = new MySqlCommand(deleteItems, conn, trans);
                        cmdDelete.Parameters.AddWithValue("@id", PurchaseOrderID);
                        cmdDelete.ExecuteNonQuery();

                        // Insert new items
                        foreach (ListViewItem item in lvItems.Items)
                        {
                            string materialID = item.SubItems[1].Text;
                            decimal qty = Convert.ToDecimal(item.SubItems[3].Text);
                            string unit = item.SubItems[4].Text;
                            decimal unitPrice = Convert.ToDecimal(item.SubItems[5].Text);

                            MySqlCommand cmdItem = new MySqlCommand(insertItem, conn, trans);
                            cmdItem.Parameters.AddWithValue("@poid", PurchaseOrderID);
                            cmdItem.Parameters.AddWithValue("@mid", materialID);
                            cmdItem.Parameters.AddWithValue("@qty", qty);
                            cmdItem.Parameters.AddWithValue("@unit", unit);
                            cmdItem.Parameters.AddWithValue("@price", unitPrice);
                            cmdItem.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show($"Purchase Order updated successfully.\nStatus: {status}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
                MessageBox.Show("Error updating PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
