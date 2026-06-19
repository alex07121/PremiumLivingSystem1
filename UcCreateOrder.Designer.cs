namespace PremiumLivingSystem
{
    partial class UcCreateOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCreateOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddStandard = new System.Windows.Forms.Button();
            this.btnAddCustom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.cmbCustomer, "cmbCustomer");
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Name = "cmbCustomer";
            resources.ApplyResources(this.cmbProduct, "cmbProduct");
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            resources.ApplyResources(this.numQuantity, "numQuantity");
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            resources.ApplyResources(this.dtpRequiredDate, "dtpRequiredDate");
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            resources.ApplyResources(this.txtUnitPrice, "txtUnitPrice");
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            resources.ApplyResources(this.btnAddStandard, "btnAddStandard");
            this.btnAddStandard.Name = "btnAddStandard";
            this.btnAddStandard.UseVisualStyleBackColor = true;
            this.btnAddStandard.Click += new System.EventHandler(this.btnAddStandard_Click);
            resources.ApplyResources(this.btnAddCustom, "btnAddCustom");
            this.btnAddCustom.Name = "btnAddCustom";
            this.btnAddCustom.UseVisualStyleBackColor = true;
            this.btnAddCustom.Click += new System.EventHandler(this.btnAddCustom_Click);
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.dgvCart, "dgvCart");
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowTemplate.Height = 42;
            resources.ApplyResources(this.btnSubmitOrder, "btnSubmitOrder");
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            resources.ApplyResources(this.txtStock, "txtStock");
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            resources.ApplyResources(this.cboCategory, "cboCategory");
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            resources.ApplyResources(this.lblTotalAmount, "lblTotalAmount");
            this.lblTotalAmount.Name = "lblTotalAmount";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnSubmitOrder);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddCustom);
            this.Controls.Add(this.btnAddStandard);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpRequiredDate);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label1);
            this.Name = "UcCreateOrder";
            this.Load += new System.EventHandler(this.UcCreateOrder1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAddStandard;
        private System.Windows.Forms.Button btnAddCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}
