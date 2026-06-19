namespace PremiumLivingSystem
{
    partial class ProductionClerkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionClerkForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApproveTransfers = new System.Windows.Forms.Button();
            this.btnSearchTransfer = new System.Windows.Forms.Button();
            this.btnCreateTransfer = new System.Windows.Forms.Button();
            this.btnCreateMaterialRequest = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.btnApproveTransfers);
            this.panel2.Controls.Add(this.btnSearchTransfer);
            this.panel2.Controls.Add(this.btnCreateTransfer);
            this.panel2.Controls.Add(this.btnCreateMaterialRequest);
            this.panel2.Name = "panel2";
            resources.ApplyResources(this.btnApproveTransfers, "btnApproveTransfers");
            this.btnApproveTransfers.Name = "btnApproveTransfers";
            this.btnApproveTransfers.UseVisualStyleBackColor = true;
            this.btnApproveTransfers.Click += new System.EventHandler(this.btnApproveTransfers_Click);
            resources.ApplyResources(this.btnSearchTransfer, "btnSearchTransfer");
            this.btnSearchTransfer.Name = "btnSearchTransfer";
            this.btnSearchTransfer.UseVisualStyleBackColor = true;
            this.btnSearchTransfer.Click += new System.EventHandler(this.btnSearchTransfer_Click);
            resources.ApplyResources(this.btnCreateTransfer, "btnCreateTransfer");
            this.btnCreateTransfer.Name = "btnCreateTransfer";
            this.btnCreateTransfer.UseVisualStyleBackColor = true;
            this.btnCreateTransfer.Click += new System.EventHandler(this.btnCreateTransfer_Click);
            // btnCreateMaterialRequest — positioned below btnCreateTransfer
            this.btnCreateMaterialRequest.Name = "btnCreateMaterialRequest";
            this.btnCreateMaterialRequest.UseVisualStyleBackColor = true;
            this.btnCreateMaterialRequest.Text = "Create Material Request";
            // Position: same X as btnCreateTransfer, Y offset by +60 (default button height + margin)
            // We copy the location from btnCreateTransfer at runtime in the .cs constructor
            // because btnCreateTransfer's location comes from the .resx resource.
            this.btnCreateMaterialRequest.Size = new System.Drawing.Size(200, 50);
            this.btnCreateMaterialRequest.Click += new System.EventHandler(this.btnCreateMaterialRequest_Click);
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            this.cmbLanguage.Name = "cmbLanguage";
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Name = "label2";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainPanel);
            this.Name = "ProductionClerkForm";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearchTransfer;
        private System.Windows.Forms.Button btnCreateTransfer;
        private System.Windows.Forms.Button btnCreateMaterialRequest;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApproveTransfers;
    }
}