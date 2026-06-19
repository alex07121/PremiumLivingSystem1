namespace PremiumLivingSystem
{
    partial class UcArrangeShipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcArrangeShipment));
            this.dgvOrders = new System.Windows.Forms.ListView();
            this.btnCreateDN = new System.Windows.Forms.Button();
            this.lblDispatchDate = new System.Windows.Forms.Label();
            this.dtpDispatchDate = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cboAddress = new System.Windows.Forms.ComboBox();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            resources.ApplyResources(this.dgvOrders, "dgvOrders");
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.View = System.Windows.Forms.View.Details;
            this.dgvOrders.FullRowSelect = true;
            this.dgvOrders.GridLines = true;
            this.dgvOrders.HideSelection = false;
            this.dgvOrders.SelectedIndexChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            resources.ApplyResources(this.btnCreateDN, "btnCreateDN");
            this.btnCreateDN.Name = "btnCreateDN";
            this.btnCreateDN.UseVisualStyleBackColor = true;
            this.btnCreateDN.Click += new System.EventHandler(this.btnCreateDN_Click);
            resources.ApplyResources(this.lblDispatchDate, "lblDispatchDate");
            this.lblDispatchDate.Name = "lblDispatchDate";
            resources.ApplyResources(this.dtpDispatchDate, "dtpDispatchDate");
            this.dtpDispatchDate.Name = "dtpDispatchDate";
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            resources.ApplyResources(this.cboAddress, "cboAddress");
            this.cboAddress.FormattingEnabled = true;
            this.cboAddress.Name = "cboAddress";
            resources.ApplyResources(this.lblOrderID, "lblOrderID");
            this.lblOrderID.Name = "lblOrderID";
            resources.ApplyResources(this.txtOrderID, "txtOrderID");
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.cboDeliveryMethod, "cboDeliveryMethod");
            this.cboDeliveryMethod.FormattingEnabled = true;
            this.cboDeliveryMethod.Items.AddRange(new object[] {
            resources.GetString("cboDeliveryMethod.Items"),
            resources.GetString("cboDeliveryMethod.Items1")});
            this.cboDeliveryMethod.Name = "cboDeliveryMethod";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDeliveryMethod);
            this.Controls.Add(this.btnCreateDN);
            this.Controls.Add(this.lblDispatchDate);
            this.Controls.Add(this.dtpDispatchDate);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.cboAddress);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.dgvOrders);
            this.Name = "UcArrangeShipment";
            this.Load += new System.EventHandler(this.UcArrangeShipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListView dgvOrders;
        #endregion

        private System.Windows.Forms.Button btnCreateDN;
        private System.Windows.Forms.Label lblDispatchDate;
        private System.Windows.Forms.DateTimePicker dtpDispatchDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cboAddress;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDeliveryMethod;
    }
}
