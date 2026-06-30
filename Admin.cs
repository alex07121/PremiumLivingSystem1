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
    // ✅ 改為繼承 MaterialForm
    public partial class Admin : MaterialForm
    {
        private Type currentUcType = null;

        public Admin()
        {
            ApplyLanguage();
            InitializeComponent();
            InitializeLanguageComboBox();
            SetupMaterialSkin();

            // 🔹 初始化按鈕文字
            SetButtonTexts();

            UpdateAdminInfo();
            SetLanguageComboBoxValue();
        }

        // 🔹 設定 MaterialSkin 主題
        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // 🎨 管理員使用紅色系 (Red)，代表權限與重要性
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red500,
                Accent.Red200,
                TextShade.WHITE
            );
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

        // 🔹 更新管理員資訊
        private void UpdateAdminInfo()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";

            if (label2 != null)
            {
                label2.Text = isChinese
                    ? $"管理員: {UserSession.CurrentName}\n員工編號: ({UserSession.CurrentStaffId})"
                    : $"Admin: {UserSession.CurrentName}\nStaff ID: ({UserSession.CurrentStaffId})";
            }
        }

        // 🔹 集中管理所有按鈕文字
        private void SetButtonTexts()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";

            if (btnLogout != null)
                btnLogout.Text = isChinese ? "登出" : "Logout";

            if (btnSalesReport != null)
                btnSalesReport.Text = isChinese ? "銷售總結報告" : "Sales Summary Report";

            if (button1 != null)
                button1.Text = isChinese ? "更新員工資料" : "Update Staff";
        }

        // 🔹 套用語言設定
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

        // 🔹 設定語言下拉選單初始值
        private void InitializeLanguageComboBox()
        {
            if (cmbLanguage == null || cmbLanguage.Items.Count > 0)
                return;

            cmbLanguage.Items.Add("English");
            cmbLanguage.Items.Add("中文");
        }

        private void SetLanguageComboBoxValue()
        {
            if (cmbLanguage != null)
            {
                InitializeLanguageComboBox();
                cmbLanguage.SelectedIndexChanged -= cmbLanguage_SelectedIndexChanged;
                cmbLanguage.SelectedIndex = UserSession.CurrentCulture == "zh-Hans-HK" ? 1 : 0;
                cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            }
        }

        // 🔹 刷新表單文字
        private void RefreshFormText()
        {
            ApplyLanguage();
            UpdateAdminInfo();
            SetLanguageComboBoxValue();
            SetButtonTexts();

            if (currentUcType != null)
            {
                UserControl refreshedUc = (UserControl)Activator.CreateInstance(currentUcType);
                ShowUserControl(refreshedUc);
            }
        }

        // 🔹 語言切換事件
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
