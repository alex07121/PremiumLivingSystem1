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
    public partial class UcAddNewTrackingRecord : UserControl
    {
        public UcAddNewTrackingRecord()
        {
            InitializeComponent();
        }
        private void UcAddNewTrackingRecord_Load(object sender, EventArgs e)
        {
            FillDNID();
        }
        private void FillDNID()
        {
            try
            {
                string query = "SELECT DNID FROM DeliveryNote where Status ='Issued' or Status = 'InTransit'";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                  
                    cboDNID.DataSource = dt;

                    cboDNID.DisplayMember = "DNID";

                   
                    cboDNID.ValueMember = "DNID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO DeliveryTracking 
                     (TrackingID, DNID, Location, Action, UpdatedBy,Remarks) 
                     VALUES 
                     (NULL, @dnId, @location, @action, @staff, @remark)";
            string currentStaffId = string.IsNullOrWhiteSpace(UserSession.CurrentStaffId)
    ? "S-001"
    : UserSession.CurrentStaffId;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@dnId", cboDNID.Text.Trim());
                    cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@action", cboAction.Text.Trim());
                    cmd.Parameters.AddWithValue("@staff", currentStaffId);
                    cmd.Parameters.AddWithValue("@remark", txtRemark.Text.Trim());

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tracking record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboDNID.SelectedIndex = -1;
                        cboAction.SelectedIndex = -1;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }


    }
}
