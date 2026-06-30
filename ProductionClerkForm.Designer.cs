namespace PremiumLivingSystem
{
    partial class ProductionClerkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionClerkForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMaterialRequest = new System.Windows.Forms.Button();
            this.btnProductManufacturing = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.btnProductManufacturing);
            this.panel2.Controls.Add(this.btnMaterialRequest);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            //
            // btnMaterialRequest
            //
            resources.ApplyResources(this.btnMaterialRequest, "btnMaterialRequest");
            this.btnMaterialRequest.Name = "btnMaterialRequest";
            this.btnMaterialRequest.UseVisualStyleBackColor = true;
            this.btnMaterialRequest.Click += new System.EventHandler(this.btnMaterialRequest_Click);
            //
            // btnProductManufacturing
            // [v5.5 ADDED] - properties set inline (no .resx entry) since it is a
            // new button. Dock=Top so it stacks above btnMaterialRequest inside panel2.
            // Z-order: buttons added later to panel2.Controls appear ABOVE earlier
            // ones when Dock=Top, so btnProductManufacturing is added FIRST in the
            // Controls.Add calls above to make it render BELOW btnMaterialRequest.
            //
            this.btnProductManufacturing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductManufacturing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProductManufacturing.Name = "btnProductManufacturing";
            this.btnProductManufacturing.Size = new System.Drawing.Size(362, 97);
            this.btnProductManufacturing.TabIndex = 5;
            this.btnProductManufacturing.Text = "Product Manufacturing";
            this.btnProductManufacturing.UseVisualStyleBackColor = true;
            this.btnProductManufacturing.Click += new System.EventHandler(this.btnProductManufacturing_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            // 
            // btnLogout
            // 
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ProductionClerkForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainPanel);
            this.Name = "ProductionClerkForm";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMaterialRequest;
        private System.Windows.Forms.Button btnProductManufacturing;
    }
}