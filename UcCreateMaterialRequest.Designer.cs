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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCreateMaterialRequest));
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
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.cmbOrderFilter = new System.Windows.Forms.ComboBox();
            this.lblOrderFilter = new System.Windows.Forms.Label();
            this.cmbOrderItem = new System.Windows.Forms.ComboBox();
            this.lblOrderItem = new System.Windows.Forms.Label();
            this.btnAutoFillBOM = new System.Windows.Forms.Button();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lvMaterials = new System.Windows.Forms.ListView();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.grpCommon = new System.Windows.Forms.GroupBox();
            this.cmbUrgency = new System.Windows.Forms.ComboBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.grpSelection.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpCommon.SuspendLayout();
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
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.TabStop = false;
            // 
            // txtRequestID
            // 
            resources.ApplyResources(this.txtRequestID, "txtRequestID");
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            // 
            // lblRequestID
            // 
            resources.ApplyResources(this.lblRequestID, "lblRequestID");
            this.lblRequestID.Name = "lblRequestID";
            // 
            // txtRequestDate
            // 
            resources.ApplyResources(this.txtRequestDate, "txtRequestDate");
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.ReadOnly = true;
            // 
            // lblRequestDate
            // 
            resources.ApplyResources(this.lblRequestDate, "lblRequestDate");
            this.lblRequestDate.Name = "lblRequestDate";
            // 
            // txtReqPos
            // 
            resources.ApplyResources(this.txtReqPos, "txtReqPos");
            this.txtReqPos.Name = "txtReqPos";
            this.txtReqPos.ReadOnly = true;
            // 
            // lblReqPos
            // 
            resources.ApplyResources(this.lblReqPos, "lblReqPos");
            this.lblReqPos.Name = "lblReqPos";
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
            // grpSelection
            // 
            resources.ApplyResources(this.grpSelection, "grpSelection");
            this.grpSelection.Controls.Add(this.cmbOrderFilter);
            this.grpSelection.Controls.Add(this.lblOrderFilter);
            this.grpSelection.Controls.Add(this.cmbOrderItem);
            this.grpSelection.Controls.Add(this.lblOrderItem);
            this.grpSelection.Controls.Add(this.btnAutoFillBOM);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.TabStop = false;
            // 
            // cmbOrderFilter
            // 
            resources.ApplyResources(this.cmbOrderFilter, "cmbOrderFilter");
            this.cmbOrderFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderFilter.Name = "cmbOrderFilter";
            // 
            // lblOrderFilter
            // 
            resources.ApplyResources(this.lblOrderFilter, "lblOrderFilter");
            this.lblOrderFilter.Name = "lblOrderFilter";
            // 
            // cmbOrderItem
            // 
            resources.ApplyResources(this.cmbOrderItem, "cmbOrderItem");
            this.cmbOrderItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderItem.Name = "cmbOrderItem";
            // 
            // lblOrderItem
            // 
            resources.ApplyResources(this.lblOrderItem, "lblOrderItem");
            this.lblOrderItem.Name = "lblOrderItem";
            // 
            // btnAutoFillBOM
            // 
            resources.ApplyResources(this.btnAutoFillBOM, "btnAutoFillBOM");
            this.btnAutoFillBOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnAutoFillBOM.ForeColor = System.Drawing.Color.White;
            this.btnAutoFillBOM.Name = "btnAutoFillBOM";
            this.btnAutoFillBOM.UseVisualStyleBackColor = false;
            // 
            // grpItems
            // 
            resources.ApplyResources(this.grpItems, "grpItems");
            this.grpItems.Controls.Add(this.lvMaterials);
            this.grpItems.Controls.Add(this.cmbMaterial);
            this.grpItems.Controls.Add(this.lblMaterial);
            this.grpItems.Controls.Add(this.nudQuantity);
            this.grpItems.Controls.Add(this.lblQuantity);
            this.grpItems.Controls.Add(this.btnAddRow);
            this.grpItems.Controls.Add(this.btnRemoveRow);
            this.grpItems.Name = "grpItems";
            this.grpItems.TabStop = false;
            // 
            // lvMaterials
            // 
            resources.ApplyResources(this.lvMaterials, "lvMaterials");
            this.lvMaterials.FullRowSelect = true;
            this.lvMaterials.GridLines = true;
            this.lvMaterials.HideSelection = false;
            this.lvMaterials.MultiSelect = false;
            this.lvMaterials.Name = "lvMaterials";
            this.lvMaterials.UseCompatibleStateImageBehavior = false;
            this.lvMaterials.View = System.Windows.Forms.View.Details;
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
            // grpCommon
            // 
            resources.ApplyResources(this.grpCommon, "grpCommon");
            this.grpCommon.Controls.Add(this.cmbUrgency);
            this.grpCommon.Controls.Add(this.lblUrgency);
            this.grpCommon.Controls.Add(this.dtpRequiredDate);
            this.grpCommon.Controls.Add(this.lblRequiredDate);
            this.grpCommon.Controls.Add(this.txtRemarks);
            this.grpCommon.Controls.Add(this.lblRemarks);
            this.grpCommon.Name = "grpCommon";
            this.grpCommon.TabStop = false;
            // 
            // cmbUrgency
            // 
            resources.ApplyResources(this.cmbUrgency, "cmbUrgency");
            this.cmbUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgency.Items.AddRange(new object[] {
            resources.GetString("cmbUrgency.Items"),
            resources.GetString("cmbUrgency.Items1"),
            resources.GetString("cmbUrgency.Items2"),
            resources.GetString("cmbUrgency.Items3")});
            this.cmbUrgency.Name = "cmbUrgency";
            // 
            // lblUrgency
            // 
            resources.ApplyResources(this.lblUrgency, "lblUrgency");
            this.lblUrgency.Name = "lblUrgency";
            // 
            // dtpRequiredDate
            // 
            resources.ApplyResources(this.dtpRequiredDate, "dtpRequiredDate");
            this.dtpRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequiredDate.MinDate = new System.DateTime(2026, 6, 20, 0, 0, 0, 0);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Value = new System.DateTime(2026, 6, 23, 0, 0, 0, 0);
            // 
            // lblRequiredDate
            // 
            resources.ApplyResources(this.lblRequiredDate, "lblRequiredDate");
            this.lblRequiredDate.Name = "lblRequiredDate";
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
            // UcCreateMaterialRequest
            // 
            resources.ApplyResources(this, "$this");
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
            this.Load += new System.EventHandler(this.UcCreateMaterialRequest_Load);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
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
