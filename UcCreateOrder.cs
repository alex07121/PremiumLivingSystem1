using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiumLivingSystem
{
    public partial class UcCreateOrder : UserControl
    {

        public UcCreateOrder()
        {
            InitializeComponent();

        }
        BindingList<CartItem> shoppingCart = new BindingList<CartItem>();
       
        private void UcCreateOrder1_Load(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            dgvCart.DataSource = shoppingCart;
            if (UserSession.jobId == "J-001")
            {
                FillCustomerB2B();
            }
            else if(UserSession.jobId == "J-003")
            {
                FillCustomerB2C();
            }
            FillCategory();
        }

        private void FillCategory()
        {
            try
            {
                string query = @"
                        SELECT CategoryID,
                               CategoryName,
                               CONCAT(CategoryID, ' - ', CategoryName) AS DisplayText
                        FROM productcategory
                        ORDER BY CategoryID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

              
                    cboCategory.DataSource = dt;

                 
                    cboCategory.DisplayMember = "DisplayText";

              
                    cboCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProduct();
        }
        private void FillProduct()
        {
            try
            {
                string query = @"
                        SELECT ProductID,
                               ProductName,
                               CONCAT(ProductID, ' - ', ProductName) AS DisplayText
                        FROM Product
                        WHERE CategoryID = @catId
                        ORDER BY ProductID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@catId", cboCategory.SelectedValue.ToString());
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

            
                    cmbProduct.DataSource = dt;

        
                    cmbProduct.DisplayMember = "DisplayText";

                    cmbProduct.ValueMember = "ProductID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void FillCustomerB2C()
        {
            try
            {
                string query = @"
                        SELECT CustomerID,
                               CustomerName,
                               CustomerType,
                               CONCAT(CustomerID, ' - ', CustomerName, '(' ,CustomerType , ')' ) AS DisplayText
                        FROM Customer
                        WHERE CustomerType = 'B2C'
                        ORDER BY CustomerID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

     
                    cmbCustomer.DataSource = dt;

       
                    cmbCustomer.DisplayMember = "DisplayText";

                    cmbCustomer.ValueMember = "CustomerID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void FillCustomerB2B()
        {
            try
            {
                string query = @"
                        SELECT CustomerID,
                               CustomerName,
                               CustomerType,
                               CONCAT(CustomerID, ' - ', CustomerName, '(' ,CustomerType , ')' ) AS DisplayText
                        FROM Customer
                        WHERE CustomerType = 'B2B'
                        ORDER BY CustomerID";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

        
                    cmbCustomer.DataSource = dt;

                    cmbCustomer.DisplayMember = "DisplayText";

                    cmbCustomer.ValueMember = "CustomerID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in shoppingCart)
            {
                total += item.SubTotal;
            }
            lblTotalAmount.Text = $"Total: ${total:N2}";
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue is DataRowView) return;

            try
            {
                string query = "SELECT UnitPrice, Stock FROM Product WHERE ProductID = @id";
                using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cmbProduct.SelectedValue.ToString());

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUnitPrice.Text = Convert.ToDecimal(reader["UnitPrice"]).ToString("0.00");
                        int currentStock = Convert.ToInt32(reader["Stock"]);
                        txtStock.Text = currentStock.ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnAddStandard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitPrice.Text)) return;
            string selectedProductID = cmbProduct.SelectedValue.ToString();
            int requestQty = (int)numQuantity.Value;

            // If already in cart, just increase quantity
            foreach (var cartItem in shoppingCart)
            {
                if (cartItem.ProductID == selectedProductID)
                {
                    cartItem.Quantity += requestQty;
                    UpdateTotalAmount();
                    return;
                }
            }

            CartItem item = new CartItem
            {
                ProductID = cmbProduct.SelectedValue.ToString(),
                ProductName = cmbProduct.Text,
                Quantity = (int)numQuantity.Value,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                ItemType = "Standard",
                CustomStatus = "NotRequired"
            };
            shoppingCart.Add(item);
            UpdateTotalAmount();
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUnitPrice.Text)) return;

                decimal basePrice = decimal.Parse(txtUnitPrice.Text);

         
                using (frmCustomization customForm = new frmCustomization(basePrice))
                {
           
                    Form parentForm = this.FindForm();
                    DialogResult result = customForm.ShowDialog(parentForm);

                    if (result == DialogResult.OK)
                    {
                        CartItem item = new CartItem
                        {
                            ProductID = cmbProduct.SelectedValue.ToString(),
                            ProductName = cmbProduct.Text + " (Customization)",
                            Quantity = (int)numQuantity.Value,
                         
                            UnitPrice = customForm.FinalCustomPrice,
                            ItemType = "Custom",
                            CustomStatus = "PendingConfirm",
                            CustomDetails = customForm.CustomData
                        };
                        shoppingCart.Add(item);
                        UpdateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening customization form:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count == 0)
            {
                MessageBox.Show("Shopping cart is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlOrder = "INSERT INTO `Order` (OrderID, CustomerID, SalesStaffID, OrderDate, RequiredDate, Status) VALUES (NULL, @custId, @staffId, CURDATE(), @reqDate, 'Pending')";
            string sqlGetId = "SELECT OrderID FROM `Order` WHERE CustomerID = @custId ORDER BY OrderID DESC LIMIT 1";
            string sqlItem = "INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, UnitPrice, ItemType, CustomStatus) VALUES (NULL, @orderId, @prodId, @qty, @price, @type, @status)";
            string sqlUpdateStock = "UPDATE Product SET Stock = Stock - @qty WHERE ProductID = @prodId";

            using (MySqlConnection conn = new MySqlConnection(Program.ConnectionString))
            {
                MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn);
                cmdOrder.Parameters.AddWithValue("@custId", cmbCustomer.SelectedValue.ToString());
                cmdOrder.Parameters.AddWithValue("@staffId", UserSession.CurrentStaffId ?? "S-001");
                cmdOrder.Parameters.AddWithValue("@reqDate", dtpRequiredDate.Value);

                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    cmdOrder.Transaction = trans;
                    try
                    {
                        cmdOrder.ExecuteNonQuery();

                        MySqlCommand cmdGetOrderId = new MySqlCommand(sqlGetId, conn, trans);
                        cmdGetOrderId.Parameters.AddWithValue("@custId", cmbCustomer.SelectedValue.ToString());
                        string newOrderId = cmdGetOrderId.ExecuteScalar().ToString();

                        MySqlCommand cmdItem = new MySqlCommand(sqlItem, conn, trans);
                        cmdItem.Parameters.Add("@orderId", MySqlDbType.VarChar);
                        cmdItem.Parameters.Add("@prodId", MySqlDbType.VarChar);
                        cmdItem.Parameters.Add("@qty", MySqlDbType.Int32);
                        cmdItem.Parameters.Add("@price", MySqlDbType.Decimal);
                        cmdItem.Parameters.Add("@type", MySqlDbType.VarChar);
                        cmdItem.Parameters.Add("@status", MySqlDbType.VarChar);

                        MySqlCommand cmdUpdateStock = new MySqlCommand(sqlUpdateStock, conn, trans);
                        cmdUpdateStock.Parameters.Add("@qty", MySqlDbType.Int32);
                        cmdUpdateStock.Parameters.Add("@prodId", MySqlDbType.VarChar);

                        foreach (CartItem item in shoppingCart)
                        {
                            cmdItem.Parameters["@orderId"].Value = newOrderId;
                            cmdItem.Parameters["@prodId"].Value = item.ProductID;
                            cmdItem.Parameters["@qty"].Value = item.Quantity;
                            cmdItem.Parameters["@price"].Value = item.UnitPrice;
                            cmdItem.Parameters["@type"].Value = item.ItemType;
                            cmdItem.Parameters["@status"].Value = item.CustomStatus;
                            cmdItem.ExecuteNonQuery();

                            cmdUpdateStock.Parameters["@qty"].Value = item.Quantity;
                            cmdUpdateStock.Parameters["@prodId"].Value = item.ProductID;
                            cmdUpdateStock.ExecuteNonQuery();

                            if (item.ItemType == "Custom" && item.CustomDetails != null)
                            {
                                MySqlCommand cmdGetItemId = new MySqlCommand("SELECT OrderItemID FROM OrderItem WHERE OrderID = @orderId ORDER BY OrderItemID DESC LIMIT 1", conn, trans);
                                cmdGetItemId.Parameters.AddWithValue("@orderId", newOrderId);
                                string newItemId = cmdGetItemId.ExecuteScalar().ToString();

                                string sqlCustom = "INSERT INTO OrderItemCustomization (CustomID, OrderItemID, DimensionL, DimensionW, DimensionH, Material, Color, FinishType, CustomDescription) VALUES (NULL, @itemId, @dimL, @dimW, @dimH, @mat, @color, @finish, @desc)";
                                MySqlCommand cmdCustom = new MySqlCommand(sqlCustom, conn, trans);
                                cmdCustom.Parameters.AddWithValue("@itemId", newItemId);
                                cmdCustom.Parameters.AddWithValue("@dimL", item.CustomDetails.DimensionL);
                                cmdCustom.Parameters.AddWithValue("@dimW", item.CustomDetails.DimensionW);
                                cmdCustom.Parameters.AddWithValue("@dimH", item.CustomDetails.DimensionH);
                                cmdCustom.Parameters.AddWithValue("@mat", item.CustomDetails.Material);
                                cmdCustom.Parameters.AddWithValue("@color", item.CustomDetails.Color);
                                cmdCustom.Parameters.AddWithValue("@finish", item.CustomDetails.FinishType);
                                cmdCustom.Parameters.AddWithValue("@desc", item.CustomDetails.CustomDescription);
                                cmdCustom.ExecuteNonQuery();

                                if (item.CustomDetails.ImageDataList.Count > 0)
                                {
                                    MySqlCommand cmdGetCustomId = new MySqlCommand("SELECT CustomID FROM OrderItemCustomization WHERE OrderItemID = @itemId", conn, trans);
                                    cmdGetCustomId.Parameters.AddWithValue("@itemId", newItemId);
                                    string newCustomId = cmdGetCustomId.ExecuteScalar().ToString();

                                    // [v5.5] Images are now stored as LONGBLOB directly in the DB;
                                    // no file-system copy / upload folder is needed anymore.
                                    string sqlImage = "INSERT INTO CustomizationImage (ImageID, CustomID, ImageData) VALUES (NULL, @cId, @imgData)";
                                    MySqlCommand cmdImage = new MySqlCommand(sqlImage, conn, trans);
                                    cmdImage.Parameters.Add("@cId", MySqlDbType.VarChar);
                                    cmdImage.Parameters.Add("@imgData", MySqlDbType.LongBlob);

                                    foreach (byte[] imgBytes in item.CustomDetails.ImageDataList)
                                    {
                                        cmdImage.Parameters["@cId"].Value = newCustomId;
                                        cmdImage.Parameters["@imgData"].Value = imgBytes;
                                        cmdImage.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        trans.Commit();
                        MessageBox.Show($"Order placed successfully!\nGenerated Order ID: {newOrderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        shoppingCart.Clear();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error inserting record: " + ex.Message);
                    }
                }
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }

    public class CustomDetailsDTO
    {
        public decimal DimensionL { get; set; }
        public decimal DimensionW { get; set; }
        public decimal DimensionH { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string FinishType { get; set; }
        public string CustomDescription { get; set; }
        public List<string> ImagePaths { get; set; } = new List<string>();
        // [v5.5] Raw image bytes — persisted as CustomizationImage.ImageData (LONGBLOB)
        public List<byte[]> ImageDataList { get; set; } = new List<byte[]>();
    }

    public class CartItem
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal => Quantity * UnitPrice; 

        public string ItemType { get; set; }
        public string CustomStatus { get; set; }

        [Browsable(false)] 
        public CustomDetailsDTO CustomDetails { get; set; }
    }
}
