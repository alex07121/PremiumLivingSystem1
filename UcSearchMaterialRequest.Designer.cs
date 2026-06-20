namespace PremiumLivingSystem
{
    partial class UcSearchMaterialRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchMaterialRequest));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblRequestID = new System.Windows.Forms.Label();
            this.txtRequestID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.ListView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.txtUrgency = new System.Windows.Forms.TextBox();
            this.lblReqDate = new System.Windows.Forms.Label();
            this.txtReqDate = new System.Windows.Forms.TextBox();
            this.lblReqBy = new System.Windows.Forms.Label();
            this.txtReqBy = new System.Windows.Forms.TextBox();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.txtCurrentStatus = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarksDet = new System.Windows.Forms.TextBox();
            this.lblStockAvail = new System.Windows.Forms.Label();
            this.txtStockAvail = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCreateTransfer = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpSearch.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // grpSearch
            // 
            resources.ApplyResources(this.grpSearch, "grpSearch");
            this.grpSearch.Controls.Add(this.lblRequestID);
            this.grpSearch.Controls.Add(this.txtRequestID);
            this.grpSearch.Controls.Add(this.lblStatus);
            this.grpSearch.Controls.Add(this.cmbStatusFilter);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnShowAll);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.TabStop = false;
            // 
            // lblRequestID
            // 
            resources.ApplyResources(this.lblRequestID, "lblRequestID");
            this.lblRequestID.Name = "lblRequestID";
            // 
            // txtRequestID
            // 
            resources.ApplyResources(this.txtRequestID, "txtRequestID");
            this.txtRequestID.Name = "txtRequestID";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // cmbStatusFilter
            // 
            resources.ApplyResources(this.cmbStatusFilter, "cmbStatusFilter");
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            resources.GetString("cmbStatusFilter.Items"),
            resources.GetString("cmbStatusFilter.Items1"),
            resources.GetString("cmbStatusFilter.Items2"),
            resources.GetString("cmbStatusFilter.Items3")});
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowAll
            // 
            resources.ApplyResources(this.btnShowAll, "btnShowAll");
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // grpResults
            // 
            resources.ApplyResources(this.grpResults, "grpResults");
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Name = "grpResults";
            this.grpResults.TabStop = false;
            // 
            // dgvResults
            // 
            resources.ApplyResources(this.dgvResults, "dgvResults");
            this.dgvResults.FullRowSelect = true;
            this.dgvResults.GridLines = true;
            this.dgvResults.HideSelection = false;
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.UseCompatibleStateImageBehavior = false;
            this.dgvResults.View = System.Windows.Forms.View.Details;
            this.dgvResults.SelectedIndexChanged += new System.EventHandler(this.dgvResults_SelectedIndexChanged);
            // 
            // grpDetails
            // 
            resources.ApplyResources(this.grpDetails, "grpDetails");
            this.grpDetails.Controls.Add(this.lblMaterialName);
            this.grpDetails.Controls.Add(this.txtMaterialName);
            this.grpDetails.Controls.Add(this.lblQuantity);
            this.grpDetails.Controls.Add(this.txtQuantity);
            this.grpDetails.Controls.Add(this.lblUrgency);
            this.grpDetails.Controls.Add(this.txtUrgency);
            this.grpDetails.Controls.Add(this.lblReqDate);
            this.grpDetails.Controls.Add(this.txtReqDate);
            this.grpDetails.Controls.Add(this.lblReqBy);
            this.grpDetails.Controls.Add(this.txtReqBy);
            this.grpDetails.Controls.Add(this.lblCurrentStatus);
            this.grpDetails.Controls.Add(this.txtCurrentStatus);
            this.grpDetails.Controls.Add(this.lblRemarks);
            this.grpDetails.Controls.Add(this.txtRemarksDet);
            this.grpDetails.Controls.Add(this.lblStockAvail);
            this.grpDetails.Controls.Add(this.txtStockAvail);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabStop = false;
            // 
            // lblMaterialName
            // 
            resources.ApplyResources(this.lblMaterialName, "lblMaterialName");
            this.lblMaterialName.Name = "lblMaterialName";
            // 
            // txtMaterialName
            // 
            resources.ApplyResources(this.txtMaterialName, "txtMaterialName");
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Name = "lblQuantity";
            // 
            // txtQuantity
            // 
            resources.ApplyResources(this.txtQuantity, "txtQuantity");
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            // 
            // lblUrgency
            // 
            resources.ApplyResources(this.lblUrgency, "lblUrgency");
            this.lblUrgency.Name = "lblUrgency";
            // 
            // txtUrgency
            // 
            resources.ApplyResources(this.txtUrgency, "txtUrgency");
            this.txtUrgency.Name = "txtUrgency";
            this.txtUrgency.ReadOnly = true;
            // 
            // lblReqDate
            // 
            resources.ApplyResources(this.lblReqDate, "lblReqDate");
            this.lblReqDate.Name = "lblReqDate";
            // 
            // txtReqDate
            // 
            resources.ApplyResources(this.txtReqDate, "txtReqDate");
            this.txtReqDate.Name = "txtReqDate";
            this.txtReqDate.ReadOnly = true;
            // 
            // lblReqBy
            // 
            resources.ApplyResources(this.lblReqBy, "lblReqBy");
            this.lblReqBy.Name = "lblReqBy";
            // 
            // txtReqBy
            // 
            resources.ApplyResources(this.txtReqBy, "txtReqBy");
            this.txtReqBy.Name = "txtReqBy";
            this.txtReqBy.ReadOnly = true;
            // 
            // lblCurrentStatus
            // 
            resources.ApplyResources(this.lblCurrentStatus, "lblCurrentStatus");
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            // 
            // txtCurrentStatus
            // 
            resources.ApplyResources(this.txtCurrentStatus, "txtCurrentStatus");
            this.txtCurrentStatus.Name = "txtCurrentStatus";
            this.txtCurrentStatus.ReadOnly = true;
            // 
            // lblRemarks
            // 
            resources.ApplyResources(this.lblRemarks, "lblRemarks");
            this.lblRemarks.Name = "lblRemarks";
            // 
            // txtRemarksDet
            // 
            resources.ApplyResources(this.txtRemarksDet, "txtRemarksDet");
            this.txtRemarksDet.Name = "txtRemarksDet";
            this.txtRemarksDet.ReadOnly = true;
            // 
            // lblStockAvail
            // 
            resources.ApplyResources(this.lblStockAvail, "lblStockAvail");
            this.lblStockAvail.Name = "lblStockAvail";
            // 
            // txtStockAvail
            // 
            resources.ApplyResources(this.txtStockAvail, "txtStockAvail");
            this.txtStockAvail.Name = "txtStockAvail";
            this.txtStockAvail.ReadOnly = true;
            // 
            // btnApprove
            // 
            resources.ApplyResources(this.btnApprove, "btnApprove");
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnCreateTransfer
            // 
            resources.ApplyResources(this.btnCreateTransfer, "btnCreateTransfer");
            this.btnCreateTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnCreateTransfer.ForeColor = System.Drawing.Color.White;
            this.btnCreateTransfer.Name = "btnCreateTransfer";
            this.btnCreateTransfer.UseVisualStyleBackColor = false;
            this.btnCreateTransfer.Click += new System.EventHandler(this.btnCreateTransfer_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UcSearchMaterialRequest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCreateTransfer);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcSearchMaterialRequest";
            this.Load += new System.EventHandler(this.UcSearchMaterialRequest_Load);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblRequestID;
        private System.Windows.Forms.TextBox txtRequestID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;

        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.ListView dgvResults;

        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.TextBox txtUrgency;
        private System.Windows.Forms.Label lblReqDate;
        private System.Windows.Forms.TextBox txtReqDate;
        private System.Windows.Forms.Label lblReqBy;
        private System.Windows.Forms.TextBox txtReqBy;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.TextBox txtCurrentStatus;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarksDet;
        private System.Windows.Forms.Label lblStockAvail;
        private System.Windows.Forms.TextBox txtStockAvail;

        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCreateTransfer;
        private System.Windows.Forms.Button btnRefresh;
    }
}
