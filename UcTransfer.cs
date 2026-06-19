using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcTransfer : UserControl
    {
        public UcTransfer()
        {
            InitializeComponent();
        }

        private void UcTransfer_Load(object sender, EventArgs e)
        {
            GenerateTransferID();
            SetupDataGridView();
            LoadStaffDropdowns();

            // ApprovedBy / ReceivedBy / IssuedBy are filled later in workflow.
            // During creation (UcTransfer), they are read-only.
            cmbApprovedBy.Enabled = false;
            cmbReceivedBy.Enabled = false;
            cmbIssuedBy.Enabled = false;
            dtpApprovedDate.Enabled = false;
            dtpReceivedDate.Enabled = false;
            dtpIssuedDate.Enabled = false;
            LoadCurrentUser();

            // Default to Material mode
            rbMaterial.Checked = true;
            LoadItemList();
        }

        // ================================================================
        // INITIALIZATION
        // ================================================================

        private void GenerateTransferID()
        {
            try
            {
                // Format: IT + YYMMDD + 4-digit sequence
                string prefix = "IT" + DateTime.Now.ToString("yyMMdd");
                string query = @"
                    SELECT TransferID FROM RawMaterialTransfer
                    WHERE TransferID LIKE @prefix
                    ORDER BY TransferID DESC LIMIT 1";

                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@prefix", prefix + "%");
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    int seq = 1;
                    if (result != null)
                    {
                        string lastId = result.ToString();
                        string seqStr = lastId.Substring(8); // "YYMMDD" = 6 chars + "IT" = 2 chars
                        if (int.TryParse(seqStr, out int lastSeq))
                            seq = lastSeq + 1;
                    }
                    txtTransferNo.Text = prefix + seq.ToString("D4");
                }
            }
            catch (Exception ex)
            {
                txtTransferNo.Text = "IT" + DateTime.Now.ToString("yyMMdd") + "0001";
                System.Diagnostics.Debug.WriteLine("TransferID generation failed: " + ex.Message);
            }
        }

        private void SetupDataGridView()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("colItemID", "Item ID");
            dgvItems.Columns.Add("colDescription", "Description");
            dgvItems.Columns.Add("colQty", "Quantity");
            dgvItems.Columns.Add("colUnit", "Unit");
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadStaffDropdowns()
        {
            try
            {
                string query = @"
                    SELECT s.StaffID, s.StaffName, j.Job_Title,
                           CONCAT(s.StaffID, ' - ', s.StaffName, ' (', j.Job_Title, ')') AS DisplayText
                    FROM Staff s
                    JOIN Jobs j ON s.Job_ID = j.Job_ID
                    WHERE s.IsActive = TRUE
                    ORDER BY s.StaffID";

                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                }

                // Fill all 3 dropdowns
                cmbApprovedBy.DataSource = dt.Copy();
                cmbApprovedBy.DisplayMember = "DisplayText";
                cmbApprovedBy.ValueMember = "StaffID";

                cmbReceivedBy.DataSource = dt.Copy();
                cmbReceivedBy.DisplayMember = "DisplayText";
                cmbReceivedBy.ValueMember = "StaffID";

                cmbIssuedBy.DataSource = dt.Copy();
                cmbIssuedBy.DisplayMember = "DisplayText";
                cmbIssuedBy.ValueMember = "StaffID";

                // Default: no selection
                cmbApprovedBy.SelectedIndex = -1;
                cmbReceivedBy.SelectedIndex = -1;
                cmbIssuedBy.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadCurrentUser()
        {
            try
            {
                string staffId = UserSession.CurrentStaffId;
                if (string.IsNullOrEmpty(staffId)) return;

                string query = @"
                    SELECT s.StaffID, s.StaffName, j.Job_Title, s.Phone
                    FROM Staff s
                    JOIN Jobs j ON s.Job_ID = j.Job_ID
                    WHERE s.StaffID = @staffId";

                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffId", staffId);
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtReqBy.Text = reader["StaffID"].ToString();
                        txtReqName.Text = reader["StaffName"].ToString();
                        txtReqPos.Text = reader["Job_Title"].ToString();
                        txtReqPhone.Text = reader["Phone"]?.ToString() ?? "";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadCurrentUser failed: " + ex.Message);
            }
        }

        // ================================================================
        // ITEM MANAGEMENT
        // ================================================================

        private void rbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemList();
        }

        private void rbProduct_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemList();
        }

        private void LoadItemList()
        {
            string query;
            if (rbMaterial.Checked)
            {
                query = @"
                    SELECT MaterialID AS ItemID, MaterialName AS ItemName, Unit,
                           CONCAT(MaterialID, ' - ', MaterialName, ' [', Unit, ']') AS DisplayText
                    FROM RawMaterial
                    ORDER BY MaterialID";
            }
            else
            {
                query = @"
                    SELECT ProductID AS ItemID, ProductName AS ItemName, 'pcs' AS Unit,
                           CONCAT(ProductID, ' - ', ProductName) AS DisplayText
                    FROM Product
                    ORDER BY ProductID";
            }

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                }

                cmbItem.DataSource = dt;
                cmbItem.DisplayMember = "DisplayText";
                cmbItem.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedValue == null) return;

            var rowView = cmbItem.SelectedItem as DataRowView;
            if (rowView == null) return;

            string itemId = cmbItem.SelectedValue.ToString();
            string itemName = rowView["ItemName"].ToString();
            string unit = rowView["Unit"].ToString();
            decimal qty = nudQty.Value;

            // Prevent duplicates
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["colItemID"].Value?.ToString() == itemId)
                {
                    MessageBox.Show("This item is already in the list.");
                    return;
                }
            }

            dgvItems.Rows.Add(itemId, itemName, qty.ToString("F2"), unit);
            nudQty.Value = 1;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItems.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvItems.Rows.Remove(row);
                }
            }
        }

        // ================================================================
        // SAVE / SUBMIT
        // ================================================================

        private string GetTransferType()
        {
            if (rbMaterial.Checked)
                return "RawMaterial_Out"; // Default: warehouse -> production
            else
                return "Product_In";      // Default: production -> warehouse
        }

        private string SaveTransfer(string status)
        {
            if (dgvItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one item.");
                return null;
            }

            string transferType = GetTransferType();
            // Use dtpReqDate for TransferDate -- it's the Requested By signature date
            string transferDate = dtpReqDate.Value.ToString("yyyy-MM-dd");
            string orderId = string.IsNullOrWhiteSpace(txtOrderID.Text) ? null : txtOrderID.Text.Trim();
            string prodId = string.IsNullOrWhiteSpace(txtProductionID.Text) ? null : txtProductionID.Text.Trim();
            string reqBy = txtReqBy.Text.Trim();
            string fromLoc = txtFromLocation.Text.Trim();
            string toLoc = txtToLocation.Text.Trim();
            string approvedBy = cmbApprovedBy.SelectedValue?.ToString();
            string issuedBy = cmbIssuedBy.SelectedValue?.ToString();
            string receivedBy = cmbReceivedBy.SelectedValue?.ToString();
            string remarks = txtRemarks.Text.Trim();

            object approvedDate = (approvedBy != null) ? (object)dtpApprovedDate.Value.ToString("yyyy-MM-dd") : DBNull.Value;
            object issuedDate = (issuedBy != null) ? (object)dtpIssuedDate.Value.ToString("yyyy-MM-dd") : DBNull.Value;
            object receivedDate = (receivedBy != null) ? (object)dtpReceivedDate.Value.ToString("yyyy-MM-dd") : DBNull.Value;

            string insertHeader = @"
                INSERT INTO RawMaterialTransfer
                (TransferDate, TransferType, OrderID, ProductionID,
                 RequestedBy, FromLocation, ToLocation, Status,
                 ApprovedBy, ApprovedDate, IssuedBy, IssuedDate,
                 ReceivedBy, ReceivedDate, Remarks)
                VALUES
                (@tDate, @tType, @oId, @pId,
                 @reqBy, @from, @to, @status,
                 @appBy, @appDate, @issBy, @issDate,
                 @recBy, @recDate, @remarks)";

            string insertItem = @"
                INSERT INTO RawMaterialTransferItem
                (TransferID, MaterialID, ProductID, Quantity, Unit, Description)
                VALUES (@tId, @matId, @prodId, @qty, @unit, @desc)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmdHeader = new MySqlCommand(insertHeader, conn);
                    cmdHeader.Parameters.AddWithValue("@tDate", transferDate);
                    cmdHeader.Parameters.AddWithValue("@tType", transferType);
                    cmdHeader.Parameters.AddWithValue("@oId", (object)orderId ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@pId", (object)prodId ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@reqBy", reqBy);
                    cmdHeader.Parameters.AddWithValue("@from", (object)fromLoc ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@to", (object)toLoc ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@status", status);
                    cmdHeader.Parameters.AddWithValue("@appBy", (object)approvedBy ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@appDate", approvedDate);
                    cmdHeader.Parameters.AddWithValue("@issBy", (object)issuedBy ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@issDate", issuedDate);
                    cmdHeader.Parameters.AddWithValue("@recBy", (object)receivedBy ?? DBNull.Value);
                    cmdHeader.Parameters.AddWithValue("@recDate", receivedDate);
                    cmdHeader.Parameters.AddWithValue("@remarks", string.IsNullOrEmpty(remarks) ? (object)DBNull.Value : remarks);

                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();
                    cmdHeader.Transaction = trans;

                    try
                    {
                        int rowsHeader = cmdHeader.ExecuteNonQuery();

                        // Retrieve the actual TransferID generated by DB trigger
                        string actualTransferId;
                        string queryId = @"
                            SELECT TransferID FROM RawMaterialTransfer
                            WHERE TransferID LIKE CONCAT('IT', DATE_FORMAT(@tDate, '%y%m%d'), '%')
                            AND RequestedBy = @reqBy
                            ORDER BY TransferID DESC LIMIT 1";
                        MySqlCommand cmdGetId = new MySqlCommand(queryId, conn, trans);
                        cmdGetId.Parameters.AddWithValue("@tDate", transferDate);
                        cmdGetId.Parameters.AddWithValue("@reqBy", reqBy);
                        actualTransferId = cmdGetId.ExecuteScalar()?.ToString();
                        if (string.IsNullOrEmpty(actualTransferId))
                            throw new Exception("Failed to retrieve generated TransferID.");

                        // Update UI and return the real DB-generated ID
                        txtTransferNo.Text = actualTransferId;

                        // Step 2: Insert items using real TransferID
                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string itemId = row.Cells["colItemID"].Value?.ToString();
                            string description = row.Cells["colDescription"].Value?.ToString();
                            decimal qty = Convert.ToDecimal(row.Cells["colQty"].Value);
                            string unit = row.Cells["colUnit"].Value?.ToString();

                            MySqlCommand cmdItem = new MySqlCommand(insertItem, conn, trans);
                            cmdItem.Parameters.AddWithValue("@tId", actualTransferId);
                            cmdItem.Parameters.AddWithValue("@matId", rbMaterial.Checked ? (object)itemId : DBNull.Value);
                            cmdItem.Parameters.AddWithValue("@prodId", rbMaterial.Checked ? DBNull.Value : (object)itemId);
                            cmdItem.Parameters.AddWithValue("@qty", qty);
                            cmdItem.Parameters.AddWithValue("@unit", (object)unit ?? DBNull.Value);
                            cmdItem.Parameters.AddWithValue("@desc", (object)description ?? DBNull.Value);
                            cmdItem.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return actualTransferId;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
                return null;
            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            string result = SaveTransfer("Draft");
            if (result != null)
            {
                MessageBox.Show($"Transfer saved as Draft.\nTransfer #: {result}", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                GenerateTransferID();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtReqBy.Text))
            {
                MessageBox.Show("Requested By is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFromLocation.Text))
            {
                MessageBox.Show("Transfer From location is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtToLocation.Text))
            {
                MessageBox.Show("Transfer To location is required.");
                return;
            }

            string result = SaveTransfer("Pending");
            if (result != null)
            {
                MessageBox.Show($"Transfer submitted successfully.\nTransfer #: {result}", "Submitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                GenerateTransferID();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            GenerateTransferID();
        }

        private void ClearForm()
        {
            txtOrderID.Clear();
            txtProductionID.Clear();
            txtFromLocation.Clear();
            txtToLocation.Clear();
            txtRemarks.Clear();
            dgvItems.Rows.Clear();

            cmbApprovedBy.SelectedIndex = -1;
            cmbReceivedBy.SelectedIndex = -1;
            cmbIssuedBy.SelectedIndex = -1;

            dtpTransferDate.Value = DateTime.Now;
            dtpReqDate.Value = DateTime.Now;
            dtpApprovedDate.Value = DateTime.Now;
            dtpReceivedDate.Value = DateTime.Now;
            dtpIssuedDate.Value = DateTime.Now;
        }

        // ================================================================
        // PRINT TO PDF
        // ================================================================

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintToPdf();
        }

        private void PrintToPdf()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"Transfer_{txtTransferNo.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                sfd.DefaultExt = "pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (Bitmap bitmap = CaptureFormToBitmap())
                {
                    try
                    {
                        SaveBitmapAsPdf(bitmap, sfd.FileName);
                        MessageBox.Show("PDF exported successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        string pngPath = Path.ChangeExtension(sfd.FileName, ".png");
                        bitmap.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show(
                            $"PDF export failed: {ex.Message}\n\nSaved as PNG instead:\n{pngPath}",
                            "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Saves a Bitmap as a PDF file using pure C# (no external dependencies).
        /// </summary>
        private void SaveBitmapAsPdf(Bitmap bitmap, string filePath)
        {
            using (MemoryStream jpegStream = new MemoryStream())
            {
                bitmap.Save(jpegStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] jpegBytes = jpegStream.ToArray();

                int width = bitmap.Width;
                int height = bitmap.Height;
                float pdfWidth = width * 72f / 96f;
                float pdfHeight = height * 72f / 96f;

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    List<long> byteOffsets = new List<long>();
                    Action<string> writeLine = (s) =>
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(s + "\n");
                        fs.Write(bytes, 0, bytes.Length);
                    };

                    byteOffsets.Add(fs.Position);
                    writeLine("%PDF-1.4");

                    byteOffsets.Add(fs.Position);
                    writeLine("1 0 obj");
                    writeLine("<< /Type /Catalog /Pages 2 0 R >>");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("2 0 obj");
                    writeLine("<< /Type /Pages /Kids [3 0 R] /Count 1 >>");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("3 0 obj");
                    writeLine($"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {pdfWidth} {pdfHeight}] /Contents 4 0 R /Resources << /XObject << /Im0 5 0 R >> >> >>");
                    writeLine("endobj");

                    string contentStream = $"q {pdfWidth} 0 0 {pdfHeight} 0 0 cm /Im0 Do Q";
                    byte[] contentBytes = Encoding.ASCII.GetBytes(contentStream);
                    byteOffsets.Add(fs.Position);
                    writeLine("4 0 obj");
                    writeLine($"<< /Length {contentBytes.Length} >>");
                    writeLine("stream");
                    fs.Write(contentBytes, 0, contentBytes.Length);
                    writeLine("");
                    writeLine("endstream");
                    writeLine("endobj");

                    byteOffsets.Add(fs.Position);
                    writeLine("5 0 obj");
                    writeLine($"<< /Type /XObject /Subtype /Image /Width {width} /Height {height} /ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode /Length {jpegBytes.Length} >>");
                    writeLine("stream");
                    fs.Write(jpegBytes, 0, jpegBytes.Length);
                    writeLine("");
                    writeLine("endstream");
                    writeLine("endobj");

                    long xrefOffset = fs.Position;
                    writeLine("xref");
                    writeLine("0 6");
                    writeLine("0000000000 65535 f ");
                    for (int i = 1; i < byteOffsets.Count; i++)
                    {
                        writeLine($"{byteOffsets[i]:0000000000} 00000 n ");
                    }

                    writeLine("trailer");
                    writeLine("<< /Size 6 /Root 1 0 R >>");
                    writeLine("startxref");
                    writeLine($"{xrefOffset}");
                    writeLine("%%EOF");

                    fs.Flush();
                }
            }
        }

        private Bitmap CaptureFormToBitmap()
        {
            btnPrint.Visible = false;
            this.Refresh();

            // Get full control bounds including scrollable area
            int totalWidth = this.DisplayRectangle.Width;
            int totalHeight = this.DisplayRectangle.Height;

            // Find the lowest control to determine actual needed height
            int bottomMost = totalHeight;
            foreach (Control ctrl in this.Controls)
            {
                int ctrlBottom = ctrl.Bottom + ctrl.Margin.Bottom;
                if (ctrlBottom > bottomMost)
                    bottomMost = ctrlBottom;
            }

            Bitmap bitmap = new Bitmap(totalWidth, bottomMost);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, totalWidth, bottomMost));

            btnPrint.Visible = true;
            return bitmap;
        }
    }
}
