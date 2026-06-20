namespace PremiumLivingSystem
{
    partial class UcSearchProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvProductStock = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtPid
            // 
            resources.ApplyResources(this.txtPid, "txtPid");
            this.txtPid.Name = "txtPid";
            this.txtPid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvProductStock
            // 
            resources.ApplyResources(this.dgvProductStock, "dgvProductStock");
            this.dgvProductStock.FullRowSelect = true;
            this.dgvProductStock.GridLines = true;
            this.dgvProductStock.HideSelection = false;
            this.dgvProductStock.Name = "dgvProductStock";
            this.dgvProductStock.UseCompatibleStateImageBehavior = false;
            this.dgvProductStock.View = System.Windows.Forms.View.Details;
            // 
            // UcSearchProduct
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvProductStock);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.label1);
            this.Name = "UcSearchProduct";
            this.Load += new System.EventHandler(this.UcSearchProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView dgvProductStock;
    }
}
