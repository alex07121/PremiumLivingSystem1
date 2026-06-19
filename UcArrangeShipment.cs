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

namespace PremiumLivingSystem
{
    public partial class UcArrangeShipment : UserControl
    {
        public UcArrangeShipment()
        {
            InitializeComponent();
        }

        private void UcArrangeShipment_Load(object sender, EventArgs e)
        {
            dgvOrders.View = View.Details;
            dgvOrders.FullRowSelect = true;
            dgvOrders.GridLines = true;
            dgvOrders.MultiSelect = false;
            dgvOrders.Columns.Add("OrderID", 120);
            dgvOrders.Columns.Add("OrderDate", 120);
            dgvOrders.Columns.Add("Status", 100);
            dgvOrders.Columns.Add("CustomerName", 180);
            dgvOrders.Columns.Add("Address", 250);
            LoadReadyOrders();
        }

        private void LoadReadyOrders()
        {
            string query = @"
                SELECT o.OrderID, o.OrderDate, o.Status, c.CustomerName, c.Address 
                FROM `Order` o
                JOIN Customer c ON o.CustomerID = c.CustomerID
                WHERE o.Status IN ('ReadyToShip', 'Pending', 'InProduction') 
                ORDER BY o.OrderDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    dgvOrders.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["OrderDate"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["Address"]?.ToString() ?? "");
                        dgvOrders.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedItems.Count > 0)
            {
                ListViewItem item = dgvOrders.SelectedItems[0];
                txtOrderID.Text = item.Text;

                cboAddress.Items.Clear();
                string address = item.SubItems[4].Text;
                if (!string.IsNullOrEmpty(address))
                {
                    cboAddress.Items.Add(address);
                    cboAddress.SelectedIndex = 0;
                }
                else
                {
                    cboAddress.Text = "";
                }
            }
            else
            {
                txtOrderID.Text = "";
                cboAddress.Items.Clear();
                cboAddress.Text = "";
            }
        }

        private void btnCreateDN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Please select an order first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cboAddress.Text))
            {
                MessageBox.Show("Please provide a shipping address.");
                return;
            }

            string orderId = txtOrderID.Text.Trim();
            string address = cboAddress.Text.Trim();
            DateTime dispatchDate = dtpDispatchDate.Value.Date;
            string deliveryMethod = cboDeliveryMethod.SelectedItem?.ToString(); 
            string staffId = UserSession.CurrentStaffId ?? "S-007"; // fallback if null

            string dnQuery = @"INSERT INTO DeliveryNote (OrderID, IssuedByStaff, DispatchDate, DeliveryMethod, Status) 
                               VALUES (@oid, @staff, @dDate, @deliveryMethod, 'Issued')";
            string sqlGetId = "SELECT DNID FROM DeliveryNote WHERE OrderID = @oid ORDER BY DNID DESC LIMIT 1";
            string copyItemsQuery = @"
                INSERT INTO DeliveryNoteItem (DNID, ProductID, Description, QtyOrdered)
                SELECT @dnId, oi.ProductID, p.ProductName, oi.Quantity
                FROM OrderItem oi
                JOIN Product p ON oi.ProductID = p.ProductID
                WHERE oi.OrderID = @oid";
            string updateOrderQuery = "UPDATE `Order` SET Status = 'Shipped' WHERE OrderID = @oid";

            using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
            {
                MySqlCommand dnCmd = new MySqlCommand(dnQuery, conn);
                dnCmd.Parameters.AddWithValue("@oid", orderId);
                dnCmd.Parameters.AddWithValue("@staff", staffId);
                dnCmd.Parameters.AddWithValue("@dDate", dispatchDate);
                dnCmd.Parameters.AddWithValue("@deliveryMethod", deliveryMethod);

                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                dnCmd.Transaction = tran;
                try
                {
                    int dnRows = dnCmd.ExecuteNonQuery();

                    MySqlCommand getDnIdCmd = new MySqlCommand(sqlGetId, conn, tran);
                    getDnIdCmd.Parameters.AddWithValue("@oid", orderId);
                    string dnId = getDnIdCmd.ExecuteScalar()?.ToString();

                    if (dnId == null) throw new Exception("Failed to retrieve new Delivery Note ID.");

                    MySqlCommand copyCmd = new MySqlCommand(copyItemsQuery, conn, tran);
                    copyCmd.Parameters.AddWithValue("@dnId", dnId);
                    copyCmd.Parameters.AddWithValue("@oid", orderId);
                    int copyRows = copyCmd.ExecuteNonQuery();

                    MySqlCommand updateOrderCmd = new MySqlCommand(updateOrderQuery, conn, tran);
                    updateOrderCmd.Parameters.AddWithValue("@oid", orderId);
                    int updateRows = updateOrderCmd.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Delivery Note created successfully!\nDN ID: " + dnId);
                    txtOrderID.Text = "";
                    cboAddress.Items.Clear();
                    cboAddress.Text = "";
                    LoadReadyOrders();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error inserting record: " + ex.Message);
                }
            }
        }
    }
}
