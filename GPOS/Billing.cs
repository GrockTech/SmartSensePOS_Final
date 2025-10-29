using MySql.Data.MySqlClient;
using System.Data;
using System.Timers;

namespace GPOS
{
    public partial class Billing : Form
    {
        private int printRowIndex = 0;
        private List<(string Product, float Qty, float Price, float Subtotal)> printItems = new();
        private float printGrandTotal = 0;
        private bool footerPrinted = false;

        private string _username;

        private float printOriginalTotal;   // Total before discount
        private float printFinalTotal;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Billing(string username)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        {


            InitializeComponent();
            DisplayProducts();
            CheckDailySales();

            printDocument1.BeginPrint += printDocument1_BeginPrint;
            printDocument1.PrintPage += printDocument1_PrintPage;



            CheckMonthlySales();
            ProductsDVG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductsDVG.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            ProductsDVG.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            _username = username;
            //label7 += username;
            label7.Text = _username + ", you are welcome! ";
        }

        //private class ReceiptItem
        //{
        //    public string ProductName { get; set; }
        //    public float Quantity { get; set; }
        //    public float Price { get; set; }
        //    public float Subtotal { get; set; }
        //}
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.FormBorderStyle = FormBorderStyle.None; // remove title bar & borders
            this.WindowState = FormWindowState.Maximized; // cover whole screen
        }



