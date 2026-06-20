namespace PremiumLivingSystem
{
    partial class UcApproveTransfers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcApproveTransfers));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.listTransfers = new System.Windows.Forms.ListView();
            this.listItems = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            resources.ApplyResources(this.lblSearch, "lblSearch");
            this.lblSearch.Name = "lblSearch";
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblItems
            // 
            resources.ApplyResources(this.lblItems, "lblItems");
            this.lblItems.Name = "lblItems";
            // 
            // btnIssue
            // 
            resources.ApplyResources(this.btnIssue, "btnIssue");
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // listTransfers
            // 
            resources.ApplyResources(this.listTransfers, "listTransfers");
            this.listTransfers.FullRowSelect = true;
            this.listTransfers.GridLines = true;
            this.listTransfers.HideSelection = false;
            this.listTransfers.MultiSelect = false;
            this.listTransfers.Name = "listTransfers";
            this.listTransfers.UseCompatibleStateImageBehavior = false;
            this.listTransfers.View = System.Windows.Forms.View.Details;
            this.listTransfers.SelectedIndexChanged += new System.EventHandler(this.listTransfers_SelectedIndexChanged);
            // 
            // listItems
            // 
            resources.ApplyResources(this.listItems, "listItems");
            this.listItems.FullRowSelect = true;
            this.listItems.GridLines = true;
            this.listItems.HideSelection = false;
            this.listItems.Name = "listItems";
            this.listItems.UseCompatibleStateImageBehavior = false;
            this.listItems.View = System.Windows.Forms.View.Details;
            // 
            // UcApproveTransfers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listItems);
            this.Controls.Add(this.listTransfers);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "UcApproveTransfers";
            this.Load += new System.EventHandler(this.UcApprovedTransfers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.ListView listTransfers;
        private System.Windows.Forms.ListView listItems;
    }
}
