using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPOS
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Reset()
        {
            CusName.Text = "";
            CusAdd.Text = "";
            CusPhone.Text = "";
            CusRem.Text = "";
        }
        //SqlConnection Con = new SqlConnection("server=localhost; database=posdb; username=root; password=;");
        // SqlConnection Con = DatabaseHelper.GetConnection();
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (CusName.Text == "" || CusAdd.Text == "" || CusPhone.Text == "" || CusRem.Text == "")
            {
                MBox1.Show("All fields are required");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    MySqlCommand cmd = new MySqlCommand(" insert into CustomerTbl(CusName, CusAdd, CusPhone, CusRem) values(@CN, @CA, @CP, @CR)", Con);
                    cmd.Parameters.AddWithValue("@CN", CusName.Text);
                    cmd.Parameters.AddWithValue("@CA", CusAdd.Text);
                    cmd.Parameters.AddWithValue("@CP", Convert.ToInt32(CusPhone.Text).ToString());
                    cmd.Parameters.AddWithValue("@CR", CusRem.Text);

                    cmd.ExecuteNonQuery();
                    MBox1.Show("Customer Added");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void CusRem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
