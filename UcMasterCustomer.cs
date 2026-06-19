using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterCustomer : UserControl
    {
        public UcMasterCustomer()
        {
            InitializeComponent();
        }

        private void UcMasterCustomer_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadCustomers();
            ClearFields();
        }

        private void SetupListView()
        {
            lvCustomers.Columns.Clear();
            lvCustomers.Columns.Add("CustomerID", 90);
            lvCustomers.Columns.Add("CustomerName", 180);
            lvCustomers.Columns.Add("Type", 60);
            lvCustomers.Columns.Add("Phone", 120);
            lvCustomers.Columns.Add("Email", 180);
            lvCustomers.Columns.Add("Address", 200);
        }

        private void LoadCustomers()
        {
            try
            {
                lvCustomers.Items.Clear();
                string query = @"SELECT CustomerID, CustomerName, CustomerType, Phone, Email, Address 
                                 FROM Customer ORDER BY CustomerID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["CustomerType"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Email"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Address"]?.ToString() ?? "");
                        lvCustomers.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCustomers.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                cmbType.Text = item.SubItems[2].Text;
                txtPhone.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;
                txtAddress.Text = item.SubItems[5].Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Customer Name is required.");
                return;
            }
            if (cmbType.SelectedIndex < 0)
            {
                MessageBox.Show("Customer Type is required.");
                return;
            }

            try
            {
                string query = @"INSERT INTO Customer (CustomerType, CustomerName, Phone, Email, Address) 
                                 VALUES (@type, @name, @phone, @email, @address)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@type", cmbType.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Customer added successfully.");
                }
                LoadCustomers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Customer Name is required.");
                return;
            }

            try
            {
                string query = @"UPDATE Customer SET CustomerType = @type, CustomerName = @name, 
                                 Phone = @phone, Email = @email, Address = @address 
                                 WHERE CustomerID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@type", cmbType.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Customer updated successfully.");
                }
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this customer?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string query = "DELETE FROM Customer WHERE CustomerID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Customer deleted successfully.");
                }
                LoadCustomers();
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
            txtAddress.Clear();
            cmbType.SelectedIndex = -1;
            lvCustomers.SelectedItems.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadCustomers();
                return;
            }

            try
            {
                lvCustomers.Items.Clear();
                string query = @"SELECT CustomerID, CustomerName, CustomerType, Phone, Email, Address 
                                 FROM Customer 
                                 WHERE CustomerID LIKE @kw OR CustomerName LIKE @kw OR Phone LIKE @kw OR Email LIKE @kw
                                 ORDER BY CustomerID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["CustomerType"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Email"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Address"]?.ToString() ?? "");
                        lvCustomers.Items.Add(item);
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
