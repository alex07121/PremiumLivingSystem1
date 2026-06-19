using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{
  
    public partial class EditOrderForm : MaterialForm
    {
        public EditOrderForm()
        {
            InitializeComponent();

           
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,       
                Primary.Green900,
                Primary.Green500,
                Accent.LightGreen200,
                TextShade.WHITE
            );
        }

        private void EditOrderForm_Load(object sender, EventArgs e)
        {
            // Set up ListView
            dgvItems.View = View.Details;
            dgvItems.FullRowSelect = true;
            dgvItems.GridLines = true;
            dgvItems.MultiSelect = false;
            dgvItems.Columns.Add("OrderItemID", 120);
            dgvItems.Columns.Add("Product Name", 200);
            dgvItems.Columns.Add("ProductID", 120);
            dgvItems.Columns.Add("Quantity", 80);
            dgvItems.Columns.Add("Unit Price", 100);
            dgvItems.Columns.Add("Item Type", 100);
            dgvItems.Columns.Add("Custom Status", 120);
            FillCategory();
        }

        private void FillCategory()
        {
            string query = @"SELECT CategoryID, CategoryName, CONCAT(CategoryID, ' - ', CategoryName) AS DisplayText FROM productcategory ORDER BY CategoryID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    adapter.Fill(dt);
                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "DisplayText";
                    cmbCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProduct();
        }

        private void FillProduct()
        {
            if (cmbCategory.SelectedValue == null) return;
            string query = @"SELECT ProductID, ProductName, UnitPrice, CONCAT(ProductID, ' - ', ProductName) AS DisplayText FROM Product WHERE Stock > 0 AND CategoryID = @catId ORDER BY ProductID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@catId", cmbCategory.SelectedValue.ToString());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    adapter.Fill(dt);
                    cmbProduct.DataSource = dt;
                    cmbProduct.DisplayMember = "DisplayText";
                    cmbProduct.ValueMember = "ProductID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadOrderItems(string orderId)
        {
            string query = @"
                SELECT oi.OrderItemID, p.ProductName, oi.ProductID, oi.Quantity, oi.UnitPrice, oi.ItemType, oi.CustomStatus 
                FROM OrderItem oi 
                JOIN Product p ON oi.ProductID = p.ProductID 
                WHERE oi.OrderID = @orderId";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    conn.Open();

                    dgvItems.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderItemID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["UnitPrice"].ToString());
                        item.SubItems.Add(reader["ItemType"].ToString());
                        item.SubItems.Add(reader["CustomStatus"].ToString());
                        dgvItems.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public void LoadOrderData(string orderId)
        {
            string query = "SELECT * FROM `Order` WHERE OrderID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtOrderID.Text = reader["OrderID"].ToString();
                        txtCustomerID.Text = reader["CustomerID"].ToString();
                        txtSalesStaffID.Text = reader["SalesStaffID"].ToString();

                        if (DateTime.TryParse(reader["OrderDate"].ToString(), out DateTime orderDate))
                            txtOrderDate.Text = orderDate.ToString("yyyy-MM-dd");

                        if (reader["RequiredDate"] != DBNull.Value && DateTime.TryParse(reader["RequiredDate"].ToString(), out DateTime reqDate))
                            dtpRequiredDate.Value = reqDate;

                        string status = reader["Status"].ToString();
                        if (cboStatus.Items.Contains(status))
                            cboStatus.SelectedItem = status;
                    }
                    reader.Close();
                }
                LoadOrderItems(orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE `Order` SET  
                    RequiredDate = @requiredDate, 
                    Status = @status 
                    WHERE OrderID = @id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@requiredDate", dtpRequiredDate.Value.Date);
                    cmd.Parameters.AddWithValue("@status", cboStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", txtOrderID.Text.Trim());

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order updated successfully!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddOrderItem("Standard", "NotRequired");
        }

        private void btnAddCustomProduct_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null) return;
            DataRowView drv = (DataRowView)cmbProduct.SelectedItem;
            decimal basePrice = Convert.ToDecimal(drv["UnitPrice"]);

            frmCustomization customForm = new frmCustomization(basePrice);
            if (customForm.ShowDialog() == DialogResult.OK)
            {
                AddOrderItem("Custom", "Draft", customForm.FinalCustomPrice, customForm.CustomData);
            }
        }

        private void AddOrderItem(string itemType, string customStatus, decimal? customPrice = null, CustomDetailsDTO customDetails = null)
        {
            if (cmbProduct.SelectedValue == null) return;
            if (!int.TryParse(numQuantity.Value.ToString(), out int qty) || qty <= 0)

            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            string query = "INSERT INTO OrderItem (OrderID, ProductID, Quantity, UnitPrice, ItemType, CustomStatus) VALUES (@orderId, @prodId, @qty, @price, @itemType, @status)";
            string getIdQuery = "SELECT OrderItemID FROM OrderItem ORDER BY OrderItemID DESC LIMIT 1";
            string insertCustomQuery = @"INSERT INTO OrderItemCustomization 
                (OrderItemID, DimensionL, DimensionW, DimensionH, Material, Color, FinishType, CustomDescription) 
                VALUES (@itemId, @dimL, @dimW, @dimH, @mat, @color, @fin, @desc)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    DataRowView drv = (DataRowView)cmbProduct.SelectedItem;
                    decimal unitPrice = customPrice ?? Convert.ToDecimal(drv["UnitPrice"]);

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", txtOrderID.Text.Trim());
                    cmd.Parameters.AddWithValue("@prodId", cmbProduct.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@price", unitPrice);
                    cmd.Parameters.AddWithValue("@itemType", itemType);
                    cmd.Parameters.AddWithValue("@status", customStatus);

                    // Prepare customization command if needed
                    MySqlCommand insertCustomCmd = null;
                    if (customDetails != null)
                    {
                        insertCustomCmd = new MySqlCommand(insertCustomQuery, conn);
                        insertCustomCmd.Parameters.AddWithValue("@dimL", customDetails.DimensionL);
                        insertCustomCmd.Parameters.AddWithValue("@dimW", customDetails.DimensionW);
                        insertCustomCmd.Parameters.AddWithValue("@dimH", customDetails.DimensionH);
                        insertCustomCmd.Parameters.AddWithValue("@mat", customDetails.Material);
                        insertCustomCmd.Parameters.AddWithValue("@color", customDetails.Color);
                        insertCustomCmd.Parameters.AddWithValue("@fin", customDetails.FinishType);
                        insertCustomCmd.Parameters.AddWithValue("@desc", customDetails.CustomDescription);
                    }

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (customDetails != null)
                        {
                            MySqlCommand getIdCmd = new MySqlCommand(getIdQuery, conn);
                            var newItemId = getIdCmd.ExecuteScalar()?.ToString();

                            insertCustomCmd.Parameters.AddWithValue("@itemId", newItemId);
                            int customRowsAffected = insertCustomCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Product added!");
                        LoadOrderItems(txtOrderID.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedItems.Count == 0) return;
            string oiId = dgvItems.SelectedItems[0].Text;

            var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string deleteCustQuery = "DELETE FROM OrderItemCustomization WHERE OrderItemID = @orderId";
            string deleteItemQuery = "DELETE FROM OrderItem WHERE OrderItemID = @orderId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmdCust = new MySqlCommand(deleteCustQuery, conn);
                    cmdCust.Parameters.AddWithValue("@orderId", oiId);

                    MySqlCommand cmd = new MySqlCommand(deleteItemQuery, conn);
                    cmd.Parameters.AddWithValue("@orderId", oiId);

                    conn.Open();
                    cmdCust.ExecuteNonQuery();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product deleted!");
                        LoadOrderItems(txtOrderID.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }
    }
}
