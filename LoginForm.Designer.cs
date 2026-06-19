namespace PremiumLivingSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.staffid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.staffidtext = new System.Windows.Forms.TextBox();
            this.pswdtext = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // staffid
            // 
            this.staffid.AutoSize = true;
            this.staffid.Font = new System.Drawing.Font("新細明體", 12F);
            this.staffid.Location = new System.Drawing.Point(243, 443);
            this.staffid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.staffid.Name = "staffid";
            this.staffid.Size = new System.Drawing.Size(124, 36);
            this.staffid.TabIndex = 0;
            this.staffid.Text = "Staff ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F);
            this.label2.Location = new System.Drawing.Point(243, 531);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // staffidtext
            // 
            this.staffidtext.Location = new System.Drawing.Point(422, 443);
            this.staffidtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.staffidtext.Name = "staffidtext";
            this.staffidtext.Size = new System.Drawing.Size(370, 40);
            this.staffidtext.TabIndex = 2;
            // 
            // pswdtext
            // 
            this.pswdtext.Location = new System.Drawing.Point(422, 531);
            this.pswdtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pswdtext.Name = "pswdtext";
            this.pswdtext.Size = new System.Drawing.Size(370, 40);
            this.pswdtext.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 12F);
            this.button1.Location = new System.Drawing.Point(649, 673);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 72);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 12F);
            this.button2.Location = new System.Drawing.Point(250, 673);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 72);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::PremiumLivingSystem.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(422, 155);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 997);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pswdtext);
            this.Controls.Add(this.staffidtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.staffid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(2, 63, 2, 2);
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label staffid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox staffidtext;
        private System.Windows.Forms.TextBox pswdtext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}