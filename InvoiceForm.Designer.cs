namespace PremiumLivingSystem
{
    partial class InvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtStamp = new System.Windows.Forms.TextBox();
            this.lblStamp = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.colItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnitCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.lblBillingAddress = new System.Windows.Forms.Label();
            this.txtDeliveryMethod = new System.Windows.Forms.TextBox();
            this.txtDispatchDate = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lblDeliveryMethod = new System.Windows.Forms.Label();
            this.lblDispatchDate = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.invoicePanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.invoicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPrint.Location = new System.Drawing.Point(1855, 1558);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(292, 66);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print to PDF";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtStamp
            // 
            this.txtStamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStamp.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStamp.Location = new System.Drawing.Point(1022, 1236);
            this.txtStamp.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtStamp.Multiline = true;
            this.txtStamp.Name = "txtStamp";
            this.txtStamp.ReadOnly = true;
            this.txtStamp.Size = new System.Drawing.Size(336, 189);
            this.txtStamp.TabIndex = 24;
            // 
            // lblStamp
            // 
            this.lblStamp.AutoSize = true;
            this.lblStamp.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblStamp.Location = new System.Drawing.Point(1015, 1184);
            this.lblStamp.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblStamp.Name = "lblStamp";
            this.lblStamp.Size = new System.Drawing.Size(287, 38);
            this.lblStamp.TabIndex = 23;
            this.lblStamp.Text = "Company Stamp:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 10F);
            this.txtRemarks.Location = new System.Drawing.Point(54, 1236);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(907, 189);
            this.txtRemarks.TabIndex = 22;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(47, 1184);
            this.lblRemarks.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(347, 38);
            this.lblRemarks.TabIndex = 21;
            this.lblRemarks.Text = "OTHER COMMENTS:";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(1622, 1284);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(371, 42);
            this.txtTotal.TabIndex = 20;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOther
            // 
            this.txtOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOther.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOther.Location = new System.Drawing.Point(1622, 1215);
            this.txtOther.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtOther.Name = "txtOther";
            this.txtOther.ReadOnly = true;
            this.txtOther.Size = new System.Drawing.Size(371, 42);
            this.txtOther.TabIndex = 19;
            this.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSubtotal.Location = new System.Drawing.Point(1622, 1146);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(371, 42);
            this.txtSubtotal.TabIndex = 18;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(1472, 1290);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(105, 38);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total:";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOther.Location = new System.Drawing.Point(1461, 1221);
            this.lblOther.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(107, 38);
            this.lblOther.TabIndex = 16;
            this.lblOther.Text = "Other:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Arial", 11F);
            this.lblSubtotal.Location = new System.Drawing.Point(1423, 1153);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(143, 38);
            this.lblSubtotal.TabIndex = 15;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // listViewItems
            // 
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemId,
            this.colDescription,
            this.colQuantity,
            this.colUnitCost,
            this.colDiscount,
            this.colPrice});
            this.listViewItems.Font = new System.Drawing.Font("Arial", 10F);
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(54, 717);
            this.listViewItems.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(1936, 401);
            this.listViewItems.TabIndex = 14;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // colItemId
            // 
            this.colItemId.Text = "Item ID";
            this.colItemId.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 285;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity";
            this.colQuantity.Width = 95;
            // 
            // colUnitCost
            // 
            this.colUnitCost.Text = "Unit Cost";
            this.colUnitCost.Width = 115;
            // 
            // colDiscount
            // 
            this.colDiscount.Text = "Discount";
            this.colDiscount.Width = 115;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Price";
            this.colPrice.Width = 115;
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingAddress.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBillingAddress.Location = new System.Drawing.Point(369, 523);
            this.txtBillingAddress.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtBillingAddress.Multiline = true;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.ReadOnly = true;
            this.txtBillingAddress.Size = new System.Drawing.Size(1624, 143);
            this.txtBillingAddress.TabIndex = 13;
            // 
            // lblBillingAddress
            // 
            this.lblBillingAddress.AutoSize = true;
            this.lblBillingAddress.Font = new System.Drawing.Font("Arial", 12F);
            this.lblBillingAddress.Location = new System.Drawing.Point(47, 530);
            this.lblBillingAddress.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblBillingAddress.Name = "lblBillingAddress";
            this.lblBillingAddress.Size = new System.Drawing.Size(258, 41);
            this.lblBillingAddress.TabIndex = 12;
            this.lblBillingAddress.Text = "Billing Address:";
            // 
            // txtDeliveryMethod
            // 
            this.txtDeliveryMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryMethod.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDeliveryMethod.Location = new System.Drawing.Point(1575, 424);
            this.txtDeliveryMethod.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDeliveryMethod.Name = "txtDeliveryMethod";
            this.txtDeliveryMethod.ReadOnly = true;
            this.txtDeliveryMethod.Size = new System.Drawing.Size(417, 42);
            this.txtDeliveryMethod.TabIndex = 11;
            // 
            // txtDispatchDate
            // 
            this.txtDispatchDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDispatchDate.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDispatchDate.Location = new System.Drawing.Point(1575, 355);
            this.txtDispatchDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDispatchDate.Name = "txtDispatchDate";
            this.txtDispatchDate.ReadOnly = true;
            this.txtDispatchDate.Size = new System.Drawing.Size(417, 42);
            this.txtDispatchDate.TabIndex = 10;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCustomerID.Location = new System.Drawing.Point(1575, 287);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(417, 42);
            this.txtCustomerID.TabIndex = 9;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderID.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrderID.Location = new System.Drawing.Point(1575, 218);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(417, 42);
            this.txtOrderID.TabIndex = 8;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDate.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrderDate.Location = new System.Drawing.Point(1575, 150);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(417, 42);
            this.txtOrderDate.TabIndex = 7;
            // 
            // lblDeliveryMethod
            // 
            this.lblDeliveryMethod.AutoSize = true;
            this.lblDeliveryMethod.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDeliveryMethod.Location = new System.Drawing.Point(1260, 430);
            this.lblDeliveryMethod.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDeliveryMethod.Name = "lblDeliveryMethod";
            this.lblDeliveryMethod.Size = new System.Drawing.Size(254, 38);
            this.lblDeliveryMethod.TabIndex = 6;
            this.lblDeliveryMethod.Text = "Delivery Method:";
            // 
            // lblDispatchDate
            // 
            this.lblDispatchDate.AutoSize = true;
            this.lblDispatchDate.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDispatchDate.Location = new System.Drawing.Point(1260, 361);
            this.lblDispatchDate.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDispatchDate.Name = "lblDispatchDate";
            this.lblDispatchDate.Size = new System.Drawing.Size(229, 38);
            this.lblDispatchDate.TabIndex = 5;
            this.lblDispatchDate.Text = "Dispatch Date:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Arial", 11F);
            this.lblCustomerID.Location = new System.Drawing.Point(1260, 293);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(208, 38);
            this.lblCustomerID.TabIndex = 4;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrderNo.Location = new System.Drawing.Point(1260, 224);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(136, 38);
            this.lblOrderNo.TabIndex = 3;
            this.lblOrderNo.Text = "Order #:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrderDate.Location = new System.Drawing.Point(1260, 156);
            this.lblOrderDate.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(185, 38);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(1750, 31);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 70);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Invoice";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.Location = new System.Drawing.Point(42, 37);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(796, 56);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Premium Living Furniture Co. Ltd.";
            // 
            // invoicePanel
            // 
            this.invoicePanel.BackColor = System.Drawing.Color.White;
            this.invoicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invoicePanel.Controls.Add(this.pictureBox2);
            this.invoicePanel.Controls.Add(this.lblCompanyName);
            this.invoicePanel.Controls.Add(this.lblTitle);
            this.invoicePanel.Controls.Add(this.lblOrderDate);
            this.invoicePanel.Controls.Add(this.lblOrderNo);
            this.invoicePanel.Controls.Add(this.lblCustomerID);
            this.invoicePanel.Controls.Add(this.lblDispatchDate);
            this.invoicePanel.Controls.Add(this.lblDeliveryMethod);
            this.invoicePanel.Controls.Add(this.txtOrderDate);
            this.invoicePanel.Controls.Add(this.txtOrderID);
            this.invoicePanel.Controls.Add(this.txtCustomerID);
            this.invoicePanel.Controls.Add(this.txtDispatchDate);
            this.invoicePanel.Controls.Add(this.txtDeliveryMethod);
            this.invoicePanel.Controls.Add(this.lblBillingAddress);
            this.invoicePanel.Controls.Add(this.txtBillingAddress);
            this.invoicePanel.Controls.Add(this.listViewItems);
            this.invoicePanel.Controls.Add(this.lblSubtotal);
            this.invoicePanel.Controls.Add(this.lblOther);
            this.invoicePanel.Controls.Add(this.lblTotal);
            this.invoicePanel.Controls.Add(this.txtSubtotal);
            this.invoicePanel.Controls.Add(this.txtOther);
            this.invoicePanel.Controls.Add(this.txtTotal);
            this.invoicePanel.Controls.Add(this.lblRemarks);
            this.invoicePanel.Controls.Add(this.txtRemarks);
            this.invoicePanel.Controls.Add(this.lblStamp);
            this.invoicePanel.Controls.Add(this.txtStamp);
            this.invoicePanel.Location = new System.Drawing.Point(47, 37);
            this.invoicePanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.invoicePanel.Name = "invoicePanel";
            this.invoicePanel.Size = new System.Drawing.Size(2097, 1493);
            this.invoicePanel.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = global::PremiumLivingSystem.Properties.Resources.Logo;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(1089, 1253);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 156);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2203, 1664);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.invoicePanel);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "InvoiceForm";
            this.Text = "Invoice";
            this.invoicePanel.ResumeLayout(false);
            this.invoicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtStamp;
        private System.Windows.Forms.Label lblStamp;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader colItemId;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colUnitCost;
        private System.Windows.Forms.ColumnHeader colDiscount;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Label lblBillingAddress;
        private System.Windows.Forms.TextBox txtDeliveryMethod;
        private System.Windows.Forms.TextBox txtDispatchDate;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblDeliveryMethod;
        private System.Windows.Forms.Label lblDispatchDate;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Panel invoicePanel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
