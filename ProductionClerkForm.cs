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
using PLFC_Project; // Ensure UserSession is accessible

namespace PremiumLivingSystem
{
    // Inherits from MaterialForm
    public partial class ProductionClerkForm : MaterialForm
    {
        private Type currentUcType = null;

        public ProductionClerkForm()
        {
            ApplyLanguage();
            InitializeComponent();

            SetupMaterialSkin();
            UpdateStaffInfo();
            SetLanguageComboBoxValue();

        }

        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Use blue color scheme (Indigo) for Production Clerk, to distinguish from other roles
            materialSkinManager.ColorScheme = new ColorScheme(
               Primary.Indigo800,
               Primary.Indigo900,
               Primary.Indigo500,
               Accent.LightBlue200,
               TextShade.WHITE
            );
        }

        private void UpdateStaffInfo()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";
            // Ensure label2 control exists in the Designer
            if (label2 != null)
            {
                label2.Text = isChinese
                    ? $"員工姓名: {UserSession.CurrentName}\n員工編號: ({UserSession.CurrentStaffId})"
                    : $"Staff Name: {UserSession.CurrentName}\nStaff ID: ({UserSession.CurrentStaffId})";
            }
        }

        private void ApplyLanguage()
        {
            if (!string.IsNullOrEmpty(UserSession.CurrentCulture))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(UserSession.CurrentCulture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(UserSession.CurrentCulture);
            }
        }

        private void SetLanguageComboBoxValue()
        {
            if (cmbLanguage != null)
            {
                cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;
                cmbLanguage.SelectedIndex = UserSession.CurrentCulture == "zh-Hans-HK" ? 1 : 0;
                cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            }
        }

        private void RefreshFormText()
        {
            ApplyLanguage();
            UpdateStaffInfo();
            SetLanguageComboBoxValue();

            // Button text update logic can be added here (SetButtonTexts())

            if (currentUcType != null)
            {
                UserControl refreshedUc = (UserControl)Activator.CreateInstance(currentUcType);
                ShowUserControl(refreshedUc);
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage == null) return;

            string newCulture = cmbLanguage.SelectedIndex == 0 ? "en" : "zh-Hans-HK";
            if (UserSession.CurrentCulture != newCulture)
            {
                UserSession.CurrentCulture = newCulture;
                RefreshFormText();
            }
        }

        private void ShowUserControl(UserControl uc)
        {
            if (MainPanel != null)
            {
                MainPanel.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                MainPanel.Controls.Add(uc);
                currentUcType = uc.GetType();
            }
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

        private void btnCreateTransfer_Click(object sender, EventArgs e)
        {
            UcTransfer ucTransfer = new UcTransfer();
            ShowUserControl(ucTransfer);
        }

        private void btnCreateMaterialRequest_Click(object sender, EventArgs e)
        {
            UcCreateMaterialRequest ucMaterialRequest = new UcCreateMaterialRequest();
            ShowUserControl(ucMaterialRequest);
        }

        private void btnSearchTransfer_Click(object sender, EventArgs e)
        {
            UcReceivableTransfers ucReceivableTransfers = new UcReceivableTransfers();
            ShowUserControl(ucReceivableTransfers);
        }

        private void btnApproveTransfers_Click(object sender, EventArgs e)
        {
            UcPendingTransfers ucPendingTransfers = new UcPendingTransfers();
            ShowUserControl(ucPendingTransfers);
        }

        private void btnMaterialRequest_Click(object sender, EventArgs e)
        {
            UcCreateMaterialRequest uc = new UcCreateMaterialRequest();
            ShowUserControl(uc);
        }
    }
}