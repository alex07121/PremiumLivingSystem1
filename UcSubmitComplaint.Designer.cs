namespace PremiumLivingSystem
{
    partial class UcSubmitComplaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSubmitComplaint));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCutomerID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cboOrderID = new System.Windows.Forms.ComboBox();
            this.cboComplaintType = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.lstPhotos = new System.Windows.Forms.ListBox();
            this.btnRemovePhoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            resources.ApplyResources(this.txtCutomerID, "txtCutomerID");
            this.txtCutomerID.Name = "txtCutomerID";
            this.txtCutomerID.ReadOnly = true;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(this.contextMenuStrip3, "contextMenuStrip3");
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            resources.ApplyResources(this.cboOrderID, "cboOrderID");
            this.cboOrderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOrderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOrderID.FormattingEnabled = true;
            this.cboOrderID.Name = "cboOrderID";
            this.cboOrderID.SelectedIndexChanged += new System.EventHandler(this.cboOrderID_SelectedIndexChanged);
            resources.ApplyResources(this.cboComplaintType, "cboComplaintType");
            this.cboComplaintType.AllowDrop = true;
            this.cboComplaintType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboComplaintType.FormattingEnabled = true;
            this.cboComplaintType.Items.AddRange(new object[] {
            resources.GetString("cboComplaintType.Items"),
            resources.GetString("cboComplaintType.Items1"),
            resources.GetString("cboComplaintType.Items2"),
            resources.GetString("cboComplaintType.Items3"),
            resources.GetString("cboComplaintType.Items4")});
            this.cboComplaintType.Name = "cboComplaintType";
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            resources.ApplyResources(this.btnUploadPhoto, "btnUploadPhoto");
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            resources.ApplyResources(this.lstPhotos, "lstPhotos");
            this.lstPhotos.FormattingEnabled = true;
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cboComplaintType);
            this.Controls.Add(this.cboOrderID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCutomerID);
            this.Controls.Add(this.label1);
            this.Name = "UcSubmitComplaint";
            this.Load += new System.EventHandler(this.UcSubmitComplaint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCutomerID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ComboBox cboOrderID;
        private System.Windows.Forms.ComboBox cboComplaintType;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.ListBox lstPhotos;
        private System.Windows.Forms.Button btnRemovePhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
