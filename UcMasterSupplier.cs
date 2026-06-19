using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterSupplier : UserControl
    {
        public UcMasterSupplier()
        {
            InitializeComponent();
        }

        private void UcMasterSupplier_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadSuppliers();
            ClearFields();
        }

        private void SetupListView()
        {
            lvSuppliers.Columns.Clear();
            lvSuppliers.Columns.Add("SupplierID", 100);
            lvSuppliers.Columns.Add("SupplierName", 200);
            lvSuppliers.Columns.Add("Phone", 120);
            lvSuppliers.Columns.Add("Email", 200);
        }

        private void LoadSuppliers()
        {
            try
            {
                lvSuppliers.Items.Clear();
                string query = "SELECT SupplierID, SupplierName, Phone, Email FROM Supplier ORDER BY SupplierID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["SupplierID"].ToString());
                        item.SubItems.Add(reader["SupplierName"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Email"]?.ToString() ?? "");
                        lvSuppliers.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSuppliers.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Supplier Name is required.");
                return;
            }

            try
            {
                string query = @"INSERT INTO Supplier (SupplierName, Phone, Email) 
                                 VALUES (@name, @phone, @email)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Supplier added successfully.");
                }
                LoadSuppliers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Supplier Name is required.");
                return;
            }

            try
            {
                string query = @"UPDATE Supplier SET SupplierName = @name, Phone = @phone, Email = @email 
                                 WHERE SupplierID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Supplier updated successfully.");
                }
                LoadSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this supplier?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string query = "DELETE FROM Supplier WHERE SupplierID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Supplier deleted successfully.");
                }
                LoadSuppliers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
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
            txtPhone.Clear();
            txtEmail.Clear();
            lvSuppliers.SelectedItems.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadSuppliers();
                return;
            }

            try
            {
                lvSuppliers.Items.Clear();
                string query = @"SELECT SupplierID, SupplierName, Phone, Email FROM Supplier 
                                 WHERE SupplierID LIKE @kw OR SupplierName LIKE @kw OR Phone LIKE @kw OR Email LIKE @kw
                                 ORDER BY SupplierID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["SupplierID"].ToString());
                        item.SubItems.Add(reader["SupplierName"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Email"]?.ToString() ?? "");
                        lvSuppliers.Items.Add(item);
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
