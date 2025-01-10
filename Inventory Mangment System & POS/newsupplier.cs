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
    public partial class newsupplier : Form
    {
        private Models.Suppliers suppliers;
        public newsupplier()
        {
            InitializeComponent();
            suppliers = new Models.Suppliers();
        }

        private void newsupplier_Load(object sender, EventArgs e)
        {
            txt_date.ReadOnly = true;
            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Check if textboxes are not empty
            if (!string.IsNullOrEmpty(txt_sname.Text) && !string.IsNullOrEmpty(txt_email.Text) && !string.IsNullOrEmpty(txt_Saddress.Text))
            {
                string sname = txt_sname.Text;
                string email = txt_email.Text;
                string address = txt_Saddress.Text;
                DateTime date = Convert.ToDateTime(txt_date.Text);
                suppliers.SetNewSupplier(sname, email, address, date);
                clear();
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }

        }
        private void clear()
        {
            txt_sname.Clear();
            txt_email.Clear();
            txt_Saddress.Clear();
        }
    }
}
