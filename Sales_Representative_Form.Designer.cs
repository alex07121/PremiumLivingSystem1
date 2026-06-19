namespace PremiumLivingSystem
{
    partial class Sales_Representative_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Representative_Form));
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            resources.ApplyResources(this.btnCreateOrder, "btnCreateOrder");
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.btnCreateOrder);
            this.panel1.Controls.Add(this.button4);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            resources.ApplyResources(this.btnCustomer, "btnCustomer");
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mainPanel);
            this.Name = "Sales_Representative_Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnCustomer;
    }
}