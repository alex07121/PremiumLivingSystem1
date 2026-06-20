namespace PremiumLivingSystem
{
    partial class EditPruchaseOrder
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
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lvItems = new System.Windows.Forms.ListView();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.GroupBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.btnSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(513, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(610, 70);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Edit Purchase Order";
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
            this.grpHeader.Controls.Add(this.txtSupplierID);
            this.grpHeader.Controls.Add(this.txtSupplierName);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.lblStatus);
            this.grpHeader.Controls.Add(this.cmbPaymentStatus);
            this.grpHeader.Controls.Add(this.lblPaymentStatus);
            this.grpHeader.Controls.Add(this.cmbPaymentMethod);
            this.grpHeader.Controls.Add(this.lblPaymentMethod);
            this.grpHeader.Location = new System.Drawing.Point(62, 90);
            this.grpHeader.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Size = new System.Drawing.Size(1556, 280);
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
            this.dtpOrderDate.Enabled = false;
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
            this.cmbSupplier.Enabled = false;
            this.cmbSupplier.Location = new System.Drawing.Point(171, 108);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(309, 35);
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
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(171, 108);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(120, 40);
            this.txtSupplierID.TabIndex = 8;
            this.txtSupplierID.Visible = false;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(496, 108);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(435, 40);
            this.txtSupplierName.TabIndex = 9;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Draft",
            "Sent",
            "PartiallyReceived",
            "Received",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(171, 176);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(309, 35);
            this.cmbStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(31, 180);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 27);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status:";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentStatus.Enabled = false;
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "Unpaid",
            "Partial",
            "Paid"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(700, 176);
            this.cmbPaymentStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(231, 35);
            this.cmbPaymentStatus.TabIndex = 12;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Location = new System.Drawing.Point(560, 180);
            this.lblPaymentStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(108, 27);
            this.lblPaymentStatus.TabIndex = 13;
            this.lblPaymentStatus.Text = "Payment:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "BankTransfer",
            "CreditCard",
            "FPS"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(1151, 176);
            this.cmbPaymentMethod.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(309, 35);
            this.cmbPaymentMethod.TabIndex = 14;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(1027, 180);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(118, 27);
            this.lblPaymentMethod.TabIndex = 15;
            this.lblPaymentMethod.Text = "Pay Meth:";
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.lvItems);
            this.grpItems.Controls.Add(this.cmbMaterial);
            this.grpItems.Controls.Add(this.lblMaterial);
            this.grpItems.Controls.Add(this.nudQuantity);
            this.grpItems.Controls.Add(this.lblQuantity);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Location = new System.Drawing.Point(62, 390);
            this.grpItems.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpItems.Size = new System.Drawing.Size(1556, 420);
            this.grpItems.TabIndex = 4;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Order Items";
            // 
            // lvItems
            // 
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(31, 172);
            this.lvItems.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1493, 225);
            this.lvItems.TabIndex = 0;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
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
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
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
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Controls.Add(this.lblSubTotal);
            this.btnSave.Controls.Add(this.txtSubTotal);
            this.btnSave.Controls.Add(this.lblTotal);
            this.btnSave.Controls.Add(this.txtTotal);
            this.btnSave.Controls.Add(this.lblRemarks);
            this.btnSave.Controls.Add(this.txtRemarks);
            this.btnSave.Location = new System.Drawing.Point(62, 840);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Size = new System.Drawing.Size(1556, 240);
            this.btnSave.TabIndex = 3;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Totals & Remarks";
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
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(964, 1110);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(249, 68);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit (Sent)";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 11F);
            this.btnClose.Location = new System.Drawing.Point(1223, 1110);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(249, 68);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDraft.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveDraft.ForeColor = System.Drawing.Color.White;
            this.btnSaveDraft.Location = new System.Drawing.Point(705, 1110);
            this.btnSaveDraft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(249, 68);
            this.btnSaveDraft.TabIndex = 8;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditPruchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 1200);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EditPruchaseOrder";
            this.Text = "Edit Purchase Order";
            this.Load += new System.EventHandler(this.EditPruchaseOrder_Load);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.btnSave.ResumeLayout(false);
            this.btnSave.PerformLayout();
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
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;

        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;

        private System.Windows.Forms.GroupBox btnSave;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveDraft;
    }
}
