using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPOS
{
    public partial class DailySales : Form
    {
        public DailySales()
        {
            InitializeComponent();
        }

        //private void LoadDailySales()
        //{
        //    // Connection string: Replace with your actual connection string
        //    string connectionString = "server=localhost; database=posdb; username=root; password=;";

        //    // SQL query
        //    string query = @"
        //        SELECT 
        //            DATE_FORMAT(Bdate, '%Y-%m-%d') AS Day, 
        //            SUM(Amt) AS TotalSales
        //        FROM 
        //            billt
        //        GROUP BY 
        //            DATE_FORMAT(Bdate, '%Y-%m-%d')
        //        ORDER BY 
        //            MIN(Bdate);";

        //    // Load data into a DataTable
        //    DataTable monthlySalesTable = new DataTable();
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        MySqlCommand command = new MySqlCommand(query, connection);
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        //        connection.Open();
        //        adapter.Fill(monthlySalesTable);
        //    }

        //    // Bind data to DataGridView
        //    dataGridView1.DataSource = monthlySalesTable;
        //}


        private void LoadDailySales()
        {
            // Database connection string
            string connectionString = "server=localhost; database=posdb; username=root; password=;";

            // SQL query using only billdetails table
            // Assuming billdetails has Bdate (bill date), Price (selling price), H_Price (wholesale price), and Quantity columns
            string query = @"
        SELECT 
            DATE_FORMAT(Date, '%Y-%m-%d') AS Day,          
            SUM(Price * Quantity) AS TotalSales,              
            SUM((Price - HPrice) * Quantity) AS TotalProfit  
        FROM 
            billdetails                                     
        GROUP BY 
            DATE_FORMAT(Date, '%Y-%m-%d')                   
        ORDER BY 
            MAX(Day) DESC;"; 

    // Create DataTable to store the results
    DataTable dailySalesTable = new DataTable();

            // Database operations with proper resource management
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create command with our query
                MySqlCommand command = new MySqlCommand(query, connection);

                // DataAdapter to fill the DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                // Open connection and execute query
                connection.Open();
                adapter.Fill(dailySalesTable);
                // Connection automatically closes when leaving the using block
            }

            // Bind the results to DataGridView for display
            dataGridView1.DataSource = dailySalesTable;
        }

        // Close button event handler
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();  // Close the current form
        }

        // Form load event handler
        private void DailySales_Load(object sender, EventArgs e)
        {
            LoadDailySales();  // Load data when form opens
        }
        
    }
}
