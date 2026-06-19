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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listTransfers = new System.Windows.Forms.ListView();
            this.listItems = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(78, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Transfer ID:";
            this.txtSearch.Location = new System.Drawing.Point(95, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 0;
            this.btnSearch.Location = new System.Drawing.Point(305, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblItems.Location = new System.Drawing.Point(12, 315);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(53, 16);
            this.lblItems.TabIndex = 5;
            this.lblItems.Text = "Items:";
            this.btnApprove.Enabled = false;
            this.btnApprove.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.Location = new System.Drawing.Point(700, 335);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(130, 50);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(845, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel Transfer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.listTransfers.FullRowSelect = true;
            this.listTransfers.GridLines = true;
            this.listTransfers.HideSelection = false;
            this.listTransfers.Location = new System.Drawing.Point(12, 45);
            this.listTransfers.MultiSelect = false;
            this.listTransfers.Name = "listTransfers";
            this.listTransfers.Size = new System.Drawing.Size(960, 260);
            this.listTransfers.TabIndex = 4;
            this.listTransfers.UseCompatibleStateImageBehavior = false;
            this.listTransfers.View = System.Windows.Forms.View.Details;
            this.listTransfers.SelectedIndexChanged += new System.EventHandler(this.listTransfers_SelectedIndexChanged);
            this.listItems.FullRowSelect = true;
            this.listItems.GridLines = true;
            this.listItems.HideSelection = false;
            this.listItems.Location = new System.Drawing.Point(12, 335);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(640, 180);
            this.listItems.TabIndex = 6;
            this.listItems.UseCompatibleStateImageBehavior = false;
            this.listItems.View = System.Windows.Forms.View.Details;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
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
            this.Size = new System.Drawing.Size(990, 530);
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
