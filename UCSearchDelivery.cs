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
    public partial class UcSearchDelivery : UserControl
    {
        public UcSearchDelivery()
        {
            InitializeComponent();

        }

        private void LoadAllDelivery()
        {
            string query = @"SELECT DNID, OrderID, DispatchDate, DeliveryMethod, Status, InvoiceAddress 
                             FROM DeliveryNote ORDER BY DNID";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    dgvDelivery.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["DNID"].ToString());
                        item.SubItems.Add(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["DispatchDate"].ToString());
                        item.SubItems.Add(reader["DeliveryMethod"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["InvoiceAddress"]?.ToString() ?? "");
                        dgvDelivery.Items.Add(item);
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
            string keyword = txtDeliveryID.Text.Trim();

            if (keyword == "")
            {
                LoadAllDelivery();
                return;
            }

            string query = @"SELECT DNID, OrderID, DispatchDate, DeliveryMethod, Status, InvoiceAddress 
                             FROM DeliveryNote WHERE DNID = @dnId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", keyword);

                    conn.Open();
                    dgvDelivery.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["DNID"].ToString());
                        item.SubItems.Add(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["DispatchDate"].ToString());
                        item.SubItems.Add(reader["DeliveryMethod"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["InvoiceAddress"]?.ToString() ?? "");
                        dgvDelivery.Items.Add(item);
                    }
                    reader.Close();

                    if (dgvDelivery.Items.Count > 0)
                        MessageBox.Show("Record found!");
                    else
                        MessageBox.Show("No record found with that code.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dgvDelivery.SelectedItems.Count > 0)
            {
                string dnId = dgvDelivery.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(dnId))
                {
                    txtDeliveryID.Text = dnId;
                }
            }

            if (string.IsNullOrWhiteSpace(txtDeliveryID.Text))
            {
                MessageBox.Show("Please select or enter a Delivery Note ID.");
                return;
            }

            using (Delivery delivery = new Delivery())
            {
                delivery.LoadDeliveryItem(txtDeliveryID.Text.Trim());
                delivery.LoadDeliveryNoteItems(txtDeliveryID.Text.Trim());
                delivery.ShowDialog(this.FindForm());
            }
        }

        private void btnReplySlip_Click(object sender, EventArgs e)
        {
            // Try to get data from the selected row first
            string dnId = "";
            string orderId = "";

            if (dgvDelivery.SelectedItems.Count > 0)
            {
                dnId = dgvDelivery.SelectedItems[0].Text;
                orderId = dgvDelivery.SelectedItems[0].SubItems[1].Text;

                if (!string.IsNullOrEmpty(dnId))
                {
                    txtDeliveryID.Text = dnId;
                }
            }

            if (!string.IsNullOrEmpty(orderId) && !string.IsNullOrEmpty(dnId))
            {
                using (Reply reply = new Reply())
                {
                    reply.LoadDeliveryItem(orderId);
                    reply.LoadDeliveryNoteItems(dnId);
                    reply.LoadDeliveryNoteStatus(dnId);
                    reply.ShowDialog(this.FindForm());
                }
                return;
            }

            // Fallback: try DNID from textbox as OrderID (for manual entry)
            if (!string.IsNullOrWhiteSpace(txtDeliveryID.Text))
            {
                dnId = txtDeliveryID.Text.Trim();
                using (Reply reply = new Reply())
                {
                    reply.LoadDeliveryItem(dnId);
                    reply.LoadDeliveryNoteItems(dnId);
                    reply.LoadDeliveryNoteStatus(dnId);
                    reply.ShowDialog(this.FindForm());
                }
            }
            else
            {
                MessageBox.Show("Please select a Delivery Note first.");
            }
        }

        private void UcSearchDelivery_Load(object sender, EventArgs e)
        {
            dgvDelivery.View = View.Details;
            dgvDelivery.FullRowSelect = true;
            dgvDelivery.GridLines = true;
            dgvDelivery.MultiSelect = false;
            dgvDelivery.Columns.Add("DNID", 120);
            dgvDelivery.Columns.Add("OrderID", 120);
            dgvDelivery.Columns.Add("DispatchDate", 140);
            dgvDelivery.Columns.Add("DeliveryMethod", 140);
            dgvDelivery.Columns.Add("Status", 100);
            dgvDelivery.Columns.Add("InvoiceAddress", 250);
            LoadAllDelivery();
        }
    }
}
