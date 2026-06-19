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

            // ----------------------------------------------------------------
            // lblTitle
            // ----------------------------------------------------------------
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(330, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 31);
            this.lblTitle.Text = "Search Raw Material Request";

            // ----------------------------------------------------------------
            // grpSearch
            // ----------------------------------------------------------------
            this.grpSearch.Controls.Add(this.lblRequestID);
            this.grpSearch.Controls.Add(this.txtRequestID);
            this.grpSearch.Controls.Add(this.lblStatus);
            this.grpSearch.Controls.Add(this.cmbStatusFilter);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.btnShowAll);
            this.grpSearch.Location = new System.Drawing.Point(40, 70);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(960, 110);
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search Criteria";

            this.lblRequestID.AutoSize = true;
            this.lblRequestID.Location = new System.Drawing.Point(20, 35);
            this.lblRequestID.Text = "Request ID:";
            this.txtRequestID.Location = new System.Drawing.Point(110, 32);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.Size = new System.Drawing.Size(180, 27);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(330, 35);
            this.lblStatus.Text = "Status:";
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Items.AddRange(new object[] { "All", "Requested", "Approved", "Fulfilled" });
            this.cmbStatusFilter.Location = new System.Drawing.Point(400, 32);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(160, 27);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(600, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 40);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Arial", 10F);
            this.btnShowAll.Location = new System.Drawing.Point(760, 30);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(140, 40);
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);

            // ----------------------------------------------------------------
            // grpResults — ListView (matches UcSearchOrder style)
            // ----------------------------------------------------------------
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Location = new System.Drawing.Point(40, 200);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(960, 240);
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Search Results";

            this.dgvResults.HideSelection = false;
            this.dgvResults.Location = new System.Drawing.Point(20, 25);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(920, 200);
            this.dgvResults.UseCompatibleStateImageBehavior = false;
            this.dgvResults.View = System.Windows.Forms.View.Details;
            this.dgvResults.FullRowSelect = true;
            this.dgvResults.GridLines = true;
            this.dgvResults.MultiSelect = false;
            this.dgvResults.SelectedIndexChanged += new System.EventHandler(this.dgvResults_SelectedIndexChanged);

            // ----------------------------------------------------------------
            // grpDetails
            // ----------------------------------------------------------------
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
            this.grpDetails.Location = new System.Drawing.Point(40, 460);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(960, 220);
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Request Details (read-only)";

            // Row 1
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(20, 30);
            this.lblMaterialName.Text = "Material:";
            this.txtMaterialName.Location = new System.Drawing.Point(120, 27);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(330, 27);

            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(490, 30);
            this.lblQuantity.Text = "Quantity:";
            this.txtQuantity.Location = new System.Drawing.Point(570, 27);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(100, 27);

            this.lblStockAvail.AutoSize = true;
            this.lblStockAvail.Location = new System.Drawing.Point(700, 30);
            this.lblStockAvail.Text = "In Stock:";
            this.txtStockAvail.Location = new System.Drawing.Point(770, 27);
            this.txtStockAvail.Name = "txtStockAvail";
            this.txtStockAvail.ReadOnly = true;
            this.txtStockAvail.Size = new System.Drawing.Size(150, 27);

            // Row 2
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Location = new System.Drawing.Point(20, 75);
            this.lblUrgency.Text = "Urgency:";
            this.txtUrgency.Location = new System.Drawing.Point(120, 72);
            this.txtUrgency.Name = "txtUrgency";
            this.txtUrgency.ReadOnly = true;
            this.txtUrgency.Size = new System.Drawing.Size(150, 27);

            this.lblReqDate.AutoSize = true;
            this.lblReqDate.Location = new System.Drawing.Point(310, 75);
            this.lblReqDate.Text = "Required Date:";
            this.txtReqDate.Location = new System.Drawing.Point(420, 72);
            this.txtReqDate.Name = "txtReqDate";
            this.txtReqDate.ReadOnly = true;
            this.txtReqDate.Size = new System.Drawing.Size(150, 27);

            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(610, 75);
            this.lblCurrentStatus.Text = "Status:";
            this.txtCurrentStatus.Location = new System.Drawing.Point(670, 72);
            this.txtCurrentStatus.Name = "txtCurrentStatus";
            this.txtCurrentStatus.ReadOnly = true;
            this.txtCurrentStatus.Size = new System.Drawing.Size(150, 27);

            // Row 3
            this.lblReqBy.AutoSize = true;
            this.lblReqBy.Location = new System.Drawing.Point(20, 120);
            this.lblReqBy.Text = "Requested By:";
            this.txtReqBy.Location = new System.Drawing.Point(120, 117);
            this.txtReqBy.Name = "txtReqBy";
            this.txtReqBy.ReadOnly = true;
            this.txtReqBy.Size = new System.Drawing.Size(250, 27);

            // Row 4 — Remarks
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(20, 165);
            this.lblRemarks.Text = "Remarks:";
            this.txtRemarksDet.Location = new System.Drawing.Point(120, 162);
            this.txtRemarksDet.Multiline = true;
            this.txtRemarksDet.Name = "txtRemarksDet";
            this.txtRemarksDet.ReadOnly = true;
            this.txtRemarksDet.Size = new System.Drawing.Size(800, 40);

            // ----------------------------------------------------------------
            // Buttons
            // ----------------------------------------------------------------
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnApprove.Enabled = false;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(620, 700);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(160, 45);
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // btnCreateTransfer — only enabled when Status = 'Approved'
            this.btnCreateTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnCreateTransfer.Enabled = false;
            this.btnCreateTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTransfer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreateTransfer.ForeColor = System.Drawing.Color.White;
            this.btnCreateTransfer.Location = new System.Drawing.Point(440, 700);
            this.btnCreateTransfer.Name = "btnCreateTransfer";
            this.btnCreateTransfer.Size = new System.Drawing.Size(170, 45);
            this.btnCreateTransfer.Text = "Create Transfer";
            this.btnCreateTransfer.UseVisualStyleBackColor = false;
            this.btnCreateTransfer.Click += new System.EventHandler(this.btnCreateTransfer_Click);

            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 11F);
            this.btnRefresh.Location = new System.Drawing.Point(800, 700);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 45);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ----------------------------------------------------------------
            // UcSearchMaterialRequest
            // ----------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
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
            this.Size = new System.Drawing.Size(1040, 770);
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
