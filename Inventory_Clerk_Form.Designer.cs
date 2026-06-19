namespace PremiumLivingSystem
{
    partial class Inventory_Clerk_Form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory_Clerk_Form));
            this.button2 = new System.Windows.Forms.Button();
            this.btnManageReturns = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnMasterCategory = new System.Windows.Forms.Button();
            this.btnRawMaterial = new System.Windows.Forms.Button();
            this.btnMasterProduct = new System.Windows.Forms.Button();
            this.btnMasterSupplier = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLogout_Click);
            resources.ApplyResources(this.btnManageReturns, "btnManageReturns");
            this.btnManageReturns.Name = "btnManageReturns";
            this.btnManageReturns.UseVisualStyleBackColor = true;
            this.btnManageReturns.Click += new System.EventHandler(this.btnManageReturns_Click);
            resources.ApplyResources(this.lblUserInfo, "lblUserInfo");
            this.lblUserInfo.Name = "lblUserInfo";
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Controls.Add(this.btnMasterCategory);
            this.pnlSidebar.Controls.Add(this.btnRawMaterial);
            this.pnlSidebar.Controls.Add(this.btnMasterProduct);
            this.pnlSidebar.Controls.Add(this.btnMasterSupplier);
            this.pnlSidebar.Controls.Add(this.button5);
            this.pnlSidebar.Controls.Add(this.button3);
            this.pnlSidebar.Controls.Add(this.button1);
            this.pnlSidebar.Controls.Add(this.button4);
            this.pnlSidebar.Controls.Add(this.btnManageReturns);
            resources.ApplyResources(this.pnlSidebar, "pnlSidebar");
            this.pnlSidebar.Name = "pnlSidebar";
            resources.ApplyResources(this.btnMasterCategory, "btnMasterCategory");
            this.btnMasterCategory.Name = "btnMasterCategory";
            this.btnMasterCategory.UseVisualStyleBackColor = true;
            this.btnMasterCategory.Click += new System.EventHandler(this.btnMasterCategory_Click_1);
            resources.ApplyResources(this.btnRawMaterial, "btnRawMaterial");
            this.btnRawMaterial.Name = "btnRawMaterial";
            this.btnRawMaterial.UseVisualStyleBackColor = true;
            this.btnRawMaterial.Click += new System.EventHandler(this.btnRawMaterial_Click);
            resources.ApplyResources(this.btnMasterProduct, "btnMasterProduct");
            this.btnMasterProduct.Name = "btnMasterProduct";
            this.btnMasterProduct.UseVisualStyleBackColor = true;
            this.btnMasterProduct.Click += new System.EventHandler(this.btnMasterProduct_Click_1);
            resources.ApplyResources(this.btnMasterSupplier, "btnMasterSupplier");
            this.btnMasterSupplier.Name = "btnMasterSupplier";
            this.btnMasterSupplier.UseVisualStyleBackColor = true;
            this.btnMasterSupplier.Click += new System.EventHandler(this.btnMasterStaff_Click_1);
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.mainPanel.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.label1);
            this.Name = "Inventory_Clerk_Form";
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnManageReturns;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnMasterSupplier;
        private System.Windows.Forms.Button btnMasterCategory;
        private System.Windows.Forms.Button btnRawMaterial;
        private System.Windows.Forms.Button btnMasterProduct;
    }
}