using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PremiumLivingSystem
{
    public partial class ProcessOrder : UserControl
    {
        public ProcessOrder()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UpDataStock
            // 
            this.Name = "ProcessOrder";
            this.Size = new System.Drawing.Size(990, 608);
            this.ResumeLayout(false);

        }
    }
}