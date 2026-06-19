namespace PremiumLivingSystem
{
    partial class UcTransfer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcTransfer));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTransferNo = new System.Windows.Forms.Label();
            this.txtTransferNo = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbMaterial = new System.Windows.Forms.RadioButton();
            this.grpRequestor = new System.Windows.Forms.GroupBox();
            this.lblReqPhone = new System.Windows.Forms.Label();
            this.txtReqPhone = new System.Windows.Forms.TextBox();
            this.lblReqPos = new System.Windows.Forms.Label();
            this.txtReqPos = new System.Windows.Forms.TextBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.txtReqName = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.grpAuth = new System.Windows.Forms.GroupBox();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.cmbReceivedBy = new System.Windows.Forms.ComboBox();
            this.lblReceivedBy = new System.Windows.Forms.Label();
            this.dtpApprovedDate = new System.Windows.Forms.DateTimePicker();
            this.lblApprovedDate = new System.Windows.Forms.Label();
            this.cmbApprovedBy = new System.Windows.Forms.ComboBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.dtpReqDate = new System.Windows.Forms.DateTimePicker();
            this.lblReqDate = new System.Windows.Forms.Label();
            this.txtReqBy = new System.Windows.Forms.TextBox();
            this.lblReqBy = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtToLocation = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtFromLocation = new System.Windows.Forms.TextBox();
            this.grpInventory = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.dtpIssuedDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssuedDate = new System.Windows.Forms.Label();
            this.cmbIssuedBy = new System.Windows.Forms.ComboBox();
            this.lblIssuedBy = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpType.SuspendLayout();
            this.grpRequestor.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.grpAuth.SuspendLayout();
            this.grpInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblTransferNo
            // 
            resources.ApplyResources(this.lblTransferNo, "lblTransferNo");
            this.lblTransferNo.Name = "lblTransferNo";
            // 
            // txtTransferNo
            // 
            resources.ApplyResources(this.txtTransferNo, "txtTransferNo");
            this.txtTransferNo.Name = "txtTransferNo";
            this.txtTransferNo.ReadOnly = true;
            this.txtTransferNo.TabStop = false;
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpTransferDate, "dtpTransferDate");
            this.dtpTransferDate.Name = "dtpTransferDate";
            // 
            // lblOrderID
            // 
            resources.ApplyResources(this.lblOrderID, "lblOrderID");
            this.lblOrderID.Name = "lblOrderID";
            // 
            // txtOrderID
            // 
            resources.ApplyResources(this.txtOrderID, "txtOrderID");
            this.txtOrderID.Name = "txtOrderID";
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rbProduct);
            this.grpType.Controls.Add(this.rbMaterial);
            resources.ApplyResources(this.grpType, "grpType");
            this.grpType.Name = "grpType";
            this.grpType.TabStop = false;
            // 
            // rbProduct
            // 
            resources.ApplyResources(this.rbProduct, "rbProduct");
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.CheckedChanged += new System.EventHandler(this.rbProduct_CheckedChanged);
            // 
            // rbMaterial
            // 
            resources.ApplyResources(this.rbMaterial, "rbMaterial");
            this.rbMaterial.Checked = true;
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.TabStop = true;
            this.rbMaterial.CheckedChanged += new System.EventHandler(this.rbMaterial_CheckedChanged);
            // 
            // grpRequestor
            // 
            this.grpRequestor.Controls.Add(this.lblReqPhone);
            this.grpRequestor.Controls.Add(this.txtReqPhone);
            this.grpRequestor.Controls.Add(this.lblReqPos);
            this.grpRequestor.Controls.Add(this.txtReqPos);
            this.grpRequestor.Controls.Add(this.lblReqName);
            this.grpRequestor.Controls.Add(this.txtReqName);
            resources.ApplyResources(this.grpRequestor, "grpRequestor");
            this.grpRequestor.Name = "grpRequestor";
            this.grpRequestor.TabStop = false;
            // 
            // lblReqPhone
            // 
            resources.ApplyResources(this.lblReqPhone, "lblReqPhone");
            this.lblReqPhone.Name = "lblReqPhone";
            // 
            // txtReqPhone
            // 
            resources.ApplyResources(this.txtReqPhone, "txtReqPhone");
            this.txtReqPhone.Name = "txtReqPhone";
            this.txtReqPhone.ReadOnly = true;
            // 
            // lblReqPos
            // 
            resources.ApplyResources(this.lblReqPos, "lblReqPos");
            this.lblReqPos.Name = "lblReqPos";
            // 
            // txtReqPos
            // 
            resources.ApplyResources(this.txtReqPos, "txtReqPos");
            this.txtReqPos.Name = "txtReqPos";
            this.txtReqPos.ReadOnly = true;
            // 
            // lblReqName
            // 
            resources.ApplyResources(this.lblReqName, "lblReqName");
            this.lblReqName.Name = "lblReqName";
            // 
            // txtReqName
            // 
            resources.ApplyResources(this.txtReqName, "txtReqName");
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.ReadOnly = true;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.nudQty);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.lblQty);
            this.grpItems.Controls.Add(this.lblItem);
            this.grpItems.Controls.Add(this.dgvItems);
            resources.ApplyResources(this.grpItems, "grpItems");
            this.grpItems.Name = "grpItems";
            this.grpItems.TabStop = false;
            // 
            // btnRemoveRow
            // 
            resources.ApplyResources(this.btnRemoveRow, "btnRemoveRow");
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddRow
            // 
            resources.ApplyResources(this.btnAddRow, "btnAddRow");
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // nudQty
            // 
            this.nudQty.DecimalPlaces = 2;
            resources.ApplyResources(this.nudQty, "nudQty");
            this.nudQty.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FormattingEnabled = true;
            resources.ApplyResources(this.cmbItem, "cmbItem");
            this.cmbItem.Name = "cmbItem";
            // 
            // lblQty
            // 
            resources.ApplyResources(this.lblQty, "lblQty");
            this.lblQty.Name = "lblQty";
            // 
            // lblItem
            // 
            resources.ApplyResources(this.lblItem, "lblItem");
            this.lblItem.Name = "lblItem";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvItems, "dgvItems");
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // grpAuth
            // 
            this.grpAuth.Controls.Add(this.dtpReceivedDate);
            this.grpAuth.Controls.Add(this.lblReceivedDate);
            this.grpAuth.Controls.Add(this.cmbReceivedBy);
            this.grpAuth.Controls.Add(this.lblReceivedBy);
            this.grpAuth.Controls.Add(this.dtpApprovedDate);
            this.grpAuth.Controls.Add(this.lblApprovedDate);
            this.grpAuth.Controls.Add(this.cmbApprovedBy);
            this.grpAuth.Controls.Add(this.lblApprovedBy);
            this.grpAuth.Controls.Add(this.dtpReqDate);
            this.grpAuth.Controls.Add(this.lblReqDate);
            this.grpAuth.Controls.Add(this.txtReqBy);
            this.grpAuth.Controls.Add(this.lblReqBy);
            this.grpAuth.Controls.Add(this.lblTo);
            this.grpAuth.Controls.Add(this.txtToLocation);
            this.grpAuth.Controls.Add(this.lblFrom);
            this.grpAuth.Controls.Add(this.txtFromLocation);
            resources.ApplyResources(this.grpAuth, "grpAuth");
            this.grpAuth.Name = "grpAuth";
            this.grpAuth.TabStop = false;
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpReceivedDate, "dtpReceivedDate");
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            // 
            // lblReceivedDate
            // 
            resources.ApplyResources(this.lblReceivedDate, "lblReceivedDate");
            this.lblReceivedDate.Name = "lblReceivedDate";
            // 
            // cmbReceivedBy
            // 
            this.cmbReceivedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceivedBy.FormattingEnabled = true;
            resources.ApplyResources(this.cmbReceivedBy, "cmbReceivedBy");
            this.cmbReceivedBy.Name = "cmbReceivedBy";
            // 
            // lblReceivedBy
            // 
            resources.ApplyResources(this.lblReceivedBy, "lblReceivedBy");
            this.lblReceivedBy.Name = "lblReceivedBy";
            // 
            // dtpApprovedDate
            // 
            this.dtpApprovedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpApprovedDate, "dtpApprovedDate");
            this.dtpApprovedDate.Name = "dtpApprovedDate";
            // 
            // lblApprovedDate
            // 
            resources.ApplyResources(this.lblApprovedDate, "lblApprovedDate");
            this.lblApprovedDate.Name = "lblApprovedDate";
            // 
            // cmbApprovedBy
            // 
            this.cmbApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovedBy.FormattingEnabled = true;
            resources.ApplyResources(this.cmbApprovedBy, "cmbApprovedBy");
            this.cmbApprovedBy.Name = "cmbApprovedBy";
            // 
            // lblApprovedBy
            // 
            resources.ApplyResources(this.lblApprovedBy, "lblApprovedBy");
            this.lblApprovedBy.Name = "lblApprovedBy";
            // 
            // dtpReqDate
            // 
            this.dtpReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpReqDate, "dtpReqDate");
            this.dtpReqDate.Name = "dtpReqDate";
            // 
            // lblReqDate
            // 
            resources.ApplyResources(this.lblReqDate, "lblReqDate");
            this.lblReqDate.Name = "lblReqDate";
            // 
            // txtReqBy
            // 
            resources.ApplyResources(this.txtReqBy, "txtReqBy");
            this.txtReqBy.Name = "txtReqBy";
            this.txtReqBy.ReadOnly = true;
            // 
            // lblReqBy
            // 
            resources.ApplyResources(this.lblReqBy, "lblReqBy");
            this.lblReqBy.Name = "lblReqBy";
            // 
            // lblTo
            // 
            resources.ApplyResources(this.lblTo, "lblTo");
            this.lblTo.Name = "lblTo";
            // 
            // txtToLocation
            // 
            resources.ApplyResources(this.txtToLocation, "txtToLocation");
            this.txtToLocation.Name = "txtToLocation";
            // 
            // lblFrom
            // 
            resources.ApplyResources(this.lblFrom, "lblFrom");
            this.lblFrom.Name = "lblFrom";
            // 
            // txtFromLocation
            // 
            resources.ApplyResources(this.txtFromLocation, "txtFromLocation");
            this.txtFromLocation.Name = "txtFromLocation";
            // 
            // grpInventory
            // 
            this.grpInventory.Controls.Add(this.txtRemarks);
            this.grpInventory.Controls.Add(this.lblRemarks);
            this.grpInventory.Controls.Add(this.dtpIssuedDate);
            this.grpInventory.Controls.Add(this.lblIssuedDate);
            this.grpInventory.Controls.Add(this.cmbIssuedBy);
            this.grpInventory.Controls.Add(this.lblIssuedBy);
            resources.ApplyResources(this.grpInventory, "grpInventory");
            this.grpInventory.Name = "grpInventory";
            this.grpInventory.TabStop = false;
            // 
            // txtRemarks
            // 
            resources.ApplyResources(this.txtRemarks, "txtRemarks");
            this.txtRemarks.Name = "txtRemarks";
            // 
            // lblRemarks
            // 
            resources.ApplyResources(this.lblRemarks, "lblRemarks");
            this.lblRemarks.Name = "lblRemarks";
            // 
            // dtpIssuedDate
            // 
            this.dtpIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpIssuedDate, "dtpIssuedDate");
            this.dtpIssuedDate.Name = "dtpIssuedDate";
            // 
            // lblIssuedDate
            // 
            resources.ApplyResources(this.lblIssuedDate, "lblIssuedDate");
            this.lblIssuedDate.Name = "lblIssuedDate";
            // 
            // cmbIssuedBy
            // 
            this.cmbIssuedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIssuedBy.FormattingEnabled = true;
            resources.ApplyResources(this.cmbIssuedBy, "cmbIssuedBy");
            this.cmbIssuedBy.Name = "cmbIssuedBy";
            // 
            // lblIssuedBy
            // 
            resources.ApplyResources(this.lblIssuedBy, "lblIssuedBy");
            this.lblIssuedBy.Name = "lblIssuedBy";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // UcTransfer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grpInventory);
            this.Controls.Add(this.grpAuth);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpRequestor);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.dtpTransferDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtTransferNo);
            this.Controls.Add(this.lblTransferNo);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcTransfer";
            this.Load += new System.EventHandler(this.UcTransfer_Load);
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpRequestor.ResumeLayout(false);
            this.grpRequestor.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.grpAuth.ResumeLayout(false);
            this.grpAuth.PerformLayout();
            this.grpInventory.ResumeLayout(false);
            this.grpInventory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTransferNo;
        private System.Windows.Forms.TextBox txtTransferNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransferDate;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbMaterial;
        private System.Windows.Forms.GroupBox grpRequestor;
        private System.Windows.Forms.Label lblReqName;
        private System.Windows.Forms.TextBox txtReqName;
        private System.Windows.Forms.Label lblReqPos;
        private System.Windows.Forms.TextBox txtReqPos;
        private System.Windows.Forms.Label lblReqPhone;
        private System.Windows.Forms.TextBox txtReqPhone;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox grpAuth;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtFromLocation;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtToLocation;
        private System.Windows.Forms.Label lblReqBy;
        private System.Windows.Forms.TextBox txtReqBy;
        private System.Windows.Forms.Label lblReqDate;
        private System.Windows.Forms.DateTimePicker dtpReqDate;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.ComboBox cmbApprovedBy;
        private System.Windows.Forms.Label lblApprovedDate;
        private System.Windows.Forms.DateTimePicker dtpApprovedDate;
        private System.Windows.Forms.Label lblReceivedBy;
        private System.Windows.Forms.ComboBox cmbReceivedBy;
        private System.Windows.Forms.Label lblReceivedDate;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.GroupBox grpInventory;
        private System.Windows.Forms.Label lblIssuedBy;
        private System.Windows.Forms.ComboBox cmbIssuedBy;
        private System.Windows.Forms.Label lblIssuedDate;
        private System.Windows.Forms.DateTimePicker dtpIssuedDate;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
    }
}
