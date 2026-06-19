using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcRecordInwardGoods : UserControl
    {
        public UcRecordInwardGoods()
        {
            InitializeComponent();
        }

        private void UcRecordInwardGoods_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadSuppliers();
        }

        private void SetupDataGridView()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("colMaterialID", "Material ID");
            dgvItems.Columns.Add("colMaterialName", "Material Name");
            dgvItems.Columns.Add("colQty", "Quantity");
            dgvItems.Columns.Add("colUnit", "Unit");
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSuppliers()
        {
            try
            {
                string query = "SELECT SupplierID, SupplierName, CONCAT(SupplierID, ' - ', SupplierName) AS DisplayText FROM Supplier ORDER BY SupplierID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    cmbSupplier.DisplayMember = "DisplayText";   
                    cmbSupplier.ValueMember = "SupplierID";      
                    cmbSupplier.DataSource = dt;                
                }
                LoadMaterials();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadMaterials()
        {
            if (cmbSupplier.SelectedValue == null) return;

            try
            {
                string query = "SELECT MaterialID, MaterialName, Unit, CONCAT(MaterialID, ' - ', MaterialName) AS DisplayText FROM RawMaterial WHERE SupplierID = @supplierId ORDER BY MaterialID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@supplierId", cmbSupplier.SelectedValue);
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);   
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbMaterial.DataSource = dt;
                    cmbMaterial.DisplayMember = "DisplayText";
                    cmbMaterial.ValueMember = "MaterialID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
                LoadMaterials();
        }


        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null || cmbMaterial.SelectedItem == null) return;

            var rowView = cmbMaterial.SelectedItem as DataRowView;
            if (rowView == null) return;

            string materialId = cmbMaterial.SelectedValue.ToString();
            string materialName = rowView["MaterialName"].ToString();
            string unit = rowView["Unit"].ToString();
            decimal qty = nudQty.Value;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["colMaterialID"].Value?.ToString() == materialId)
                {
                    MessageBox.Show("This material is already in the list.");
                    return;
                }
            }

            dgvItems.Rows.Add(materialId, materialName, qty, unit);
            nudQty.Value = 1;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItems.SelectedRows)
                    dgvItems.Rows.Remove(row);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one material.");
                return;
            }

            string sqlInsert = "INSERT INTO RawMaterialMovement (MaterialID, MovementType, Quantity, RecordedBy) VALUES (@mid, 'Inbound', @qty, @staff)";
            string sqlUpdate = "UPDATE RawMaterial SET StockQty = StockQty + @qty WHERE MaterialID = @mid";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlTransaction trans = null;
                    try
                    {
                        conn.Open();
                        trans = conn.BeginTransaction();

                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            string materialId = row.Cells["colMaterialID"].Value.ToString();
                            decimal qty = Convert.ToDecimal(row.Cells["colQty"].Value);

                            MySqlCommand cmd1 = new MySqlCommand(sqlInsert, conn, trans);
                            cmd1.Parameters.AddWithValue("@mid", materialId);
                            cmd1.Parameters.AddWithValue("@qty", qty);
                            cmd1.Parameters.AddWithValue("@staff", UserSession.CurrentStaffId ?? "S-007");
                            int rows1 = cmd1.ExecuteNonQuery();

                            MySqlCommand cmd2 = new MySqlCommand(sqlUpdate, conn, trans);
                            cmd2.Parameters.AddWithValue("@qty", qty);
                            cmd2.Parameters.AddWithValue("@mid", materialId);
                            int rows2 = cmd2.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show($"{dgvItems.Rows.Count} materials recorded successfully.");
                        dgvItems.Rows.Clear();
                    }
                    catch
                    {
                        if (trans != null) trans.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedItem is DataRowView row)
                txtUnit.Text = row["Unit"].ToString();
        }


    }
}
