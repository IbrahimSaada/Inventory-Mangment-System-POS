using Inventory_Mangment_System___POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_uname.Text;
            string password = txt_psw.Text;

            Session session = new Session(username, password);
            session.CheckAccount();

            if (session.IsAuthenticated)
            {

                Form1 frm = new Form1(session);
                frm.Show();
                this.Hide(); // Hide9 the login form
            }
            else
            {
                // Authentication failed, show an error message
                MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_uname.Clear();
                txt_psw.Clear();
            }


        }
    }
}
