using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{

    public partial class LoginForm : MaterialForm
    {
        private void LoginForm_Load(object sender, EventArgs e)
        {
        
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        public LoginForm()
        {
            InitializeComponent();
            Login = false;
        }

        public bool Login = false;


        private void button2_Click(object sender, EventArgs e)
        {
            staffidtext.Clear();
            pswdtext.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr = "";
            Login = false;

            if (staffidtext.Text.Length == 0 || pswdtext.Text.Length == 0)
            {
                MessageBox.Show("Missing username or password. Please try again.");
                staffidtext.Clear();
                pswdtext.Clear();
            }
            else
            {
                try
                {
                    string jobId = null;
                    sqlStr = "SELECT Job_ID, StaffName, PasswordHash, IsSupervisor FROM staff WHERE StaffID = @staffid";
                    using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                        cmd.Parameters.AddWithValue("@staffid", staffidtext.Text.Trim());

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();

                                if (BCrypt.Net.BCrypt.Verify(pswdtext.Text.Trim(), storedHash))
                                {
                                    jobId = reader["Job_ID"].ToString();
                                    string staffName = reader["StaffName"].ToString();
                                    Login = true;
                                    UserSession.jobId = jobId;
                                    UserSession.CurrentStaffId = staffidtext.Text.Trim();
                                    UserSession.CurrentName = staffName;
                                    UserSession.IsSupervisor = Convert.ToBoolean(reader["IsSupervisor"]);
                                }
                            }
                        }
                    }

                    if (Login)
                    {
                        this.Hide();
                        DialogResult result = DialogResult.Cancel;

                        try
                        {
                            if (staffidtext.Text == "S-011")
                            {
                                using (Admin admin = new Admin())
                                    result = admin.ShowDialog();
                            }
                            else if (jobId == "J-001")
                            {
                                using (Sales_Representative_Form sales = new Sales_Representative_Form())
                                    result = sales.ShowDialog();
                            }
                            else if (jobId == "J-002")
                            {
                                using (Finance_Staff_Form finance = new Finance_Staff_Form())
                                    result = finance.ShowDialog();
                            }
                            else if (jobId == "J-003")
                            {
                                using (Home_Planning_Specialist_Form homePlan = new Home_Planning_Specialist_Form())
                                    result = homePlan.ShowDialog();
                            }
                            else if (jobId == "J-004")
                            {
                                using (Inventory_Clerk_Form inventory = new Inventory_Clerk_Form())
                                    result = inventory.ShowDialog();
                            }
                            else if (jobId == "J-005")
                            {
                                using (Logistics_Staff_Form logistics = new Logistics_Staff_Form())
                                    result = logistics.ShowDialog();
                            }
                            else if(jobId == "J-006")
                            {
                                using (ProductionClerkForm proudction = new ProductionClerkForm())
                                    result = proudction.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "The application encountered an error and will return to login." + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            result = DialogResult.OK; // return to login, don't close the app
                        }

                        if (result == DialogResult.OK)
                        {
                            staffidtext.Clear();
                            pswdtext.Clear();
                            this.Show();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Staff Id or Password. Please try again.");
                        staffidtext.Clear();
                        pswdtext.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login failed. Please try again or contact system administrator.");
                }
            }
        }
    }

    public static class UserSession
    {
        public static string jobId { get; set; } = null;
        public static string CurrentStaffId { get; set; } = null;
        public static string CurrentName { get; set; } = null;
        public static bool IsSupervisor { get; set; } = false;
        public static string CurrentCulture { get; set; } = "en";
    }
}