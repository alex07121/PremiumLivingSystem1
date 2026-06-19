using MySql.Data.MySqlClient;
using PremiumLivingSystem;
using System;
using System.Data;
using System.Windows.Forms;

namespace PLFC_Project
{
    public partial class UcSearchTracking : UserControl
    {


        public UcSearchTracking()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Set up columns if not already set
            if (dgvTracking.Columns.Count == 0)
            {
                dgvTracking.Columns.Add("Transit Location", 180);
                dgvTracking.Columns.Add("Status", 120);
                dgvTracking.Columns.Add("Scan Time", 160);
                dgvTracking.Columns.Add("Staff ID", 120);
                dgvTracking.Columns.Add("Remarks", 200);
            }

            string query = @"SELECT Location, Action, ScanTime, UpdatedBy, Remarks
                     FROM DeliveryTracking 
                     WHERE DNID = @dnId 
                     ORDER BY ScanTime DESC;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", txtSearchDNID.Text.Trim());

                    conn.Open();
                    dgvTracking.Items.Clear();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Location"].ToString());
                        item.SubItems.Add(reader["Action"].ToString());
                        item.SubItems.Add(reader["ScanTime"].ToString());
                        item.SubItems.Add(reader["UpdatedBy"].ToString());
                        item.SubItems.Add(reader["Remarks"].ToString());
                        dgvTracking.Items.Add(item);
                    }
                    reader.Close();

                    if (dgvTracking.Items.Count == 0)
                        MessageBox.Show("No tracking records found for this DNID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


    }
}
