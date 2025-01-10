using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory_Mangment_System___POS.Models;
using static Inventory_Mangment_System___POS.Models.pos;

namespace Inventory_Mangment_System___POS
{
    public partial class View_Suppliers : Form
    {
        private Suppliers suppliers;

        public View_Suppliers()
        {
            InitializeComponent();
            suppliers = new Suppliers();
        }

        private void View_Suppliers_Load(object sender, EventArgs e)
        {
            if (dgv_suppliers.Columns.Count == 0)
            {
                dgv_suppliers.Columns.Add("SupplierID", "Supplier NO#");
                dgv_suppliers.Columns.Add("SupplierName", "Provider Name");  
                dgv_suppliers.Columns.Add("ContactInformation", "Phone");
                dgv_suppliers.Columns.Add("Address", "Location");
                dgv_suppliers.Columns.Add("RegisterDate", "Started Date");
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.Name = "edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgv_suppliers.Columns.Add(editButtonColumn);
            }

            dgv_suppliers.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv_suppliers.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgv_suppliers.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_suppliers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LoadSupplierData();
        }

        private void LoadSupplierData()
        {
            dgv_suppliers.Rows.Clear();

            List<Suppliers> supplierList = suppliers.GetSupplierInfo();

            foreach (var supplier in supplierList)
            {
                dgv_suppliers.Rows.Add(
                    supplier.sid,
                    supplier.sname,
                    supplier.sinfo,
                    supplier.address,
                    supplier.sdate.ToString("yyyy-MM-dd"));
            }
        }

        private void btn_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = btn_search.Text.Trim();
            List<Suppliers> searchResults = suppliers.GetSupplierInfo(searchText);
            PopulateDataGridView(searchResults);
        }
        private void PopulateDataGridView(List<Suppliers> searchResults)
        {
            dgv_suppliers.Rows.Clear();

            foreach (var supplier in searchResults)
            {
                dgv_suppliers.Rows.Add(
                    supplier.sid,
                    supplier.sname,
                    supplier.sinfo,
                    supplier.address,
                    supplier.sdate.ToString("yyyy-MM-dd"));
            }
        }

        private void dgv_suppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_suppliers.Columns["edit"].Index)
            {
                int supplierId = Convert.ToInt32(dgv_suppliers.Rows[e.RowIndex].Cells["SupplierID"].Value);
                string supplierName = dgv_suppliers.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();
                string contactInformation = dgv_suppliers.Rows[e.RowIndex].Cells["ContactInformation"].Value.ToString();
                string address = dgv_suppliers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                DateTime registerDate = Convert.ToDateTime(dgv_suppliers.Rows[e.RowIndex].Cells["RegisterDate"].Value);

                suppliers.UpdateSupplierInfo(supplierId, supplierName, contactInformation, address, registerDate);

                LoadSupplierData();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newsupplier frm = new newsupplier();
            frm.ShowDialog();

        }
    }
}
