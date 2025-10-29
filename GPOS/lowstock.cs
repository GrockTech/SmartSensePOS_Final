//using iTextSharp.text;
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

namespace GPOS
{
    public partial class lowstock : Form
    {
        public lowstock()
        {
            InitializeComponent();
            CheckStock();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost; database=posdb; username=root; password=;");

        private void CheckStock()
        {
            int lowstockNo = 5;

            Con.Open();

            string query = "SELECT * FROM productTbl WHERE PQty < @lowStockNo";
            MySqlCommand cmd = new MySqlCommand(query, Con);
            cmd.Parameters.AddWithValue("@lowStockNo", lowstockNo);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            LD.DataSource = ds.Tables[0];




            Con.Close();
        }

        private void lowstock_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
