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
using static Inventory_Mangment_System___POS.Models.view_inventory;

namespace Inventory_Mangment_System___POS
{
    public partial class Addproduct : Form
    {
        Models.view_inventory inv = new Models.view_inventory();
        Models.view_inventory.Supplier Supplier = new Models.view_inventory.Supplier();

        public Addproduct()
        {
            InitializeComponent();
        }

        private void Addproduct_Load(object sender, EventArgs e)
        {
            List<string> categoryInfo = inv.GetCategoryNames();
            List<string> brandinfo = inv.GetBrandName();
            List<string> SupplierNames = inv.GetSuppliersNames();

            foreach (var category in categoryInfo)
            {
                pcategory_combo.Items.Add(category);
            }
            foreach (var brand in brandinfo)
            {
                pbrand_combo.Items.Add(brand);
            }
            foreach (var supplier in SupplierNames)
            {
                supp_como.Items.Add(supplier);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_pname.Text) &&
                !string.IsNullOrEmpty(txt_pdesc.Text) &&
                !string.IsNullOrEmpty(txt_sellingprice.Text) &&
                !string.IsNullOrEmpty(txt_qnty.Text) &&
                pcategory_combo.SelectedIndex != -1 &&
                pbrand_combo.SelectedIndex != -1 &&
                supp_como.SelectedIndex!=-1)
            {
                string product = txt_pname.Text;
                string description = txt_pdesc.Text;
                decimal price = Convert.ToDecimal(txt_sellingprice.Text);
                decimal buyprice = Convert.ToDecimal(txt_buyingprice.Text);
                int qty = Convert.ToInt32(txt_qnty.Text);
                string categname = pcategory_combo.SelectedItem.ToString();
                string bname = pbrand_combo.SelectedItem.ToString();
                int categoryId = inv.getCategoryID(categname);
                int brandid = inv.getBrandID(bname);
                inv.AddProduct(product, description, price, qty, categoryId, brandid);
                inv.addExpenses(inv.getPid(), inv.GetSupplierID(supp_como.SelectedItem.ToString()), buyprice);
                clear();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supp_como_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (supp_como.SelectedIndex != -1)
            {
                string selectedSupplierName = supp_como.SelectedItem.ToString();
                Supplier = inv.GetSupplierInfo(selectedSupplierName);

                if (Supplier != null)
                {
                    txt_contact.Text = Supplier.ContactInformation;
                    txt_address.Text = Supplier.Address;
                }
                else
                {
                    MessageBox.Show("Supplier information not found.");
                }
            }
        }

        private void pcategory_combo_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            txt_address.Clear();
            txt_contact.Clear();
            txt_buyingprice.Clear();
            txt_pname.Clear();
            txt_pdesc.Clear();
            txt_qnty.Clear();
            txt_sellingprice.Clear();


        }
    }
}
