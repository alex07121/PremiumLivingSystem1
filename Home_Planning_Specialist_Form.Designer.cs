namespace PremiumLivingSystem
{
    partial class Home_Planning_Specialist_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Planning_Specialist_Form));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnSubmitComplaint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnMasterCustomer = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            resources.ApplyResources(this.btnCreateOrder, "btnCreateOrder");
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.btnAddCustomer, "btnAddCustomer");
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            resources.ApplyResources(this.btnSubmitComplaint, "btnSubmitComplaint");
            this.btnSubmitComplaint.Name = "btnSubmitComplaint";
            this.btnSubmitComplaint.UseVisualStyleBackColor = true;
            this.btnSubmitComplaint.Click += new System.EventHandler(this.btnSubmitComplaint_Click);
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Controls.Add(this.btnMasterCustomer);
            this.pnlSidebar.Controls.Add(this.button5);
            this.pnlSidebar.Controls.Add(this.button4);
            this.pnlSidebar.Controls.Add(this.btnCreateOrder);
            this.pnlSidebar.Controls.Add(this.button3);
            this.pnlSidebar.Controls.Add(this.btnAddCustomer);
            this.pnlSidebar.Controls.Add(this.button1);
            this.pnlSidebar.Controls.Add(this.btnSubmitComplaint);
            resources.ApplyResources(this.pnlSidebar, "pnlSidebar");
            this.pnlSidebar.Name = "pnlSidebar";
            resources.ApplyResources(this.btnMasterCustomer, "btnMasterCustomer");
            this.btnMasterCustomer.Name = "btnMasterCustomer";
            this.btnMasterCustomer.UseVisualStyleBackColor = true;
            this.btnMasterCustomer.Click += new System.EventHandler(this.btnMaster_Click);
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mainPanel);
            this.Name = "Home_Planning_Specialist_Form";
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnSubmitComplaint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMasterCustomer;
    }
}