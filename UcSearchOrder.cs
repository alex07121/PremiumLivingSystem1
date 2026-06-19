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
    public partial class UcSearchOrder : UserControl
    {
        public UcSearchOrder()
        {
            InitializeComponent();
        }
        private void UcSearchOrder_Load(object sender, EventArgs e)
        {
            dgvOrder.View = View.Details;
            dgvOrder.FullRowSelect = true;
            dgvOrder.GridLines = true;
            dgvOrder.MultiSelect = false;
            dgvOrder.Columns.Add("OrderID", 120);
            dgvOrder.Columns.Add("CustomerID", 120);
            dgvOrder.Columns.Add("OrderDate", 120);
            dgvOrder.Columns.Add("RequiredDate", 120);
            dgvOrder.Columns.Add("Status", 100);
            dgvOrder.Columns.Add("PaymentStatus", 120);
            LoadAllOrder();
            btnEdit.Enabled = false;
        }

        private void LoadAllOrder()
        {
            string query = @"SELECT OrderID, CustomerID, OrderDate, RequiredDate, Status, PaymentStatus
                            FROM `Order`
                             ORDER BY OrderID";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    dgvOrder.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["OrderDate"].ToString());
                        item.SubItems.Add(reader["RequiredDate"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["PaymentStatus"].ToString());
                        dgvOrder.Items.Add(item);
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
            string keyword = txtOrderID.Text.Trim();

            if (keyword == "")
            {
                LoadAllOrder();
                return;
            }

            string query = @"SELECT OrderID, CustomerID, OrderDate, RequiredDate, Status, PaymentStatus
                FROM `Order`
                WHERE OrderID = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", keyword);

                    conn.Open();
                    dgvOrder.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["OrderDate"].ToString());
                        item.SubItems.Add(reader["RequiredDate"]?.ToString() ?? "");
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["PaymentStatus"].ToString());
                        dgvOrder.Items.Add(item);
                    }
                    reader.Close();

                    if (dgvOrder.Items.Count > 0)
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditOrderForm editForm = new EditOrderForm();
            editForm.LoadOrderData(txtOrderID.Text.Trim());
            editForm.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            InvoiceFomr ucinvoice = new InvoiceFomr();
            //ucinvoice.LoadInvoiceByOrderID(txtOrderID.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to cancel this order? Product stock will be restored.",
                                          "Confirm Cancel Order",
                                          MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string checkQuery = "SELECT Status FROM `Order` WHERE OrderID = @id";
                string currentStatus = "";

                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@id", txtOrderID.Text.Trim());
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        currentStatus = result.ToString();
                    }
                }

                if (currentStatus == "")
                {
                    MessageBox.Show("No record found with that code.");
                    return;
                }

                if (currentStatus == "Cancelled")
                {
                    MessageBox.Show("This order is already cancelled.");
                    return;
                }

                if (currentStatus != "Pending")
                {
                    MessageBox.Show("Only 'Pending' orders can be cancelled. Current status: " + currentStatus);
                    return;
                }
                string getItemsQuery = "SELECT ProductID, Quantity FROM OrderItem WHERE OrderID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmdItems = new MySqlCommand(getItemsQuery, conn);
                    cmdItems.Parameters.AddWithValue("@id", txtOrderID.Text.Trim());
                    conn.Open();
                    using (MySqlDataReader reader = cmdItems.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productID = reader["ProductID"].ToString();
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            string restoreQuery = "UPDATE Product SET Stock = Stock + @qty WHERE ProductID = @pid";
                            using (MySqlConnection conn2 = new MySqlConnection(Program.ConnectionString))
                            {
                                MySqlCommand cmdRestore = new MySqlCommand(restoreQuery, conn2);
                                cmdRestore.Parameters.AddWithValue("@qty", qty);
                                cmdRestore.Parameters.AddWithValue("@pid", productID);
                                conn2.Open();
                                cmdRestore.ExecuteNonQuery();
                            }
                        }
                    }
                }

                string cancelQuery = "UPDATE `Order` SET Status = 'Cancelled' WHERE OrderID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(cancelQuery, conn);
                    cmd.Parameters.AddWithValue("@id", txtOrderID.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order cancelled successfully. Product stock has been restored.");

                txtOrderID.Clear();
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                LoadAllOrder();
            }
        }


    }
}
