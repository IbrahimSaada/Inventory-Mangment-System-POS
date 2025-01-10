using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS
{
    public partial class addbrands : Form
    {
        Models.view_inventory inv = new Models.view_inventory();
        public addbrands()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtbname.Text) && !string.IsNullOrEmpty(txt_bdesc.Text))
            {
                inv.AddBrand(txtbname.Text, txt_bdesc.Text);
                txtbname.Clear();
                txt_bdesc.Clear();
            }
            else
            {
                MessageBox.Show("brosho");
            }
        }
    }
}
