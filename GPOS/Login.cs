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
    public partial class Login : Form
    {
        public static string username;

        public static string recby
        {
            get { return username; }
            set { username = value; }


        }
        public Login()
        {
            InitializeComponent();
            //  loginButton.Click += new EventHandler(loginButton_Click);

            //this.Icon = new Icon("E:\\source\\GrockTech\\POS_big-solo_updated\\GPOS\\sense.ico");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //  private void Login_Load(object sender, EventArgs e){  }
        private void label5_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            //string password = PasswordTB.Text;
            string pass = txtPass.Text;
            if (username == "" || pass == "")
            {
                MBox1.Show("Enter UserName and Password");

            }
            else if(username == "afosaah" && pass == "afosaah1")
            {
                Billing obj = new Billing(username);
                obj.Show();
                this.Hide();
            }
            
        }
        string pass;
        private void Loginclick()

        {
            string username = UsernameTB.Text;
            //string password = PasswordTB.Text;
            string pass = txtPass.Text;
            if (username == "" || pass == "")
            {
                MBox1.Show("Enter UserName and Password");

            }
            else if (username == "happyventures" && pass == "happyventures@two")
            {
                Mainmenu Obj = new Mainmenu();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MBox1.Show("Wrong Username or Password");
            }

        }
       

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Loginclick();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void showpwd_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        /*
private void ViewPassword_CheckedChanged(object sender, EventArgs e)
{
if (ViewPassword.Checked)
{
PasswordTB.PasswordChar = '\0';
}
else
{
PasswordTB.PasswordChar = '*';
}
}
*/
    }
}
