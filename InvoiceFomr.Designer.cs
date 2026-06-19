namespace PremiumLivingSystem
{
    partial class InvoiceFomr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceFomr));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.baddress = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.Other = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.Stotal = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtDeliveryMethod = new System.Windows.Forms.TextBox();
            this.txtDispatchDate = new System.Windows.Forms.TextBox();
            this.Dmethod = new System.Windows.Forms.Label();
            this.Ddate = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.Label();
            this.txtCutomer = new System.Windows.Forms.TextBox();
            this.Order = new System.Windows.Forms.Label();
            this.Odate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.textBox9, "textBox9");
            this.textBox9.Name = "textBox9";
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            resources.ApplyResources(this.baddress, "baddress");
            this.baddress.Name = "baddress";
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            resources.ApplyResources(this.Other, "Other");
            this.Other.Name = "Other";
            resources.ApplyResources(this.textBox8, "textBox8");
            this.textBox8.Name = "textBox8";
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            resources.ApplyResources(this.Stotal, "Stotal");
            this.Stotal.Name = "Stotal";
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Name = "label3";
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Name = "label4";
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            resources.ApplyResources(this.txtDeliveryMethod, "txtDeliveryMethod");
            this.txtDeliveryMethod.Name = "txtDeliveryMethod";
            resources.ApplyResources(this.txtDispatchDate, "txtDispatchDate");
            this.txtDispatchDate.Name = "txtDispatchDate";
            resources.ApplyResources(this.Dmethod, "Dmethod");
            this.Dmethod.Name = "Dmethod";
            resources.ApplyResources(this.Ddate, "Ddate");
            this.Ddate.Name = "Ddate";
            resources.ApplyResources(this.CID, "CID");
            this.CID.Name = "CID";
            resources.ApplyResources(this.txtCutomer, "txtCutomer");
            this.txtCutomer.Name = "txtCutomer";
            resources.ApplyResources(this.Order, "Order");
            this.Order.Name = "Order";
            resources.ApplyResources(this.Odate, "Odate");
            this.Odate.Name = "Odate";
            resources.ApplyResources(this.txtOrderDate, "txtOrderDate");
            this.txtOrderDate.Name = "txtOrderDate";
            resources.ApplyResources(this.txtOrder, "txtOrder");
            this.txtOrder.Name = "txtOrder";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.baddress);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.Other);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.Stotal);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtDeliveryMethod);
            this.Controls.Add(this.txtDispatchDate);
            this.Controls.Add(this.Dmethod);
            this.Controls.Add(this.Ddate);
            this.Controls.Add(this.CID);
            this.Controls.Add(this.txtCutomer);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.Odate);
            this.Controls.Add(this.txtOrderDate);
            this.Name = "InvoiceFomr";
            this.Load += new System.EventHandler(this.InvoiceFomr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label baddress;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label Other;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label Stotal;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtDeliveryMethod;
        private System.Windows.Forms.TextBox txtDispatchDate;
        private System.Windows.Forms.Label Dmethod;
        private System.Windows.Forms.Label Ddate;
        private System.Windows.Forms.Label CID;
        private System.Windows.Forms.TextBox txtCutomer;
        private System.Windows.Forms.Label Order;
        private System.Windows.Forms.Label Odate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtOrder;
    }
}