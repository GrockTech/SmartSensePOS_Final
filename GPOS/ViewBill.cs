using MySql.Data.MySqlClient;
using System.Data;

namespace GPOS
{
    public partial class ViewBill : Form
    {
        public ViewBill()
        {
            InitializeComponent();
            ViewBills();
            SellDGV.CellClick += SellDGV_CellContentClick;

        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");


        private void ExecuteQueryAndUpdateDataGridView(string query)
        {
            // Define the connection string (replace with your actual connection string)

            string connectionString = "server=localhost; database=posdb; username=root; password=;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open(); // Open the database connection

                // Create a MySqlDataAdapter with the query and connection
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                var ds = new DataSet();

                // Fill the DataSet with the result of the query
                adapter.Fill(ds);

                // Bind the DataTable to the DataGridView
                SellDGV.DataSource = ds.Tables[0];
            }
        }








        private void ViewBills()
        {
            Con.Open();

            string query = @"
                SELECT * 
                FROM billdetails
                ORDER BY 
                    (DATE(Date) = CURDATE()) DESC,  -- today's records first
                    Date DESC;                      -- then all others in descending order
            ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            SellDGV.DataSource = ds.Tables[0];


            SellDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            Con.Close();

        }



        //private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get the selected option from the ComboBox
        //    //    string OptionSelected = cmbSort.SelectedItem.ToString();

        //        // Open the database connection
        //        Con.Open();

        //        // Correct the SQL query syntax
        //        string query = "SELECT * FROM billt WHERE PMethod = @PMethod";

        //        // Create a MySqlCommand with the query and connection
        //        MySqlCommand cmd = new MySqlCommand(query, Con);
        //        cmd.Parameters.AddWithValue("@PMethod", OptionSelected);

        //        // Create a MySqlDataAdapter to execute the command and fill the DataSet
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
        //        var ds = new DataSet();
        //        adapter.Fill(ds);

        //        // Fill the DataGridView with the data from the DataSet
        //        SellDGV.DataSource = ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors that occur
        //        MessageBox.Show($"An error occurred: {ex.Message}");
        //    }
        //    finally
        //    {
        //        // Ensure the database connection is closed
        //        if (Con.State == System.Data.ConnectionState.Open)
        //        {
        //            Con.Close();
        //        }
        //    }
        //}


        // Function to execute the query and update the DataGridView

        private void ViewBill_Load(object sender, EventArgs e)
        {

        }

        private void SellDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int billId = Convert.ToInt32(SellDGV.Rows[e.RowIndex].Cells["Id"].Value);
                    ReceiptPreview preview = new ReceiptPreview(billId);
                    preview.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening receipt preview: " + ex.Message);
                }
            }
        }

    }
}

