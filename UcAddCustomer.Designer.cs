namespace PremiumLivingSystem
{
    partial class UcAddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAddCustomer));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cboCustomerType = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            resources.ApplyResources(this.txtCustomerName, "txtCustomerName");
            this.txtCustomerName.Name = "txtCustomerName";
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.Name = "txtPhone";
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.Name = "txtAddress";
            resources.ApplyResources(this.cboCustomerType, "cboCustomerType");
            this.cboCustomerType.FormattingEnabled = true;
            this.cboCustomerType.Items.AddRange(new object[] {
            resources.GetString("cboCustomerType.Items"),
            resources.GetString("cboCustomerType.Items1")});
            this.cboCustomerType.Name = "cboCustomerType";
            this.cboCustomerType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboCustomerType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcAddCustomer";
            this.Load += new System.EventHandler(this.UcAddCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cboCustomerType;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClear;
    }
}
