namespace PremiumLivingSystem
{
    partial class UserControl2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductsQTY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsQTY)).BeginInit();
            this.SuspendLayout();
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(164, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 267);
            this.dataGridView1.TabIndex = 57;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 27);
            this.label1.TabIndex = 58;
            this.label1.Text = "ProductID";
            this.ProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProductID.FormattingEnabled = true;
            this.ProductID.Location = new System.Drawing.Point(380, 98);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(344, 21);
            this.ProductID.TabIndex = 59;
            this.ProductID.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 27);
            this.label2.TabIndex = 60;
            this.label2.Text = "Quantity";
            this.ProductsQTY.Location = new System.Drawing.Point(380, 147);
            this.ProductsQTY.Name = "ProductsQTY";
            this.ProductsQTY.Size = new System.Drawing.Size(344, 20);
            this.ProductsQTY.TabIndex = 62;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProductsQTY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProductID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1051, 559);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsQTY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ProductsQTY;
    }
}
