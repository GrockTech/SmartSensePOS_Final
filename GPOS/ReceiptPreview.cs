

using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace GPOS
{
    public partial class ReceiptPreview : Form
    {
        private int billId; // Store the selected BillID
        private MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");
        private DataTable billItems = new DataTable(); // To hold the data for printing

        public ReceiptPreview()
        {
            InitializeComponent();

        }

        public ReceiptPreview(int selectedBillId)
        {
            InitializeComponent();

            billId = selectedBillId; // Assign the passed BillID
            printDocument1.PrintPage -= printDocument1_PrintPage;
            printDocument1.PrintPage += printDocument1_PrintPage;
            LoadBillItems(); // Load bill items immediately
        }

        private void ReceiptPreview_Load(object sender, EventArgs e)
        {
        }



        private void LoadBillItems()
        {
            try
            {
                Con.Open();
                // Query using Id column instead of bID
                string query = "SELECT Id, ProductName, Quantity, Price, Subtotal FROM billdetails WHERE Id = @billId";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@billId", billId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(billItems);
                BillDVG.DataSource = billItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bill: {ex.Message}");
            }
            finally
            {
                Con.Close();
            }
        }

        // Handle the printing
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int pos = 40; // Starting print position
            float grandTotal = 0; // Accumulate total

            // ===== HEADER =====
            string title = "HAPPY VENTURES";
            string contact = "Tel:+233 249589113";
            string location = "Location: JEMA, OPP. TUES. MARKET";


            e.Graphics.DrawString(title, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Black, 50, pos);
            pos += 20;
            e.Graphics.DrawString(contact, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 50, pos);
            pos += 15;
            e.Graphics.DrawString(location, new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 50, pos);
            pos += 20;
            e.Graphics.DrawString("-------------------------------------------------------", new Font("Century Gothic", 7), Brushes.Black, 50, pos);
            pos += 20;

            // ===== COLUMN HEADER =====
            e.Graphics.DrawString("Item", new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 50, pos);
            e.Graphics.DrawString("Qty", new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 130, pos);
            e.Graphics.DrawString("Price", new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 180, pos);
            e.Graphics.DrawString("Total", new Font("Century Gothic", 7, FontStyle.Bold), Brushes.Black, 240, pos);
            pos += 20;

            // ===== BILL ITEMS =====
            try
            {
                Con.Open();
                string query = "SELECT ProductName, Quantity, Price, Subtotal FROM billdetails WHERE Id = @billId";
                MySqlCommand cmd = new MySqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@billId", billId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string pname = reader["ProductName"].ToString();
                        int qty = Convert.ToInt32(reader["Quantity"]);
                        float price = Convert.ToSingle(reader["Price"]);
                        float total = Convert.ToSingle(reader["Subtotal"]);

                        grandTotal += total;

                        e.Graphics.DrawString(pname, new Font("Century Gothic", 7), Brushes.Black, 50, pos);
                        e.Graphics.DrawString(qty.ToString(), new Font("Century Gothic", 7), Brushes.Black, 130, pos);
                        e.Graphics.DrawString(price.ToString("0.00"), new Font("Century Gothic", 7), Brushes.Black, 180, pos);
                        e.Graphics.DrawString(total.ToString("0.00"), new Font("Century Gothic", 7), Brushes.Black, 240, pos);

                        pos += 15;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while printing: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }

            // ===== FOOTER =====
            pos += 10;
            e.Graphics.DrawString("-------------------------------------------------------", new Font("Century Gothic", 7), Brushes.Black, 50, pos);
            pos += 20;
            e.Graphics.DrawString($"GRAND TOTAL: {grandTotal:0.00}", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, 50, pos);
            pos += 30;

            e.Graphics.DrawString("Thank you for shopping with us!", new Font("Century Gothic", 7, FontStyle.Italic), Brushes.Black, 50, pos);
            pos += 15;
            e.Graphics.DrawString("Please visit again.", new Font("Century Gothic", 7, FontStyle.Italic), Brushes.Black, 50, pos);
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;
            // previewDialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

            previewDialog.Document = printDocument1;
            previewDialog.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //ReceiptPreview receiptPreview = new ReceiptPreview();
            //receiptPreview.Close();
            this.Close();

        }
    }
}
