namespace PremiumLivingSystem
{
    partial class UcProductManufacturing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        ///
        /// NOTE: This Designer.cs is hand-written. Opening UcProductManufacturing.cs
        /// in the Visual Studio Designer view will REGENERATE this file and wipe
        /// the layout. Always edit via View Code (F7) instead.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtOrderSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitDetails = new System.Windows.Forms.SplitContainer();
            this.grpSpec = new System.Windows.Forms.GroupBox();
            this.lblDescriptionCaption = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFinishTypeCaption = new System.Windows.Forms.Label();
            this.lblFinishType = new System.Windows.Forms.Label();
            this.lblColorCaption = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblMaterialCaption = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblDimHCaption = new System.Windows.Forms.Label();
            this.lblDimH = new System.Windows.Forms.Label();
            this.lblDimWCaption = new System.Windows.Forms.Label();
            this.lblDimW = new System.Windows.Forms.Label();
            this.lblDimLCaption = new System.Windows.Forms.Label();
            this.lblDimL = new System.Windows.Forms.Label();
            this.grpImages = new System.Windows.Forms.GroupBox();
            this.lblNoImages = new System.Windows.Forms.Label();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCustomItem = new System.Windows.Forms.Label();
            this.cboCustomItem = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitDetails)).BeginInit();
            this.splitDetails.Panel1.SuspendLayout();
            this.splitDetails.Panel2.SuspendLayout();
            this.splitDetails.SuspendLayout();
            this.grpSpec.SuspendLayout();
            this.grpImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(185, 27);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search Order ID:";
            // 
            // txtOrderSearch
            // 
            this.txtOrderSearch.Location = new System.Drawing.Point(150, 22);
            this.txtOrderSearch.Name = "txtOrderSearch";
            this.txtOrderSearch.Size = new System.Drawing.Size(280, 40);
            this.txtOrderSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(445, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.GridLines = true;
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(20, 70);
            this.lvOrders.MultiSelect = false;
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(900, 180);
            this.lvOrders.TabIndex = 2;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.lvOrders_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order ID";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Order Date";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Required Date";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Customer ID";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 100;
            // 
            // splitDetails
            // 
            this.splitDetails.Location = new System.Drawing.Point(20, 305);
            this.splitDetails.Name = "splitDetails";
            // 
            // splitDetails.Panel1
            // 
            this.splitDetails.Panel1.Controls.Add(this.grpSpec);
            this.splitDetails.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitDetails.Panel2
            // 
            this.splitDetails.Panel2.Controls.Add(this.grpImages);
            this.splitDetails.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitDetails.Size = new System.Drawing.Size(1109, 360);
            this.splitDetails.SplitterDistance = 470;
            this.splitDetails.TabIndex = 3;
            // 
            // grpSpec
            // 
            this.grpSpec.Controls.Add(this.lblDescriptionCaption);
            this.grpSpec.Controls.Add(this.lblDescription);
            this.grpSpec.Controls.Add(this.lblFinishTypeCaption);
            this.grpSpec.Controls.Add(this.lblFinishType);
            this.grpSpec.Controls.Add(this.lblColorCaption);
            this.grpSpec.Controls.Add(this.lblColor);
            this.grpSpec.Controls.Add(this.lblMaterialCaption);
            this.grpSpec.Controls.Add(this.lblMaterial);
            this.grpSpec.Controls.Add(this.lblDimHCaption);
            this.grpSpec.Controls.Add(this.lblDimH);
            this.grpSpec.Controls.Add(this.lblDimWCaption);
            this.grpSpec.Controls.Add(this.lblDimW);
            this.grpSpec.Controls.Add(this.lblDimLCaption);
            this.grpSpec.Controls.Add(this.lblDimL);
            this.grpSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSpec.Location = new System.Drawing.Point(10, 10);
            this.grpSpec.Name = "grpSpec";
            this.grpSpec.Size = new System.Drawing.Size(450, 340);
            this.grpSpec.TabIndex = 0;
            this.grpSpec.TabStop = false;
            this.grpSpec.Text = "Customization Spec";
            // 
            // lblDescriptionCaption
            // 
            this.lblDescriptionCaption.AutoSize = true;
            this.lblDescriptionCaption.Location = new System.Drawing.Point(20, 245);
            this.lblDescriptionCaption.Name = "lblDescriptionCaption";
            this.lblDescriptionCaption.Size = new System.Drawing.Size(137, 27);
            this.lblDescriptionCaption.TabIndex = 0;
            this.lblDescriptionCaption.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(20, 275);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(350, 70);
            this.lblDescription.TabIndex = 1;
            // 
            // lblFinishTypeCaption
            // 
            this.lblFinishTypeCaption.AutoSize = true;
            this.lblFinishTypeCaption.Location = new System.Drawing.Point(20, 210);
            this.lblFinishTypeCaption.Name = "lblFinishTypeCaption";
            this.lblFinishTypeCaption.Size = new System.Drawing.Size(143, 27);
            this.lblFinishTypeCaption.TabIndex = 2;
            this.lblFinishTypeCaption.Text = "Finish Type:";
            // 
            // lblFinishType
            // 
            this.lblFinishType.AutoSize = true;
            this.lblFinishType.Location = new System.Drawing.Point(140, 210);
            this.lblFinishType.Name = "lblFinishType";
            this.lblFinishType.Size = new System.Drawing.Size(0, 27);
            this.lblFinishType.TabIndex = 3;
            // 
            // lblColorCaption
            // 
            this.lblColorCaption.AutoSize = true;
            this.lblColorCaption.Location = new System.Drawing.Point(20, 175);
            this.lblColorCaption.Name = "lblColorCaption";
            this.lblColorCaption.Size = new System.Drawing.Size(77, 27);
            this.lblColorCaption.TabIndex = 4;
            this.lblColorCaption.Text = "Color:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(140, 175);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(0, 27);
            this.lblColor.TabIndex = 5;
            // 
            // lblMaterialCaption
            // 
            this.lblMaterialCaption.AutoSize = true;
            this.lblMaterialCaption.Location = new System.Drawing.Point(20, 140);
            this.lblMaterialCaption.Name = "lblMaterialCaption";
            this.lblMaterialCaption.Size = new System.Drawing.Size(104, 27);
            this.lblMaterialCaption.TabIndex = 6;
            this.lblMaterialCaption.Text = "Material:";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(140, 140);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(0, 27);
            this.lblMaterial.TabIndex = 7;
            // 
            // lblDimHCaption
            // 
            this.lblDimHCaption.AutoSize = true;
            this.lblDimHCaption.Location = new System.Drawing.Point(20, 105);
            this.lblDimHCaption.Name = "lblDimHCaption";
            this.lblDimHCaption.Size = new System.Drawing.Size(142, 27);
            this.lblDimHCaption.TabIndex = 8;
            this.lblDimHCaption.Text = "Height (cm):";
            // 
            // lblDimH
            // 
            this.lblDimH.AutoSize = true;
            this.lblDimH.Location = new System.Drawing.Point(140, 105);
            this.lblDimH.Name = "lblDimH";
            this.lblDimH.Size = new System.Drawing.Size(0, 27);
            this.lblDimH.TabIndex = 9;
            // 
            // lblDimWCaption
            // 
            this.lblDimWCaption.AutoSize = true;
            this.lblDimWCaption.Location = new System.Drawing.Point(20, 70);
            this.lblDimWCaption.Name = "lblDimWCaption";
            this.lblDimWCaption.Size = new System.Drawing.Size(137, 27);
            this.lblDimWCaption.TabIndex = 10;
            this.lblDimWCaption.Text = "Width (cm):";
            // 
            // lblDimW
            // 
            this.lblDimW.AutoSize = true;
            this.lblDimW.Location = new System.Drawing.Point(140, 70);
            this.lblDimW.Name = "lblDimW";
            this.lblDimW.Size = new System.Drawing.Size(0, 27);
            this.lblDimW.TabIndex = 11;
            // 
            // lblDimLCaption
            // 
            this.lblDimLCaption.AutoSize = true;
            this.lblDimLCaption.Location = new System.Drawing.Point(20, 35);
            this.lblDimLCaption.Name = "lblDimLCaption";
            this.lblDimLCaption.Size = new System.Drawing.Size(146, 27);
            this.lblDimLCaption.TabIndex = 12;
            this.lblDimLCaption.Text = "Length (cm):";
            // 
            // lblDimL
            // 
            this.lblDimL.AutoSize = true;
            this.lblDimL.Location = new System.Drawing.Point(140, 35);
            this.lblDimL.Name = "lblDimL";
            this.lblDimL.Size = new System.Drawing.Size(0, 27);
            this.lblDimL.TabIndex = 13;
            // 
            // grpImages
            // 
            this.grpImages.Controls.Add(this.lblNoImages);
            this.grpImages.Controls.Add(this.flowLayoutPanelImages);
            this.grpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImages.Location = new System.Drawing.Point(10, 10);
            this.grpImages.Name = "grpImages";
            this.grpImages.Size = new System.Drawing.Size(615, 340);
            this.grpImages.TabIndex = 0;
            this.grpImages.TabStop = false;
            this.grpImages.Text = "Customer Reference Images";
            // 
            // lblNoImages
            // 
            this.lblNoImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoImages.Location = new System.Drawing.Point(3, 36);
            this.lblNoImages.Name = "lblNoImages";
            this.lblNoImages.Size = new System.Drawing.Size(609, 301);
            this.lblNoImages.TabIndex = 0;
            this.lblNoImages.Text = "No custom images for this order.";
            this.lblNoImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoImages.Visible = false;
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(609, 301);
            this.flowLayoutPanelImages.TabIndex = 0;
            // 
            // lblCustomItem
            // 
            this.lblCustomItem.AutoSize = true;
            this.lblCustomItem.Location = new System.Drawing.Point(20, 270);
            this.lblCustomItem.Name = "lblCustomItem";
            this.lblCustomItem.Size = new System.Drawing.Size(152, 27);
            this.lblCustomItem.TabIndex = 5;
            this.lblCustomItem.Text = "Custom Item:";
            // 
            // cboCustomItem
            // 
            this.cboCustomItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomItem.Location = new System.Drawing.Point(178, 267);
            this.cboCustomItem.Name = "cboCustomItem";
            this.cboCustomItem.Size = new System.Drawing.Size(400, 35);
            this.cboCustomItem.TabIndex = 4;
            this.cboCustomItem.SelectedIndexChanged += new System.EventHandler(this.cboCustomItem_SelectedIndexChanged);
            // 
            // UcProductManufacturing
            // 
            this.Controls.Add(this.splitDetails);
            this.Controls.Add(this.cboCustomItem);
            this.Controls.Add(this.lblCustomItem);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtOrderSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "UcProductManufacturing";
            this.Size = new System.Drawing.Size(1441, 903);
            this.Load += new System.EventHandler(this.UcProductManufacturing_Load);
            this.splitDetails.Panel1.ResumeLayout(false);
            this.splitDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDetails)).EndInit();
            this.splitDetails.ResumeLayout(false);
            this.grpSpec.ResumeLayout(false);
            this.grpSpec.PerformLayout();
            this.grpImages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtOrderSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.SplitContainer splitDetails;
        private System.Windows.Forms.Label lblCustomItem;
        private System.Windows.Forms.ComboBox cboCustomItem;
        private System.Windows.Forms.GroupBox grpSpec;
        private System.Windows.Forms.Label lblDimLCaption;
        private System.Windows.Forms.Label lblDimL;
        private System.Windows.Forms.Label lblDimWCaption;
        private System.Windows.Forms.Label lblDimW;
        private System.Windows.Forms.Label lblDimHCaption;
        private System.Windows.Forms.Label lblDimH;
        private System.Windows.Forms.Label lblMaterialCaption;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblColorCaption;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblFinishTypeCaption;
        private System.Windows.Forms.Label lblFinishType;
        private System.Windows.Forms.Label lblDescriptionCaption;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpImages;
        private System.Windows.Forms.Label lblNoImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
    }
}
