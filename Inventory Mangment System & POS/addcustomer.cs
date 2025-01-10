using Inventory_Mangment_System___POS.Models;
using iText.Kernel.Pdf.Action;
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
    public partial class addcustomer : Form
    {
        private customers cus = new customers();
        public addcustomer()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cname.Text) && !string.IsNullOrEmpty(txt_info.Text) && !string.IsNullOrEmpty(txt_address.Text))
            {
                string name = txt_cname.Text;
                string info = txt_info.Text;
                string address = txt_address.Text;
                DateTime dt = DateTime.Now;
                string formattedDate = dt.ToString("yyyy/MM/dd");
                cus.AddCustomers(name, info, address, formattedDate);
            }
        }

        private void addcustomer_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.ReadOnly = true;
            bunifuTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
