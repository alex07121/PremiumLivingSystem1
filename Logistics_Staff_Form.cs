using PLFC_Project;
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
    public partial class Logistics_Staff_Form : MaterialForm
    {
        private Type currentUcType = null;

        public Logistics_Staff_Form()
        {
            ApplyLanguage();
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Teal800,      // 物流青色調
                Primary.Teal900,
                Primary.Teal500,
                Accent.Cyan200,
                TextShade.WHITE
            );

            // 🔹 新增：初始化按鈕文字
            SetButtonTexts();

            UpdateStaffInfo();
            SetLanguageComboBoxValue();
        }

        private void ShowUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
            currentUcType = uc.GetType();
        }

        // 🔹 新增：集中管理所有按鈕文字
        private void SetButtonTexts()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";

            // 根據您的按鈕名稱設定文字
            if (btnsearchd != null)
                btnsearchd.Text = isChinese ? "查詢送貨" : "Search Delivery";

            if (button1 != null)
                button1.Text = isChinese ? "搜尋追蹤記錄" : "Search Tracking";

            if (btnAddTrackRecord != null)
                btnAddTrackRecord.Text = isChinese ? "新增追蹤記錄" : "Add Tracking Record";

            if (button5 != null)
                button5.Text = isChinese ? "安排出貨" : "Arrange Shipment";

            if (btnHandGood != null)
                btnHandGood.Text = isChinese ? "客戶收貨確認" : "Handing Customer Good Received";

            if (button2 != null)
                button2.Text = isChinese ? "確認收貨" : "Handing Good Received";

            if (btnLogout != null)
                btnLogout.Text = isChinese ? "登出" : "Logout";
        }

        // ✅ 保留所有原有事件處理器
        private void button1_Click(object sender, EventArgs e)
        {
            UcAddNewTrackingRecord uc = new UcAddNewTrackingRecord();
            ShowUserControl(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string msg = UserSession.CurrentCulture == "zh-Hans-HK" ? "您確定要登出嗎？" : "Are you sure you want to logout?";
            string title = UserSession.CurrentCulture == "zh-Hans-HK" ? "確認登出" : "Confirm Logout";

            var confirm = MessageBox.Show(msg, title, MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                UserSession.CurrentStaffId = null;
                UserSession.CurrentName = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void UpdateStaffInfo()
        {
            if (UserSession.CurrentCulture == "zh-Hans-HK")
            {
                label2.Text = $"員工姓名: {UserSession.CurrentName} \n員工編號: ({UserSession.CurrentStaffId})";
            }
            else
            {
                label2.Text = $"Staff Name: {UserSession.CurrentName} \nStaff ID: ({UserSession.CurrentStaffId})";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UcSearchTracking uc = new UcSearchTracking();
            ShowUserControl(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UcSearchProduct uc = new UcSearchProduct();
            ShowUserControl(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UcArrangeShipment uc = new UcArrangeShipment();
            ShowUserControl(uc);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // 如果需要功能，在此加入
        }

        private void btnsearchd_Click(object sender, EventArgs e)
        {
            UcSearchDelivery uc = new UcSearchDelivery();
            ShowUserControl(uc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UcRecordInwardGoods uc = new UcRecordInwardGoods();
            ShowUserControl(uc);
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

            // 🔹 關鍵：切換語言時更新按鈕文字
            SetButtonTexts();

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

        private void btnHandGood_Click(object sender, EventArgs e)
        {
            UcConfirmGoodsReceived ucConfirmGoodsReceived = new UcConfirmGoodsReceived();
            ShowUserControl(ucConfirmGoodsReceived);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UcReceivableTransfers uc = new UcReceivableTransfers();
            ShowUserControl(uc);
        }
    }
}