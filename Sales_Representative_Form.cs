using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;       
using System.Globalization;  
using MaterialSkin;
using MaterialSkin.Controls;
using PLFC_Project;          

namespace PremiumLivingSystem
{
    public partial class Sales_Representative_Form : MaterialForm
    {
        private Type currentUcType = null;

        public Sales_Representative_Form()
        {
            InitializeComponent();

          
            ApplyLanguage();

            
            SetupMaterialSkin();

            SetButtonTexts();

            UpdateStaffInfo();
            SetLanguageComboBoxValue();
            btnCustomer.Visible = UserSession.IsSupervisor;
        }

        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.LightGreen200,
                TextShade.WHITE
            );
        }

        private void ApplyLanguage()
        {
            if (!string.IsNullOrEmpty(UserSession.CurrentCulture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserSession.CurrentCulture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(UserSession.CurrentCulture);
            }
        }

 
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            string newCulture = cmbLanguage.SelectedIndex == 0 ? "en" : "zh-HK";

            if (UserSession.CurrentCulture != newCulture)
            {
                UserSession.CurrentCulture = newCulture;
                RefreshFormText();
            }
        }

        private void RefreshFormText()
        {
       
            ApplyLanguage();

      
            SetButtonTexts();

  
            UpdateStaffInfo();

    
            SetLanguageComboBoxValue();

    
            if (currentUcType != null)
            {
                ShowUserControl((UserControl)Activator.CreateInstance(currentUcType));
            }
        }

  
        private void SetButtonTexts()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-HK";

  
            btnCreateOrder.Text = isChinese ? "建立訂單" : "Create Order";
            btnLogout.Text = isChinese ? "登出" : "Logout";

            if (button4 != null)
                button4.Text = isChinese ? "查詢訂單" : "Search Order";
        }

    
        private void UpdateStaffInfo()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-HK";

 
            if (label2 != null)
            {
                label2.Text = isChinese
                    ? $"員工姓名: {UserSession.CurrentName}\n員工編號: ({UserSession.CurrentStaffId})"
                    : $"Staff Name: {UserSession.CurrentName}\nStaff ID: ({UserSession.CurrentStaffId})";
            }
        }

 
        private void SetLanguageComboBoxValue()
        {
   
            cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;

     
            cmbLanguage.SelectedIndex = UserSession.CurrentCulture == "zh-HK" ? 1 : 0;

            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            bool isChinese = UserSession.CurrentCulture == "zh-HK";
            string msg = isChinese ? "您確定要登出嗎？" : "Are you sure you want to logout?";
            string title = isChinese ? "確認登出" : "Confirm Logout";

            var confirm = MessageBox.Show(msg, title, MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                UserSession.CurrentStaffId = null;
                UserSession.CurrentName = null;

                this.DialogResult = DialogResult.OK;
                this.Close();
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
            UcCreateOrder uc = new UcCreateOrder();
            ShowUserControl(uc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UcSearchOrder uc = new UcSearchOrder();
            ShowUserControl(uc);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            UcMasterCustomer uc = new UcMasterCustomer();
            ShowUserControl(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcSalesSummaryReport uc = new UcSalesSummaryReport();
            ShowUserControl(uc);
        }
    }
}