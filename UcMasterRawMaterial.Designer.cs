namespace PremiumLivingSystem
{
    partial class UcMasterRawMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMasterRawMaterial));
            this.lvMaterials = new System.Windows.Forms.ListView();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblStockQty = new System.Windows.Forms.Label();
            this.lblReorder = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.txtReorder = new System.Windows.Forms.TextBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            resources.ApplyResources(this.lvMaterials, "lvMaterials");
            this.lvMaterials.FullRowSelect = true;
            this.lvMaterials.GridLines = true;
            this.lvMaterials.HideSelection = false;
            this.lvMaterials.Name = "lvMaterials";
            this.lvMaterials.UseCompatibleStateImageBehavior = false;
            this.lvMaterials.View = System.Windows.Forms.View.Details;
            this.lvMaterials.SelectedIndexChanged += new System.EventHandler(this.lvMaterials_SelectedIndexChanged);
            resources.ApplyResources(this.lblID, "lblID");
            this.lblID.Name = "lblID";
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            resources.ApplyResources(this.lblSupplier, "lblSupplier");
            this.lblSupplier.Name = "lblSupplier";
            resources.ApplyResources(this.lblUnit, "lblUnit");
            this.lblUnit.Name = "lblUnit";
            resources.ApplyResources(this.lblStockQty, "lblStockQty");
            this.lblStockQty.Name = "lblStockQty";
            resources.ApplyResources(this.lblReorder, "lblReorder");
            this.lblReorder.Name = "lblReorder";
            resources.ApplyResources(this.txtID, "txtID");
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            resources.ApplyResources(this.txtUnit, "txtUnit");
            this.txtUnit.Name = "txtUnit";
            resources.ApplyResources(this.txtStockQty, "txtStockQty");
            this.txtStockQty.Name = "txtStockQty";
            resources.ApplyResources(this.txtReorder, "txtReorder");
            this.txtReorder.Name = "txtReorder";
            resources.ApplyResources(this.cmbSupplier, "cmbSupplier");
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Name = "cmbSupplier";
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
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.txtReorder);
            this.Controls.Add(this.txtStockQty);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblReorder);
            this.Controls.Add(this.lblStockQty);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lvMaterials);
            this.Name = "UcMasterRawMaterial";
            this.Load += new System.EventHandler(this.UcMasterRawMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMaterials;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblStockQty;
        private System.Windows.Forms.Label lblReorder;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.TextBox txtReorder;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
