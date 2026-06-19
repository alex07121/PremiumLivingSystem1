namespace PremiumLivingSystem
{
    partial class UcMasterSupplier
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMasterSupplier));
            this.lvSuppliers = new System.Windows.Forms.ListView();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            resources.ApplyResources(this.lvSuppliers, "lvSuppliers");
            this.lvSuppliers.FullRowSelect = true;
            this.lvSuppliers.GridLines = true;
            this.lvSuppliers.HideSelection = false;
            this.lvSuppliers.Name = "lvSuppliers";
            this.lvSuppliers.UseCompatibleStateImageBehavior = false;
            this.lvSuppliers.View = System.Windows.Forms.View.Details;
            this.lvSuppliers.SelectedIndexChanged += new System.EventHandler(this.lvSuppliers_SelectedIndexChanged);
            resources.ApplyResources(this.lblID, "lblID");
            this.lblID.Name = "lblID";
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            resources.ApplyResources(this.lblPhone, "lblPhone");
            this.lblPhone.Name = "lblPhone";
            resources.ApplyResources(this.lblEmail, "lblEmail");
            this.lblEmail.Name = "lblEmail";
            resources.ApplyResources(this.txtID, "txtID");
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.Name = "txtPhone";
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lvSuppliers);
            this.Name = "UcMasterSupplier";
            this.Load += new System.EventHandler(this.UcMasterSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSuppliers;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
