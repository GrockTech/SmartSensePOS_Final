using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace GPOS
{
    public partial class Expiring : Form
    {
        public Expiring()
        {
            InitializeComponent();
            showExpiry();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showExpiry()
        {
            using (MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;"))
            {
                try
                {
                    Con.Open(); // Ensure the connection is open

                    //          string query = "SELECT * FROM producttbl WHERE STR_TO_DATE(expiry_date, '%Y-%m-%d') BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY);";
                    // string querry = "SELECT * FROM producttbl WHERE STR_TO_DATE(expiry_date, '%Y-%m-%d') BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY);";
                    //string querry = "SELECT * FROM producttbl WHERE expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY);";
                    string query = "SELECT * FROM producttbl WHERE STR_TO_DATE(expiry_date, '%Y-%m-%d') BETWEEN DATE_SUB(STR_TO_DATE(expiry_date, '%Y-%m-%d'), INTERVAL 30 DAY) AND STR_TO_DATE(expiry_date, '%Y-%m-%d');";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, Con);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                    var ds = new DataSet();
                    adapter.Fill(ds);

                    // Fill data grid with the actual data in the database
                    dataGridView1.DataSource = ds.Tables[0];
                    //showExpiry();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }
        private void Expiring_Load(object sender, EventArgs e)
        {
           // showExpiry();
        }
    }
}
