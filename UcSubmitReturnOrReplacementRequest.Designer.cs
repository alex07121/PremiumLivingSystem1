namespace PremiumLivingSystem
{
    partial class UcSubmitReturnOrReplacementRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSubmitReturnOrReplacementRequest));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cboOrderID = new System.Windows.Forms.ComboBox();
            this.cboReturnType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.lstPhotos = new System.Windows.Forms.ListBox();
            this.btnRemovePhoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.cboOrderID.FormattingEnabled = true;
            resources.ApplyResources(this.cboOrderID, "cboOrderID");
            this.cboOrderID.Name = "cboOrderID";
            this.cboOrderID.SelectedIndexChanged += new System.EventHandler(this.cboOrderID_SelectedIndexChanged);
            this.cboReturnType.FormattingEnabled = true;
            this.cboReturnType.Items.AddRange(new object[] {
            resources.GetString("cboReturnType.Items"),
            resources.GetString("cboReturnType.Items1"),
            resources.GetString("cboReturnType.Items2")});
            resources.ApplyResources(this.cboReturnType, "cboReturnType");
            this.cboReturnType.Name = "cboReturnType";
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            resources.ApplyResources(this.btnUploadPhoto, "btnUploadPhoto");
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            this.lstPhotos.FormattingEnabled = true;
            resources.ApplyResources(this.lstPhotos, "lstPhotos");
            this.lstPhotos.Name = "lstPhotos";
            resources.ApplyResources(this.btnRemovePhoto, "btnRemovePhoto");
            this.btnRemovePhoto.Name = "btnRemovePhoto";
            this.btnRemovePhoto.UseVisualStyleBackColor = true;
            this.btnRemovePhoto.Click += new System.EventHandler(this.btnRemovePhoto_Click);
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.Multiselect = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemovePhoto);
            this.Controls.Add(this.lstPhotos);
            this.Controls.Add(this.btnUploadPhoto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboReturnType);
            this.Controls.Add(this.cboOrderID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "UcSubmitReturnOrReplacementRequest";
            this.Load += new System.EventHandler(this.UcSubmitReturnOrReplacementRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox cboOrderID;
        private System.Windows.Forms.ComboBox cboReturnType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.ListBox lstPhotos;
        private System.Windows.Forms.Button btnRemovePhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
