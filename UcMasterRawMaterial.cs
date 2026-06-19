using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterRawMaterial : UserControl
    {
        public UcMasterRawMaterial()
        {
            InitializeComponent();
        }

        private void UcMasterRawMaterial_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadSuppliers();
            LoadMaterials();
            ClearFields();

            // Position lblPrice + txtPrice to the right of lblReorder + txtReorder
            // (other controls use .resx layout, so we position at runtime)
            lblPrice.Location = new System.Drawing.Point(
                lblReorder.Location.X + lblReorder.Width + 80,
                lblReorder.Location.Y);
            txtPrice.Location = new System.Drawing.Point(
                txtReorder.Location.X + txtReorder.Width + 30,
                txtReorder.Location.Y);
        }

        private void SetupListView()
        {
            lvMaterials.Columns.Clear();
            lvMaterials.Columns.Add("MaterialID", 90);
            lvMaterials.Columns.Add("MaterialName", 180);
            lvMaterials.Columns.Add("Supplier", 150);
            lvMaterials.Columns.Add("Unit", 60);
            lvMaterials.Columns.Add("StockQty", 80);
            lvMaterials.Columns.Add("ReorderLvl", 80);
            lvMaterials.Columns.Add("Price", 90);
        }

        private void LoadSuppliers()
        {
            try
            {
                cmbSupplier.Items.Clear();
                string query = "SELECT SupplierID, SupplierName FROM Supplier ORDER BY SupplierName";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbSupplier.Items.Add(new { Text = reader["SupplierName"].ToString(), Value = reader["SupplierID"].ToString() });
                    }
                    reader.Close();
                }
                cmbSupplier.DisplayMember = "Text";
                cmbSupplier.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadMaterials()
        {
            try
            {
                lvMaterials.Items.Clear();
                string query = @"SELECT rm.MaterialID, rm.MaterialName, s.SupplierName, rm.Unit, rm.StockQty, rm.ReorderLevel, rm.UnitPurchasePrice
                                 FROM RawMaterial rm
                                 LEFT JOIN Supplier s ON rm.SupplierID = s.SupplierID
                                 ORDER BY rm.MaterialID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaterialID"].ToString());
                        item.SubItems.Add(reader["MaterialName"].ToString());
                        item.SubItems.Add(reader["SupplierName"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Unit"]?.ToString() ?? "");
                        item.SubItems.Add(reader["StockQty"]?.ToString() ?? "0");
                        item.SubItems.Add(reader["ReorderLevel"]?.ToString() ?? "0");
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPurchasePrice"]).ToString("F2"));
                        lvMaterials.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMaterials.SelectedItems.Count > 0)
            {
                ListViewItem item = lvMaterials.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtUnit.Text = item.SubItems[3].Text;
                txtStockQty.Text = item.SubItems[4].Text;
                txtReorder.Text = item.SubItems[5].Text;
                txtPrice.Text = item.SubItems[6].Text;

                string supName = item.SubItems[2].Text;
                for (int i = 0; i < cmbSupplier.Items.Count; i++)
                {
                    dynamic supItem = cmbSupplier.Items[i];
                    if (supItem.Text == supName)
                    {
                        cmbSupplier.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private string GetSelectedSupplierID()
        {
            if (cmbSupplier.SelectedItem != null)
            {
                dynamic selected = cmbSupplier.SelectedItem;
                return selected.Value;
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Material Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Unit is required.");
                return;
            }

            try
            {
                string query = @"INSERT INTO RawMaterial (SupplierID, MaterialName, Unit, StockQty, ReorderLevel, UnitPurchasePrice)
                                 VALUES (@supId, @name, @unit, @qty, @reorder, @price)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@supId", (object)GetSelectedSupplierID() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@qty", decimal.TryParse(txtStockQty.Text.Trim(), out decimal q) ? q : 0);
                    cmd.Parameters.AddWithValue("@reorder", decimal.TryParse(txtReorder.Text.Trim(), out decimal r) ? r : 0);
                    cmd.Parameters.AddWithValue("@price", decimal.TryParse(txtPrice.Text.Trim(), out decimal p) ? p : 0);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Raw material added successfully.");
                }
                LoadMaterials();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvMaterials.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a raw material to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Material Name is required.");
                return;
            }

            try
            {
                string query = @"UPDATE RawMaterial SET SupplierID = @supId, MaterialName = @name, Unit = @unit,
                                 StockQty = @qty, ReorderLevel = @reorder, UnitPurchasePrice = @price WHERE MaterialID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@supId", (object)GetSelectedSupplierID() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@qty", decimal.TryParse(txtStockQty.Text.Trim(), out decimal q) ? q : 0);
                    cmd.Parameters.AddWithValue("@reorder", decimal.TryParse(txtReorder.Text.Trim(), out decimal r) ? r : 0);
                    cmd.Parameters.AddWithValue("@price", decimal.TryParse(txtPrice.Text.Trim(), out decimal p) ? p : 0);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Raw material updated successfully.");
                }
                LoadMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtUnit.Clear();
            txtStockQty.Clear();
            txtReorder.Clear();
            txtPrice.Clear();
            cmbSupplier.SelectedIndex = -1;
            lvMaterials.SelectedItems.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadMaterials();
                return;
            }

            try
            {
                lvMaterials.Items.Clear();
                string query = @"SELECT rm.MaterialID, rm.MaterialName, s.SupplierName, rm.Unit, rm.StockQty, rm.ReorderLevel, rm.UnitPurchasePrice
                                 FROM RawMaterial rm
                                 LEFT JOIN Supplier s ON rm.SupplierID = s.SupplierID
                                 WHERE rm.MaterialID LIKE @kw OR rm.MaterialName LIKE @kw OR s.SupplierName LIKE @kw
                                 ORDER BY rm.MaterialID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaterialID"].ToString());
                        item.SubItems.Add(reader["MaterialName"].ToString());
                        item.SubItems.Add(reader["SupplierName"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Unit"]?.ToString() ?? "");
                        item.SubItems.Add(reader["StockQty"]?.ToString() ?? "0");
                        item.SubItems.Add(reader["ReorderLevel"]?.ToString() ?? "0");
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPurchasePrice"]).ToString("F2"));
                        lvMaterials.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
    }
}
