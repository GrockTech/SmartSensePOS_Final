using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace GPOS
{
    public partial class TrackerNew : Form
    {
        public TrackerNew()
        {
            InitializeComponent();
            DisplayExpenses();
        }

        private void TrackerNew_Load(object sender, EventArgs e)
        {

        }
        private void DisplayExpenses()
        {

            //con.Open();
            string dpExp = "SELECT * FROM expenses";


            MySqlDataAdapter adapter = new MySqlDataAdapter(dpExp, con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            dataGridView1.DataSource = ds.Tables[0];


            con.Close();




        }

        string TCost;
        public double SumCostByDateRange(string connectionString, string startDate, string endDate)
        {
            double totalCost = 0.0;

            string sumQuery = "SELECT SUM(cost) FROM expenses WHERE STR_TO_DATE(date, '%Y-%m-%d') >= @StartDate AND STR_TO_DATE(date, '%Y-%m-%d') <= @EndDate";
            string selectQuery = "SELECT * FROM expenses WHERE STR_TO_DATE(date, '%Y-%m-%d') >= @StartDate AND STR_TO_DATE(date, '%Y-%m-%d') <= @EndDate";

            using (var con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // First, get the total cost
                    using (var sumCmd = new MySqlCommand(sumQuery, con))
                    {
                        sumCmd.Parameters.AddWithValue("@StartDate", startDate);
                        sumCmd.Parameters.AddWithValue("@EndDate", endDate);
                        object result = sumCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            totalCost = Convert.ToDouble(result);
                        }
                    }

                    // Now, fill the DataGridView with data
                    using (var selectCmd = new MySqlCommand(selectQuery, con))
                    {
                        selectCmd.Parameters.AddWithValue("@StartDate", startDate);
                        selectCmd.Parameters.AddWithValue("@EndDate", endDate);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(selectCmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log, rethrow, etc.)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return totalCost; // Return the total cost
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost; database=posdb; username=root; password=;";
            string sdate = txtDateFrom.Value.ToString("yyyy-MM-dd");
            string tdate = txtDateTo.Value.ToString("yyyy-MM-dd");

            double TotalCost = SumCostByDateRange(connectionString, sdate, tdate);
            label7.Text = TotalCost.ToString("F2"); // Format for currency display
            TCost = TotalCost.ToString();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");


        private void button1_Click(object sender, EventArgs e)
        {
            /// insert query
            ///     
            string service = txtSerivce.Text;
            double cost = Convert.ToDouble(txtCost.Text);
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            if (service == "" || cost <= 0 || date == "")
            {

                MessageBox.Show("All fields are required.");
            }
            else
            {
                try
                {
                    string expenseQ = "INSERT INTO expenses(service, cost, date) value(@SS, @CT, @DT)";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(expenseQ, con);
                    cmd.Parameters.AddWithValue("@CT", cost);
                    cmd.Parameters.AddWithValue("@SS", service);
                    cmd.Parameters.AddWithValue("@DT", date);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record saved!");
                    DisplayExpenses();

                    txtCost.Text = "";
                    txtSerivce.Text = "";
                    //  txtCost.Text = "";
                    // dateTimePicker1.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.Rows.Count > 0)
        //    {
        //        SaveFileDialog save = new SaveFileDialog();
        //        save.Filter = "PDF (*.pdf)|*.pdf";
        //        save.FileName = "Expenses.pdf";
        //        bool ErrorMessage = false;
        //        if (save.ShowDialog() == DialogResult.OK)
        //        {
        //            if (File.Exists(save.FileName))
        //            {
        //                try
        //                {
        //                    File.Delete(save.FileName);
        //                }
        //                catch (Exception ex)
        //                {
        //                    ErrorMessage = true;
        //                    MessageBox.Show("Unable to write data to disk: " + ex.Message);
        //                }
        //            }
        //            if (!ErrorMessage)
        //            {
        //                try
        //                {
        //                    // Create PdfPTable for DCS
        //                    PdfPTable pTable1 = new PdfPTable(dataGridView1.Columns.Count);
        //                    pTable1.DefaultCell.Padding = 2;
        //                    pTable1.WidthPercentage = 100;
        //                    pTable1.HorizontalAlignment = Element.ALIGN_LEFT;
        //                    foreach (DataGridViewColumn col in dataGridView1.Columns)
        //                    {
        //                        PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
        //                        pTable1.AddCell(pCell);
        //                    }
        //                    foreach (DataGridViewRow viewRow in dataGridView1.Rows)
        //                    {
        //                        foreach (DataGridViewCell dcell in viewRow.Cells)
        //                        {
        //                            pTable1.AddCell(dcell.Value?.ToString() ?? string.Empty);
        //                        }
        //                    }



        //                    using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
        //                    {

        //                        Paragraph heading = new Paragraph("EXPENSES\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
        //                        Paragraph subheading = new Paragraph("YOUR COMPANY NAME\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
        //                        // string cashiername;
        //                        //     cashiername = Form1.recby;
        //                        string showTotal = TCost.ToString();



        //                        iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 8f, 16f, 16f, 8f);
        //                        PdfWriter.GetInstance(document, fileStream);
        //                        document.Open();
        //                        document.Add(heading);
        //                        document.Add(subheading);
        //                        // document.Add(showTotal);
        //                        document.Add(pTable1);
        //                        document.Add(new Paragraph("\n\n")); // Add some space between the tables
        //                        document.Add(new Paragraph("\n\n")); // Add some space between the tables

        //                        document.Close();
        //                        fileStream.Close();
        //                    }
        //                    MessageBox.Show("Data Exported Successfully", "Info");
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error while exporting data: " + ex.Message);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Record Found", "Info");
        //    }


        //}

        private void txtDateFrom_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
