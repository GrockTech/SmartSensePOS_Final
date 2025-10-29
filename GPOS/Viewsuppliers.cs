using GPOS.Properties;
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
    public partial class Viewsuppliers : Form
    {
        public Viewsuppliers()
        {
            InitializeComponent();
            DisplaySuppliers();
            SupplierDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SupplierDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            SupplierDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Mainmenu obj = new Mainmenu();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Viewsuppliers Obj = new Viewsuppliers();
            Obj.Show();
            this.Close();
        }



        //    SqlConnection Con = new SqlConnection(@"DESKTOP-NQAIIND\SQLEXPRESS; Initial Catalog=mydb; Integrated Security = True; Connect Timeout = 30; ");
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");
        private void DisplaySuppliers()
        {
            Con.Open();
            string Query = "select * from SupplierTBL";
            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            SupplierDGV.DataSource = ds.Tables[0];


            SupplierDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            Con.Close();

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // setting data in datagrid to fit text box for edit RESPECTIVELY 
            SupName.Text = SupplierDGV.SelectedRows[0].Cells[1].Value.ToString();
            SupAdd.Text = SupplierDGV.SelectedRows[0].Cells[2].Value.ToString();
            SupPhone.Text = SupplierDGV.SelectedRows[0].Cells[3].Value.ToString();
            SupRem.Text = SupplierDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (SupName.Text == "")
            {

                key = 0;
            }
            else
            {

                key = Convert.ToInt32(SupplierDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SupName.Text == "" || SupAdd.Text == "" || SupPhone.Text == "" || SupRem.Text == "")
            {
                MBox1.Show("Select the product ");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand(" Update SupplierTBL set SupName = @SN, SupAddress=@SA, SupPhone = @SP, SupRem = @SR where SupId = @Pkey", Con);
                    cmd.Parameters.AddWithValue("@SN", SupName.Text);
                    cmd.Parameters.AddWithValue("@SA", SupAdd.Text);
                    cmd.Parameters.AddWithValue("@SP", SupPhone.Text);
                    cmd.Parameters.AddWithValue("@SR", SupRem.Text);
                    cmd.Parameters.AddWithValue("@Pkey", key);

                    cmd.ExecuteNonQuery();
                    MBox1.Show("Supplier Detail Updated");
                    Con.Close();
                    DisplaySuppliers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void Reset()
        {
            SupName.Text = "";
            SupAdd.Text = "";
            SupPhone.Text = "";
            SupRem.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MBox1.Show("select the Supplier");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand(" delete from SupplierTbl where SupId=@Pkey", Con);
                    cmd.Parameters.AddWithValue("@PKey", key);


                    cmd.ExecuteNonQuery();
                    MBox1.Show("Supplier Deleted ");
                    Con.Close();
                    DisplaySuppliers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox1.Show(Ex.Message);
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Viewsuppliers_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            SuppliersAdd Obj = new SuppliersAdd();
            Obj.Show();
            this.Close();
        }
    }
}
