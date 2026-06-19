using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            // Set up ListView columns
            dataGridView1.View = View.Details;
            dataGridView1.FullRowSelect = true;
            dataGridView1.GridLines = true;
            dataGridView1.MultiSelect = false;

            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";
            dataGridView1.Columns.Add(isChinese ? "產品編號" : "ProductID", 120);
            dataGridView1.Columns.Add(isChinese ? "產品名稱" : "Product Name", 200);
            dataGridView1.Columns.Add(isChinese ? "產品分類" : "Category", 150);
            dataGridView1.Columns.Add(isChinese ? "單價" : "Unit Price", 100);
            dataGridView1.Columns.Add(isChinese ? "庫存數量" : "Stock Qty", 100);

            LoadProductComboBox();
            LoadAllProduct();
        }

        private void LoadAllProduct()
        {
            string query = @"SELECT p.ProductID, p.ProductName, c.CategoryName, p.UnitPrice, p.Stock 
                             FROM Product p 
                             LEFT JOIN ProductCategory c ON p.CategoryID = c.CategoryID 
                             ORDER BY p.ProductID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();

                    dataGridView1.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["CategoryName"]?.ToString() ?? "");
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPrice"]).ToString("C2"));
                        item.SubItems.Add(reader["Stock"].ToString());
                        dataGridView1.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadProductComboBox()
        {
            string query = "SELECT ProductID, ProductName FROM Product ORDER BY ProductID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    ProductID.DataSource = dt;
                    ProductID.DisplayMember = "ProductName";
                    ProductID.ValueMember = "ProductID";
                    ProductID.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void ExecuteStockAdjustment(string actionType, int qty)
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";

            if (ProductID.SelectedValue == null)
            {
                MessageBox.Show(isChinese ? "請先選擇一項產品！" : "Please select a product first.");
                return;
            }

            if (qty <= 0)
            {
                MessageBox.Show(isChinese ? "數量必須大於 0！" : "Quantity must be greater than 0.");
                return;
            }

            string prodId = ProductID.SelectedValue.ToString();
            string sqlOperator = (actionType == "Add") ? "+" : "-";

            string checkQuery = "SELECT Stock FROM Product WHERE ProductID = @prodId";
            string updateQuery = $"UPDATE Product SET Stock = Stock {sqlOperator} @qty WHERE ProductID = @prodId";

            using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
            {
                try
                {
                    // If reducing stock, first verify quantity is sufficient
                    if (actionType == "Reduce")
                    {
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@prodId", prodId);

                        conn.Open();
                        int currentStock = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (currentStock < qty)
                        {
                            conn.Close();
                            MessageBox.Show(isChinese ? "庫存不足，無法扣減！" : "Insufficient stock for this action.");
                            return;
                        }
                        conn.Close();
                    }

                    // Directly update the Stock field in the Product table
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@qty", qty);
                    updateCmd.Parameters.AddWithValue("@prodId", prodId);

                    conn.Open();
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(isChinese ? "產品庫存更新成功！" : "Product stock updated successfully.");

                        // Reset controls and reload the table
                        ProductsQTY.Value = 0;
                        ProductID.SelectedIndex = -1;
                        LoadAllProduct();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating record: " + ex.Message);
                }
            }
        }

        // Bind UI button for adding stock (e.g. named btnStockIn)
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            ExecuteStockAdjustment("Add", Convert.ToInt32(ProductsQTY.Value));
        }

        // Bind UI button for reducing stock (e.g. named btnStockOut)
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            ExecuteStockAdjustment("Reduce", Convert.ToInt32(ProductsQTY.Value));
        }
    }
}
