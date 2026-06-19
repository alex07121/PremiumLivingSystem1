namespace PremiumLivingSystem
{
    partial class UcProcessReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcProcessReturn));
            this.dgvReturns = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRefundAmount = new System.Windows.Forms.TextBox();
            this.lblRefundAmount = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReturnType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.txtReturnID = new System.Windows.Forms.TextBox();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            resources.ApplyResources(this.dgvReturns, "dgvReturns");
            this.dgvReturns.Name = "dgvReturns";
            this.dgvReturns.View = System.Windows.Forms.View.Details;
            this.dgvReturns.FullRowSelect = true;
            this.dgvReturns.GridLines = true;
            this.dgvReturns.HideSelection = false;
            this.dgvReturns.SelectedIndexChanged += new System.EventHandler(this.dgvReturns_SelectionChanged);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Controls.Add(this.txtRefundAmount);
            this.groupBox1.Controls.Add(this.lblRefundAmount);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.txtReturnType);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.txtOrderID);
            this.groupBox1.Controls.Add(this.lblOrderID);
            this.groupBox1.Controls.Add(this.txtReturnID);
            this.groupBox1.Controls.Add(this.lblReturnID);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            resources.ApplyResources(this.txtRemarks, "txtRemarks");
            this.txtRemarks.Name = "txtRemarks";
            resources.ApplyResources(this.lblRemarks, "lblRemarks");
            this.lblRemarks.Name = "lblRemarks";
            resources.ApplyResources(this.txtRefundAmount, "txtRefundAmount");
            this.txtRefundAmount.Name = "txtRefundAmount";
            resources.ApplyResources(this.lblRefundAmount, "lblRefundAmount");
            this.lblRefundAmount.Name = "lblRefundAmount";
            resources.ApplyResources(this.cboStatus, "cboStatus");
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            resources.GetString("cboStatus.Items"),
            resources.GetString("cboStatus.Items1"),
            resources.GetString("cboStatus.Items2"),
            resources.GetString("cboStatus.Items3")});
            this.cboStatus.Name = "cboStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.txtReason, "txtReason");
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            resources.ApplyResources(this.lblReason, "lblReason");
            this.lblReason.Name = "lblReason";
            resources.ApplyResources(this.txtReturnType, "txtReturnType");
            this.txtReturnType.Name = "txtReturnType";
            this.txtReturnType.ReadOnly = true;
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            resources.ApplyResources(this.txtOrderID, "txtOrderID");
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            resources.ApplyResources(this.lblOrderID, "lblOrderID");
            this.lblOrderID.Name = "lblOrderID";
            resources.ApplyResources(this.txtReturnID, "txtReturnID");
            this.txtReturnID.Name = "txtReturnID";
            this.txtReturnID.ReadOnly = true;
            resources.ApplyResources(this.lblReturnID, "lblReturnID");
            this.lblReturnID.Name = "lblReturnID";
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(10, 470);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(550, 70);
            this.flowLayoutPanelImages.TabIndex = 15;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReturns);
            this.Name = "UcProcessReturn";
            this.Load += new System.EventHandler(this.UcProcessReturn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ListView dgvReturns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReturnID;
        private System.Windows.Forms.Label lblReturnID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtReturnType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtRefundAmount;
        private System.Windows.Forms.Label lblRefundAmount;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        #endregion
    }
}
