using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PremiumLivingSystem
{
    public class BaseForm : Form
    {
        protected Guna2Panel topPanel;
        protected Guna2Panel contentPanel;
        protected PictureBox picLogo;
        protected Guna2Button btnLogout;

        public BaseForm()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            InitializeBaseComponents();
        }

        private void InitializeBaseComponents()
        {
            // Top Panel
            topPanel = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                FillColor = Color.FromArgb(94, 148, 255),
                BackColor = Color.Transparent
            };

            // Logo
            picLogo = new PictureBox
            {
                Image = Properties.Resources.Logo,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(100, 100),
                Location = new Point(20, 10),
                BackColor = Color.Transparent
            };
            topPanel.Controls.Add(picLogo);

            // Logout Button
            btnLogout = CreateGunaButton("Logout", Color.FromArgb(255, 100, 100), Color.White);
            btnLogout.Location = new Point(this.Width - 180, 25);
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Click += (s, e) => {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            topPanel.Controls.Add(btnLogout);

            // Content Panel (with scroll support)
            contentPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(240, 242, 245),
                BackColor = Color.Transparent,
                Padding = new Padding(20),
                AutoScroll = true
            };

            this.Controls.Add(contentPanel);
            this.Controls.Add(topPanel);
        }

        protected Guna2Button CreateGunaButton(string text, Color fillColor, Color foreColor)
        {
            return new Guna2Button
            {
                Text = text,
                BorderRadius = 10,
                FillColor = fillColor,
                ForeColor = foreColor,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Size = new Size(140, 60),
                Animated = true,
                HoverState = {
                    FillColor = ControlPaint.Light(fillColor, 0.8f)
                }
            };
        }

        protected void AddNavButton(Guna2Button btn, int xPosition)
        {
            btn.Location = new Point(xPosition, 30);
            topPanel.Controls.Add(btn);
        }
    }
}
