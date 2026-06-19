namespace PremiumLivingSystem
{
    partial class EditOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOrderForm));
            this.lblOrderID = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblSalesStaffID = new System.Windows.Forms.Label();
            this.txtSalesStaffID = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.ListView();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.btnAddCustomProduct = new System.Windows.Forms.Button();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.lblOrderID, "lblOrderID");
            this.lblOrderID.Name = "lblOrderID";
            resources.ApplyResources(this.txtOrderID, "txtOrderID");
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            resources.ApplyResources(this.lblCustomerID, "lblCustomerID");
            this.lblCustomerID.Name = "lblCustomerID";
            resources.ApplyResources(this.txtCustomerID, "txtCustomerID");
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            resources.ApplyResources(this.lblSalesStaffID, "lblSalesStaffID");
            this.lblSalesStaffID.Name = "lblSalesStaffID";
            resources.ApplyResources(this.txtSalesStaffID, "txtSalesStaffID");
            this.txtSalesStaffID.Name = "txtSalesStaffID";
            this.txtSalesStaffID.ReadOnly = true;
            resources.ApplyResources(this.lblOrderDate, "lblOrderDate");
            this.lblOrderDate.Name = "lblOrderDate";
            resources.ApplyResources(this.lblRequiredDate, "lblRequiredDate");
            this.lblRequiredDate.Name = "lblRequiredDate";
            resources.ApplyResources(this.dtpRequiredDate, "dtpRequiredDate");
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            resources.GetString("cboStatus.Items"),
            resources.GetString("cboStatus.Items1"),
            resources.GetString("cboStatus.Items2"),
            resources.GetString("cboStatus.Items3"),
            resources.GetString("cboStatus.Items4"),
            resources.GetString("cboStatus.Items5")});
            resources.ApplyResources(this.cboStatus, "cboStatus");
            this.cboStatus.Name = "cboStatus";
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.dgvItems.HideSelection = false;
            resources.ApplyResources(this.dgvItems, "dgvItems");
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.UseCompatibleStateImageBehavior = false;
            this.dgvItems.View = System.Windows.Forms.View.Details;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCategory, "cmbCategory");
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            resources.ApplyResources(this.cmbProduct, "cmbProduct");
            this.cmbProduct.Name = "cmbProduct";
            resources.ApplyResources(this.btnAddProduct, "btnAddProduct");
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            resources.ApplyResources(this.btnDeleteProduct, "btnDeleteProduct");
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            resources.ApplyResources(this.lblCategory, "lblCategory");
            this.lblCategory.Name = "lblCategory";
            resources.ApplyResources(this.lblProduct, "lblProduct");
            this.lblProduct.Name = "lblProduct";
            resources.ApplyResources(this.lblQty, "lblQty");
            this.lblQty.Name = "lblQty";
            resources.ApplyResources(this.btnAddCustomProduct, "btnAddCustomProduct");
            this.btnAddCustomProduct.Name = "btnAddCustomProduct";
            this.btnAddCustomProduct.UseVisualStyleBackColor = true;
            this.btnAddCustomProduct.Click += new System.EventHandler(this.btnAddCustomProduct_Click);
            resources.ApplyResources(this.txtOrderDate, "txtOrderDate");
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            resources.ApplyResources(this.numQuantity, "numQuantity");
            this.numQuantity.Name = "numQuantity";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnAddCustomProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.lblRequiredDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.txtSalesStaffID);
            this.Controls.Add(this.lblSalesStaffID);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lblOrderID);
            this.Name = "EditOrderForm";
            this.Load += new System.EventHandler(this.EditOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblSalesStaffID;
        private System.Windows.Forms.TextBox txtSalesStaffID;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListView dgvItems;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnAddCustomProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.NumericUpDown numQuantity;
    }
}