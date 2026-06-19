using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterCategory : UserControl
    {
        public UcMasterCategory()
        {
            InitializeComponent();
        }

        private void UcMasterCategory_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadCategories();
            ClearFields();
        }

        private void SetupListView()
        {
            lvCategories.Columns.Clear();
            lvCategories.Columns.Add("CategoryID", 100);
            lvCategories.Columns.Add("CategoryName", 200);
            lvCategories.Columns.Add("Description", 300);
        }

        private void LoadCategories()
        {
            try
            {
                lvCategories.Items.Clear();
                string query = "SELECT CategoryID, CategoryName, Description FROM ProductCategory ORDER BY CategoryID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CategoryID"].ToString());
                        item.SubItems.Add(reader["CategoryName"].ToString());
                        item.SubItems.Add(reader["Description"]?.ToString() ?? "");
                        lvCategories.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategories.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCategories.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtDescription.Text = item.SubItems[2].Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Category Name is required.");
                return;
            }

            try
            {
                string query = @"INSERT INTO ProductCategory (CategoryName, Description) 
                                 VALUES (@name, @desc)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Category added successfully.");
                }
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvCategories.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a category to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Category Name is required.");
                return;
            }

            try
            {
                string query = @"UPDATE ProductCategory SET CategoryName = @name, Description = @desc 
                                 WHERE CategoryID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Category updated successfully.");
                }
                LoadCategories();
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
            txtDescription.Clear();
            lvCategories.SelectedItems.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadCategories();
                return;
            }

            try
            {
                lvCategories.Items.Clear();
                string query = @"SELECT CategoryID, CategoryName, Description FROM ProductCategory 
                                 WHERE CategoryID LIKE @kw OR CategoryName LIKE @kw OR Description LIKE @kw
                                 ORDER BY CategoryID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CategoryID"].ToString());
                        item.SubItems.Add(reader["CategoryName"].ToString());
                        item.SubItems.Add(reader["Description"]?.ToString() ?? "");
                        lvCategories.Items.Add(item);
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
