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
    public partial class expenses : Form
    {
        Suppliers suppliers = new Suppliers();
        public expenses()
        {
            InitializeComponent();
        }

        private void expenses_Load(object sender, EventArgs e)
        {
            if (dgv_expenses.Columns.Count == 0)
            {
                dgv_expenses.Columns.Add("pname", "Item Name");
                dgv_expenses.Columns.Add("sellprice", "SellingPrice");
                dgv_expenses.Columns.Add("buyprice", "BuyingPrice");
                dgv_expenses.Columns.Add("sname", "SupplierName");
            }
            dgv_expenses.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv_expenses.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgv_expenses.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_expenses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LoadExpenseData();
        }
        private void LoadExpenseData()
        {
            // Clear existing rows
            dgv_expenses.Rows.Clear();


            List<Suppliers> expensesList = suppliers.GetExpenses();

            // Add expense data to the DataGridView
            foreach (var expense in expensesList)
            {
                dgv_expenses.Rows.Add(
                    expense.epname,
                    expense.esellprice,
                    expense.ebuyprice,
                    expense.esname);
            }
        }

        private void btn_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = btn_search.Text.Trim();
            List<Suppliers> searchResults = suppliers.GetExpenses(searchText);
            PopulateDataGridView(searchResults);
        }
        private void PopulateDataGridView(List<Suppliers> searchResults)
        {
            // Clear existing rows
            dgv_expenses.Rows.Clear();

            // Add search results to the DataGridView
            foreach (var expense in searchResults)
            {
                dgv_expenses.Rows.Add(
                    expense.epname,
                    expense.esellprice,
                    expense.ebuyprice,
                    expense.esname);
            }
        }
    }
}
