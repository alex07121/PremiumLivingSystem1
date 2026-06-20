using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;
using PLFC_Project;

namespace PremiumLivingSystem
{
    public partial class Inventory_Clerk_Form : MaterialForm
    {
        private Type currentUcType = null;

        public Inventory_Clerk_Form()
        {
            ApplyLanguage();
            InitializeComponent();
            SetupMaterialSkin();

            // 🔹 新增：初始化按鈕文字
            SetButtonTexts();

            UpdateStaffInfo();
            SetLanguageComboBoxValue();
            btnMasterCategory.Visible = UserSession.IsSupervisor;
            btnMasterProduct.Visible = UserSession.IsSupervisor;
            btnMasterSupplier.Visible = UserSession.IsSupervisor;
            btnRawMaterial.Visible = UserSession.IsSupervisor;
            btnApproveTransfers.Visible = UserSession.IsSupervisor;
        }

        private void SetupMaterialSkin()
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

        private void UpdateStaffInfo()
        {
            if (UserSession.CurrentCulture == "zh-Hans-HK")
            {
                string role = UserSession.IsSupervisor ? " (Supervisor)" : "";
                lblUserInfo.Text = "員工姓名: " + UserSession.CurrentName + role +
                                   "\n員工編號: (" + UserSession.CurrentStaffId + ")";
            }
            else
            {
                string role = UserSession.IsSupervisor ? " (Supervisor)" : "";
                lblUserInfo.Text = "Staff Name: " + UserSession.CurrentName + role +
                                   "\nStaff ID: (" + UserSession.CurrentStaffId + ")";
            }
            ApplyRoleVisibility();
        }

        private void ApplyRoleVisibility()
        {
            if (btnMasterSupplier != null)
                btnMasterSupplier.Visible = UserSession.IsSupervisor;
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

            if (UserSession.CurrentCulture == "zh-Hans-HK")
            {
                cmbLanguage.SelectedIndex = 1;
            }
            else
            {
                cmbLanguage.SelectedIndex = 0;
            }

            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
        }

        private void RefreshFormText()
        {
            ApplyLanguage();
            UpdateStaffInfo();
            SetLanguageComboBoxValue();

            // 🔹 新增：切換語言時更新按鈕文字
            SetButtonTexts();

            if (currentUcType != null)
            {
                UserControl newUc = (UserControl)Activator.CreateInstance(currentUcType);
                ShowUserControl(newUc);
            }
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedIndex == 0)
            {
                if (UserSession.CurrentCulture != "en")
                {
                    UserSession.CurrentCulture = "en";
                    RefreshFormText();
                }
            }
            else if (cmbLanguage.SelectedIndex == 1)
            {
                if (UserSession.CurrentCulture != "zh-Hans-HK")
                {
                    UserSession.CurrentCulture = "zh-Hans-HK";
                    RefreshFormText();
                }
            }
        }

        private void ShowUserControl(UserControl uc)
        {
            if (btnCreateProcurement != null)
            {
                btnCreateProcurement.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                btnCreateProcurement.Controls.Add(uc);
                currentUcType = uc.GetType();
            }
        }

        // 🔹 新增：集中管理所有按鈕文字
        private void SetButtonTexts()
        {
            bool isChinese = UserSession.CurrentCulture == "zh-Hans-HK";

            // 依截圖順序設定按鈕文字
            if (button4 != null)
                button4.Text = isChinese ? "入庫記錄" : "Record of inward goods";

            if (button1 != null)
                button1.Text = isChinese ? "搜尋產品" : "Search Product";

            if (btnMasterSupplier != null)
                btnMasterSupplier.Text = isChinese ? "供應商資料管理" : "Master Supplier";

            if (btnMasterProduct != null)
                btnMasterProduct.Text = isChinese ? "產品資料管理" : "Master Product";

            if (btnRawMaterial != null)
                btnRawMaterial.Text = isChinese ? "原材料資料管理" : "Master Raw Material";

            if (btnMasterCategory != null)
                btnMasterCategory.Text = isChinese ? "分類資料管理" : "Master Category";

          
            if (btnSearchProcurement != null)
                btnSearchProcurement.Text = isChinese ? "搜尋採購" : "Search Procurement";

            if (btnCreateProcur != null)
                btnCreateProcur.Text = isChinese ? "建立採購" : "Create Procurement";

            if (btnSearchMaterialRequest != null)
                btnSearchMaterialRequest.Text = isChinese ? "搜尋物料申請" : "Search Material Request";

            if (btnApproveTransfers != null)
                btnApproveTransfers.Text = isChinese ? "發出轉撥" : "Issue Transfers";

            if (btnCreateTransfer != null)
                btnCreateTransfer.Text = isChinese ? "建立轉撥" : "Create Transfer";

            if (btnApprovedTransfer != null)
                btnApprovedTransfer.Text = isChinese ? "已核准轉撥" : "Approved Transfer";

            if (button2 != null)
                button2.Text = isChinese ? "登出" : "Logout";
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
        }

