using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPOS
{
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
            DisplayProducts();
            ProductDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
           ProductDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Mainmenu obj = new Mainmenu();
            obj.Show();
            this.Hide();
        }
        //  SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GidCode\Desktop\CodeMe\GPOSDB.mdf;Integrated Security=True;Connect Timeout=30");
        // SqlConnection Con = new SqlConnection(Data Source="DESKTOP-NQAIIND\SQLEXPRESS; Initial Catalog=mydb; Integrated Security = True; Connect Timeout = 30; ");
        //  SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NQAIIND\SQLEXPRESS; Initial Catalog=mydb; Integrated Security = True; Connect Timeout = 30; ");
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");

        private void DisplayProducts()
        {
            Con.Open();
            string Query = "select * from ProductTbl";

            //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            MySqlCommand cmd = new MySqlCommand(Query, Con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            ProductDGV.DataSource = ds.Tables[0];


            ProductDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            Con.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (keyMain == 0)
            {
                MBox1.Show("select the product");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand(" delete from ProductTbl where PId=@Pkey", Con);
                    cmd.Parameters.AddWithValue("@PKey", keyMain);


                    cmd.ExecuteNonQuery();
                    MBox1.Show("Product Deleted!");
                    Con.Close();
                    DisplayProducts();
                    //eset();
                    PnameTb.Clear();
                    PriceTb.Clear();
                    QtyTb.Clear();


                }
                catch (Exception Ex)
                {
                    MBox1.Show(Ex.Message);
                }
            }

        }

        int keyMain = 0;
        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            // setting data in datagrid to fit text box for edit RESPECTIVELY 
            PnameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value?.ToString();
            PcatCB.SelectedItem = ProductDGV.SelectedRows[0].Cells[2].Value?.ToString();
            //txtHprice.Text = ProductDGV.SelectedRows[0].Cells[4].Value?.ToString(); 
            //PriceTb.Text = ProductDGV.SelectedRows[0].Cells[3].Value?.ToString();
            //QtyTb.Text = ProductDGV.SelectedRows[0].Cells[5].Value?.ToString();
            //// string expiry = dateTimePicker1.Value.ToString();
            //  string selectedDate = ProductDGV.SelectedRows[0].Cells[5].Value?.ToStr ing();
            // dateTimePicker1.Value = selectedDate;
            PriceTb.Text = ProductDGV.SelectedRows[0].Cells[3].Value?.ToString();   // if Pprice column is 4
            txtHprice.Text = ProductDGV.SelectedRows[0].Cells[4].Value?.ToString(); // if HPrice column is 3
           
            QtyTb.Text = ProductDGV.SelectedRows[0].Cells[5].Value?.ToString();     // if pQty column is 5


            // dateTimePicker1.Value = selectedDateUpdate.Date;
            //  expiry = selectedDate;


            if (PnameTb.Text == "")
            {

                keyMain = 0;
            }
            else
            {

                keyMain = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());

            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            //edit button

            if (PnameTb.Text == "" ||  PriceTb.Text == "" || QtyTb.Text == "")
            {
                MBox1.Show("Select the product or product category ");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand(" Update ProductTbl set PName = @PN, Pprice = @PP,H_Price = @HP,   pQty = @PQ where PId = @Pkey", Con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    //cmd.Parameters.AddWithValue("@PC", PcatCB.SelectedItem.ToString());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@HP", txtHprice.Text);
                  
                    // cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", float.Parse(QtyTb.Text));

                    cmd.Parameters.AddWithValue("@Pkey", keyMain);
                   // cmd.Parameters.AddWithValue("DD", dateTimePicker1);

                    cmd.ExecuteNonQuery();
                    MBox1.Show("Product Updated");
                    Con.Close();
                    DisplayProducts();
                    //  Reset();
                    PnameTb.Clear();
                    PriceTb.Clear();
                    QtyTb.Clear();  
                    txtHprice.Clear();
                    //PcatCB.Items.Clear();
                }
                catch (Exception Ex)
                {
                    MBox1.Show(Ex.Message);
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddProducts obj = new AddProducts();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewProducts Obj = new ViewProducts();
            Obj.Show();
            this.Close();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = search.Text.Trim();
            SearchProducts(searchTerm);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = search.Text.Trim();
            SearchProducts(searchTerm);
        }
        private void SearchProducts(string searchTerm)
        {
            try
            {
                Con.Open();
                string Query = "SELECT * FROM ProductTbl WHERE PName LIKE @SearchTerm";
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ProductDGV.DataSource = dt;
                ProductDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            txtSearch.Text = "";
        }
    }
}
