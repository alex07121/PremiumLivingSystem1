namespace PremiumLivingSystem
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.btnLogin.Location = new System.Drawing.Point(169, 168);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(99, 29);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogout.Location = new System.Drawing.Point(169, 266);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(1);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 29);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(116, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Premium Living System";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1, 28, 1, 1);
            this.Text = "Furniture Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
    }
}

