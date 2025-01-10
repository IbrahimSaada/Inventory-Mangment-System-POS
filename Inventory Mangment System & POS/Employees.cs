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
using static Inventory_Mangment_System___POS.Models.pos;

namespace Inventory_Mangment_System___POS
{
    public partial class Employees : Form
    {
        private empclass emp;

        public Employees()
        {
            InitializeComponent();
            emp = new empclass();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            if (dgv_employees.Columns.Count == 0)
            {
                dgv_employees.Columns.Add("EmployeeID", "Employee NO#");
                dgv_employees.Columns.Add("EmployeeName", "Name");
                dgv_employees.Columns.Add("ContactInformation", "Phone");
                dgv_employees.Columns.Add("Role", "Type");
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.Name = "edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgv_employees.Columns.Add(editButtonColumn);
            }

            dgv_employees.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv_employees.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgv_employees.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_employees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            List<empclass> employeesList = emp.GetEmployees();
            PopulateDataGridView(employeesList);
        }

        private void PopulateDataGridView(List<empclass> employees)
        {
            dgv_employees.Rows.Clear();

            foreach (empclass employee in employees)
            {
                int rowIndex = dgv_employees.Rows.Add();
                dgv_employees.Rows[rowIndex].Cells["EmployeeID"].Value = employee.Id;
                dgv_employees.Rows[rowIndex].Cells["EmployeeName"].Value = employee.Name;
                dgv_employees.Rows[rowIndex].Cells["ContactInformation"].Value = employee.ContactInformation;
                dgv_employees.Rows[rowIndex].Cells["Role"].Value = employee.RoleId;
            }
        }

        private void btn_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = btn_search.Text.Trim();
            List<empclass> searchResults = emp.GetEmployees(searchText);
            PopulateDataGridView(searchResults);
        }

        private void dgv_employees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_employees.Columns["edit"].Index)
            {
                int employeeId = Convert.ToInt32(dgv_employees.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                string employeeName = dgv_employees.Rows[e.RowIndex].Cells["EmployeeName"].Value.ToString();
                string contactInformation = dgv_employees.Rows[e.RowIndex].Cells["ContactInformation"].Value.ToString();
                string role = dgv_employees.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                emp.SetEmployee(employeeId, employeeName, contactInformation);

                LoadEmployees();
            }
        }
    }
}
