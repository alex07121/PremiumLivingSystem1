namespace PremiumLivingSystem
{
    partial class UcPendingTransfers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPendingTransfers));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            // btnApprove
            // 
            resources.ApplyResources(this.btnApprove, "btnApprove");
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // UcPendingTransfers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listItems);
            this.Controls.Add(this.listTransfers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "UcPendingTransfers";
            this.Load += new System.EventHandler(this.UcPendingTransfers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listTransfers;
        private System.Windows.Forms.ListView listItems;
    }
}
