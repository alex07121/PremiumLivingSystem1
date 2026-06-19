using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PremiumLivingSystem
{
    public partial class InvoiceFomr : UserControl
    {
        public InvoiceFomr()
        {
            InitializeComponent();
        }
        private void InvoiceFomr_Load(object sender, EventArgs e)
        {

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
                        txtOrderDate.Text = reader["OrderDate"].ToString();
                        txtOrder.Text = reader["OrderID"].ToString();
                        txtCutomer.Text = reader["CustomerID"].ToString();
                    }
                    reader.Close();
                }
                //LoadOrderItems(orderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sending order data to printer...", "Print Order",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
