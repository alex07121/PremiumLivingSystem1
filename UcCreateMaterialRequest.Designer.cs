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

            // ---- Header group ----
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

            // ---- Selection group (Order filter + OrderItem + BOM auto-fill) ----
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.cmbOrderFilter = new System.Windows.Forms.ComboBox();
            this.lblOrderFilter = new System.Windows.Forms.Label();
            this.cmbOrderItem = new System.Windows.Forms.ComboBox();
            this.lblOrderItem = new System.Windows.Forms.Label();
            this.btnAutoFillBOM = new System.Windows.Forms.Button();

            // ---- Items group (manual add + ListView) ----
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lvMaterials = new System.Windows.Forms.ListView();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();

            // ---- Common settings ----
            this.grpCommon = new System.Windows.Forms.GroupBox();
            this.cmbUrgency = new System.Windows.Forms.ComboBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();

            // ---- Buttons ----
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.grpHeader.SuspendLayout();
            this.grpSelection.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpCommon.SuspendLayout();
            this.SuspendLayout();

            // ----------------------------------------------------------------
            // lblTitle
            // ----------------------------------------------------------------
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 31);
            this.lblTitle.Text = "Create Raw Material Request";

            // ----------------------------------------------------------------
            // grpHeader
            // ----------------------------------------------------------------
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
            this.grpHeader.Location = new System.Drawing.Point(40, 60);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1000, 130);
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Request Information";

            this.lblRequestID.AutoSize = true;
            this.lblRequestID.Location = new System.Drawing.Point(20, 30);
            this.lblRequestID.Text = "Request ID:";
            this.txtRequestID.Location = new System.Drawing.Point(120, 27);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            this.txtRequestID.Size = new System.Drawing.Size(160, 27);

            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Location = new System.Drawing.Point(320, 30);
            this.lblRequestDate.Text = "Request Date:";
            this.txtRequestDate.Location = new System.Drawing.Point(430, 27);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.ReadOnly = true;
            this.txtRequestDate.Size = new System.Drawing.Size(200, 27);

            this.lblReqByID.AutoSize = true;
            this.lblReqByID.Location = new System.Drawing.Point(20, 75);
            this.lblReqByID.Text = "Requested By:";
            this.txtReqByID.Location = new System.Drawing.Point(120, 72);
            this.txtReqByID.Name = "txtReqByID";
            this.txtReqByID.ReadOnly = true;
            this.txtReqByID.Size = new System.Drawing.Size(120, 27);

            this.lblReqName.AutoSize = true;
            this.lblReqName.Location = new System.Drawing.Point(280, 75);
            this.lblReqName.Text = "Name:";
            this.txtReqName.Location = new System.Drawing.Point(340, 72);
            this.txtReqName.Name = "txtReqName";
            this.txtReqName.ReadOnly = true;
            this.txtReqName.Size = new System.Drawing.Size(240, 27);

            this.lblReqPos.AutoSize = true;
            this.lblReqPos.Location = new System.Drawing.Point(640, 75);
            this.lblReqPos.Text = "Position:";
            this.txtReqPos.Location = new System.Drawing.Point(710, 72);
            this.txtReqPos.Name = "txtReqPos";
            this.txtReqPos.ReadOnly = true;
            this.txtReqPos.Size = new System.Drawing.Size(200, 27);

            // ----------------------------------------------------------------
            // grpSelection — OrderItem + Auto-fill BOM button
            // ----------------------------------------------------------------
            this.grpSelection.Controls.Add(this.cmbOrderFilter);
            this.grpSelection.Controls.Add(this.lblOrderFilter);
            this.grpSelection.Controls.Add(this.cmbOrderItem);
            this.grpSelection.Controls.Add(this.lblOrderItem);
            this.grpSelection.Controls.Add(this.btnAutoFillBOM);
            this.grpSelection.Location = new System.Drawing.Point(40, 210);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(1000, 110);
            this.grpSelection.TabStop = false;
            this.grpSelection.Text = "Select Order Item (auto-fills BOM materials)";

            // Row 1: Order filter
            this.lblOrderFilter.AutoSize = true;
            this.lblOrderFilter.Location = new System.Drawing.Point(20, 30);
            this.lblOrderFilter.Text = "Filter by Order:";
            this.cmbOrderFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderFilter.Location = new System.Drawing.Point(130, 27);
            this.cmbOrderFilter.Name = "cmbOrderFilter";
            this.cmbOrderFilter.Size = new System.Drawing.Size(600, 27);

            // Row 2: Order Item dropdown
            this.lblOrderItem.AutoSize = true;
            this.lblOrderItem.Location = new System.Drawing.Point(20, 68);
            this.lblOrderItem.Text = "Order Item:";
            this.cmbOrderItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderItem.Location = new System.Drawing.Point(130, 65);
            this.cmbOrderItem.Name = "cmbOrderItem";
            this.cmbOrderItem.Size = new System.Drawing.Size(600, 27);

            this.btnAutoFillBOM.BackColor = System.Drawing.Color.FromArgb(56, 142, 60);
            this.btnAutoFillBOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoFillBOM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAutoFillBOM.ForeColor = System.Drawing.Color.White;
            this.btnAutoFillBOM.Location = new System.Drawing.Point(750, 63);
            this.btnAutoFillBOM.Name = "btnAutoFillBOM";
            this.btnAutoFillBOM.Size = new System.Drawing.Size(220, 32);
            this.btnAutoFillBOM.Text = "Auto-Fill from BOM";
            this.btnAutoFillBOM.UseVisualStyleBackColor = false;

            // ----------------------------------------------------------------
            // grpItems — manual add + ListView
            // ----------------------------------------------------------------
            this.grpItems.Controls.Add(this.lvMaterials);
            this.grpItems.Controls.Add(this.cmbMaterial);
            this.grpItems.Controls.Add(this.lblMaterial);
            this.grpItems.Controls.Add(this.nudQuantity);
            this.grpItems.Controls.Add(this.lblQuantity);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Location = new System.Drawing.Point(40, 340);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1000, 310);
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Material List";

            // Material dropdown (for manual add)
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(20, 28);
            this.lblMaterial.Text = "Material:";
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.Location = new System.Drawing.Point(90, 25);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(380, 27);

            // Quantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(500, 28);
            this.lblQuantity.Text = "Qty:";
            this.nudQuantity.DecimalPlaces = 2;
            this.nudQuantity.Location = new System.Drawing.Point(540, 25);
            this.nudQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(110, 27);
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // Add / Remove buttons
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(680, 24);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(100, 30);
            this.btnAddRow.Text = "Add";
            this.btnAddRow.UseVisualStyleBackColor = false;

            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.Font = new System.Drawing.Font("Arial", 9F);
            this.btnRemoveRow.Location = new System.Drawing.Point(790, 24);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveRow.Text = "Remove";
            this.btnRemoveRow.UseVisualStyleBackColor = true;

            // ListView — T3 style: View.Details + FullRowSelect + GridLines
            this.lvMaterials.FullRowSelect = true;
            this.lvMaterials.GridLines = true;
            this.lvMaterials.HideSelection = false;
            this.lvMaterials.Location = new System.Drawing.Point(20, 65);
            this.lvMaterials.MultiSelect = false;
            this.lvMaterials.Name = "lvMaterials";
            this.lvMaterials.Size = new System.Drawing.Size(960, 230);
            this.lvMaterials.UseCompatibleStateImageBehavior = false;
            this.lvMaterials.View = System.Windows.Forms.View.Details;

            // ----------------------------------------------------------------
            // grpCommon — Urgency + RequiredDate + Remarks (applies to all rows)
            // ----------------------------------------------------------------
            this.grpCommon.Controls.Add(this.cmbUrgency);
            this.grpCommon.Controls.Add(this.lblUrgency);
            this.grpCommon.Controls.Add(this.dtpRequiredDate);
            this.grpCommon.Controls.Add(this.lblRequiredDate);
            this.grpCommon.Controls.Add(this.txtRemarks);
            this.grpCommon.Controls.Add(this.lblRemarks);
            this.grpCommon.Location = new System.Drawing.Point(40, 670);
            this.grpCommon.Name = "grpCommon";
            this.grpCommon.Size = new System.Drawing.Size(1000, 130);
            this.grpCommon.TabStop = false;
            this.grpCommon.Text = "Common Settings (applies to all materials)";

            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Location = new System.Drawing.Point(20, 30);
            this.lblUrgency.Text = "Urgency:";
            this.cmbUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgency.Items.AddRange(new object[] { "Low", "Medium", "High", "Urgent" });
            this.cmbUrgency.Location = new System.Drawing.Point(100, 27);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.Size = new System.Drawing.Size(150, 27);

            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(290, 30);
            this.lblRequiredDate.Text = "Required Delivery Date:";
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.Location = new System.Drawing.Point(430, 27);
            this.dtpRequiredDate.MinDate = System.DateTime.Today;
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(180, 27);
            this.dtpRequiredDate.Value = System.DateTime.Today.AddDays(3);

            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(20, 75);
            this.lblRemarks.Text = "Remarks:";
            this.txtRemarks.Location = new System.Drawing.Point(100, 72);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(870, 45);

            // ----------------------------------------------------------------
            // Buttons
            // ----------------------------------------------------------------
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(620, 820);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(160, 45);
            this.btnSubmit.Text = "Submit All";
            this.btnSubmit.UseVisualStyleBackColor = false;

            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 11F);
            this.btnClear.Location = new System.Drawing.Point(800, 820);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(160, 45);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;

            // ----------------------------------------------------------------
            // UcCreateMaterialRequest
            // ----------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpCommon);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpSelection);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcCreateMaterialRequest";
            this.Size = new System.Drawing.Size(1080, 890);
            this.Load += new System.EventHandler(this.UcCreateMaterialRequest_Load);

            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpSelection.ResumeLayout(false);
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpCommon.ResumeLayout(false);
            this.grpCommon.PerformLayout();
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

        private System.Windows.Forms.GroupBox grpSelection;
        private System.Windows.Forms.ComboBox cmbOrderFilter;
        private System.Windows.Forms.Label lblOrderFilter;
        private System.Windows.Forms.ComboBox cmbOrderItem;
        private System.Windows.Forms.Label lblOrderItem;
        private System.Windows.Forms.Button btnAutoFillBOM;

        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.ListView lvMaterials;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnRemoveRow;

        private System.Windows.Forms.GroupBox grpCommon;
        private System.Windows.Forms.ComboBox cmbUrgency;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
    }
}
