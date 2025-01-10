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
    public partial class addcateg : Form
    {
        Models.view_inventory inv = new Models.view_inventory();
        public addcateg()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_categname.Text) && !string.IsNullOrEmpty(txt_cdesc.Text))
            {
                inv.AddCateg
                    (txt_categname.Text, txt_cdesc.Text);
                txt_categname.Clear();
                txt_cdesc.Clear();
            }
            else
            {
                MessageBox.Show("brosho");
            }
        }
    }
}
