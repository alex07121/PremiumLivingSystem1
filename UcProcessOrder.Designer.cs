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
            this.dataGridView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductsQTY = new System.Windows.Forms.NumericUpDown();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.btnStockOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsQTY)).BeginInit();
            this.SuspendLayout();
            this.dataGridView1.HideSelection = false;
            this.dataGridView1.Location = new System.Drawing.Point(21, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(777, 246);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.UseCompatibleStateImageBehavior = false;
            this.dataGridView1.View = System.Windows.Forms.View.Details;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 58;
            this.label1.Text = "ProductID";
            this.ProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProductID.FormattingEnabled = true;
            this.ProductID.Location = new System.Drawing.Point(266, 20);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(344, 20);
            this.ProductID.TabIndex = 59;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 60;
            this.label2.Text = "Quantity";
            this.ProductsQTY.Location = new System.Drawing.Point(266, 66);
            this.ProductsQTY.Name = "ProductsQTY";
            this.ProductsQTY.Size = new System.Drawing.Size(344, 22);
            this.ProductsQTY.TabIndex = 62;
            this.btnStockIn.Location = new System.Drawing.Point(101, 390);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(112, 37);
            this.btnStockIn.TabIndex = 63;
            this.btnStockIn.Text = "Stock In";
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            this.btnStockOut.Location = new System.Drawing.Point(471, 390);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(105, 37);
            this.btnStockOut.TabIndex = 64;
            this.btnStockOut.Text = "Stock Out";
            this.btnStockOut.UseVisualStyleBackColor = true;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStockOut);
            this.Controls.Add(this.btnStockIn);
            this.Controls.Add(this.ProductsQTY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProductID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(860, 469);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsQTY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ProductsQTY;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button btnStockOut;
    }
}
