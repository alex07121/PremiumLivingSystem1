namespace PremiumLivingSystem
{
    partial class UcSalesSummaryReport
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

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.txtTotalOrders = new System.Windows.Forms.TextBox();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.txtTotalRevenue = new System.Windows.Forms.TextBox();
            this.lblB2B = new System.Windows.Forms.Label();
            this.txtB2B = new System.Windows.Forms.TextBox();
            this.lblB2C = new System.Windows.Forms.Label();
            this.txtB2C = new System.Windows.Forms.TextBox();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.txtCancelled = new System.Windows.Forms.TextBox();

            this.grpMonthly = new System.Windows.Forms.GroupBox();
            this.lvMonthly = new System.Windows.Forms.ListView();

            this.grpTopProducts = new System.Windows.Forms.GroupBox();
            this.lvTopProducts = new System.Windows.Forms.ListView();

            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lvStatus = new System.Windows.Forms.ListView();

            this.grpFilter.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.grpMonthly.SuspendLayout();
            this.grpTopProducts.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();

            // ----------------------------------------------------------------
            // lblTitle
            // ----------------------------------------------------------------
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(350, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 31);
            this.lblTitle.Text = "Sales Summary Report";

            // ----------------------------------------------------------------
            // grpFilter
            // ----------------------------------------------------------------
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.btnGenerate);
            this.grpFilter.Controls.Add(this.btnExport);
            this.grpFilter.Location = new System.Drawing.Point(40, 70);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(1040, 100);
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Date Range Filter";

            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 35);
            this.lblFrom.Text = "From:";

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(70, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(160, 27);
            this.dtpFrom.Value = new System.DateTime(System.DateTime.Now.Year, 1, 1);

            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(260, 35);
            this.lblTo.Text = "To:";

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(300, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(160, 27);
            this.dtpTo.Value = System.DateTime.Now;

            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(500, 30);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 40);
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10F);
            this.btnExport.Location = new System.Drawing.Point(680, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.Text = "Export PDF";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // ----------------------------------------------------------------
            // grpSummary — KPI cards
            // ----------------------------------------------------------------
            this.grpSummary.Controls.Add(this.lblTotalOrders);
            this.grpSummary.Controls.Add(this.txtTotalOrders);
            this.grpSummary.Controls.Add(this.lblTotalRevenue);
            this.grpSummary.Controls.Add(this.txtTotalRevenue);
            this.grpSummary.Controls.Add(this.lblB2B);
            this.grpSummary.Controls.Add(this.txtB2B);
            this.grpSummary.Controls.Add(this.lblB2C);
            this.grpSummary.Controls.Add(this.txtB2C);
            this.grpSummary.Controls.Add(this.lblCancelled);
            this.grpSummary.Controls.Add(this.txtCancelled);
            this.grpSummary.Location = new System.Drawing.Point(40, 190);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(1040, 100);
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";

            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Location = new System.Drawing.Point(20, 35);
            this.lblTotalOrders.Text = "Total Orders:";
            this.txtTotalOrders.Location = new System.Drawing.Point(110, 32);
            this.txtTotalOrders.Name = "txtTotalOrders";
            this.txtTotalOrders.ReadOnly = true;
            this.txtTotalOrders.Size = new System.Drawing.Size(100, 27);
            this.txtTotalOrders.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(240, 35);
            this.lblTotalRevenue.Text = "Total Revenue:";
            this.txtTotalRevenue.Location = new System.Drawing.Point(340, 32);
            this.txtTotalRevenue.Name = "txtTotalRevenue";
            this.txtTotalRevenue.ReadOnly = true;
            this.txtTotalRevenue.Size = new System.Drawing.Size(140, 27);
            this.txtTotalRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblB2B.AutoSize = true;
            this.lblB2B.Location = new System.Drawing.Point(510, 35);
            this.lblB2B.Text = "B2B:";
            this.txtB2B.Location = new System.Drawing.Point(550, 32);
            this.txtB2B.Name = "txtB2B";
            this.txtB2B.ReadOnly = true;
            this.txtB2B.Size = new System.Drawing.Size(80, 27);
            this.txtB2B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblB2C.AutoSize = true;
            this.lblB2C.Location = new System.Drawing.Point(660, 35);
            this.lblB2C.Text = "B2C:";
            this.txtB2C.Location = new System.Drawing.Point(700, 32);
            this.txtB2C.Name = "txtB2C";
            this.txtB2C.ReadOnly = true;
            this.txtB2C.Size = new System.Drawing.Size(80, 27);
            this.txtB2C.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Location = new System.Drawing.Point(810, 35);
            this.lblCancelled.Text = "Cancelled:";
            this.txtCancelled.Location = new System.Drawing.Point(890, 32);
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.ReadOnly = true;
            this.txtCancelled.Size = new System.Drawing.Size(80, 27);
            this.txtCancelled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // ----------------------------------------------------------------
            // grpMonthly — Monthly breakdown ListView
            // ----------------------------------------------------------------
            this.grpMonthly.Controls.Add(this.lvMonthly);
            this.grpMonthly.Location = new System.Drawing.Point(40, 310);
            this.grpMonthly.Name = "grpMonthly";
            this.grpMonthly.Size = new System.Drawing.Size(510, 250);
            this.grpMonthly.TabStop = false;
            this.grpMonthly.Text = "Monthly Sales Breakdown";

            this.lvMonthly.HideSelection = false;
            this.lvMonthly.Location = new System.Drawing.Point(15, 25);
            this.lvMonthly.Name = "lvMonthly";
            this.lvMonthly.Size = new System.Drawing.Size(480, 210);
            this.lvMonthly.UseCompatibleStateImageBehavior = false;
            this.lvMonthly.View = System.Windows.Forms.View.Details;
            this.lvMonthly.FullRowSelect = true;
            this.lvMonthly.GridLines = true;

            // ----------------------------------------------------------------
            // grpTopProducts — Top 5 products ListView
            // ----------------------------------------------------------------
            this.grpTopProducts.Controls.Add(this.lvTopProducts);
            this.grpTopProducts.Location = new System.Drawing.Point(570, 310);
            this.grpTopProducts.Name = "grpTopProducts";
            this.grpTopProducts.Size = new System.Drawing.Size(510, 250);
            this.grpTopProducts.TabStop = false;
            this.grpTopProducts.Text = "Top 5 Best-Selling Products";

            this.lvTopProducts.HideSelection = false;
            this.lvTopProducts.Location = new System.Drawing.Point(15, 25);
            this.lvTopProducts.Name = "lvTopProducts";
            this.lvTopProducts.Size = new System.Drawing.Size(480, 210);
            this.lvTopProducts.UseCompatibleStateImageBehavior = false;
            this.lvTopProducts.View = System.Windows.Forms.View.Details;
            this.lvTopProducts.FullRowSelect = true;
            this.lvTopProducts.GridLines = true;

            // ----------------------------------------------------------------
            // grpStatus — Order status distribution ListView
            // ----------------------------------------------------------------
            this.grpStatus.Controls.Add(this.lvStatus);
            this.grpStatus.Location = new System.Drawing.Point(40, 580);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(1040, 170);
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Order Status Distribution";

            this.lvStatus.HideSelection = false;
            this.lvStatus.Location = new System.Drawing.Point(15, 25);
            this.lvStatus.Name = "lvStatus";
            this.lvStatus.Size = new System.Drawing.Size(1010, 130);
            this.lvStatus.UseCompatibleStateImageBehavior = false;
            this.lvStatus.View = System.Windows.Forms.View.Details;
            this.lvStatus.FullRowSelect = true;
            this.lvStatus.GridLines = true;

            // ----------------------------------------------------------------
            // UcSalesSummaryReport
            // ----------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpTopProducts);
            this.Controls.Add(this.grpMonthly);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcSalesSummaryReport";
            this.Size = new System.Drawing.Size(1120, 780);
            this.Load += new System.EventHandler(this.UcSalesSummaryReport_Load);

            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.grpMonthly.ResumeLayout(false);
            this.grpTopProducts.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.TextBox txtTotalOrders;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.TextBox txtTotalRevenue;
        private System.Windows.Forms.Label lblB2B;
        private System.Windows.Forms.TextBox txtB2B;
        private System.Windows.Forms.Label lblB2C;
        private System.Windows.Forms.TextBox txtB2C;
        private System.Windows.Forms.Label lblCancelled;
        private System.Windows.Forms.TextBox txtCancelled;

        private System.Windows.Forms.GroupBox grpMonthly;
        private System.Windows.Forms.ListView lvMonthly;

        private System.Windows.Forms.GroupBox grpTopProducts;
        private System.Windows.Forms.ListView lvTopProducts;

        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.ListView lvStatus;
    }
}
