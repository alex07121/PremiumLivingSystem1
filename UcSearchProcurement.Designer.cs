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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchProcurement));
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
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblPOID
            // 
            resources.ApplyResources(this.lblPOID, "lblPOID");
            this.lblPOID.Name = "lblPOID";
            // 
            // txtPOID
            // 
            resources.ApplyResources(this.txtPOID, "txtPOID");
            this.txtPOID.Name = "txtPOID";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvResults
            // 
            resources.ApplyResources(this.lvResults, "lvResults");
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.HideSelection = false;
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // grpResults
            // 
            resources.ApplyResources(this.grpResults, "grpResults");
            this.grpResults.Controls.Add(this.lvResults);
            this.grpResults.Name = "grpResults";
            this.grpResults.TabStop = false;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbStatusFilter
            // 
            resources.ApplyResources(this.cmbStatusFilter, "cmbStatusFilter");
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            resources.GetString("cmbStatusFilter.Items"),
            resources.GetString("cmbStatusFilter.Items1"),
            resources.GetString("cmbStatusFilter.Items2"),
            resources.GetString("cmbStatusFilter.Items3"),
            resources.GetString("cmbStatusFilter.Items4"),
            resources.GetString("cmbStatusFilter.Items5")});
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            // 
            // UcSearchProcurement
            // 
            resources.ApplyResources(this, "$this");
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
            this.Name = "UcSearchProcurement";
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
