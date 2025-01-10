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
    public partial class addbrand : Form
    {
        addbrands addbrands = new addbrands();
        editbrand editbrand = new editbrand();
        addcateg addcateg = new addcateg();
        editcateg editcateg = new editcateg();
        public addbrand()
        {
            InitializeComponent();
            addbrands.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(addbrands);

            addbrands.Show();
;
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {

            addbrands.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(addbrands);

            addbrands.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editbrand.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(editbrand);

            editbrand.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcateg.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(addcateg);
            addcateg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editcateg.TopLevel = false;
            panel2.Controls.Clear();
            panel2.Controls.Add(editcateg);
            editcateg.Show();

        }
    }
}
