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
using System.Windows.Forms.VisualStyles;

namespace PremiumLivingSystem
{
    public partial class UcAddCustomer : UserControl
    {
        public UcAddCustomer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cType = cboCustomerType.SelectedItem?.ToString() ?? "";
            string cName = txtCustomerName.Text.Trim();
            string cPhone = txtPhone.Text.Trim();
            string cEmail = txtEmail.Text.Trim();
            string cAddress = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(cType) || string.IsNullOrWhiteSpace(cName))
            {
                MessageBox.Show("Please select customer type and enter customer name.");
                return;
            }

            string query = @"
        INSERT INTO Customer
            (CustomerID, CustomerType, CustomerName, Phone, Email, Address)
        VALUES
            (NULL, @type, @name, @phone, @email, @address)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@type", cType);
                    cmd.Parameters.AddWithValue("@name", cName);
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(cPhone) ? DBNull.Value : (object)cPhone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(cEmail) ? DBNull.Value : (object)cEmail);
                    cmd.Parameters.AddWithValue("@address", string.IsNullOrWhiteSpace(cAddress) ? DBNull.Value : (object)cAddress);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer added successfully!");
                        cboCustomerType.SelectedIndex = -1;
                        txtCustomerName.Clear();
                        txtPhone.Clear();
                        txtEmail.Clear();
                        txtAddress.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void UcAddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
