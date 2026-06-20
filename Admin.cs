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
    public partial class Admin : Form
    {
        private Type currentUcType = null;
        public Admin()
        {
            InitializeComponent();
        }
        private void ShowUserControl(UserControl uc)
        {
            if (mainPanel != null)
            {
                mainPanel.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(uc);
                currentUcType = uc.GetType();
            }
        }
        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";
            string msg = isChinese ? "您確定要登出嗎？" : "Are you sure you want to logout?";
            string title = isChinese ? "確認登出" : "Confirm Logout";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.CurrentStaffId = null;
                UserSession.CurrentName = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSalesSummaryReport());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcMasterStaff uc = new UcMasterStaff();
            ShowUserControl(uc);
        }
    }
}
