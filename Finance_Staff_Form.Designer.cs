namespace PremiumLivingSystem
{
    partial class Finance_Staff_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finance_Staff_Form));
            this.btnLogout = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.mainpanel, "mainpanel");
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.cmbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Click += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.btnLogout);
            this.Name = "Finance_Staff_Form";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}