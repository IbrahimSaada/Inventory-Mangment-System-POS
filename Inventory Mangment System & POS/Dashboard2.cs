using Bunifu.UI.WinForms;
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
    public partial class Dashboard2 : Form
    {
        private Button currentButton;
        public Dashboard2()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();
            SetDateMenuButtonsUI(btnLast7Days);
            LoadData();
            dgvUnderstock.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
        }

        private void LoadData()
        {
            Dashboard d = new Dashboard();
            var refreshData = d.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData == true)
            {
                lblNumOrders.Text = d.NumOrders.ToString();
                lblTotalRevenue.Text = "$" + d.TotalRevenue.ToString();
                lblTotalProfit.Text = "$" + d.TotalProfit.ToString();

                lblNumCustomers.Text = d.NumCustomers.ToString();
                lblNumSuppliers.Text = d.NumSuppliers.ToString();
                lblNumProducts.Text = d.NumProducts.ToString();

                chartGrossRevenue.DataSource = d.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date";
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                chartGrossRevenue.DataBind();

                chartTopProducts.DataSource = d.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();

                dgvUnderstock.DataSource = d.UnderstockList;
                dgvUnderstock.Columns[0].HeaderText = "Item";
                dgvUnderstock.Columns[1].HeaderText = "Units";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");

        }
        private void DisableCustomDates()
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOkCustomDate.Visible = false;
        }
        private void SetDateMenuButtonsUI(object button)
        {
            var btn =(Button)button;
            btn.BackColor = btnLast30Days.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;
            if(currentButton != null  && currentButton!=btn)
            {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }
            currentButton = btn;
            if(btn == btnCustomDate)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
                btnOkCustomDate.Visible = true;
                lblStartDate.Cursor = Cursors.Hand;
                lblEndDate.Cursor = Cursors.Hand;
            }

            else
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                btnOkCustomDate.Visible = false;
                lblStartDate.Cursor = Cursors.Hand;
                lblEndDate.Cursor = Cursors.Default;
                lblEndDate.Cursor = Cursors.Default;
            }
        }
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }
        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }
        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }
        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }
        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkCustomDate.Visible = true;
            SetDateMenuButtonsUI(sender);
        }
        private void Dashboard2_Load(object sender, EventArgs e)
        {
            lblStartDate.Text = dtpStartDate.Text;
            lblEndDate.Text = dtpEndDate.Text;
        }

        private void lblNumCustomers_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lblStartDate_Click_1(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpStartDate.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void lblEndDate_Click(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpEndDate.Select();
                SendKeys.Send("%{DOWN}");
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            lblEndDate.Text = dtpEndDate.Text;
        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            lblStartDate.Text = dtpStartDate.Text;
        }

        private void btnOkCustomDate_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvUnderstock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
