using System;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class TransferForm : Form
    {
        // The UcTransfer UserControl hosted inside this form.
        // All transfer logic (DataGridView, save, pre-fill) lives in UcTransfer;
        // TransferForm is just a dialog wrapper.
        private UcTransfer _ucTransfer;

        public TransferForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Create and host UcTransfer, filling the entire form client area
            _ucTransfer = new UcTransfer();
            _ucTransfer.Dock = DockStyle.Fill;
            this.Controls.Add(_ucTransfer);
        }

        /// <summary>
        /// Queues a Material Request ID for pre-filling the transfer form.
        /// The actual pre-fill happens during UcTransfer_Load (after all
        /// controls are initialized), so this is safe to call before
        /// ShowDialog().
        /// </summary>
        public void PrefillFromMaterialRequest(string requestID)
        {
            _ucTransfer.SetPendingRequestID(requestID);
        }
    }
}
