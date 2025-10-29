


using GPOS.Properties;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
//using GPOS.Utilities;

namespace GPOS
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
            //   this.Load += new System.EventHandler(this.Mainmenu_Load);
            //  notifyIcon1.Icon = "C://Users/Elva/sourcerepos\\GrockTech\\GPOS-CSharp\\GPOS\\icons8-warning-96.ico";

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }




        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }
        /*
        private void ShowStockNotification(string productname, int quantity)
        {

            notifyIcon1.BalloonTipTitle = "Low Stock Alert";
            notifyIcon1.BalloonTipText = $"{productname} stock is low: Only {quantity} left";
            notifyIcon1.ShowBalloonTip(5000);
        }
        */

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddProducts obj = new AddProducts();
            obj.Show();
            obj.TopMost = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SuppliersAdd obj = new SuppliersAdd();
            obj.Show();
            obj.TopMost = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddCustomer obj = new AddCustomer();
            obj.Show();
            obj.TopMost = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewProducts obj = new ViewProducts();
            obj.Show();
            obj.TopMost = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewCustomers obj = new ViewCustomers();
            obj.Show();
            obj.TopMost = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Viewsuppliers obj = new Viewsuppliers();
            obj.Show();
            //obj.TopMost = true;
            Mainmenu wantoHide = new Mainmenu();
            obj.TopMost = true;
            wantoHide.Hide();
        }


        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");

        private decimal CalculateTotalPrices()
        {
            decimal totalPrice = 0m;

            using (MySqlConnection con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                string query = "SELECT PPrice, PQty FROM ProductTbl";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal price = Convert.ToDecimal(reader["PPrice"]);
                            int quantity = Convert.ToInt32(reader["PQty"]);
                            totalPrice += price * quantity;
                        }
                    }
                }
            }

            return totalPrice;
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            decimal mainTotal = CalculateTotalPrices();
            MessageBox.Show($"Store Value GH¢: {mainTotal}", "Store Values");
            //Box1.Show($"Store Value GH¢: {mainTotal}", "Store Values");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();

            this.Close();
        }


        //*************************
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
                            
                            //   totalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(reader["TotalQuantity"]) : 0;
                        }
                    }
                }
            }

            MessageBox.Show($"Total Sales for Today: GH¢ {totalSales}", "Daily Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //  MessageBox.Show($"Daily Sales is GH¢: {totalSales}", "Daily Sales");

            // MBox1.Show("Total Sales for Today: GHS '"++"');

        }

        //public async void CheckProductQuantity()
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM producttbl WHERE PQty < 5";

        //        using (MySqlConnection connection = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
        //        {
        //            MySqlCommand command = new MySqlCommand(query, connection);
        //            connection.Open();
        //            MySqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                string productName = reader["PName"].ToString();
        //                //                Task.Delay(10000);
        //                //              ShowNotification(productName);
        //            }

        //            reader.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {

        //    }

        //}

        //public async void CheckProductQuantity()
        //{
        //    try
        //    {
        //        string query = "SELECT PName FROM producttbl WHERE PQty < 5";

        //        using (MySqlConnection connection = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
        //        {
        //            await connection.OpenAsync();
        //            MySqlCommand command = new MySqlCommand(query, connection);
        //            MySqlDataReader reader = await command.ExecuteReaderAsync();

        //            while (await reader.ReadAsync())
        //            {
        //                string productName = reader["PName"].ToString();

        //                // 🪄 Show the toast message
        //                ToastNotification.ShowToast($"Low stock: {productName}");

        //                // ⏳ Wait 1 second before showing the next one (so they don't overlap)
        //                await Task.Delay(1000);
        //            }

        //            reader.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


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

        private void button1_Click(object sender, EventArgs e)
        {
            //CheckDailySales();
           DailySales ds = new DailySales();
            ds.Show();
            ds.TopMost = true; 
        }

        private void btnMonthlySales_Click(object sender, EventArgs e)
        {
            MonthlyBreakdown mb = new MonthlyBreakdown();
            mb.Show();
            mb.TopMost = true; 
        }

        private async void Mainmenu_Load(object sender, EventArgs e)
        {
            //            await Task.Delay(20000);
            //          CheckProductQuantity();
              CheckProductQuantity();  // Fire and forget

        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            TrackerNew expenseTracker = new TrackerNew();
            expenseTracker.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lowstock ld = new lowstock();
            ld.Show();
        }
    }
}

