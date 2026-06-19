using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;

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
            UpdateStaffInfo();      
            SetLanguageComboBoxValue();
            btnMasterCategory.Visible = UserSession.IsSupervisor;
            btnMasterProduct.Visible = UserSession.IsSupervisor;
            btnMasterSupplier.Visible = UserSession.IsSupervisor;
            btnRawMaterial.Visible = UserSession.IsSupervisor;
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
            // Supervisor-only: Staff management
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
            if (mainPanel != null)
            {
                mainPanel.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(uc);
                currentUcType = uc.GetType();
            }
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
            UcApprovedTransfers uc = new UcApprovedTransfers();
            ShowUserControl(uc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UcApprovedTransfers uc = new UcApprovedTransfers();
            ShowUserControl(uc);
        }

        // Master Data — Supplier
        private void btnMasterSupplier_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterSupplier());
        }

        // Master Data — Product
        private void btnMasterProduct_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterProduct());
        }

        // Master Data — Raw Material
        private void btnMasterRawMaterial_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterRawMaterial());
        }

        // Master Data — Product Category
        private void btnMasterCategory_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UcMasterCategory());
        }

        // Master Data — Staff (Supervisor only)
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
    }
}