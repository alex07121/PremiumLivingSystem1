namespace PremiumLivingSystem
{
    partial class UcRecordInwardGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcRecordInwardGoods));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            resources.ApplyResources(this.cmbSupplier, "cmbSupplier");
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            resources.ApplyResources(this.cmbMaterial, "cmbMaterial");
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            resources.ApplyResources(this.nudQty, "nudQty");
            this.nudQty.Name = "nudQty";
            resources.ApplyResources(this.txtUnit, "txtUnit");
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddRow_Click);
            resources.ApplyResources(this.dgvItems, "dgvItems");
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowTemplate.Height = 42;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnRemoveRow_Click);
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcRecordInwardGoods";
            this.Load += new System.EventHandler(this.UcRecordInwardGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
    }
}