        public void CheckDailySales()
        {
            decimal totalSales = 0m;
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            int totalQuantity = 0;
#pragma warning restore CS0219 // Variable is assigned but its value is never used


            ////
            ///



            using (MySqlConnection con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                string query = "SELECT SUM(Amt) AS TotalSales FROM BillT WHERE DATE(BDate) =  CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    //con.Open();
                    con.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            totalSales = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0m;
                            //   textBox1.Text = totalSales.ToString("N2");
                            textBox2.Text = "GH₵" + " " + totalSales.ToString("N2");
                            //   totalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(reader["TotalQuantity"]) : 0;
                        }
                    }
                }
            }


        }


        private void label14_Click(object sender, EventArgs e)
        {

        }
        //string CustomerName;
        private void SupName_TextChanged(object sender, EventArgs e)
        {
            getCustomer();
        }
        string productName;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SupAdd_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //search production btn

        private void button3_Click(object sender, EventArgs e)
        {
            string searchTerm = Search.Text.Trim();
            SearchProducts(searchTerm);
        }

        private void SearchProducts(string searchTerm)
        {
            using (MySqlConnection localCon = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                try
                {
                    localCon.Open();
                    string Query = "SELECT * FROM ProductTbl WHERE PName LIKE @SearchTerm";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(Query, localCon);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ProductsDVG.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Example event handler for a search button or search box text change




        private void label11_Click(object sender, EventArgs e)
        {

        }



        //}
        private void DisplayProducts()
        {
            using (MySqlConnection localCon = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                try
                {
                    localCon.Open();
                    string Query = "select * from ProductTbl";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(Query, localCon);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    // we fill data grid with the actual data in db
                    ProductsDVG.DataSource = ds.Tables[0];
                    ProductsDVG.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying products: " + ex.Message);
                }
                // No need for Close() - using statement handles disposal
            }
        }
        int keyMain = 0;
        string PnameTb;
        //PStock is tracking the remaining stock
        float Pprice;
        float PStock;
        float total;
        int n = 0;

        private void Reset()
        {
            PnameTb = "";
            Quantity.Text = "";
            keyMain = 0;


        }

        private void UpdateSalesLabel(object sender, EventArgs e)
        {

        }


        public void CheckMonthlySales()
        {
            decimal totalSales = 0m;
            int totalQuantity = 0;

            string connectionString = "server=localhost; database=posdb; username=root; password=;";
            string query = @"
        SELECT 
            SUM(Amt) AS TotalSales, 
            COUNT(*) AS TotalQuantity 
        FROM 
            BillT 
        WHERE 
            MONTH(BDate) = MONTH(CURDATE()) 
            AND YEAR(BDate) = YEAR(CURDATE());
    ";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalSales = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0m;
                                totalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(reader["TotalQuantity"]) : 0;
                            }
                            con.Close();
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }
        int trackR = 0;
        private void getCustomer()
        {
            using (MySqlConnection localCon = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                try
                {
                    localCon.Open();
                    MySqlCommand cmd = new MySqlCommand("Select CusId from CustomerTbl", localCon);
                    MySqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CusId", typeof(int));
                    dt.Load(rdr);
                    CusIDCB.ValueMember = "CusId";
                    CusIDCB.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customers: " + ex.Message);
                }
                // No need for Close() - using statement handles disposal
            }
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            // 1️⃣ Validate inputs
            if (string.IsNullOrEmpty(PnameTb))
            {
                MBox1.Show("Select a product first.");
                return;
            }

            if (string.IsNullOrEmpty(Quantity.Text))
            {
                MBox1.Show("Enter the quantity.");
                return;
            }

            if (!float.TryParse(Quantity.Text, out float qty))
            {
                MBox1.Show("Invalid quantity.");
                return;
            }

            if (qty <= 0)
            {
                MBox1.Show("Quantity must be greater than zero.");
                return;
            }

            if (qty > PStock)
            {
                MBox1.Show("Not enough stock available.");
                return;
            }

            // 2️⃣ Calculate subtotal and update total
            float subtotal = qty * Pprice;
            total += subtotal;

            // 3️⃣ Add product to BillDGV (cart)
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(BillDGV);
            newRow.Cells[0].Value = n;          // Item number
            newRow.Cells[1].Value = PnameTb;    // Product name
            newRow.Cells[2].Value = qty;        // Quantity
            newRow.Cells[3].Value = Pprice;     // Selling price
            newRow.Cells[4].Value = subtotal;   // Subtotal

            BillDGV.Rows.Add(newRow);

            // 4️⃣ Update stock in producttbl
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE producttbl SET PQty = PQty - @Qty WHERE PName = @PN", con))
                    {
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@PN", PnameTb);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MBox1.Show("Error updating stock: " + ex.Message);
                return;
            }

            // 5️⃣ Update subtotal display
            SubTotal.Text = total.ToString("0.00");
            UpdateGrandTotal();

            // 6️⃣ Reset input fields
            n++;
            Reset();
        }






        
        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            BillDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BillDGV.MultiSelect = false;
            BillDGV.ReadOnly = true;
            BillDGV.AllowUserToAddRows = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = BillDGV.Rows[e.RowIndex];

                string productName = selectedRow.Cells[1].Value.ToString(); // Product name
                int deletedQty = Convert.ToInt32(selectedRow.Cells[2].Value); // Quantity
                float deletedSubtotal = float.Parse(selectedRow.Cells[4].Value.ToString()); // Subtotal

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to remove '{productName}' and add back {deletedQty} to stock?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string connectionString = "server=localhost; database=posdb; username=root; password=;";
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();

                            // Step 1️⃣: Get current quantity from producttbl
                            string selectQuery = "SELECT PQty FROM producttbl WHERE PName = @PName";
                            int currentQty = 0;

                            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                            {
                                selectCmd.Parameters.AddWithValue("@PName", productName);
                                object result = selectCmd.ExecuteScalar();

                                if (result != null && result != DBNull.Value)
                                {
                                    currentQty = Convert.ToInt32(result);
                                }
                                else
                                {
                                    MessageBox.Show($"Product '{productName}' not found in the database.",
                                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            // Step 2️⃣: Add back the deleted quantity
                            int newQty = currentQty + deletedQty;

                            // Step 3️⃣: Update product quantity in producttbl
                            string updateQuery = "UPDATE producttbl SET PQty = @NewQty WHERE PName = @PName";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@NewQty", newQty);
                                updateCmd.Parameters.AddWithValue("@PName", productName);
                                updateCmd.ExecuteNonQuery();
                            }

                            // Step 4️⃣: Remove row from BillDGV
                            BillDGV.Rows.RemoveAt(e.RowIndex);

                            // Step 5️⃣: Update totals
                            total -= deletedSubtotal; // Deduct subtotal of removed item
                            if (total < 0) total = 0; // Safety check

                            SubTotal.Text = total.ToString("0.00");
                            UpdateGrandTotal(); // Recalculate any taxes/discounts if applicable

                            MessageBox.Show($"'{productName}' removed and stock updated successfully!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (ProductsDVG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                PnameTb = ProductsDVG.SelectedRows[0].Cells[1].Value.ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            else
            {
                // Handle the case where no row is selected or the cell value is null
                MessageBox.Show("Please select a valid row with a valid product name.");
                PnameTb = string.Empty; // or some other default value
            }





            //PnameTb = ProductsDVG.SelectedRows[0].Cells[1].Value.ToString();
            //PcatCB.SelectedItem = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            Pprice = Convert.ToSingle(ProductsDVG.SelectedRows[0].Cells[3].Value.ToString());
            PStock = Convert.ToSingle(ProductsDVG.SelectedRows[0].Cells[4].Value.ToString());


            if (PnameTb == "")
            {

                keyMain = 0;
            }
            else
            {

                keyMain = Convert.ToInt32(ProductsDVG.SelectedRows[0].Cells[0].Value.ToString());
                AddBtn.BackColor = Color.ForestGreen;
            }


        }


        //UPDATE QUANTITY

        private void UpdateQuantity(float quantitySold, int productId)
        {
            try
            {
                // Get current PQty from DB (safer than trusting PStock variable)
                float currentQty = 0f;
                string connectionString = "server=localhost; database=posdb; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand sel = new MySqlCommand("SELECT PQty FROM ProductTbl WHERE PId = @id", con))
                    {
                        sel.Parameters.AddWithValue("@id", productId);
                        var obj = sel.ExecuteScalar();



                        currentQty = obj != DBNull.Value && obj != null ? Convert.ToSingle(obj) : 0f;
                    }

                    float newQty = currentQty - quantitySold;
                    if (newQty < 0) newQty = 0; // prevent negative

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE ProductTbl SET PQty = @PQ WHERE PId = @Pkey", con))
                    {
                        cmd.Parameters.AddWithValue("@PQ", newQty);
                        cmd.Parameters.AddWithValue("@Pkey", productId);
                        cmd.ExecuteNonQuery();
                    }
                }

                DisplayProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"UpdateQuantity error: {ex.Message}");
            }
        }

        private void InsertR()
        {
            string connectionString = "server=localhost; database=posdb; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                foreach (DataGridViewRow row in BillDGV.Rows)
                {
                    if (row.IsNewRow) continue;

                    string productName = row.Cells[1].Value.ToString();
                    double qty = Convert.ToDouble(row.Cells[2].Value);
                    double price = Convert.ToDouble(row.Cells[3].Value);
                    double subtotal = Convert.ToDouble(row.Cells[4].Value);

                    // Get cost price
                    double hPrice = 0;
                    using (MySqlCommand getCost = new MySqlCommand("SELECT H_Price FROM producttbl WHERE PName=@PN", con))
                    {
                        getCost.Parameters.AddWithValue("@PN", productName);
                        object result = getCost.ExecuteScalar();
                        if (result != null)
                            hPrice = Convert.ToDouble(result);
                    }

                    double profit = (price - hPrice) * qty;

                    // Now insert into billdetails
                    using (MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO billdetails(Date, ProductName, Quantity, Price, Subtotal, HPrice, Profit) " +
                        "VALUES(@DT, @PN, @QT, @PP, @ST, @HP, @PF)", con))
                    {
                        cmd.Parameters.AddWithValue("@DT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@PN", productName);
                        cmd.Parameters.AddWithValue("@QT", qty);
                        cmd.Parameters.AddWithValue("@PP", price);
                        cmd.Parameters.AddWithValue("@ST", subtotal);
                        cmd.Parameters.AddWithValue("@HP", hPrice);
                        cmd.Parameters.AddWithValue("@PF", profit);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //MessageBox.Show("Bill saved successfully!");
        }

        //private void PrepareReceiptItems()
        //{
        //    _receiptItems.Clear();
        //    _printItemIndex = 0;

        //    string connectionString = "server=localhost; database=posdb; username=root; password=;";
        //    using (MySqlConnection localCon = new MySqlConnection(connectionString))
        //    {
        //        localCon.Open();
        //        string query = @"
        //    SELECT ProductName, Quantity, Price, Subtotal 
        //    FROM billdetails 
        //    WHERE Date >= @CurrentTime
        //    ORDER BY Date DESC";
        //        using (MySqlCommand cmd = new MySqlCommand(query, localCon))
        //        {
        //            cmd.Parameters.AddWithValue("@CurrentTime", DateTime.Now.AddMinutes(-1));
        //            using (MySqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    _receiptItems.Add(new ReceiptItem
        //                    {
        //                        ProductName = reader["ProductName"].ToString(),
        //                        Quantity = Convert.ToSingle(reader["Quantity"]),
        //                        Price = Convert.ToSingle(reader["Price"]),
        //                        Subtotal = Convert.ToSingle(reader["Subtotal"])
        //                    });
        //                }
        //            }
        //        }
        //    }
        //}

        // Your button click handler
       

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if BillDGV has any non-empty rows

            bool hasItems = false;
            foreach (DataGridViewRow row in BillDGV.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    hasItems = true;
                    break;
                }
            }

            if (!hasItems)
            {
                MBox1.Show("No items in bill to print. Please add items first.");
                return;
            }

            // Insert bill into database
            InsertBill();
            InsertR();

            // Set up print document
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

            // Show print preview
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                // Actual printing happens here if user clicks print
                printDocument1.Print();
            }

            // NOW clear after printing is complete
            BillDGV.Rows.Clear();
            SubTotal.Text = "";
            GrdTotal.Text = "";
            discountTb.Text = "";
            VATtb.Text = "";
            total = 0;

            // Update sales displays
            CheckDailySales();
            CheckMonthlySales();
            Search.Focus();
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            Search.Text = "";
        }



        private void SupplierDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CusIDCB_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void CusIDCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  GetCusName();
        }

        private void VATtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void VATtb_MouseLeave(object sender, EventArgs e)
        {

        }

        private void VATtb_KeyDown(object sender, KeyEventArgs e)
        {

        }
        int bflag = 0;
        string getName;



        private void InsertBill()
        {

            if (string.IsNullOrWhiteSpace(PaymentCB.Text))
            {
                PaymentCB.Text = "Cash";
            }

            else
            {
                string connectionString = "server=localhost; database=posdb; username=root; password=;";
                using (MySqlConnection localCon = new MySqlConnection(connectionString))
                    try
                    {
                        // we open db connection 
                        foreach (DataGridViewRow row in BillDGV.Rows)
                        {

                            if (row.Cells["Column2"].Value != null)
                            {
                                getName = row.Cells["Column2"].Value.ToString(); // This will take the last value
                                                                                 //    Console.WriteLine($"getName: {getName}");
                            }
                        }


                        localCon.Open();
                        MySqlCommand cmd = new MySqlCommand(" insert into BillT(BDate, CustId, CustName, PMethod, Amt, ProductName) values(@BD, @CI, @CN, @PM, @AM, @PN)", localCon);
                        cmd.Parameters.AddWithValue("@BD", BDateCB.Value.Date);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        cmd.Parameters.AddWithValue("@CI", CusIDCB.SelectedValue.ToString());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        //cmd.Parameters.AddWithValue("@CN", PriceTb.Text);
                        cmd.Parameters.AddWithValue("@CN", CusNameCB.Text);
                        cmd.Parameters.AddWithValue("@PN", getName);
                        //  cmd.Parameters.AddWithValue("@PN", productName);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        cmd.Parameters.AddWithValue("@PM", PaymentCB.Text.ToString());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        cmd.Parameters.AddWithValue("@AM", Convert.ToDouble(GrdTotal.Text));

                        cmd.ExecuteNonQuery();
                        // MBox1.Show("Bill saved");



                        bflag = 1;
                        localCon.Close();
                        //Reset();
                    }
                    catch (Exception Ex)
                    {
                        MBox1.Show(Ex.Message);
                    }
            }
        }

        private void UpdateGrandTotal()
        {
            // Subtotal is the grand total in your case
            GrdTotal.Text = SubTotal.Text;
        }




        private void discountTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(SubTotal.Text))
            {
                MessageBox.Show("Add Products to Cart");
                discountTb.Text = "0";   // set discount to zero
                TotalDiscount.Text = "0";
                GrdTotal.Text = (Convert.ToSingle(SubTotal.Text) + Convert.ToSingle(TotTaxTb.Text)).ToString();
                return;
            }

            // Discount not needed, set to zero
            float Disc = 0;

            TotalDiscount.Text = Disc.ToString(); // show 0
            GrdTotal.Text = (Convert.ToSingle(SubTotal.Text) + Convert.ToSingle(TotTaxTb.Text) - Disc).ToString();
        }

        ////new
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Reset print state
            printRowIndex = 0;
            printItems.Clear();
            printOriginalTotal = 0;
            printFinalTotal = 0;
            footerPrinted = false;

            // Load recent bill items
            string connectionString = "server=localhost; database=posdb; username=root; password=;";
            using (MySqlConnection localCon = new MySqlConnection(connectionString))
            {
                localCon.Open();
                string query = @"
            SELECT ProductName, Quantity, Price, Subtotal 
            FROM billdetails 
            WHERE Date >= @CurrentTime
            ORDER BY Date DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, localCon))
                {
                    cmd.Parameters.AddWithValue("@CurrentTime", DateTime.Now.AddMinutes(-1));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prod = reader["ProductName"].ToString();
                            float qty = Convert.ToSingle(reader["Quantity"]);
                            float price = Convert.ToSingle(reader["Price"]);
                            float sub = Convert.ToSingle(reader["Subtotal"]);

                            printItems.Add((prod, qty, price, sub));
                            printOriginalTotal += sub;
                        }
                    }
                }
            }

            // Apply discount (only once)
            printFinalTotal = printOriginalTotal;

            if (!string.IsNullOrEmpty(discountTb.Text) &&
                decimal.TryParse(discountTb.Text, out decimal discount) && discount > 0)
            {
                printFinalTotal -= (float)discount;
            }
        }



        //correction one
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int pos = 40;

            // ===== HEADER =====
            string title = "HAPPY VENTURES - JEMA";
            string contact = "Tel:+233249589113";
            string location = "Location: JEMA-KINTAMPO SOUTH";

            e.Graphics.DrawString(title, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(10, pos)); pos += 20;
            e.Graphics.DrawString(contact, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(10, pos)); pos += 20;
            e.Graphics.DrawString(location, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, new Point(10, pos)); pos += 20;
            e.Graphics.DrawString("---------------------------------------------------", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 20;

            // ===== RECEIPT INFO =====
            e.Graphics.DrawString($"Receipt #: {DateTime.Now:yyyyMMddHHmmss}", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 15;
            e.Graphics.DrawString($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 15;
            e.Graphics.DrawString($"Customer: {CusNameCB.Text}", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 15;
            e.Graphics.DrawString($"Payment: {PaymentCB.Text}", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 20;

            e.Graphics.DrawString("---------------------------------------------------", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 20;

            // ===== TABLE HEADER =====
            e.Graphics.DrawString("ITEM", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(10, pos));
            e.Graphics.DrawString("QTY", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(120, pos));
            e.Graphics.DrawString("PRICE", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(160, pos));
            e.Graphics.DrawString("TOTAL", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(210, pos));
            pos += 20;
            e.Graphics.DrawString("---------------------------------------------------", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 20;

            // ===== TABLE ROWS =====
            int itemsPerPage = 20;
            int count = 0;

            while (printRowIndex < printItems.Count && count < itemsPerPage)
            {
                var item = printItems[printRowIndex];
                string displayName = item.Product.Length > 20 ? item.Product.Substring(0, 20) + "..." : item.Product;

                e.Graphics.DrawString(displayName, new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos));
                e.Graphics.DrawString(item.Qty.ToString("F1"), new Font("Century Gothic", 6), Brushes.Black, new Point(120, pos));
                e.Graphics.DrawString("₵" + item.Price.ToString("F2"), new Font("Century Gothic", 6), Brushes.Black, new Point(160, pos));
                e.Graphics.DrawString("₵" + item.Subtotal.ToString("F2"), new Font("Century Gothic", 6), Brushes.Black, new Point(210, pos));

                pos += 20;
                printRowIndex++;
                count++;
            }

            // ===== MULTI-PAGE CONTROL =====
            if (printRowIndex < printItems.Count)
            {
                e.HasMorePages = true;
                return;
            }

            // Only print footer once
            if (!footerPrinted)
            {
                e.HasMorePages = false;
                DrawFooter(e, ref pos);
                footerPrinted = true;
            }
        }

        private void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e, ref int pos)
        {
            pos += 10;
            e.Graphics.DrawString("---------------------------------------------------", new Font("Century Gothic", 6), Brushes.Black, new Point(10, pos)); pos += 20;

            // Subtotal
            e.Graphics.DrawString("Subtotal:", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(120, pos));
            e.Graphics.DrawString("GH₵" + printOriginalTotal.ToString("F2"), new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(200, pos));
            pos += 20;

            // Discount
            if (!string.IsNullOrEmpty(discountTb.Text) && decimal.TryParse(discountTb.Text, out decimal discount) && discount > 0)
            {
                e.Graphics.DrawString("Discount:", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(120, pos));
                e.Graphics.DrawString("-GH₵" + discount.ToString("F2"), new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(200, pos));
                pos += 20;
            }

            // Grand Total
            e.Graphics.DrawString("=========================", new Font("Century Gothic", 6, FontStyle.Bold), Brushes.Black, new Point(100, pos)); pos += 20;
            e.Graphics.DrawString("GRAND TOTAL:", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(100, pos));
            e.Graphics.DrawString("GH₵" + printFinalTotal.ToString("F2"), new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, new Point(200, pos));
            pos += 30;

            // Footer Message
            e.Graphics.DrawString("Thank you for shopping with us!", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(10, pos)); pos += 20;
            e.Graphics.DrawString("Visit Again!", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(10, pos));
        }


        private void label8_Click(object sender, EventArgs e)
        {
            ViewBill obj = new ViewBill();
            obj.Show();
            // this.Close();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = Search.Text.Trim();
            SearchProducts(searchTerm);
        }

        private void GrdTotal_TextChanged(object sender, EventArgs e)
        {

        }
        public void CheckProductQuantity()
        {
            try
            {
                string query = "SELECT PName FROM producttbl WHERE PQty < 20";

                using (MySqlConnection connection = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    int delay = 0; // cumulative delay for staggered toasts

                    while (reader.Read())
                    {
                        string productName = reader["PName"].ToString();

                        // Use a timer to stagger the toasts
                        // Timer staggerTimer = new Timer();
                        System.Windows.Forms.Timer staggerTimer = new System.Windows.Forms.Timer();
                        staggerTimer.Interval = Math.Max(1, delay);

                        //staggerTimer.Interval = delay; // first toast immediately, next after 1s, etc.
                        staggerTimer.Tick += (s, e) =>
                        {
                            staggerTimer.Stop(); // stop this timer
                            ToastNotification.ShowToast($"Low stock: {productName}");
                        };
                        staggerTimer.Start();

                        delay += 1000; // add 1 second before the next toast
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Billing_Load(object sender, EventArgs e)
        {
            CheckProductQuantity();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        //BillDGV.Rows.Clear();
        //// int zero = 0;
        //total = 0;
        //SubTotal.Text = "";
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (BillDGV.SelectedRows.Count == 0)
            {
                MBox1.Show("Please select an item to remove.");
                return;
            }

            DataGridViewRow selectedRow = BillDGV.SelectedRows[0];

            string productName = selectedRow.Cells[1].Value.ToString();
            int deletedQty = Convert.ToInt32(selectedRow.Cells[2].Value);
            float deletedSubtotal = float.Parse(selectedRow.Cells[4].Value.ToString());

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to remove '{productName}' and add back {deletedQty} to stock?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string connectionString = "server=localhost; database=posdb; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // 1️⃣ Get current stock
                    string selectQuery = "SELECT PQty FROM producttbl WHERE PName = @PName";
                    int currentQty = 0;
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                    {
                        selectCmd.Parameters.AddWithValue("@PName", productName);
                        object result = selectCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            currentQty = Convert.ToInt32(result);
                        else
                        {
                            MBox1.Show($"Product '{productName}' not found in the database.");
                            return;
                        }
                    }

                    // 2️⃣ Add removed qty back to stock
                    int newQty = currentQty + deletedQty;
                    string updateQuery = "UPDATE producttbl SET PQty = @NewQty WHERE PName = @PName";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@NewQty", newQty);
                        updateCmd.Parameters.AddWithValue("@PName", productName);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                // 3️⃣ Remove from DataGridView and update total
                BillDGV.Rows.Remove(selectedRow);
                total -= deletedSubtotal;
                if (total < 0) total = 0;
                SubTotal.Text = total.ToString("0.00");
                UpdateGrandTotal();

                MBox1.Show($"'{productName}' removed and stock restored successfully!");
            }
            catch (Exception ex)
            {
                MBox1.Show("Error: " + ex.Message);
            }
        }




        private void VATtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // Check if the character is a digit or a decimal point
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Ignore the input
                }

                // Optional: Prevent multiple decimal points
                if (e.KeyChar == '.' && VATtb.Text.Contains('.'))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void discountTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // Check if the character is a digit or a decimal point
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Ignore the input
                }

                // Optional: Prevent multiple decimal points
                if (e.KeyChar == '.' && discountTb.Text.Contains('.'))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VATtb.Text = "";
            discountTb.Text = "";
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Expiring exp = new Expiring();
            exp.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 vd = new Form1();
            vd.Show();
            vd.TopMost = true;
        }

        private void discountTb_TextChanged(object sender, EventArgs e)
        {

        }


        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Run your search
                button3_Click(SearchProducts, EventArgs.Empty);

                if (ProductsDVG.Rows.Count > 0)
                {
                    var firstRow = ProductsDVG.Rows[0];

                    // Make sure you use the actual column name/indices used by your grid (replace "PId" if different)
                    keyMain = Convert.ToInt32(firstRow.Cells["PId"].Value);   // <-- IMPORTANT
                    PnameTb = firstRow.Cells["PName"].Value?.ToString();
                    Pprice = Convert.ToSingle(firstRow.Cells["Pprice"].Value);
                    PStock = Convert.ToSingle(firstRow.Cells["PQty"].Value);

                    Quantity.Focus();
                }
                else
                {
                    MessageBox.Show("No product found!");
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }



        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Trigger Add button click which already calls UpdateQuantity()
                AddBtn.PerformClick();

                // Clear and ready for next product
                Search.Clear();
                Quantity.Clear();
                Search.Focus();

                e.Handled = true;
                e.SuppressKeyPress = true;
                // **DO NOT** call UpdateQuantity() here again
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            if (BillDGV.SelectedRows.Count == 0)
            {
                MBox1.Show("Please select an item to remove.");
                return;
            }

            DataGridViewRow selectedRow = BillDGV.SelectedRows[0];

            string productName = selectedRow.Cells[1].Value.ToString();
            int deletedQty = Convert.ToInt32(selectedRow.Cells[2].Value);
            float deletedSubtotal = float.Parse(selectedRow.Cells[4].Value.ToString());

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to remove '{productName}' and add back {deletedQty} to stock?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string connectionString = "server=localhost; database=posdb; username=root; password=;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // 1️⃣ Get current stock
                    string selectQuery = "SELECT PQty FROM producttbl WHERE PName = @PName";
                    int currentQty = 0;
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                    {
                        selectCmd.Parameters.AddWithValue("@PName", productName);
                        object result = selectCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            currentQty = Convert.ToInt32(result);
                        else
                        {
                            MBox1.Show($"Product '{productName}' not found in the database.");
                            return;
                        }
                    }

                    // 2️⃣ Add removed qty back to stock
                    int newQty = currentQty + deletedQty;
                    string updateQuery = "UPDATE producttbl SET PQty = @NewQty WHERE PName = @PName";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@NewQty", newQty);
                        updateCmd.Parameters.AddWithValue("@PName", productName);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                // 3️⃣ Remove from DataGridView and update total
                BillDGV.Rows.Remove(selectedRow);
                total -= deletedSubtotal;
                if (total < 0) total = 0;
                SubTotal.Text = total.ToString("0.00");
                UpdateGrandTotal();

                MBox1.Show($"'{productName}' removed and stock restored successfully!");
            }
            catch (Exception ex)
            {
                MBox1.Show("Error: " + ex.Message);
            }
        


    }
}

}
