namespace PremiumLivingSystem
{
    partial class UcCreateProcurement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCreateProcurement));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.txtPurchaseOrderID = new System.Windows.Forms.TextBox();
            this.lblPurchaseOrderID = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.txtReqByID = new System.Windows.Forms.TextBox();
            this.lblReqByID = new System.Windows.Forms.Label();
            this.txtReqName = new System.Windows.Forms.TextBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.lblStockHint = new System.Windows.Forms.Label();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // grpHeader
            // 
            resources.ApplyResources(this.grpHeader, "grpHeader");
            this.grpHeader.Controls.Add(this.txtPurchaseOrderID);
            this.grpHeader.Controls.Add(this.lblPurchaseOrderID);
            this.grpHeader.Controls.Add(this.dtpOrderDate);
            this.grpHeader.Controls.Add(this.lblOrderDate);
            this.grpHeader.Controls.Add(this.dtpExpectedDate);
            this.grpHeader.Controls.Add(this.lblExpectedDate);
            this.grpHeader.Controls.Add(this.cmbSupplier);
            this.grpHeader.Controls.Add(this.lblSupplier);
            this.grpHeader.Controls.Add(this.cmbPaymentMethod);
            this.grpHeader.Controls.Add(this.lblPaymentMethod);
            this.grpHeader.Controls.Add(this.txtReqByID);
            this.grpHeader.Controls.Add(this.lblReqByID);
            this.grpHeader.Controls.Add(this.txtReqName);
            this.grpHeader.Controls.Add(this.lblReqName);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.TabStop = false;
            // 
            // txtPurchaseOrderID
            // 
            resources.ApplyResources(this.txtPurchaseOrderID, "txtPurchaseOrderID");
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.ReadOnly = true;
            // 
            // lblPurchaseOrderID
            // 
            resources.ApplyResources(this.lblPurchaseOrderID, "lblPurchaseOrderID");
            this.lblPurchaseOrderID.Name = "lblPurchaseOrderID";
            // 
            // dtpOrderDate
            // 
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Name = "dtpOrderDate";
            // 
            // lblOrderDate
            // 
            resources.ApplyResources(this.lblOrderDate, "lblOrderDate");
            this.lblOrderDate.Name = "lblOrderDate";
            // 
            // dtpExpectedDate
            // 
            resources.ApplyResources(this.dtpExpectedDate, "dtpExpectedDate");
            this.dtpExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedDate.MinDate = new System.DateTime(2026, 6, 19, 0, 0, 0, 0);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            // 
            // lblExpectedDate
            // 
            resources.ApplyResources(this.lblExpectedDate, "lblExpectedDate");
            this.lblExpectedDate.Name = "lblExpectedDate";
            // 
            // cmbSupplier
            // 
            resources.ApplyResources(this.cmbSupplier, "cmbSupplier");
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Name = "cmbSupplier";
            // 
            // lblSupplier
            // 
            resources.ApplyResources(this.lblSupplier, "lblSupplier");
            this.lblSupplier.Name = "lblSupplier";
            // 
            // cmbPaymentMethod
            // 
            resources.ApplyResources(this.cmbPaymentMethod, "cmbPaymentMethod");
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            resources.GetString("cmbPaymentMethod.Items"),
            resources.GetString("cmbPaymentMethod.Items1"),
            resources.GetString("cmbPaymentMethod.Items2"),
            resources.GetString("cmbPaymentMethod.Items3"),
            resources.GetString("cmbPaymentMethod.Items4")});
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            // 
            // lblPaymentMethod
            // 
            resources.ApplyResources(this.lblPaymentMethod, "lblPaymentMethod");
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            // 
            // txtReqByID
            // 
            resources.ApplyResources(this.txtReqByID, "txtReqByID");
            this.txtReqByID.Name = "txtReqByID";
            this.txtReqByID.ReadOnly = true;
            // 
            // lblReqByID
            // 
            resources.ApplyResources(this.lblReqByID, "lblReqByID");
            this.lblReqByID.Name = "lblReqByID";
            // 
            // txtReqName
            // 
            resources.ApplyResources(this.txtReqName, "txtReqName");
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.ReadOnly = true;
            // 
            // lblReqName
            // 
            resources.ApplyResources(this.lblReqName, "lblReqName");
            this.lblReqName.Name = "lblReqName";
            // 
            // grpItems
            // 
            resources.ApplyResources(this.grpItems, "grpItems");
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Controls.Add(this.cmbMaterial);
            this.grpItems.Controls.Add(this.lblMaterial);
            this.grpItems.Controls.Add(this.nudQuantity);
            this.grpItems.Controls.Add(this.lblQuantity);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Controls.Add(this.lblStockHint);
            this.grpItems.Name = "grpItems";
            this.grpItems.TabStop = false;
            // 
            // dgvItems
            // 
            resources.ApplyResources(this.dgvItems, "dgvItems");
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // cmbMaterial
            // 
            resources.ApplyResources(this.cmbMaterial, "cmbMaterial");
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.Name = "cmbMaterial";
            // 
            // lblMaterial
            // 
            resources.ApplyResources(this.lblMaterial, "lblMaterial");
            this.lblMaterial.Name = "lblMaterial";
            // 
            // nudQuantity
            // 
            resources.ApplyResources(this.nudQuantity, "nudQuantity");
            this.nudQuantity.DecimalPlaces = 2;
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Name = "lblQuantity";
            // 
            // btnAddRow
            // 
            resources.ApplyResources(this.btnAddRow, "btnAddRow");
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.UseVisualStyleBackColor = false;
            // 
            // btnRemoveRow
            // 
            resources.ApplyResources(this.btnRemoveRow, "btnRemoveRow");
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            // 
            // lblStockHint
            // 
            resources.ApplyResources(this.lblStockHint, "lblStockHint");
            this.lblStockHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(110)))), ((int)(((byte)(60)))));
            this.lblStockHint.Name = "lblStockHint";
            // 
            // grpTotals
            // 
            resources.ApplyResources(this.grpTotals, "grpTotals");
            this.grpTotals.Controls.Add(this.lblSubTotal);
            this.grpTotals.Controls.Add(this.txtSubTotal);
            this.grpTotals.Controls.Add(this.lblTotal);
            this.grpTotals.Controls.Add(this.txtTotal);
            this.grpTotals.Controls.Add(this.lblRemarks);
            this.grpTotals.Controls.Add(this.txtRemarks);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.TabStop = false;
            // 
            // lblSubTotal
            // 
            resources.ApplyResources(this.lblSubTotal, "lblSubTotal");
            this.lblSubTotal.Name = "lblSubTotal";
            // 
            // txtSubTotal
            // 
            resources.ApplyResources(this.txtSubTotal, "txtSubTotal");
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.Name = "lblTotal";
            // 
            // txtTotal
            // 
            resources.ApplyResources(this.txtTotal, "txtTotal");
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            // 
            // lblRemarks
            // 
            resources.ApplyResources(this.lblRemarks, "lblRemarks");
            this.lblRemarks.Name = "lblRemarks";
            // 
            // txtRemarks
            // 
            resources.ApplyResources(this.txtRemarks, "txtRemarks");
            this.txtRemarks.Name = "txtRemarks";
            // 
            // btnSaveDraft
            // 
            resources.ApplyResources(this.btnSaveDraft, "btnSaveDraft");
            this.btnSaveDraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnSaveDraft.ForeColor = System.Drawing.Color.White;
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // UcCreateProcurement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.grpTotals);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcCreateProcurement";
            this.Load += new System.EventHandler(this.UcCreateProcurement_Load);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpTotals.ResumeLayout(false);
            this.grpTotals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.TextBox txtPurchaseOrderID;
        private System.Windows.Forms.Label lblPurchaseOrderID;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedDate;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.TextBox txtReqByID;
        private System.Windows.Forms.Label lblReqByID;
        private System.Windows.Forms.TextBox txtReqName;
        private System.Windows.Forms.Label lblReqName;

        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Label lblStockHint;

        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;

        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
    }
}
