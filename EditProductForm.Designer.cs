namespace PremiumLivingSystem
{
    partial class EditProductForm
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProductForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            resources.ApplyResources(this.txtPid, "txtPid");
            this.txtPid.BackColor = System.Drawing.SystemColors.Window;
            this.txtPid.Name = "txtPid";
            this.txtPid.ReadOnly = true;
            resources.ApplyResources(this.txtProductName, "txtProductName");
            this.txtProductName.Name = "txtProductName";
            resources.ApplyResources(this.txtStock, "txtStock");
            this.txtStock.Name = "txtStock";
            resources.ApplyResources(this.txtUnitPrice, "txtUnitPrice");
            this.txtUnitPrice.Name = "txtUnitPrice";
            resources.ApplyResources(this.cboCategory, "cboCategory");
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            resources.GetString("cboCategory.Items")});
            this.cboCategory.Name = "cboCategory";
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditProductForm";
            this.Load += new System.EventHandler(this.EditProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnUpdate;
    }
}