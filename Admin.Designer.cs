namespace PremiumLivingSystem
{
    partial class Admin
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.mainPanel.Location = new System.Drawing.Point(11, 106);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(2573, 815);
            this.mainPanel.TabIndex = 0;
            this.btnLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogout.Location = new System.Drawing.Point(11, 11);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(257, 86);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2475, 956);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.mainPanel);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnLogout;
    }
}