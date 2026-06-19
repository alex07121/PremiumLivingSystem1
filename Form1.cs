using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{
 
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE
            );

            btnLogout.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            frmLogin.ShowDialog();

            if (frmLogin.Login)
            {
                btnLogin.Enabled = false;
                btnLogout.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
        }
    }
}