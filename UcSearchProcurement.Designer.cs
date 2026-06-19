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
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lvResults = new System.Windows.Forms.ListView();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ----------------------------------------------------------------
            // lblTitle
            // ----------------------------------------------------------------
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 31);
            this.lblTitle.Text = "Search Purchase Order";

            // ----------------------------------------------------------------
            // lblPOID
            // ----------------------------------------------------------------
            this.lblPOID.AutoSize = true;
            this.lblPOID.Location = new System.Drawing.Point(40, 75);
            this.lblPOID.Name = "lblPOID";
            this.lblPOID.Text = "PO ID:";

            // ----------------------------------------------------------------
            // txtPOID
            // ----------------------------------------------------------------
            this.txtPOID.Location = new System.Drawing.Point(110, 72);
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.Size = new System.Drawing.Size(200, 27);

            // ----------------------------------------------------------------
            // lblStatus
            // ----------------------------------------------------------------
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(350, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status:";

            // ----------------------------------------------------------------
            // cmbStatusFilter — matches T3 SearchForm ComboBox pattern
            // ----------------------------------------------------------------
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
                "All",
                "Draft",
                "Sent",
                "PartiallyReceived",
                "Received",
                "Cancelled"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(420, 72);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(180, 27);

            // ----------------------------------------------------------------
            // btnSearch — matches T3 btnSearch style
            // ----------------------------------------------------------------
            this.btnSearch.Location = new System.Drawing.Point(630, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ----------------------------------------------------------------
            // btnShowAll
            // ----------------------------------------------------------------
            this.btnShowAll.Location = new System.Drawing.Point(770, 70);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(120, 35);
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // ----------------------------------------------------------------
            // btnRefresh — reset form (T3 btnDelete reset pattern)
            // ----------------------------------------------------------------
            this.btnRefresh.Location = new System.Drawing.Point(910, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ----------------------------------------------------------------
            // grpResults
            // ----------------------------------------------------------------
            this.grpResults.Controls.Add(this.lvResults);
            this.grpResults.Location = new System.Drawing.Point(40, 130);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(990, 400);
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Search Results";

            // ----------------------------------------------------------------
            // lvResults — matches UcSearchOrder ListView pattern (T3 style)
            // ----------------------------------------------------------------
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(20, 25);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(950, 360);
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;

            // ----------------------------------------------------------------
            // UcSearchProcurement
            // ----------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPOID);
            this.Controls.Add(this.lblPOID);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcSearchProcurement";
            this.Size = new System.Drawing.Size(1070, 570);
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
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.GroupBox grpResults;
    }
}
