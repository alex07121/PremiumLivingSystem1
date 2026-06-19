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
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(513, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1107, 70);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Create Purchase Order (Procurement)";
            // 
            // grpHeader
            // 
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
            this.grpHeader.Location = new System.Drawing.Point(62, 90);
            this.grpHeader.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Size = new System.Drawing.Size(1556, 240);
            this.grpHeader.TabIndex = 5;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Purchase Order Information";
            // 
            // txtPurchaseOrderID
            // 
            this.txtPurchaseOrderID.Location = new System.Drawing.Point(171, 40);
            this.txtPurchaseOrderID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.ReadOnly = true;
            this.txtPurchaseOrderID.Size = new System.Drawing.Size(309, 40);
            this.txtPurchaseOrderID.TabIndex = 0;
            // 
            // lblPurchaseOrderID
            // 
            this.lblPurchaseOrderID.AutoSize = true;
            this.lblPurchaseOrderID.Location = new System.Drawing.Point(31, 45);
            this.lblPurchaseOrderID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPurchaseOrderID.Name = "lblPurchaseOrderID";
            this.lblPurchaseOrderID.Size = new System.Drawing.Size(84, 27);
            this.lblPurchaseOrderID.TabIndex = 1;
            this.lblPurchaseOrderID.Text = "PO ID:";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(700, 40);
            this.dtpOrderDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(231, 40);
            this.dtpOrderDate.TabIndex = 2;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(560, 45);
            this.lblOrderDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(131, 27);
            this.lblOrderDate.TabIndex = 3;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // dtpExpectedDate
            // 
            this.dtpExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpectedDate.Location = new System.Drawing.Point(1229, 40);
            this.dtpExpectedDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpExpectedDate.MinDate = new System.DateTime(2026, 6, 19, 0, 0, 0, 0);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            this.dtpExpectedDate.Size = new System.Drawing.Size(231, 40);
            this.dtpExpectedDate.TabIndex = 4;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Location = new System.Drawing.Point(1027, 45);
            this.lblExpectedDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(209, 27);
            this.lblExpectedDate.TabIndex = 5;
            this.lblExpectedDate.Text = "Expected Delivery:";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Location = new System.Drawing.Point(171, 108);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(760, 35);
            this.cmbSupplier.TabIndex = 6;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(31, 112);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(105, 27);
            this.lblSupplier.TabIndex = 7;
            this.lblSupplier.Text = "Supplier:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "BankTransfer",
            "CreditCard",
            "FPS"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1151, 108);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(309, 35);
            this.cmbPaymentMethod.TabIndex = 8;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(1027, 112);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(108, 27);
            this.lblPaymentMethod.TabIndex = 9;
            this.lblPaymentMethod.Text = "Payment:";
            // 
            // txtReqByID
            // 
            this.txtReqByID.Location = new System.Drawing.Point(218, 176);
            this.txtReqByID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReqByID.Name = "txtReqByID";
            this.txtReqByID.ReadOnly = true;
            this.txtReqByID.Size = new System.Drawing.Size(184, 40);
            this.txtReqByID.TabIndex = 10;
            // 
            // lblReqByID
            // 
            this.lblReqByID.AutoSize = true;
            this.lblReqByID.Location = new System.Drawing.Point(31, 180);
            this.lblReqByID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReqByID.Name = "lblReqByID";
            this.lblReqByID.Size = new System.Drawing.Size(183, 27);
            this.lblReqByID.TabIndex = 11;
            this.lblReqByID.Text = "Created By (ID):";
            // 
            // txtReqName
            // 
            this.txtReqName.Location = new System.Drawing.Point(560, 176);
            this.txtReqName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.ReadOnly = true;
            this.txtReqName.Size = new System.Drawing.Size(371, 40);
            this.txtReqName.TabIndex = 12;
            // 
            // lblReqName
            // 
            this.lblReqName.AutoSize = true;
            this.lblReqName.Location = new System.Drawing.Point(467, 180);
            this.lblReqName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReqName.Name = "lblReqName";
            this.lblReqName.Size = new System.Drawing.Size(79, 27);
            this.lblReqName.TabIndex = 13;
            this.lblReqName.Text = "Name:";
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Controls.Add(this.cmbMaterial);
            this.grpItems.Controls.Add(this.lblMaterial);
            this.grpItems.Controls.Add(this.nudQuantity);
            this.grpItems.Controls.Add(this.lblQuantity);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Controls.Add(this.lblStockHint);
            this.grpItems.Location = new System.Drawing.Point(62, 360);
            this.grpItems.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpItems.Size = new System.Drawing.Size(1556, 420);
            this.grpItems.TabIndex = 4;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Order Items";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(31, 172);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 92;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(1493, 225);
            this.dgvItems.TabIndex = 0;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.Location = new System.Drawing.Point(156, 40);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(589, 35);
            this.cmbMaterial.TabIndex = 1;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(31, 45);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(104, 27);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.DecimalPlaces = 2;
            this.nudQuantity.Location = new System.Drawing.Point(156, 108);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.nudQuantity.Size = new System.Drawing.Size(202, 40);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(31, 112);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(108, 27);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(399, 97);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(187, 52);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "Add Item";
            this.btnAddRow.UseVisualStyleBackColor = false;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRemoveRow.Location = new System.Drawing.Point(596, 95);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(187, 52);
            this.btnRemoveRow.TabIndex = 6;
            this.btnRemoveRow.Text = "Remove";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            // 
            // lblStockHint
            // 
            this.lblStockHint.AutoSize = true;
            this.lblStockHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(110)))), ((int)(((byte)(60)))));
            this.lblStockHint.Location = new System.Drawing.Point(762, 45);
            this.lblStockHint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStockHint.Name = "lblStockHint";
            this.lblStockHint.Size = new System.Drawing.Size(0, 27);
            this.lblStockHint.TabIndex = 7;
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.lblSubTotal);
            this.grpTotals.Controls.Add(this.txtSubTotal);
            this.grpTotals.Controls.Add(this.lblTotal);
            this.grpTotals.Controls.Add(this.txtTotal);
            this.grpTotals.Controls.Add(this.lblRemarks);
            this.grpTotals.Controls.Add(this.txtRemarks);
            this.grpTotals.Location = new System.Drawing.Point(62, 810);
            this.grpTotals.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpTotals.Size = new System.Drawing.Size(1556, 240);
            this.grpTotals.TabIndex = 3;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Totals & Remarks";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(31, 45);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(104, 27);
            this.lblSubTotal.TabIndex = 0;
            this.lblSubTotal.Text = "Subtotal:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(156, 40);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(231, 40);
            this.txtSubTotal.TabIndex = 1;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(451, 45);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(73, 27);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(544, 40);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(262, 42);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(31, 112);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(109, 27);
            this.lblRemarks.TabIndex = 4;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(156, 108);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1351, 103);
            this.txtRemarks.TabIndex = 5;
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDraft.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveDraft.ForeColor = System.Drawing.Color.White;
            this.btnSaveDraft.Location = new System.Drawing.Point(684, 1080);
            this.btnSaveDraft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(249, 68);
            this.btnSaveDraft.TabIndex = 2;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(964, 1080);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(249, 68);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit (Sent)";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 11F);
            this.btnClear.Location = new System.Drawing.Point(1244, 1080);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(249, 68);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // UcCreateProcurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.grpTotals);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UcCreateProcurement";
            this.Size = new System.Drawing.Size(1680, 1185);
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
