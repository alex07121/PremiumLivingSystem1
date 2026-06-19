namespace PLFC_Project
{
    partial class UcSearchTracking
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSearchTracking));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchDNID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvTracking = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.txtSearchDNID, "txtSearchDNID");
            this.txtSearchDNID.Name = "txtSearchDNID";
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            resources.ApplyResources(this.dgvTracking, "dgvTracking");
            this.dgvTracking.FullRowSelect = true;
            this.dgvTracking.GridLines = true;
            this.dgvTracking.HideSelection = false;
            this.dgvTracking.Name = "dgvTracking";
            this.dgvTracking.UseCompatibleStateImageBehavior = false;
            this.dgvTracking.View = System.Windows.Forms.View.Details;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTracking);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchDNID);
            this.Controls.Add(this.label1);
            this.Name = "UcSearchTracking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchDNID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView dgvTracking;
    }
}
