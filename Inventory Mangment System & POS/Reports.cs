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
    public partial class Reports : Form
    {
        private Button currentButton;
        public Reports()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();
            SetDateMenuButtonsUI(btnLast7Days);
            LoadSalesOverview();
            LoadTopCustomers();
            LoadProfitAnalysis();
        }
        private void LoadSalesOverview()
        {
            buissnessreport report = new buissnessreport();
            List<buissnessreport.SalesRecord> salesRecords = report.GenerateSalesOverviewData(dtpStartDate.Value, dtpEndDate.Value);

            if (salesRecords != null && salesRecords.Any())
            {
                var dataSource = salesRecords.Select(record => new
                {
                    ItemName = record.ItemName,
                    InvoiceNo = record.InvoiceNO,
                    Date = record.Date,
                    SoldBy = record.SoldBy,
                    Type = record.Type,
                    PurchasedBy = record.PurchasedBy,
                    Quantity = record.Quantity,
                    Amount = record.Amount
                }).ToList();

                dgvsalesoverview.DataSource = dataSource;

                // Set header names
                dgvsalesoverview.Columns[0].HeaderText = "Item Name";
                dgvsalesoverview.Columns[1].HeaderText = "Invoice No";
                dgvsalesoverview.Columns[2].HeaderText = "Date";
                dgvsalesoverview.Columns[3].HeaderText = "Sold By";
                dgvsalesoverview.Columns[4].HeaderText = "Type";
                dgvsalesoverview.Columns[5].HeaderText = "Purchased By";
                dgvsalesoverview.Columns[6].HeaderText = "Quantity";
                dgvsalesoverview.Columns[7].HeaderText = "Amount";
                dgvsalesoverview.Columns["ItemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // Align content in columns and headers
                foreach (DataGridViewColumn column in dgvsalesoverview.Columns)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                dgvsalesoverview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvsalesoverview.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }
        }
        private void LoadTopCustomers()
        {
            buissnessreport report = new buissnessreport();
            List<KeyValuePair<string, decimal>> topCustomers = report.GenerateTopCustomersData(dtpStartDate.Value, dtpEndDate.Value);

            chartTopProducts.Series[0].Points.Clear();

            foreach (var customer in topCustomers)
            {
                chartTopProducts.Series[0].Points.AddXY(customer.Key, customer.Value);
            }
        }
        private void LoadProfitAnalysis()
        {
            buissnessreport report = new buissnessreport();

            List<KeyValuePair<string, decimal>> revenueData = report.GenerateRevenue(dtpStartDate.Value, dtpEndDate.Value);
            List<KeyValuePair<string, decimal>> profitData = report.GenerateProfit(dtpStartDate.Value, dtpEndDate.Value);

            chartProfitAnalysis.Series.Clear();

            var revenueSeries = chartProfitAnalysis.Series.Add("Revenue");
            revenueSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (var item in revenueData)
            {
                revenueSeries.Points.AddXY(item.Key, item.Value);
            }

            var profitSeries = chartProfitAnalysis.Series.Add("Profit");
            profitSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (var item in profitData)
            {
                profitSeries.Points.AddXY(item.Key, item.Value);
            }

            // Add legend titles for total revenue and total profit

            decimal totalRevenue = report.GetTotalRevenue(dtpStartDate.Value, dtpEndDate.Value);
            decimal totalprofit = report.GetTotalProfit(dtpStartDate.Value, dtpEndDate.Value);

            chartProfitAnalysis.Legends.Clear();
            chartProfitAnalysis.Legends.Add("Legend1");
            chartProfitAnalysis.Legends["Legend1"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            chartProfitAnalysis.Legends["Legend1"].CustomItems.Add(Color.FromArgb(1, 220, 205), "Total Revenue: " + totalRevenue.ToString());
            chartProfitAnalysis.Legends["Legend1"].CustomItems.Add(Color.FromArgb(94, 153, 254), "Total Profit: " + totalprofit.ToString()); // Add legend title for total profit
            chartProfitAnalysis.Legends["Legend1"].BackColor = Color.Transparent;
            chartProfitAnalysis.Legends["Legend1"].ForeColor = Color.Silver;
            chartProfitAnalysis.Legends["Legend1"].Font = new Font("Arial", 12);

            chartProfitAnalysis.ChartAreas[0].AxisX.Interval = 1;
            chartProfitAnalysis.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            chartProfitAnalysis.Refresh();
        }
        private void dgvsalesoverview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisableCustomDates()
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOkCustomDate.Visible = false;
        }
        private void SetDateMenuButtonsUI(object button)
        {
            var btn = (Button)button;
            btn.BackColor = btnLast30Days.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;
            if (currentButton != null && currentButton != btn)
            {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }
            currentButton = btn;
            if (btn == btnCustomDate)
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
            LoadSalesOverview();
            LoadTopCustomers();
            LoadProfitAnalysis();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesOverview();
            LoadTopCustomers();
            LoadProfitAnalysis();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesOverview();
            LoadTopCustomers();
            LoadProfitAnalysis();
            DisableCustomDates();
            SetDateMenuButtonsUI(sender);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesOverview();
            LoadTopCustomers();
            LoadProfitAnalysis();
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

        private void Reports_Load(object sender, EventArgs e)
        {
            lblStartDate.Text = dtpStartDate.Text;
            lblEndDate.Text = dtpEndDate.Text;
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Parse(lblStartDate.Text);
            dtpEndDate.Value = DateTime.Parse(lblEndDate.Text);
            LoadTopCustomers();
            LoadSalesOverview();
            LoadProfitAnalysis();
        }

        private void lblStartDate_Click(object sender, EventArgs e)
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
    }
}
