using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterProduct : UserControl
    {
        public UcMasterProduct()
        {
            InitializeComponent();
        }

        private void UcMasterProduct_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadCategories();
            LoadProducts();
            ClearFields();
        }

        private void SetupListView()
        {
            lvProducts.Columns.Clear();
            lvProducts.Columns.Add("ProductID", 80);
            lvProducts.Columns.Add("ProductName", 200);
            lvProducts.Columns.Add("Category", 120);
            lvProducts.Columns.Add("UnitPrice", 80);
            lvProducts.Columns.Add("Stock", 60);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            string query = "SELECT CategoryID, CategoryName FROM ProductCategory ORDER BY CategoryName";
            using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategory.Items.Add(new { Text = reader["CategoryName"].ToString(), Value = reader["CategoryID"].ToString() });
                }
                reader.Close();
            }
            cmbCategory.DisplayMember = "Text";
            cmbCategory.ValueMember = "Value";
        }

        private void LoadProducts()
        {
            try
            {
                lvProducts.Items.Clear();
                string query = @"SELECT p.ProductID, p.ProductName, pc.CategoryName, p.UnitPrice, p.Stock 
                                 FROM Product p 
                                 LEFT JOIN ProductCategory pc ON p.CategoryID = pc.CategoryID 
                                 ORDER BY p.ProductID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["CategoryName"]?.ToString() ?? "");
                        item.SubItems.Add(reader["UnitPrice"]?.ToString() ?? "0.00");
                        item.SubItems.Add(reader["Stock"]?.ToString() ?? "0");
                        lvProducts.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                ListViewItem item = lvProducts.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtPrice.Text = item.SubItems[3].Text;
                txtStock.Text = item.SubItems[4].Text;

                string catName = item.SubItems[2].Text;
                for (int i = 0; i < cmbCategory.Items.Count; i++)
                {
                    dynamic catItem = cmbCategory.Items[i];
                    if (catItem.Text == catName)
                    {
                        cmbCategory.SelectedIndex = i;
                        break;
                    }
                }

                // Load product image
                LoadProductImage(txtID.Text);
            }
        }

        /// <summary>
        /// Load the ProductImage from database and display in PictureBox.
        /// </summary>
        private void LoadProductImage(string productId)
        {
            // Dispose previous image to prevent memory leaks
            if (pbProductImage.Image != null)
            {
                pbProductImage.Image.Dispose();
                pbProductImage.Image = null;
            }

            try
            {
                string query = "SELECT ProductImage FROM Product WHERE ProductID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbProductImage.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Don't crash the app; just clear the image and optionally log
                if (pbProductImage.Image != null)
                {
                    pbProductImage.Image.Dispose();
                    pbProductImage.Image = null;
                }
                System.Diagnostics.Debug.WriteLine("Error loading product image: " + ex.Message);
            }
        }

        /// <summary>
        /// Upload an image for the currently selected product.
        /// </summary>
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    string query = "UPDATE Product SET ProductImage = @image WHERE ProductID = @id";
                    using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@image", imageBytes);
                        cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            MessageBox.Show("Image uploaded successfully.");
                    }

                    // Reload the image into PictureBox
                    LoadProductImage(txtID.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating record: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Click on the PictureBox to view the image in full size.
        /// </summary>
        private void pbProductImage_Click(object sender, EventArgs e)
        {
            if (pbProductImage.Image != null)
            {
                // Show the image in a new form for full-size viewing
                using (Form imageForm = new Form())
                {
                    imageForm.Text = "Product Image - " + txtID.Text;
                    imageForm.StartPosition = FormStartPosition.CenterParent;
                    imageForm.Size = new Size(600, 600);

                    PictureBox fullImage = new PictureBox
                    {
                        Image = new Bitmap(pbProductImage.Image),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Fill
                    };
                    imageForm.Controls.Add(fullImage);
                    imageForm.ShowDialog();
                    fullImage.Image?.Dispose();
                }
            }
        }

        private string GetSelectedCategoryID()
        {
            if (cmbCategory.SelectedItem != null)
            {
                dynamic selected = cmbCategory.SelectedItem;
                return selected.Value;
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required.");
                return;
            }

            try
            {
                string query = @"INSERT INTO Product (ProductName, CategoryID, UnitPrice, Stock) 
                                 VALUES (@name, @catId, @price, @stock)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@catId", (object)GetSelectedCategoryID() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", decimal.TryParse(txtPrice.Text.Trim(), out decimal p) ? p : 0);
                    cmd.Parameters.AddWithValue("@stock", int.TryParse(txtStock.Text.Trim(), out int s) ? s : 0);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Product added successfully.");
                }
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required.");
                return;
            }

            try
            {
                string query = @"UPDATE Product SET ProductName = @name, CategoryID = @catId, 
                                 UnitPrice = @price, Stock = @stock WHERE ProductID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@catId", (object)GetSelectedCategoryID() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@price", decimal.TryParse(txtPrice.Text.Trim(), out decimal p) ? p : 0);
                    cmd.Parameters.AddWithValue("@stock", int.TryParse(txtStock.Text.Trim(), out int s) ? s : 0);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Product updated successfully.");
                }
                LoadProducts();
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
            txtPrice.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
            lvProducts.SelectedItems.Clear();

            // Clear image
            if (pbProductImage.Image != null)
            {
                pbProductImage.Image.Dispose();
                pbProductImage.Image = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts();
                return;
            }

            try
            {
                lvProducts.Items.Clear();
                string query = @"SELECT p.ProductID, p.ProductName, pc.CategoryName, p.UnitPrice, p.Stock 
                                 FROM Product p 
                                 LEFT JOIN ProductCategory pc ON p.CategoryID = pc.CategoryID 
                                 WHERE p.ProductID LIKE @kw OR p.ProductName LIKE @kw OR pc.CategoryName LIKE @kw
                                 ORDER BY p.ProductID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["CategoryName"]?.ToString() ?? "");
                        item.SubItems.Add(reader["UnitPrice"]?.ToString() ?? "0.00");
                        item.SubItems.Add(reader["Stock"]?.ToString() ?? "0");
                        lvProducts.Items.Add(item);
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
