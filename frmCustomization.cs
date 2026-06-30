using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PremiumLivingSystem
{

    public partial class frmCustomization : MaterialForm
    {
        public CustomDetailsDTO CustomData { get; private set; }

        private List<string> selectedFiles = new List<string>();

        // [v5.5] Stores the raw bytes of every selected image so they can be
        // persisted directly into CustomizationImage.ImageData (LONGBLOB).
        private List<byte[]> selectedImageBytes = new List<byte[]>();

        public decimal FinalCustomPrice { get; private set; }

        public frmCustomization(decimal basePrice)
        {
            InitializeComponent();

       
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500,      
                Primary.Indigo700,
                Primary.Indigo300,
                Accent.Pink200,
                TextShade.WHITE
            );

            txtBasePrice.Text = basePrice.ToString("0.00");
            txtCustomPrice.Text = basePrice.ToString("0.00");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                CustomData = new CustomDetailsDTO
                {
                    DimensionL = decimal.Parse(txtDimL.Text),
                    DimensionW = decimal.Parse(txtDimW.Text),
                    DimensionH = decimal.Parse(txtDimH.Text),
                    Material = txtMaterial.Text,
                    Color = txtColor.Text,
                    FinishType = txtFinishType.Text,
                    CustomDescription = txtDescription.Text,
                    ImagePaths = this.selectedFiles,
                    ImageDataList = this.selectedImageBytes
                };
                FinalCustomPrice = decimal.Parse(txtCustomPrice.Text);

                if (FinalCustomPrice < decimal.Parse(txtBasePrice.Text))
                {
                    MessageBox.Show("Customized product price cannot be lower than the standard base price!", "Price Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please ensure that length, width, and height are entered correctly! " + ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        try
                        {
                            // [v5.5] Read the file bytes once at upload time so the
                            // LONGBLOB payload is ready for direct DB insertion later.
                            byte[] imageBytes = File.ReadAllBytes(filePath);

                            selectedFiles.Add(filePath);
                            selectedImageBytes.Add(imageBytes);
                            listBoxImages.Items.Add(Path.GetFileName(filePath));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"Failed to read image '{Path.GetFileName(filePath)}'.\n{ex.Message}",
                                "Upload Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            txtDimL.Clear(); 
            txtDimW.Clear();
            txtDimH.Clear();
            txtMaterial.Clear();
            txtColor.Clear();
            txtFinishType.Clear();
            txtBasePrice.Clear();
            txtCustomPrice.Clear();
            txtDescription.Clear();
        }
    }
}