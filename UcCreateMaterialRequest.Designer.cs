namespace PremiumLivingSystem
{
    partial class UcCreateMaterialRequest
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
            this.txtRequestID = new System.Windows.Forms.TextBox();
            this.lblRequestID = new System.Windows.Forms.Label();
            this.txtRequestDate = new System.Windows.Forms.TextBox();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.txtReqPos = new System.Windows.Forms.TextBox();
            this.lblReqPos = new System.Windows.Forms.Label();
            this.txtReqName = new System.Windows.Forms.TextBox();
            this.lblReqName = new System.Windows.Forms.Label();
            this.txtReqByID = new System.Windows.Forms.TextBox();
            this.lblReqByID = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.cmbOrderItem = new System.Windows.Forms.ComboBox();
            this.lblOrderItem = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbUrgency = new System.Windows.Forms.ComboBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblStockInfo = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(560, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(854, 70);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Create Raw Material Request";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.txtRequestID);
            this.grpHeader.Controls.Add(this.lblRequestID);
            this.grpHeader.Controls.Add(this.txtRequestDate);
            this.grpHeader.Controls.Add(this.lblRequestDate);
            this.grpHeader.Controls.Add(this.txtReqPos);
            this.grpHeader.Controls.Add(this.lblReqPos);
            this.grpHeader.Controls.Add(this.txtReqName);
            this.grpHeader.Controls.Add(this.lblReqName);
            this.grpHeader.Controls.Add(this.txtReqByID);
            this.grpHeader.Controls.Add(this.lblReqByID);
            this.grpHeader.Location = new System.Drawing.Point(62, 105);
            this.grpHeader.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpHeader.Size = new System.Drawing.Size(1493, 240);
            this.grpHeader.TabIndex = 4;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Request Information";
            // 
            // txtRequestID
            // 
            this.txtRequestID.Location = new System.Drawing.Point(187, 40);
            this.txtRequestID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            this.txtRequestID.Size = new System.Drawing.Size(247, 40);
            this.txtRequestID.TabIndex = 0;
            // 
            // lblRequestID
            // 
            this.lblRequestID.AutoSize = true;
            this.lblRequestID.Location = new System.Drawing.Point(31, 45);
            this.lblRequestID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRequestID.Name = "lblRequestID";
            this.lblRequestID.Size = new System.Drawing.Size(134, 27);
            this.lblRequestID.TabIndex = 1;
            this.lblRequestID.Text = "Request ID:";
            // 
            // txtRequestDate
            // 
            this.txtRequestDate.Location = new System.Drawing.Point(669, 40);
            this.txtRequestDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.ReadOnly = true;
            this.txtRequestDate.Size = new System.Drawing.Size(309, 40);
            this.txtRequestDate.TabIndex = 2;
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(498, 45);
            this.lblRequestDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(155, 27);
            this.lblRequestDate.TabIndex = 3;
            this.lblRequestDate.Text = "Request Date:";
            // 
            // txtReqPos
            // 
            this.txtReqPos.Location = new System.Drawing.Point(187, 176);
            this.txtReqPos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReqPos.Name = "txtReqPos";
            this.txtReqPos.ReadOnly = true;
            this.txtReqPos.Size = new System.Drawing.Size(309, 40);
            this.txtReqPos.TabIndex = 4;
            // 
            // lblReqPos
            // 
            this.lblReqPos.AutoSize = true;
            this.lblReqPos.Location = new System.Drawing.Point(31, 180);
            this.lblReqPos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReqPos.Name = "lblReqPos";
            this.lblReqPos.Size = new System.Drawing.Size(103, 27);
            this.lblReqPos.TabIndex = 5;
            this.lblReqPos.Text = "Position:";
            // 
            // txtReqName
            // 
            this.txtReqName.Location = new System.Drawing.Point(591, 108);
            this.txtReqName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.ReadOnly = true;
            this.txtReqName.Size = new System.Drawing.Size(387, 40);
            this.txtReqName.TabIndex = 6;
            // 
            // lblReqName
            // 
            this.lblReqName.AutoSize = true;
            this.lblReqName.Location = new System.Drawing.Point(498, 112);
            this.lblReqName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReqName.Name = "lblReqName";
            this.lblReqName.Size = new System.Drawing.Size(79, 27);
            this.lblReqName.TabIndex = 7;
            this.lblReqName.Text = "Name:";
            // 
            // txtReqByID
            // 
            this.txtReqByID.Location = new System.Drawing.Point(249, 108);
            this.txtReqByID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtReqByID.Name = "txtReqByID";
            this.txtReqByID.ReadOnly = true;
            this.txtReqByID.Size = new System.Drawing.Size(184, 40);
            this.txtReqByID.TabIndex = 8;
            // 
            // lblReqByID
            // 
            this.lblReqByID.AutoSize = true;
            this.lblReqByID.Location = new System.Drawing.Point(31, 112);
            this.lblReqByID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReqByID.Name = "lblReqByID";
            this.lblReqByID.Size = new System.Drawing.Size(211, 27);
            this.lblReqByID.TabIndex = 9;
            this.lblReqByID.Text = "Requested By (ID):";
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.cmbOrderItem);
            this.grpDetails.Controls.Add(this.lblOrderItem);
            this.grpDetails.Controls.Add(this.cmbMaterial);
            this.grpDetails.Controls.Add(this.lblMaterial);
            this.grpDetails.Controls.Add(this.nudQuantity);
            this.grpDetails.Controls.Add(this.lblQuantity);
            this.grpDetails.Controls.Add(this.cmbUrgency);
            this.grpDetails.Controls.Add(this.lblUrgency);
            this.grpDetails.Controls.Add(this.dtpRequiredDate);
            this.grpDetails.Controls.Add(this.lblRequiredDate);
            this.grpDetails.Controls.Add(this.txtRemarks);
            this.grpDetails.Controls.Add(this.lblRemarks);
            this.grpDetails.Controls.Add(this.lblStockInfo);
            this.grpDetails.Location = new System.Drawing.Point(62, 375);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpDetails.Size = new System.Drawing.Size(1493, 480);
            this.grpDetails.TabIndex = 3;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Material Request Details";
            // 
            // cmbOrderItem
            // 
            this.cmbOrderItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderItem.Location = new System.Drawing.Point(249, 48);
            this.cmbOrderItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbOrderItem.Name = "cmbOrderItem";
            this.cmbOrderItem.Size = new System.Drawing.Size(729, 35);
            this.cmbOrderItem.TabIndex = 0;
            // 
            // lblOrderItem
            // 
            this.lblOrderItem.AutoSize = true;
            this.lblOrderItem.Location = new System.Drawing.Point(31, 52);
            this.lblOrderItem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOrderItem.Name = "lblOrderItem";
            this.lblOrderItem.Size = new System.Drawing.Size(130, 27);
            this.lblOrderItem.TabIndex = 1;
            this.lblOrderItem.Text = "Order Item:";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.Location = new System.Drawing.Point(249, 116);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(729, 35);
            this.cmbMaterial.TabIndex = 2;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(31, 120);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(157, 27);
            this.lblMaterial.TabIndex = 3;
            this.lblMaterial.Text = "Raw Material:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.DecimalPlaces = 2;
            this.nudQuantity.Location = new System.Drawing.Point(249, 183);
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
            this.nudQuantity.Size = new System.Drawing.Size(233, 40);
            this.nudQuantity.TabIndex = 4;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(31, 188);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(108, 27);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgency.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High",
            "Urgent"});
            this.cmbUrgency.Location = new System.Drawing.Point(700, 183);
            this.cmbUrgency.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.Size = new System.Drawing.Size(278, 35);
            this.cmbUrgency.TabIndex = 6;
            // 
            // lblUrgency
            // 
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Location = new System.Drawing.Point(560, 188);
            this.lblUrgency.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUrgency.Name = "lblUrgency";
            this.lblUrgency.Size = new System.Drawing.Size(106, 27);
            this.lblUrgency.TabIndex = 7;
            this.lblUrgency.Text = "Urgency:";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(302, 255);
            this.dtpRequiredDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpRequiredDate.MinDate = new System.DateTime(2026, 6, 19, 0, 0, 0, 0);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(309, 40);
            this.dtpRequiredDate.TabIndex = 8;
            this.dtpRequiredDate.Value = new System.DateTime(2026, 6, 22, 0, 0, 0, 0);
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(31, 255);
            this.lblRequiredDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(261, 27);
            this.lblRequiredDate.TabIndex = 9;
            this.lblRequiredDate.Text = "Required Delivery Date:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(249, 318);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1196, 118);
            this.txtRemarks.TabIndex = 10;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(31, 322);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(109, 27);
            this.lblRemarks.TabIndex = 11;
            this.lblRemarks.Text = "Remarks:";
            // 
            // lblStockInfo
            // 
            this.lblStockInfo.AutoSize = true;
            this.lblStockInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(110)))), ((int)(((byte)(60)))));
            this.lblStockInfo.Location = new System.Drawing.Point(1011, 123);
            this.lblStockInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStockInfo.Name = "lblStockInfo";
            this.lblStockInfo.Size = new System.Drawing.Size(0, 27);
            this.lblStockInfo.TabIndex = 12;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.txtStatus);
            this.grpStatus.Controls.Add(this.lblStatus);
            this.grpStatus.Location = new System.Drawing.Point(62, 885);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpStatus.Size = new System.Drawing.Size(1493, 120);
            this.grpStatus.TabIndex = 2;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(249, 48);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(309, 40);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.Text = "Requested";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(31, 52);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 27);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(964, 1050);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(249, 68);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 11F);
            this.btnClear.Location = new System.Drawing.Point(1244, 1050);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(249, 68);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // UcCreateMaterialRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UcCreateMaterialRequest";
            this.Size = new System.Drawing.Size(1618, 1170);
            this.Load += new System.EventHandler(this.UcCreateMaterialRequest_Load);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.TextBox txtRequestID;
        private System.Windows.Forms.Label lblRequestID;
        private System.Windows.Forms.TextBox txtRequestDate;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.TextBox txtReqPos;
        private System.Windows.Forms.Label lblReqPos;
        private System.Windows.Forms.TextBox txtReqName;
        private System.Windows.Forms.Label lblReqName;
        private System.Windows.Forms.TextBox txtReqByID;
        private System.Windows.Forms.Label lblReqByID;

        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.ComboBox cmbOrderItem;
        private System.Windows.Forms.Label lblOrderItem;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cmbUrgency;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblStockInfo;

        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
    }
}
