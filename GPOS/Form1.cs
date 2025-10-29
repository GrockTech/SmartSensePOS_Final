
using MySql.Data.MySqlClient;
//using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using OfficeOpenXml;

namespace GPOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getDetails();
        }
        
        private void getDetails()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
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
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                } // Connection will be automatically closed and disposed here
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CopyToCB()
        {
            try
            {
                string headers = "";
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    headers += column.HeaderText + "\t";
                }
                headers = headers.TrimEnd('\t');

                Clipboard.SetText(headers);
                dataGridView1.SelectAll();
                DataObject obj = dataGridView1.GetClipboardContent();
                if (obj != null)
                    Clipboard.SetDataObject(obj);
                else
                    MessageBox.Show("Dataset is empty");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void Topselling()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
                {
                    con.Open();

                    // 1️⃣ Get selected date range (make sure end date includes full day)
                    DateTime startD = dateTimePicker1.Value.Date;
                    DateTime endD = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

                    // 2️⃣ Query for top selling products within range
                    string query = @"
                SELECT 
                    ProductName AS 'Product',
                    SUM(Quantity) AS 'Total Quantity Sold',
                    SUM(HPrice * Quantity) AS 'Total Cost (GH₵)',
                    SUM(Price * Quantity) AS 'Total Sales (GH₵)',
                    SUM(Profit) AS 'Total Profit (GH₵)'
                FROM billdetails
                WHERE Date BETWEEN @startD AND @endD
                GROUP BY ProductName
                ORDER BY SUM(Quantity) DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@startD", startD);
                        cmd.Parameters.AddWithValue("@endD", endD);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 3️⃣ Display results in your existing DataGridView
                        dataGridView1.DataSource = dt;

                        // Optional: auto-size columns for neat display
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MBox1.Show("Error loading top-selling products: " + ex.Message);
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {


        //        CopyToCB();
        //        Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
        //        Microsoft.Office.Interop.Excel.Workbook xlwb;
        //        Microsoft.Office.Interop.Excel.Worksheet xlsh;
        //        Microsoft.Office.Interop.Excel.Range xlr;

        //        object mv = System.Reflection.Missing.Value;

        //        xlwb = xls.Workbooks.Add(mv);
        //        xlsh = xlwb.Worksheets[1];

        //        // Define column headers (adjust column names as needed)

        //        //xlsh.Cells[1, 1] = "Product Name";
        //        //xlsh.Cells[1, 2] = "Date";
        //        //xlsh.Cells[1, 3] = "Quantity";
        //        //xlsh.Cells[1, 4] = "Price";
        //        //xlsh.Cells[1, 5] = "Subtotal";
        //        // If you are exporting the date

        //        // Make headers bold
        //        xlsh.Range["A1:E1"].Font.Bold = true;

        //        // Select the first cell below headers
        //        xlr = xlsh.Cells[2, 1];
        //        xlr.Select();

        //        // Paste copied data starting from row 2
        //        xlsh.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        //        xls.Visible = true;
        //        this.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Text = "Loading...";

            try
            {
                Topselling(); // Run the function you already built
            }
            finally
            {
                button2.Enabled = true;
                button2.Text = "Show Top Selling";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            getDetails();

        }
    }
}
