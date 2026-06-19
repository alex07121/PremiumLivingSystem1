namespace PremiumLivingSystem
{
    partial class Reply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reply));
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtDispatch = new System.Windows.Forms.TextBox();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.txtaddress1 = new System.Windows.Forms.TextBox();
            this.listItem = new System.Windows.Forms.ListView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.txtOrderDate, "txtOrderDate");
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            resources.ApplyResources(this.txtOrder, "txtOrder");
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.ReadOnly = true;
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            resources.ApplyResources(this.txtCustomerID, "txtCustomerID");
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            resources.ApplyResources(this.txtDispatch, "txtDispatch");
            this.txtDispatch.Name = "txtDispatch";
            this.txtDispatch.ReadOnly = true;
            resources.ApplyResources(this.txtMethod, "txtMethod");
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.ReadOnly = true;
            resources.ApplyResources(this.txtaddress1, "txtaddress1");
            this.txtaddress1.Name = "txtaddress1";
            this.txtaddress1.ReadOnly = true;
            resources.ApplyResources(this.listItem, "listItem");
            this.listItem.FullRowSelect = true;
            this.listItem.GridLines = true;
            this.listItem.HideSelection = false;
            this.listItem.Name = "listItem";
            this.listItem.UseCompatibleStateImageBehavior = false;
            this.listItem.View = System.Windows.Forms.View.Details;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            resources.ApplyResources(this.txtReceived, "txtReceived");
            this.txtReceived.Name = "txtReceived";
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::PremiumLivingSystem.Properties.Resources.Logo;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.txtaddress1);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.txtDispatch);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.label2);
            this.Name = "Reply";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtDispatch;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.TextBox txtaddress1;
        private System.Windows.Forms.ListView listItem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
