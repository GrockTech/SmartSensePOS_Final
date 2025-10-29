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
    public partial class showValue : Form
    {
        public showValue()
        {
            InitializeComponent();

            StoreValuems.Text = Message;
        }

        private void showValue_Load(object sender, EventArgs e)
        {

        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        static string Message;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static void Show(string msg)
        {
            Message = msg;
            showValue Obj = new showValue();
            Obj.Show();
            Obj.TopMost = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
