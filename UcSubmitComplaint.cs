using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcSubmitComplaint : UserControl
    {
        // Store uploaded images as byte[] in memory for later database insertion
        private List<byte[]> uploadedImageData = new List<byte[]>();
        private List<string> uploadedImageNames = new List<string>();

        public UcSubmitComplaint()
        {
            InitializeComponent();
        }

        private void UcSubmitComplaint_Load(object sender, EventArgs e)
        {
            FillComplaint();
        }
        private void FillComplaint()
        {
            string query = "SELECT OrderID, CustomerID FROM `Order` WHERE Status = 'Delivered'";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);
                    cboOrderID.DataSource = dt;
                    cboOrderID.DisplayMember = "OrderID";
                    cboOrderID.ValueMember = "OrderID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

        }

        private void cboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderID.SelectedItem is DataRowView rowView)
            {
                txtCutomerID.Text = rowView["CustomerID"].ToString();
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog1.FileNames)
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(filePath);
                        string fileName = Path.GetFileName(filePath);
                        uploadedImageData.Add(imageBytes);
                        uploadedImageNames.Add(fileName);
                        lstPhotos.Items.Add(fileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file: " + Path.GetFileName(filePath) + "" + ex.Message);
                    }
                }
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            if (lstPhotos.SelectedIndex >= 0)
            {
                int idx = lstPhotos.SelectedIndex;
                uploadedImageData.RemoveAt(idx);
                uploadedImageNames.RemoveAt(idx);
                lstPhotos.Items.RemoveAt(idx);
            }
            else
            {
                MessageBox.Show("Please select a photo to remove.");
            }
        }

        /// <summary>
        /// Save image binary data directly into ComplaintImage table (ImageData column).
        /// </summary>
        private void SaveImagesToDatabase(MySqlConnection conn, string complaintID)
        {
            string insertQuery = @"INSERT INTO ComplaintImage (ImageID, ComplaintID, ImageData) 
                                   VALUES (NULL, @complaintId, @imageData)";

            foreach (byte[] imageBytes in uploadedImageData)
            {
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@complaintId", complaintID);
                cmd.Parameters.AddWithValue("@imageData", imageBytes);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        private string GetLastInsertedComplaintID()
        {
            string query = "SELECT ComplaintID FROM Complaint ORDER BY ComplaintID DESC LIMIT 1";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                return null;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Complaint (
                ComplaintID, CustomerID, HandledByID, OrderID,
                ComplaintType, Description, ComplaintDate, 
                Status, Resolution) 
            VALUES (
                NULL, @cId, @hId, @oId,
                @ct, @desc, @cd, 
                @status, @re)";
            string cID = txtCutomerID.Text.Trim();
            string hID = UserSession.CurrentStaffId ?? "S-001";
            string oID = cboOrderID.SelectedValue?.ToString();
            string ct = cboComplaintType.SelectedItem?.ToString();
            string desc = txtDescription.Text.Trim();
            string cd = DateTime.Now.ToString("yyyy-MM-dd");
            string status = "Open";
            string re = null;

            if (string.IsNullOrEmpty(cID) || string.IsNullOrEmpty(oID) || string.IsNullOrEmpty(ct))
            {
                MessageBox.Show("Please fill in all required fields (Customer, Order, Complaint Type).");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cId", cID);
                    cmd.Parameters.AddWithValue("@hId", hID);
                    cmd.Parameters.AddWithValue("@oId", oID);
                    cmd.Parameters.AddWithValue("@ct", ct);
                    cmd.Parameters.AddWithValue("@desc", desc);
                    cmd.Parameters.AddWithValue("@cd", cd);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@re", re);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Get the auto-generated complaint ID
                        string complaintID = GetLastInsertedComplaintID();

                        // Save uploaded images as binary data
                        if (uploadedImageData.Count > 0 && !string.IsNullOrEmpty(complaintID))
                        {
                            SaveImagesToDatabase(conn, complaintID);
                        }

                        MessageBox.Show("Complaint added successfully!");
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            cboOrderID.SelectedIndex = -1;
            txtCutomerID.Clear();
            cboComplaintType.SelectedIndex = -1;
            txtDescription.Clear();
            uploadedImageData.Clear();
            uploadedImageNames.Clear();
            lstPhotos.Items.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
