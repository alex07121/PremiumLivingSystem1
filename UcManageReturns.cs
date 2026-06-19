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
        private DataTable orderItemsTable;
        public UserControl2()
        {
            InitializeComponent();
        }

        private void InitOrderItemsTable()
        {
            orderItemsTable = new DataTable();
            orderItemsTable.Columns.Add("ProductID", typeof(string));
            orderItemsTable.Columns.Add("ProductName", typeof(string));
            orderItemsTable.Columns.Add("Quantity", typeof(int));
            orderItemsTable.Columns.Add("UnitPrice", typeof(decimal));
            orderItemsTable.Columns.Add("LineTotal", typeof(decimal), "Quantity * UnitPrice");

            dataGridView1.DataSource = orderItemsTable;

            if (dataGridView1.Columns.Contains("ProductID"))
                dataGridView1.Columns["ProductID"].HeaderText = "Product ID";

            if (dataGridView1.Columns.Contains("ProductName"))
            {
                dataGridView1.Columns["ProductName"].HeaderText = "Product Name";
                dataGridView1.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dataGridView1.Columns.Contains("Quantity"))
                dataGridView1.Columns["Quantity"].HeaderText = "Qty";

            if (dataGridView1.Columns.Contains("UnitPrice"))
                dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";

            if (dataGridView1.Columns.Contains("LineTotal"))
                dataGridView1.Columns["LineTotal"].DefaultCellStyle.Format = "N2";

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (ProductID.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            if (ProductsQTY.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            DataRowView selectedProduct = ProductID.SelectedItem as DataRowView;
            if (selectedProduct == null)
            {
                MessageBox.Show("Invalid product selection.");
                return;
            }

            string productId = selectedProduct["ProductID"].ToString();
            string productName = selectedProduct["ProductName"].ToString();
            int qty = Convert.ToInt32(ProductsQTY.Value);
            decimal unitPrice = Convert.ToDecimal(selectedProduct["UnitPrice"]);

            foreach (DataRow row in orderItemsTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted &&
                    row["ProductID"].ToString() == productId)
                {
                    row["Quantity"] = Convert.ToInt32(row["Quantity"]) + qty;
                    return;
                }
            }

            orderItemsTable.Rows.Add(productId, productName, qty, unitPrice);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
