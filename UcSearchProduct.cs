using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PremiumLivingSystem
{
    public partial class UcSearchProduct : UserControl
    {
        public UcSearchProduct()
        {
            InitializeComponent();
        }

        private void UcSearchProduct_Load(object sender, EventArgs e)
        {
            dgvProductStock.View = View.Details;
            dgvProductStock.FullRowSelect = true;
            dgvProductStock.GridLines = true;
            dgvProductStock.MultiSelect = false;
            dgvProductStock.Columns.Add("ProductID", 120);
            dgvProductStock.Columns.Add("ProductName", 200);
            dgvProductStock.Columns.Add("UnitPrice", 100);
            dgvProductStock.Columns.Add("Stock", 80);
            LoadAllProducts();
            btnEdit.Enabled = false;
        }
        private void LoadAllProducts()
        {
            string query = @"SELECT ProductID, ProductName, UnitPrice, Stock
                             FROM Product
                             ORDER BY ProductID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    dgvProductStock.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPrice"]).ToString("C2"));
                        item.SubItems.Add(reader["Stock"].ToString());
                        dgvProductStock.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtPid.Text.Trim();

            if (keyword == "")
            {
                LoadAllProducts();
                return;
            }

            string query = @"
                SELECT ProductID, ProductName, UnitPrice, Stock
                FROM Product
                WHERE ProductID = @id
                ORDER BY ProductID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", keyword);

                    conn.Open();
                    dgvProductStock.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["UnitPrice"]).ToString("C2"));
                        item.SubItems.Add(reader["Stock"].ToString());
                        dgvProductStock.Items.Add(item);
                    }
                    reader.Close();

                    if (dgvProductStock.Items.Count > 0)
                    {
                        btnEdit.Enabled = true;
                        MessageBox.Show("Record found!");
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        MessageBox.Show("No record found with that code.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        
        private void txtKeyword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProductForm editForm = new EditProductForm();
            editForm.LoadProductData(txtPid.Text.Trim());
            editForm.ShowDialog();

        }
    }
}

