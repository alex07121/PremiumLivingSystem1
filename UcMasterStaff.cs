using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class UcMasterStaff : UserControl
    {
        public UcMasterStaff()
        {
            InitializeComponent();
        }

        private void UcMasterStaff_Load(object sender, EventArgs e)
        {
            SetupListView();
            LoadJobs();
            LoadStaff();
            ClearFields();
        }

        private void SetupListView()
        {
            lvStaff.Columns.Clear();
            lvStaff.Columns.Add("StaffID", 70);
            lvStaff.Columns.Add("StaffName", 160);
            lvStaff.Columns.Add("Job", 120);
            lvStaff.Columns.Add("Username", 100);
            lvStaff.Columns.Add("Phone", 100);
            lvStaff.Columns.Add("Supervisor", 70);
            lvStaff.Columns.Add("Active", 50);
        }

        private void LoadJobs()
        {
            try
            {
                cmbJob.Items.Clear();
                string query = "SELECT Job_ID, Job_Title FROM Jobs ORDER BY Job_ID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbJob.Items.Add(new { Text = reader["Job_Title"].ToString(), Value = reader["Job_ID"].ToString() });
                    }
                    reader.Close();
                }
                cmbJob.DisplayMember = "Text";
                cmbJob.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadStaff()
        {
            try
            {
                lvStaff.Items.Clear();
                string query = @"SELECT s.StaffID, s.StaffName, j.Job_Title, s.Username, s.Phone, 
                                        s.IsSupervisor, s.IsActive, s.Job_ID
                                 FROM Staff s 
                                 JOIN Jobs j ON s.Job_ID = j.Job_ID 
                                 ORDER BY s.StaffID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["StaffID"].ToString());
                        item.SubItems.Add(reader["StaffName"].ToString());
                        item.SubItems.Add(reader["Job_Title"].ToString());
                        item.SubItems.Add(reader["Username"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(Convert.ToBoolean(reader["IsSupervisor"]) ? "Yes" : "No");
                        item.SubItems.Add(Convert.ToBoolean(reader["IsActive"]) ? "Yes" : "No");
                        item.Tag = reader["Job_ID"].ToString();
                        lvStaff.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaff.SelectedItems.Count > 0)
            {
                ListViewItem item = lvStaff.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtUsername.Text = item.SubItems[3].Text;
                txtPhone.Text = item.SubItems[4].Text;
                chkSupervisor.Checked = item.SubItems[5].Text == "Yes";
                chkActive.Checked = item.SubItems[6].Text == "Yes";

                txtPassword.Text = "";

                string jobId = item.Tag?.ToString();
                for (int i = 0; i < cmbJob.Items.Count; i++)
                {
                    dynamic jobItem = cmbJob.Items[i];
                    if (jobItem.Value == jobId)
                    {
                        cmbJob.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private string GetSelectedJobID()
        {
            if (cmbJob.SelectedItem != null)
            {
                dynamic selected = cmbJob.SelectedItem;
                return selected.Value;
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Staff Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new staff.");
                return;
            }

            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                string query = @"INSERT INTO Staff (Job_ID, StaffName, Phone, Username, PasswordHash, IsSupervisor, IsActive) 
                                 VALUES (@jobId, @name, @phone, @username, @hash, @supervisor, @active)";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@jobId", GetSelectedJobID() ?? "");
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@hash", hashedPassword);
                    cmd.Parameters.AddWithValue("@supervisor", chkSupervisor.Checked);
                    cmd.Parameters.AddWithValue("@active", chkActive.Checked);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Staff added successfully.");
                }
                LoadStaff();
                ClearFields();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvStaff.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a staff member to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Staff Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            try
            {
                string query;
                MySqlCommand cmd;

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
                    query = @"UPDATE Staff SET Job_ID = @jobId, StaffName = @name, Phone = @phone, 
                              Username = @username, PasswordHash = @hash, IsSupervisor = @supervisor, IsActive = @active 
                              WHERE StaffID = @id";
                    cmd = new MySqlCommand(query);
                    cmd.Parameters.AddWithValue("@hash", hashedPassword);
                }
                else
                {
                    query = @"UPDATE Staff SET Job_ID = @jobId, StaffName = @name, Phone = @phone, 
                              Username = @username, IsSupervisor = @supervisor, IsActive = @active 
                              WHERE StaffID = @id";
                    cmd = new MySqlCommand(query);
                }

                cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@jobId", GetSelectedJobID() ?? "");
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@supervisor", chkSupervisor.Checked);
                cmd.Parameters.AddWithValue("@active", chkActive.Checked);

                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Staff updated successfully.");
                }
                LoadStaff();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            cmbJob.SelectedIndex = -1;
            chkSupervisor.Checked = false;
            chkActive.Checked = true;
            lvStaff.SelectedItems.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadStaff();
                return;
            }

            try
            {
                lvStaff.Items.Clear();
                string query = @"SELECT s.StaffID, s.StaffName, j.Job_Title, s.Username, s.Phone, 
                                        s.IsSupervisor, s.IsActive, s.Job_ID
                                 FROM Staff s 
                                 JOIN Jobs j ON s.Job_ID = j.Job_ID 
                                 WHERE s.StaffID LIKE @kw OR s.StaffName LIKE @kw OR s.Username LIKE @kw OR j.Job_Title LIKE @kw
                                 ORDER BY s.StaffID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["StaffID"].ToString());
                        item.SubItems.Add(reader["StaffName"].ToString());
                        item.SubItems.Add(reader["Job_Title"].ToString());
                        item.SubItems.Add(reader["Username"].ToString());
                        item.SubItems.Add(reader["Phone"]?.ToString() ?? "");
                        item.SubItems.Add(Convert.ToBoolean(reader["IsSupervisor"]) ? "Yes" : "No");
                        item.SubItems.Add(Convert.ToBoolean(reader["IsActive"]) ? "Yes" : "No");
                        item.Tag = reader["Job_ID"].ToString();
                        lvStaff.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
    }
}
