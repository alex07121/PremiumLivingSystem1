namespace PremiumLivingSystem
{
    partial class UcAddNewTrackingRecord
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAddNewTrackingRecord));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.cboDNID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            resources.ApplyResources(this.cboAction, "cboAction");
            this.cboAction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Items.AddRange(new object[] {
            resources.GetString("cboAction.Items"),
            resources.GetString("cboAction.Items1"),
            resources.GetString("cboAction.Items2")});
            this.cboAction.Name = "cboAction";
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            resources.ApplyResources(this.cboDNID, "cboDNID");
            this.cboDNID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDNID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDNID.FormattingEnabled = true;
            this.cboDNID.Name = "cboDNID";
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            resources.ApplyResources(this.txtRemark, "txtRemark");
            this.txtRemark.Name = "txtRemark";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.txtLocation, "txtLocation");
            this.txtLocation.Name = "txtLocation";
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDNID);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcAddNewTrackingRecord";
            this.Load += new System.EventHandler(this.UcAddNewTrackingRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ComboBox cboDNID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtLocation;
    }
}
