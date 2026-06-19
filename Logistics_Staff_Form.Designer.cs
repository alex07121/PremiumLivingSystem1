namespace PremiumLivingSystem
{
    partial class Logistics_Staff_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logistics_Staff_Form));
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAddTrackRecord = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsearchd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHandGood = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            resources.ApplyResources(this.btnAddTrackRecord, "btnAddTrackRecord");
            this.btnAddTrackRecord.Name = "btnAddTrackRecord";
            this.btnAddTrackRecord.UseVisualStyleBackColor = true;
            this.btnAddTrackRecord.Click += new System.EventHandler(this.button1_Click);
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            resources.ApplyResources(this.btnsearchd, "btnsearchd");
            this.btnsearchd.Name = "btnsearchd";
            this.btnsearchd.UseVisualStyleBackColor = true;
            this.btnsearchd.Click += new System.EventHandler(this.btnsearchd_Click);
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.btnHandGood);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnAddTrackRecord);
            this.panel2.Controls.Add(this.btnsearchd);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            resources.ApplyResources(this.btnHandGood, "btnHandGood");
            this.btnHandGood.Name = "btnHandGood";
            this.btnHandGood.UseVisualStyleBackColor = true;
            this.btnHandGood.Click += new System.EventHandler(this.btnHandGood_Click);
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button3_Click);
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Name = "mainPanel";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Name = "Logistics_Staff_Form";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAddTrackRecord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsearchd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnHandGood;
    }
}