        private void btnManageReturns_Click(object sender, EventArgs e)
        {
            UcProcessReturn uc = new UcProcessReturn();
            ShowUserControl(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string message;
            string title;

            if (UserSession.CurrentCulture == "zh-Hans-HK")
            {
                message = "您確定要登出嗎？";
                title = "確認登出";
            }
            else
            {
                message = "Are you sure you want to logout?";
                title = "Confirm Logout";
            }

            DialogResult result = MessageBox.Show(message, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.CurrentStaffId = null;
                UserSession.CurrentName = null;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UcRecordInwardGoods uc = new UcRecordInwardGoods();
            ShowUserControl(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcSearchProduct uc = new UcSearchProduct();
            ShowUserControl(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UcApproveTransfers uc = new UcApproveTransfers();
            ShowUserControl(uc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UcApproveTransfers uc = new UcApproveTransfers();
            ShowUserControl(uc);
        }

        private void btnMasterSupplier_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterSupplier());
        }

        private void btnMasterProduct_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterProduct());
        }

        private void btnMasterRawMaterial_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterRawMaterial());
        }

        private void btnMasterCategory_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterCategory());
        }

        private void btnMasterStaff_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsSupervisor)
            {
                MessageBox.Show("Only Supervisor can manage staff.");
                return;
            }
            ShowUserControl(new UcMasterStaff());
        }

        private void btnMasterStaff_Click_1(object sender, EventArgs e)
        {
            UcMasterSupplier ucMasterSupplier = new UcMasterSupplier();
            ShowUserControl(ucMasterSupplier);
        }

        private void btnMasterProduct_Click_1(object sender, EventArgs e)
        {
            UcMasterProduct ucMasterProduct = new UcMasterProduct();
            ShowUserControl(ucMasterProduct);
        }

        private void btnRawMaterial_Click(object sender, EventArgs e)
        {
            UcMasterRawMaterial ucMasterRawMaterial = new UcMasterRawMaterial();
            ShowUserControl(ucMasterRawMaterial);
        }

        private void btnMasterCategory_Click_1(object sender, EventArgs e)
        {
            UcMasterCategory ucMasterCategory = new UcMasterCategory();
            ShowUserControl(ucMasterCategory);
        }

        private void btnSearchProcurement_Click_1(object sender, EventArgs e)
        {
            UcSearchProcurement uc = new UcSearchProcurement();
            ShowUserControl(uc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UcCreateProcurement uc = new UcCreateProcurement();
            ShowUserControl(uc);
        }

        private void btnSearchMaterialRequest_Click(object sender, EventArgs e)
        {
            UcSearchMaterialRequest uc = new UcSearchMaterialRequest();
            ShowUserControl(uc);
        }

        private void btnApproveTransfers_Click(object sender, EventArgs e)
        {
            UcApproveTransfers uc = new UcApproveTransfers();
            ShowUserControl(uc);
        }

        private void btnCreateTransfer_Click(object sender, EventArgs e)
        {
            UcTransfer uc = new UcTransfer();
            ShowUserControl(uc);
        }

        private void btnApprovedTransfer_Click(object sender, EventArgs e)
        {
            UcPendingTransfers uc = new UcPendingTransfers();
            ShowUserControl(uc);
        }
    }
}