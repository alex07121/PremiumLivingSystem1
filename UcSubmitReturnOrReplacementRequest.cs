using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcSubmitReturnOrReplacementRequest : UserControl
    {
        // Store uploaded images as byte[] in memory for later database insertion
        private List<byte[]> uploadedImageData = new List<byte[]>();
        private List<string> uploadedImageNames = new List<string>();

        public UcSubmitReturnOrReplacementRequest()
        {
            InitializeComponent();
        }

        private void UcSubmitReturnOrReplacementRequest_Load(object sender, EventArgs e)
        {
            FillOrder();
        }
        private void FillOrder()
        {
            string query = "SELECT * FROM `Order` WHERE Status = 'Delivered'";
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
                    cboOrderID.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
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
        /// Save image binary data directly into ReturnImage table (ImageData column).
        /// </summary>
        private void SaveImagesToDatabase(MySqlConnection conn, string returnID)
        {
            string insertQuery = @"INSERT INTO ReturnImage (ImageID, ReturnID, ImageData) 
                                   VALUES (NULL, @returnId, @imageData)";

            foreach (byte[] imageBytes in uploadedImageData)
            {
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@returnId", returnID);
                cmd.Parameters.AddWithValue("@imageData", imageBytes);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        private string GetLastInsertedReturnID()
        {
            string query = "SELECT ReturnID FROM ReturnRequest ORDER BY ReturnID DESC LIMIT 1";
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
            if (cboOrderID.SelectedValue == null)
            {
                MessageBox.Show("Please select a Complaint.");
                return;
            }
            if (cboReturnType.SelectedItem == null)
            {
                MessageBox.Show("Please select a Return Type.");
                return;
            }
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Please enter a return reason.");
                return;
            }

            string query = @"INSERT INTO ReturnRequest 
                (ReturnID, ComplaintID, OrderID, ReturnType, ReturnReason, RequestDate, Status) 
                VALUES 
                (NULL, NULL , @ordId, @retType, @reason, @reqDate, 'Pending')";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ordId", cboOrderID.SelectedValue);
                    cmd.Parameters.AddWithValue("@retType", cboReturnType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@reason", richTextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@reqDate", DateTime.Now.ToString("yyyy-MM-dd"));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Get the auto-generated Return ID
                        string returnID = GetLastInsertedReturnID();

                        // Save uploaded images as binary data to database
                        if (uploadedImageData.Count > 0 && !string.IsNullOrEmpty(returnID))
                        {
                            SaveImagesToDatabase(conn, returnID);
                        }

                        MessageBox.Show("Return/Replacement request submitted successfully.");
                        btnClear_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboOrderID.SelectedIndex = -1;
            cboReturnType.SelectedIndex = -1;
            richTextBox1.Clear();
            uploadedImageData.Clear();
            uploadedImageNames.Clear();
            lstPhotos.Items.Clear();
        }

        private void cboOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
