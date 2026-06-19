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
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{

    public partial class EditProductForm : MaterialForm
    {
        public EditProductForm()
        {
            InitializeComponent();

        
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            FillCategory();
        }

        private void FillCategory()
        {
            string query = @"
                        SELECT CategoryID,
                               CategoryName,
                               CONCAT(CategoryID, ' - ', CategoryName) AS DisplayText
                        FROM productcategory
                        ORDER BY CategoryID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

               
                    cboCategory.DataSource = dt;

               
                    cboCategory.DisplayMember = "DisplayText";

                  
                    cboCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public void LoadProductData(string productid)
        {
            string query = "SELECT * FROM product WHERE productid = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productid);
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtPid.Text = reader["productid"].ToString();
                        txtProductName.Text = reader["productName"].ToString();
                        txtUnitPrice.Text = reader["UnitPrice"].ToString();
                        txtStock.Text = reader["Stock"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE product SET 
                    productName = @name, 
                    Categoryid = @catId, 
                    UnitPrice = @price, 
                    Stock = @stock 
                    WHERE ProductID = @pid";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@catId", cboCategory.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@price", txtUnitPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@stock", txtStock.Text.Trim());
                    cmd.Parameters.AddWithValue("@pid", txtPid.Text.Trim());

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Product updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }

        }
    }
}
