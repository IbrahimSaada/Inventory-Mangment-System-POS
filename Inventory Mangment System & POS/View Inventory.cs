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
    public partial class View_Inventory : Form
    {
        Models.view_inventory inventory;
        Dictionary<int, string> oldCategoryNames = new Dictionary<int, string>();

        public View_Inventory()
        {
            InitializeComponent();
        }

        private void View_Inventory_Load(object sender, EventArgs e)
        {
            inventory = new Models.view_inventory();

            if (dgv_products.Columns.Count == 0)
            {
                dgv_products.Columns.Add("ProductID", "Barcode");
                dgv_products.Columns.Add("ProductName", "Item Name");
                dgv_products.Columns.Add("Quantity", "Qty");
                dgv_products.Columns.Add("Price", "Unit Price");
                dgv_products.Columns.Add("Description", "Item Description");
                dgv_products.Columns.Add("CategoryID", "Category Name");
                dgv_products.Columns.Add("BrandID", "Brand Name");

                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.Name = "edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgv_products.Columns.Add(editButtonColumn);
            }

            dgv_products.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv_products.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgv_products.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_products.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = inventory.GetProductInfo();
            PopulateDataGridView(products);
            foreach (Product product in products)
            {
                oldCategoryNames[product.ID] = product.CategoryName;
            }
        }

        private void PopulateDataGridView(List<Product> products)
        {
            dgv_products.Rows.Clear();

            foreach (Product product in products)
            {
                int rowIndex = dgv_products.Rows.Add();
                dgv_products.Rows[rowIndex].Cells["ProductID"].Value = product.ID;
                dgv_products.Rows[rowIndex].Cells["ProductName"].Value = product.Name;
                dgv_products.Rows[rowIndex].Cells["Quantity"].Value = product.Quantity;
                dgv_products.Rows[rowIndex].Cells["Price"].Value = product.Price;
                dgv_products.Rows[rowIndex].Cells["Description"].Value = product.Description;
                dgv_products.Rows[rowIndex].Cells["CategoryID"].Value = product.CategoryName;
                dgv_products.Rows[rowIndex].Cells["BrandID"].Value = product.BrandName;
            }
        }
        private void btn_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = btn_search.Text.Trim();
            List<Product> searchResults = inventory.GetProductInfo(searchText);
            PopulateDataGridView(searchResults);
        }

        private void dgv_products_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_products.Columns["edit"].Index)
            {
                int productId = Convert.ToInt32(dgv_products.Rows[e.RowIndex].Cells["ProductID"].Value);
                string oldCategoryName = oldCategoryNames[productId]; // Retrieve old category name

                // Retrieve other product information
                string productName = dgv_products.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                int quantity = Convert.ToInt32(dgv_products.Rows[e.RowIndex].Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(dgv_products.Rows[e.RowIndex].Cells["Price"].Value);
                string description = dgv_products.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                string categoryName = dgv_products.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                string brandName = dgv_products.Rows[e.RowIndex].Cells["BrandID"].Value.ToString();

                // Perform the update
                inventory.UpdateProductInfo(productId, productName, quantity, price, description, oldCategoryName, categoryName, brandName);

                // Reload the products in the DataGridView
                LoadProducts();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addbrand frm = new addbrand();
            frm.ShowDialog();
        }
    }
}