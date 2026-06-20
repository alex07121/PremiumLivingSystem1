using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using PLFC_Project;
//testing

namespace PremiumLivingSystem
{
  
    public partial class Home_Planning_Specialist_Form : MaterialForm
    {
        private Type currentUcType = null;

        public Home_Planning_Specialist_Form()
        {
          
            ApplyLanguage();
            InitializeComponent();

          
            SetupMaterialSkin();

            UpdateStaffInfo();
            SetLanguageComboBoxValue();
            btnMasterCustomer.Visible = UserSession.IsSupervisor;

        }

      
        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

          
            materialSkinManager.ColorScheme = new ColorScheme(
               Primary.Purple800,       
               Primary.Purple900,
                 Primary.Purple500,
                 Accent.Pink200,
                 TextShade.WHITE
            );
        }

     
        private void UpdateStaffInfo()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";
            label2.Text = isChinese
                ? $"員工姓名: {UserSession.CurrentName}\n員工編號: ({UserSession.CurrentStaffId})"
                : $"Staff Name: {UserSession.CurrentName}\nStaff ID: ({UserSession.CurrentStaffId})";
        }

     
        private void ApplyLanguage()
        {
            if (DesignModeHelper.IsDesignMode())
                return;

            if (!string.IsNullOrEmpty(UserSession.CurrentCulture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserSession.CurrentCulture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(UserSession.CurrentCulture);
            }
        }

      
        private void SetLanguageComboBoxValue()
        {
            cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;
            cmbLanguage.SelectedIndex = UserSession.CurrentCulture == "zh-Hans-HK" ? 1 : 0;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
        }

       
        private void RefreshFormText()
        {
            ApplyLanguage();
            UpdateStaffInfo();
            SetLanguageComboBoxValue();

         
            if (currentUcType != null)
            {
                UserControl refreshedUc = (UserControl)Activator.CreateInstance(currentUcType);
                ShowUserControl(refreshedUc);
            }
        }

     
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newCulture = cmbLanguage.SelectedIndex == 0 ? "en" : "zh-Hans-HK";
            if (UserSession.CurrentCulture != newCulture)
            {
                UserSession.CurrentCulture = newCulture;
                RefreshFormText();
            }
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

  

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcCreateOrder());
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcAddCustomer());
        }

        private void btnSubmitComplaint_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSubmitComplaint());
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSubmitReturnOrReplacementRequest());
        }

   
        private void button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSearchOrder());
        }

   
        private void button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSearchTracking());
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

        private void label2_Click(object sender, EventArgs e) { }
        private void picLogo_Click(object sender, EventArgs e) { }
        private void mainPanel_Paint(object sender, PaintEventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            UcProcessReturn uc = new UcProcessReturn();
            ShowUserControl(uc);
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            UcMasterCustomer ucMasterCustomer = new UcMasterCustomer();
            ShowUserControl(ucMasterCustomer);
        }
    }
}