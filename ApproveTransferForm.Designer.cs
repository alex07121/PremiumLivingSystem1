namespace PremiumLivingSystem
{
    partial class ApproveTransferForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTransfers = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnViewItems = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).BeginInit();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            this.dgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfers.Location = new System.Drawing.Point(15, 40);
            this.dgvTransfers.Name = "dgvTransfers";
            this.dgvTransfers.Size = new System.Drawing.Size(960, 280);
            this.dgvTransfers.TabIndex = 0;
            this.dgvTransfers.SelectionChanged += new System.EventHandler(this.btnViewItems_Click);
            this.btnApprove.Location = new System.Drawing.Point(700, 330);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(130, 40);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnCancel.Location = new System.Drawing.Point(845, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel Transfer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnViewItems.Location = new System.Drawing.Point(15, 330);
            this.btnViewItems.Name = "btnViewItems";
            this.btnViewItems.Size = new System.Drawing.Size(130, 40);
            this.btnViewItems.TabIndex = 3;
            this.btnViewItems.Text = "View Items";
            this.btnViewItems.UseVisualStyleBackColor = true;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 18);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Pending Transfers — Supervisor Approval";
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(15, 385);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(960, 200);
            this.grpItems.TabIndex = 5;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Transfer Items";
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(10, 22);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(940, 170);
            this.dgvItems.TabIndex = 0;
            this.ClientSize = new System.Drawing.Size(990, 600);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnViewItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvTransfers);
            this.Name = "ApproveTransferForm";
            this.Text = "Approve Transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ApproveTransferForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).EndInit();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTransfers;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnViewItems;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
    }
}
