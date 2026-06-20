namespace PremiumLivingSystem
{
    partial class UcSearchProcurement
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
            this.lblPOID = new System.Windows.Forms.Label();
            this.txtPOID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvResults = new System.Windows.Forms.ListView();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(436, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(695, 70);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Search Purchase Order";
            // 
            // lblPOID
            // 
            this.lblPOID.AutoSize = true;
            this.lblPOID.Location = new System.Drawing.Point(62, 112);
            this.lblPOID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPOID.Name = "lblPOID";
            this.lblPOID.Size = new System.Drawing.Size(84, 27);
            this.lblPOID.TabIndex = 7;
            this.lblPOID.Text = "PO ID:";
            // 
            // txtPOID
            // 
            this.txtPOID.Location = new System.Drawing.Point(171, 108);
            this.txtPOID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.Size = new System.Drawing.Size(309, 40);
            this.txtPOID.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(544, 112);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 27);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(980, 105);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(187, 52);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvResults
            // 
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(31, 38);
            this.lvResults.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(1476, 538);
            this.lvResults.TabIndex = 0;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.lvResults);
            this.grpResults.Location = new System.Drawing.Point(62, 195);
            this.grpResults.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpResults.Name = "grpResults";
            this.grpResults.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.grpResults.Size = new System.Drawing.Size(1540, 600);
            this.grpResults.TabIndex = 0;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Search Results";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1207, 99);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(187, 52);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Draft",
            "Sent",
            "PartiallyReceived",
            "Received",
            "Cancelled"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(653, 108);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(278, 35);
            this.cmbStatusFilter.TabIndex = 4;
            // 
            // UcSearchProcurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPOID);
            this.Controls.Add(this.lblPOID);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UcSearchProcurement";
            this.Size = new System.Drawing.Size(1958, 855);
            this.Load += new System.EventHandler(this.UcSearchProcurement_Load);
            this.grpResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPOID;
        private System.Windows.Forms.TextBox txtPOID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
    }
}
