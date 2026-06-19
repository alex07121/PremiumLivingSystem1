namespace PremiumLivingSystem
{
    partial class UcMasterCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMasterCustomer));
            this.lvCustomers = new System.Windows.Forms.ListView();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            resources.ApplyResources(this.lvCustomers, "lvCustomers");
            this.lvCustomers.FullRowSelect = true;
            this.lvCustomers.GridLines = true;
            this.lvCustomers.HideSelection = false;
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.UseCompatibleStateImageBehavior = false;
            this.lvCustomers.View = System.Windows.Forms.View.Details;
            this.lvCustomers.SelectedIndexChanged += new System.EventHandler(this.lvCustomers_SelectedIndexChanged);
            resources.ApplyResources(this.lblID, "lblID");
            this.lblID.Name = "lblID";
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            resources.ApplyResources(this.lblPhone, "lblPhone");
            this.lblPhone.Name = "lblPhone";
            resources.ApplyResources(this.lblEmail, "lblEmail");
            this.lblEmail.Name = "lblEmail";
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            resources.ApplyResources(this.txtID, "txtID");
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.Name = "txtPhone";
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.Name = "txtAddress";
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            resources.GetString("cmbType.Items"),
            resources.GetString("cmbType.Items1")});
            this.cmbType.Name = "cmbType";
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
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lvCustomers);
            this.Name = "UcMasterCustomer";
            this.Load += new System.EventHandler(this.UcMasterCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCustomers;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
