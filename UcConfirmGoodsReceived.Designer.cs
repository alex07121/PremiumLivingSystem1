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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcConfirmGoodsReceived));
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
            // 
            // lblSearch
            // 
            resources.ApplyResources(this.lblSearch, "lblSearch");
            this.lblSearch.Name = "lblSearch";
            // 
            // txtDNID
            // 
            resources.ApplyResources(this.txtDNID, "txtDNID");
            this.txtDNID.Name = "txtDNID";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblCustomer
            // 
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.Name = "lblCustomer";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnLoadAll
            // 
            resources.ApplyResources(this.btnLoadAll, "btnLoadAll");
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // lblDeliveryNotes
            // 
            resources.ApplyResources(this.lblDeliveryNotes, "lblDeliveryNotes");
            this.lblDeliveryNotes.Name = "lblDeliveryNotes";
            // 
            // listDeliveryNotes
            // 
            resources.ApplyResources(this.listDeliveryNotes, "listDeliveryNotes");
            this.listDeliveryNotes.FullRowSelect = true;
            this.listDeliveryNotes.GridLines = true;
            this.listDeliveryNotes.HideSelection = false;
            this.listDeliveryNotes.MultiSelect = false;
            this.listDeliveryNotes.Name = "listDeliveryNotes";
            this.listDeliveryNotes.UseCompatibleStateImageBehavior = false;
            this.listDeliveryNotes.View = System.Windows.Forms.View.Details;
            this.listDeliveryNotes.SelectedIndexChanged += new System.EventHandler(this.listDeliveryNotes_SelectedIndexChanged);
            // 
            // listGoodsItems
            // 
            resources.ApplyResources(this.listGoodsItems, "listGoodsItems");
            this.listGoodsItems.FullRowSelect = true;
            this.listGoodsItems.GridLines = true;
            this.listGoodsItems.HideSelection = false;
            this.listGoodsItems.MultiSelect = false;
            this.listGoodsItems.Name = "listGoodsItems";
            this.listGoodsItems.UseCompatibleStateImageBehavior = false;
            this.listGoodsItems.View = System.Windows.Forms.View.Details;
            this.listGoodsItems.SelectedIndexChanged += new System.EventHandler(this.listGoodsItems_SelectedIndexChanged);
            // 
            // lblReceivedBy
            // 
            resources.ApplyResources(this.lblReceivedBy, "lblReceivedBy");
            this.lblReceivedBy.Name = "lblReceivedBy";
            // 
            // txtReceivedBy
            // 
            resources.ApplyResources(this.txtReceivedBy, "txtReceivedBy");
            this.txtReceivedBy.Name = "txtReceivedBy";
            // 
            // lblActualQty
            // 
            resources.ApplyResources(this.lblActualQty, "lblActualQty");
            this.lblActualQty.Name = "lblActualQty";
            // 
            // nudActualQty
            // 
            resources.ApplyResources(this.nudActualQty, "nudActualQty");
            this.nudActualQty.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudActualQty.Name = "nudActualQty";
            // 
            // btnSetQty
            // 
            resources.ApplyResources(this.btnSetQty, "btnSetQty");
            this.btnSetQty.Name = "btnSetQty";
            this.btnSetQty.UseVisualStyleBackColor = true;
            this.btnSetQty.Click += new System.EventHandler(this.btnSetQty_Click);
            // 
            // UcConfirmGoodsReceived
            // 
            resources.ApplyResources(this, "$this");
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
            this.Name = "UcConfirmGoodsReceived";
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
