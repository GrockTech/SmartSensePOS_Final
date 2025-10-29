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

using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GPOS
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // game changer string
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");

        private void Reset()
        {
            PnameTb.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
            PcatCB.SelectedIndex = -1;
            txtHprice.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //string expiry = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //DateTime expiry = dateTimePicker1.Value;

            if (PnameTb.Text == "" || PcatCB.SelectedIndex == -1 || PriceTb.Text == "" || txtHprice.Text == "" || QtyTb.Text == "")
            {
             MBox1.Show("All fields are required ");
            }
            else
            {
                try
                {
                  
                    // we open db connection 
                    Con.Open();
                   // connetionString.Open();
                    // dbConnection.Open();
                    MySqlCommand cmd = new MySqlCommand(" insert into ProductTbl(PName, Pcat, Pprice, H_Price, PQty) values(@PN, @PC, @PP, @HP, @PQ)", Con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    cmd.Parameters.AddWithValue("@PC", PcatCB.SelectedItem.ToString());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@HP", float.Parse(txtHprice.Text));
                    cmd.Parameters.AddWithValue("@PQ", float.Parse(QtyTb.Text));

                    // cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    //   cmd.Parameters.AddWithValue("@ED", expiry);

                    cmd.ExecuteNonQuery();
                    MBox1.Show("Product Added");
                    Con.Close();
              //      dbConnection.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox1.Show(Ex.Message);
                }
            }
        }

        private void PcatCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
