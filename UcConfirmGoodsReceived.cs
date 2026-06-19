using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcConfirmGoodsReceived : UserControl
    {
        private string _currentDNID = null;

        public UcConfirmGoodsReceived() { InitializeComponent(); }

        private void UcConfirmGoodsReceived_Load(object sender, EventArgs e)
        {
            listDeliveryNotes.Columns.Clear();
            listDeliveryNotes.Columns.Add("DNID", 120);
            listDeliveryNotes.Columns.Add("Order ID", 120);
            listDeliveryNotes.Columns.Add("Customer", 150);
            listDeliveryNotes.Columns.Add("Dispatch Date", 100);
            listDeliveryNotes.Columns.Add("Method", 120);
            listDeliveryNotes.Columns.Add("Status", 80);

            listGoodsItems.Columns.Clear();
            listGoodsItems.Columns.Add("Product ID", 100);
            listGoodsItems.Columns.Add("Description", 200);
            listGoodsItems.Columns.Add("Ordered", 70);
            listGoodsItems.Columns.Add("Prev Delivered", 90);
            listGoodsItems.Columns.Add("Actual Qty*", 80);
            listGoodsItems.Columns.Add("Shortage", 70);

            LoadInTransitNotes();
        }

        private void LoadInTransitNotes()
        {
            string query = @"
                SELECT dn.DNID, dn.OrderID, c.CustomerName, dn.DispatchDate,
                       dn.DeliveryMethod, dn.Status
                FROM DeliveryNote dn
                JOIN `Order` o ON dn.OrderID = o.OrderID
                JOIN Customer c ON o.CustomerID = c.CustomerID
                WHERE dn.Status IN ('InTransit','Issued')
                ORDER BY dn.DispatchDate DESC";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listDeliveryNotes.Items.Clear();
                    while (r.Read())
                    {
                        var item = new ListViewItem(r["DNID"].ToString());
                        item.SubItems.Add(r["OrderID"].ToString());
                        item.SubItems.Add(r["CustomerName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(r["DispatchDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(r["DeliveryMethod"].ToString());
                        item.SubItems.Add(r["Status"].ToString());
                        listDeliveryNotes.Items.Add(item);
                    }
                    r.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void btnLoadAll_Click(object sender, EventArgs e) { LoadInTransitNotes(); }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtDNID.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadInTransitNotes(); return; }

            string query = @"SELECT dn.DNID, dn.OrderID, c.CustomerName, dn.DispatchDate, dn.DeliveryMethod, dn.Status
                FROM DeliveryNote dn JOIN `Order` o ON dn.OrderID=o.OrderID JOIN Customer c ON o.CustomerID=c.CustomerID
                WHERE dn.DNID=@dnId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", kw);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listDeliveryNotes.Items.Clear(); bool f = false;
                    while (r.Read())
                    {
                        f = true;
                        var item = new ListViewItem(r["DNID"].ToString());
                        item.SubItems.Add(r["OrderID"].ToString());
                        item.SubItems.Add(r["CustomerName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(r["DispatchDate"]).ToString("yyyy-MM-dd"));
                        item.SubItems.Add(r["DeliveryMethod"].ToString());
                        item.SubItems.Add(r["Status"].ToString());
                        listDeliveryNotes.Items.Add(item);
                    }
                    r.Close();
                    if (!f) MessageBox.Show("No delivery note found.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void listDeliveryNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listGoodsItems.Items.Clear();
            if (listDeliveryNotes.SelectedItems.Count == 0) { btnConfirm.Enabled = false; return; }

            _currentDNID = listDeliveryNotes.SelectedItems[0].Text;
            string cust = listDeliveryNotes.SelectedItems[0].SubItems[2].Text;
            string st = listDeliveryNotes.SelectedItems[0].SubItems[5].Text;
            lblCustomer.Text = $"Customer: {cust}  |  Status: {st}";
            btnConfirm.Enabled = true;
            txtDNID.Text = _currentDNID;
            if (string.IsNullOrWhiteSpace(txtReceivedBy.Text))
                txtReceivedBy.Text = UserSession.CurrentName ?? "";

            LoadItems(_currentDNID);
        }

        private void LoadItems(string dnId)
        {
            string query = @"
                SELECT dni.ProductID, p.ProductName, dni.QtyOrdered, dni.QtyDelivered
                FROM DeliveryNoteItem dni JOIN Product p ON dni.ProductID = p.ProductID
                WHERE dni.DNID = @dnId";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dnId", dnId);
                    conn.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    listGoodsItems.Items.Clear();
                    while (r.Read())
                    {
                        int ordered = Convert.ToInt32(r["QtyOrdered"]);
                        int delivered = Convert.ToInt32(r["QtyDelivered"]);
                        int outstanding = ordered - delivered;

                        // Default: assume all outstanding items received
                        var item = new ListViewItem(r["ProductID"].ToString());
                        item.SubItems.Add(r["ProductName"].ToString());
                        item.SubItems.Add(ordered.ToString());
                        item.SubItems.Add(delivered.ToString());
                        item.SubItems.Add(outstanding.ToString());  // default actual = outstanding
                        item.SubItems.Add("0");                     // shortage = 0 initially
                        listGoodsItems.Items.Add(item);
                    }
                    r.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        private void listGoodsItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGoodsItems.SelectedItems.Count == 0) return;
            // Pre-fill the qty nud with current value
            string current = listGoodsItems.SelectedItems[0].SubItems[4].Text;
            if (int.TryParse(current, out int val)) nudActualQty.Value = val;
        }

        private void btnSetQty_Click(object sender, EventArgs e)
        {
            if (listGoodsItems.SelectedItems.Count == 0) return;

            int newQty = (int)nudActualQty.Value;
            var selected = listGoodsItems.SelectedItems[0];
            int ordered = int.Parse(selected.SubItems[2].Text);
            int prevDel = int.Parse(selected.SubItems[3].Text);

            // Validation: cannot receive more than outstanding
            int outstanding = ordered - prevDel;
            if (newQty < 0)
            {
                MessageBox.Show("Actual quantity cannot be negative.");
                return;
            }
            if (newQty > outstanding)
            {
                MessageBox.Show($"Cannot receive more than outstanding ({outstanding}).");
                return;
            }

            selected.SubItems[4].Text = newQty.ToString();

            // Recalculate shortage correctly: ordered - (prevDel + actual)
            int shortage = ordered - (prevDel + newQty);
            selected.SubItems[5].Text = shortage.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentDNID)) return;

            string receivedBy = txtReceivedBy.Text.Trim();
            if (string.IsNullOrEmpty(receivedBy))
            {
                MessageBox.Show("Please enter the receiver name.");
                return;
            }

            // Validate all items before committing
            bool allFullyDelivered = true;
            foreach (ListViewItem row in listGoodsItems.Items)
            {
                int ordered = int.Parse(row.SubItems[2].Text);
                int prevDel = int.Parse(row.SubItems[3].Text);
                int actual = int.Parse(row.SubItems[4].Text);
                int newDelivered = prevDel + actual;

                if (actual < 0)
                {
                    MessageBox.Show($"Actual quantity for {row.Text} cannot be negative.");
                    return;
                }
                if (newDelivered > ordered)
                {
                    MessageBox.Show($"Total delivered ({newDelivered}) for {row.Text} exceeds ordered ({ordered}). Please check your quantities.");
                    return;
                }
                if (ordered != newDelivered)
                {
                    allFullyDelivered = false;
                }
            }

            string sqlItem = "UPDATE DeliveryNoteItem SET QtyDelivered=@qty WHERE DNID=@dnId AND ProductID=@prodId";
            string sqlDN = "UPDATE DeliveryNote SET Status='Delivered' WHERE DNID=@dnId";
            string sqlChk = "SELECT COUNT(*) FROM ReplySlip WHERE DNID=@dnId";
            string sqlRS = "UPDATE ReplySlip SET Status='Confirmed', ReceivedBy=@recBy, ReceivedDate=NOW() WHERE DNID=@dnId";
            string sqlRSInsert = "INSERT INTO ReplySlip (DNID, ReceivedBy, ReceivedDate, Status) VALUES (@dnId, @recBy, NOW(), 'Confirmed')";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    conn.Open();
                    var trans = conn.BeginTransaction();

                    try
                    {
                        // 1. Update each item (always update QtyDelivered)
                        foreach (ListViewItem row in listGoodsItems.Items)
                        {
                            string pid = row.Text;
                            int prevDel = int.Parse(row.SubItems[3].Text);
                            int actual = int.Parse(row.SubItems[4].Text);

                            var cmdItem = new MySqlCommand(sqlItem, conn, trans);
                            cmdItem.Parameters.AddWithValue("@qty", prevDel + actual);
                            cmdItem.Parameters.AddWithValue("@dnId", _currentDNID);
                            cmdItem.Parameters.AddWithValue("@prodId", pid);
                            cmdItem.ExecuteNonQuery();
                        }

                        if (allFullyDelivered)
                        {
                            // 2. DeliveryNote -> Delivered
                            var cmdDN = new MySqlCommand(sqlDN, conn, trans);
                            cmdDN.Parameters.AddWithValue("@dnId", _currentDNID);
                            cmdDN.ExecuteNonQuery();

                            // 3. ReplySlip
                            var cmdChk = new MySqlCommand(sqlChk, conn, trans);
                            cmdChk.Parameters.AddWithValue("@dnId", _currentDNID);
                            int cnt = Convert.ToInt32(cmdChk.ExecuteScalar());

                            if (cnt > 0)
                            {
                                var cmdRS = new MySqlCommand(sqlRS, conn, trans);
                                cmdRS.Parameters.AddWithValue("@recBy", receivedBy);
                                cmdRS.Parameters.AddWithValue("@dnId", _currentDNID);
                                cmdRS.ExecuteNonQuery();
                            }
                            else
                            {
                                var cmdRS = new MySqlCommand(sqlRSInsert, conn, trans);
                                cmdRS.Parameters.AddWithValue("@recBy", receivedBy);
                                cmdRS.Parameters.AddWithValue("@dnId", _currentDNID);
                                cmdRS.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show($"Goods received confirmed.\nDN: {_currentDNID}\nReceived by: {receivedBy}\nStatus: Delivered", "Confirmed");
                        }
                        else
                        {
                            trans.Commit();
                            MessageBox.Show($"Partial delivery recorded.\nDN: {_currentDNID}\nReceived by: {receivedBy}\nStatus remains InTransit (not fully delivered).", "Partial Delivery");
                        }

                        LoadInTransitNotes();
                        listGoodsItems.Items.Clear();
                        _currentDNID = null; btnConfirm.Enabled = false; lblCustomer.Text = " ";
                    }
                    catch { trans.Rollback(); throw; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error updating record: " + ex.Message); }
        }
    }
}
