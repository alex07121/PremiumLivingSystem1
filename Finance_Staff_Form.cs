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

namespace PremiumLivingSystem
{
    public partial class Finance_Staff_Form : MaterialForm
    {
        private Type currentUcType = null;

        public Finance_Staff_Form()
        {
            ApplyLanguage();
            InitializeComponent();

            // Fix: Designer incorrectly wires cmbLanguage.Click instead of SelectedIndexChanged
            cmbLanguage.Click -= cmbLanguage_SelectedIndexChanged;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;

            SetupMaterialSkin();

            UpdateStaffInfo();
            PopulateLanguageCombo();
            SetLanguageComboBoxValue();
        }

     
        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

           
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red500,
                Accent.Red200,
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

        private void PopulateLanguageCombo()
        {
            if (cmbLanguage.Items.Count == 0)
            {
                cmbLanguage.Items.Add("English");
                cmbLanguage.Items.Add("中文");
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
            if (mainpanel != null)
            {
                mainpanel.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                mainpanel.Controls.Add(uc);
                currentUcType = uc.GetType();
            }
        }

    
        private void btninvoice_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcSearchOrder());
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

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            UcAddCustomer uc = new UcAddCustomer();
            ShowUserControl(uc);
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
    }
}