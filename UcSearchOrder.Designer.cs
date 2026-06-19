namespace PremiumLivingSystem
{
    partial class UcSearchOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchOrder));
            this.dgvOrder = new System.Windows.Forms.ListView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvOrder
            // 
            this.dgvOrder.FullRowSelect = true;
            this.dgvOrder.GridLines = true;
            this.dgvOrder.HideSelection = false;
            resources.ApplyResources(this.dgvOrder, "dgvOrder");
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.UseCompatibleStateImageBehavior = false;
            this.dgvOrder.View = System.Windows.Forms.View.Details;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtOrderID
            // 
            resources.ApplyResources(this.txtOrderID, "txtOrderID");
            this.txtOrderID.Name = "txtOrderID";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnInvoice
            // 
            resources.ApplyResources(this.btnInvoice, "btnInvoice");
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UcSearchOrder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label1);
            this.Name = "UcSearchOrder";
            this.Load += new System.EventHandler(this.UcSearchOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView dgvOrder;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnCancel;
    }
}
