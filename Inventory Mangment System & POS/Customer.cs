using Inventory_Mangment_System___POS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS
{
    public partial class Customer : Form
    {
        private customers cus = new customers();

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            if (dgv_customers.Columns.Count == 0)
            {
                dgv_customers.Columns.Add("CustomerID", "Customer ID");
                dgv_customers.Columns.Add("CustomerName", "Name");
                dgv_customers.Columns.Add("CustomerEmail", "Phone");
                dgv_customers.Columns.Add("Address", "Address");
                dgv_customers.Columns.Add("RegisterDate", "Register Date");
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.Name = "edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgv_customers.Columns.Add(editButtonColumn);
            }

            dgv_customers.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv_customers.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgv_customers.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_customers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            List<customers> customersList = cus.GetCustomers();
            PopulateDataGridView(customersList);
        }

        private void PopulateDataGridView(List<customers> customersList)
        {
            dgv_customers.Rows.Clear();

            foreach (customers customer in customersList)
            {
                int rowIndex = dgv_customers.Rows.Add();
                dgv_customers.Rows[rowIndex].Cells["CustomerID"].Value = customer.CustomerID;
                dgv_customers.Rows[rowIndex].Cells["CustomerName"].Value = customer.CustomerName;
                dgv_customers.Rows[rowIndex].Cells["CustomerEmail"].Value = customer.CustomerEmail;
                dgv_customers.Rows[rowIndex].Cells["Address"].Value = customer.Address;
                dgv_customers.Rows[rowIndex].Cells["RegisterDate"].Value = customer.RegisterDate.ToString("yyyy/MM/dd");
            }
        }

        private void btn_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = btn_search.Text.Trim();
            List<customers> searchResults = cus.GetCustomers(searchText);
            PopulateDataGridView(searchResults);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addcustomer addcustomer = new addcustomer();
            addcustomer.ShowDialog();
        }

        private void dgv_customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_customers.Columns["edit"].Index)
            {
                int cId = Convert.ToInt32(dgv_customers.Rows[e.RowIndex].Cells["CustomerID"].Value);
                string cName = dgv_customers.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
                string contactInformation = dgv_customers.Rows[e.RowIndex].Cells["CustomerEmail"].Value.ToString();
                string address = dgv_customers.Rows[e.RowIndex].Cells["Address"].Value.ToString();

                cus.SetCustomer(cId, cName, contactInformation, address);

                LoadCustomers();
            }
        }
    }
}
