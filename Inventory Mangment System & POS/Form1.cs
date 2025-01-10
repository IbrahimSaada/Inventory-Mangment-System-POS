using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.UI.WinForms;
using System.Windows.Controls;
using Inventory_Mangment_System___POS.Models;
namespace Inventory_Mangment_System___POS
{
    public partial class Form1 : Form
    {
        private Session session;
        public Form1(Session session)
        {
            InitializeComponent();
            this.session = session;
        }
        bool MenuExpand = false;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (session.UserRole == "Admin")
            {
                Dashboard2 frm = new Dashboard2();
                frm.TopLevel = false;
                panel_form.Controls.Clear();
                panel_form.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                btn_dashboard.Enabled = false;
                button14.Enabled = false;
                btn_reports.Enabled = false;
                button13.Enabled = false;
                button8.Enabled = false;
                btn_addproduct.Enabled = false; 
                pos frm = new pos(session);
                frm.TopLevel = false;
                panel_form.Controls.Clear();
                panel_form.Controls.Add(frm);
                frm.Show();
            }

        }

        private void MenuTransition_Tick(object sender, EventArgs e)
        {
            if (!MenuExpand)
            {
                if (MenuContainer.Height < 209)
                    MenuContainer.Height += 5;
                else
                {
                    MenuTransition.Stop();
                    MenuExpand = true;
                }
            }
            else
            {
                if (MenuContainer.Height > 53)
                    MenuContainer.Height -= 10;
                else
                {
                    MenuTransition.Stop();
                    MenuExpand = false;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventory_Click(object sender, EventArgs e)
        {
            MenuTransition.Start();
        }
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if (sidebar.Width > 52)
                    sidebar.Width -= 10;
                else
                {
                    sidebarTransition.Stop();
                    sidebarExpand = false;
                }
            }
            else
            {
                if (sidebar.Width < 231)
                    sidebar.Width += 10;
                else
                {
                    sidebarTransition.Stop();
                    sidebarExpand = true;
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuTransition.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View_Inventory vi = new View_Inventory();
            vi.TopLevel = false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(vi);

            vi.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void SupplierTransition_Tick(object sender, EventArgs e)
        {
            if (!MenuExpand)
            {
                if (SupplierContainer.Height < 209)
                    SupplierContainer.Height += 5;
                else
                {
                    SupplierTransition.Stop();
                    MenuExpand = true;
                }
            }
            else
            {
                if (SupplierContainer.Height > 53)
                    SupplierContainer.Height -= 10;
                else
                {
                    SupplierTransition.Stop();
                    MenuExpand = false;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SupplierTransition.Start();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            Reports frm = new Reports();
            frm.TopLevel = false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(frm);

            frm.Show();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {

            Dashboard2 frm = new Dashboard2();
            frm.TopLevel = false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(frm);

            frm.Show();

        }


        private void panel_repots_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pos frm = new pos(session);
            frm.TopLevel = false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(frm);

            frm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            pos frm = new pos(session);
            frm.TopLevel = false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(frm);

            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_addbrand_Click(object sender, EventArgs e)
        {
            addbrand frm = new addbrand();
            frm.ShowDialog();
        }

        private void btn_addproduct_Click(object sender, EventArgs e)
        {
            Addproduct frm = new Addproduct();
            frm.TopLevel=false;
            panel_form.Controls.Clear();
            panel_form.Controls.Add(frm);
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            View_Suppliers frm = new View_Suppliers();
            frm.ShowDialog();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            expenses expenses = new expenses();
            expenses.ShowDialog();
        }

        private void btn_addsupplier_Click(object sender, EventArgs e)
        {
            newsupplier frm = new newsupplier();
            frm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Access_Control access_Control = new Access_Control();
            access_Control.ShowDialog();
        }

        private void btn_customers_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ShowDialog();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.ShowDialog();
        }
    }
}
