namespace PremiumLivingSystem
{
    partial class UcConfirmGoodsReceived
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
            this.txtDNID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.lblDeliveryNotes = new System.Windows.Forms.Label();
            this.listDeliveryNotes = new System.Windows.Forms.ListView();
            this.listGoodsItems = new System.Windows.Forms.ListView();
            this.lblReceivedBy = new System.Windows.Forms.Label();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.lblActualQty = new System.Windows.Forms.Label();
            this.nudActualQty = new System.Windows.Forms.NumericUpDown();
            this.btnSetQty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudActualQty)).BeginInit();
            this.SuspendLayout();
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(24, 22);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(196, 27);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Delivery Note ID:";
            this.txtDNID.Location = new System.Drawing.Point(240, 16);
            this.txtDNID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtDNID.Name = "txtDNID";
            this.txtDNID.Size = new System.Drawing.Size(296, 40);
            this.txtDNID.TabIndex = 0;
            this.btnSearch.Location = new System.Drawing.Point(560, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 44);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(24, 206);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(103, 35);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Items:";
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(760, 22);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(19, 27);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = " ";
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(1130, 778);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(330, 64);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm Received";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            this.btnLoadAll.Location = new System.Drawing.Point(740, 13);
            this.btnLoadAll.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(240, 44);
            this.btnLoadAll.TabIndex = 2;
            this.btnLoadAll.Text = "Load In-Transit";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            this.lblDeliveryNotes.AutoSize = true;
            this.lblDeliveryNotes.Location = new System.Drawing.Point(1097, 13);
            this.lblDeliveryNotes.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeliveryNotes.Name = "lblDeliveryNotes";
            this.lblDeliveryNotes.Size = new System.Drawing.Size(363, 27);
            this.lblDeliveryNotes.TabIndex = 11;
            this.lblDeliveryNotes.Text = "(select a row to view items below)";
            this.listDeliveryNotes.FullRowSelect = true;
            this.listDeliveryNotes.GridLines = true;
            this.listDeliveryNotes.HideSelection = false;
            this.listDeliveryNotes.Location = new System.Drawing.Point(24, 71);
            this.listDeliveryNotes.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listDeliveryNotes.MultiSelect = false;
            this.listDeliveryNotes.Name = "listDeliveryNotes";
            this.listDeliveryNotes.Size = new System.Drawing.Size(1436, 125);
            this.listDeliveryNotes.TabIndex = 8;
            this.listDeliveryNotes.UseCompatibleStateImageBehavior = false;
            this.listDeliveryNotes.View = System.Windows.Forms.View.Details;
            this.listDeliveryNotes.SelectedIndexChanged += new System.EventHandler(this.listDeliveryNotes_SelectedIndexChanged);
            this.listGoodsItems.FullRowSelect = true;
            this.listGoodsItems.GridLines = true;
            this.listGoodsItems.HideSelection = false;
            this.listGoodsItems.Location = new System.Drawing.Point(24, 238);
            this.listGoodsItems.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listGoodsItems.MultiSelect = false;
            this.listGoodsItems.Name = "listGoodsItems";
            this.listGoodsItems.Size = new System.Drawing.Size(1436, 442);
            this.listGoodsItems.TabIndex = 9;
            this.listGoodsItems.UseCompatibleStateImageBehavior = false;
            this.listGoodsItems.View = System.Windows.Forms.View.Details;
            this.listGoodsItems.SelectedIndexChanged += new System.EventHandler(this.listGoodsItems_SelectedIndexChanged);
            this.lblReceivedBy.AutoSize = true;
            this.lblReceivedBy.Location = new System.Drawing.Point(24, 715);
            this.lblReceivedBy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Size = new System.Drawing.Size(150, 27);
            this.lblReceivedBy.TabIndex = 7;
            this.lblReceivedBy.Text = "Received By:";
            this.txtReceivedBy.Location = new System.Drawing.Point(24, 746);
            this.txtReceivedBy.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(396, 40);
            this.txtReceivedBy.TabIndex = 4;
            this.lblActualQty.AutoSize = true;
            this.lblActualQty.Location = new System.Drawing.Point(480, 715);
            this.lblActualQty.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblActualQty.Name = "lblActualQty";
            this.lblActualQty.Size = new System.Drawing.Size(307, 27);
            this.lblActualQty.TabIndex = 12;
            this.lblActualQty.Text = "Actual Qty for selected item:";
            this.nudActualQty.Location = new System.Drawing.Point(486, 746);
            this.nudActualQty.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.nudActualQty.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudActualQty.Name = "nudActualQty";
            this.nudActualQty.Size = new System.Drawing.Size(180, 40);
            this.nudActualQty.TabIndex = 13;
            this.btnSetQty.Location = new System.Drawing.Point(680, 743);
            this.btnSetQty.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSetQty.Name = "btnSetQty";
            this.btnSetQty.Size = new System.Drawing.Size(120, 44);
            this.btnSetQty.TabIndex = 14;
            this.btnSetQty.Text = "Set";
            this.btnSetQty.UseVisualStyleBackColor = true;
            this.btnSetQty.Click += new System.EventHandler(this.btnSetQty_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetQty);
            this.Controls.Add(this.nudActualQty);
            this.Controls.Add(this.lblActualQty);
            this.Controls.Add(this.listGoodsItems);
            this.Controls.Add(this.listDeliveryNotes);
            this.Controls.Add(this.lblDeliveryNotes);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblReceivedBy);
            this.Controls.Add(this.txtReceivedBy);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDNID);
            this.Controls.Add(this.lblSearch);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UcConfirmGoodsReceived";
            this.Size = new System.Drawing.Size(1500, 858);
            this.Load += new System.EventHandler(this.UcConfirmGoodsReceived_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudActualQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtDNID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Label lblDeliveryNotes;
        private System.Windows.Forms.ListView listDeliveryNotes;
        private System.Windows.Forms.ListView listGoodsItems;
        private System.Windows.Forms.Label lblReceivedBy;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.Label lblActualQty;
        private System.Windows.Forms.NumericUpDown nudActualQty;
        private System.Windows.Forms.Button btnSetQty;
    }
}
