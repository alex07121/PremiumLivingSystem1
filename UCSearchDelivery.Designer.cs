namespace PremiumLivingSystem
{
    partial class UcSearchDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchDelivery));
            this.dgvDelivery = new System.Windows.Forms.ListView();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.txtDeliveryID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReplySlip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvDelivery
            // 
            resources.ApplyResources(this.dgvDelivery, "dgvDelivery");
            this.dgvDelivery.FullRowSelect = true;
            this.dgvDelivery.GridLines = true;
            this.dgvDelivery.HideSelection = false;
            this.dgvDelivery.Name = "dgvDelivery";
            this.dgvDelivery.UseCompatibleStateImageBehavior = false;
            this.dgvDelivery.View = System.Windows.Forms.View.Details;
            // 
            // lblDelivery
            // 
            resources.ApplyResources(this.lblDelivery, "lblDelivery");
            this.lblDelivery.Name = "lblDelivery";
            // 
            // txtDeliveryID
            // 
            resources.ApplyResources(this.txtDeliveryID, "txtDeliveryID");
            this.txtDeliveryID.Name = "txtDeliveryID";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGenerate
            // 
            resources.ApplyResources(this.btnGenerate, "btnGenerate");
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReplySlip
            // 
            resources.ApplyResources(this.btnReplySlip, "btnReplySlip");
            this.btnReplySlip.Name = "btnReplySlip";
            this.btnReplySlip.UseVisualStyleBackColor = true;
            this.btnReplySlip.Click += new System.EventHandler(this.btnReplySlip_Click);
            // 
            // UcSearchDelivery
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReplySlip);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDeliveryID);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.dgvDelivery);
            this.Name = "UcSearchDelivery";
            this.Load += new System.EventHandler(this.UcSearchDelivery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListView dgvDelivery;
        #endregion

        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.TextBox txtDeliveryID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReplySlip;
    }
}
