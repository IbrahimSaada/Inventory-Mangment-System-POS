using Inventory_Mangment_System___POS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using static Inventory_Mangment_System___POS.Models.pos;
using PdfSharp.Fonts;
using ReaLTaiizor.Extension;

namespace Inventory_Mangment_System___POS
{
    public partial class pos : Form
    {
        private Session session;
        Models.pos t = new Models.pos();
        string formattedDate;
        private Timer timer;
        public pos(Session session)
        {
            InitializeComponent();
            DateTime currentDate = DateTime.Today;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            label3.Text = formattedDate;

            lbl_invoice.Text = t.GetInvoiceNumber().ToString();
            this.KeyPreview = true; // Set KeyPreview to true to capture key events at the form level
            this.KeyDown += pos_KeyDown; // Attach the KeyDown event handle
            this.session = session;
            lbl_name.Text = session.DbUsername;

            // Initialize the Timer
            timer = new Timer();
            timer.Interval = 1000; // Set the interval to 1 second (1000 milliseconds)
            timer.Tick += new EventHandler(UpdateTimeLabel); // Attach the event handler
            timer.Start(); // Start the timer
        }
        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Fetch product information based on the barcode entered
            List<Product> productList = t.GetProductInfo(Convert.ToInt32(txt_barcode.Text));

            // Only proceed if productList has items
            if (productList.Count > 0)
            {
                // Assuming the product list contains only one product for simplicity
                Product product = productList[0];

                // Validate quantity
                int qty;
                if (!int.TryParse(txt_qty.Text, out qty) || qty <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                // Validate discount
                decimal disc;
                if (!decimal.TryParse(txt_disc.Text.Trim('%'), out disc) || disc < 0 || disc > 100)
                {
                    MessageBox.Show("Please enter a valid discount percentage.");
                    return;
                }

                // Check if the product already exists in the DataGridView
                bool productExists = false;
                foreach (DataGridViewRow row in dgvbill.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ID"].Value) == product.ID)
                    {
                        // Update quantity and total if the product already exists
                        int newQty = Convert.ToInt32(row.Cells["Qty"].Value) + qty;
                        row.Cells["Qty"].Value = newQty;

                        // Calculate total
                        decimal totalPrice = Convert.ToDecimal(row.Cells["Price"].Value) * newQty;
                        if (disc > 0) // Apply discount if present
                        {
                            decimal discountAmount = totalPrice * (disc / 100);
                            totalPrice -= discountAmount;
                        }
                        row.Cells["tot"].Value = totalPrice;

                        productExists = true;
                        break;
                    }
                }

                if (!productExists)
                {
                    // If the product doesn't exist, add a new row
                    AddNewRow(product, qty, disc);
                }
            }
            else
            {
                MessageBox.Show("Product not found.");
            }
            CalculateTotalPrice();
            ComputeTotals();
        }

        private void AddNewRow(Product product, int qty, decimal disc)
        {
            // Calculate total
            decimal totalPrice = product.Price * qty;
            if (disc > 0) // Apply discount if present
            {
                decimal discountAmount = totalPrice * (disc / 100);
                totalPrice -= discountAmount;
            }

            // Add to DataGridView
            object[] row = new object[] { product.ID, product.Name, product.Price, qty, disc, totalPrice };
            dgvbill.Rows.Add(row);
        }

        private void pos_Load(object sender, EventArgs e)
        {
            if (dgvbill.Columns.Count == 0)
            {
                dgvbill.Columns.Add("ID", "Barcode");
                dgvbill.Columns.Add("Name", "Description");
                dgvbill.Columns.Add("Price", "Unit Price");
                dgvbill.Columns.Add("Qty", "Quantity");
                dgvbill.Columns.Add("Disc", "% Discount");
                dgvbill.Columns.Add("tot", "Total");

            }
            foreach (DataGridViewColumn column in dgvbill.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvbill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvbill.SelectionChanged += dgvbill_SelectionChanged;
            dgvbill.AllowUserToAddRows = false;
            dgvbill.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
        }

        private void dgvbill_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvbill.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvbill.SelectedRows[0];

                // Extract values from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string name = Convert.ToString(selectedRow.Cells["Name"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                int qty = Convert.ToInt32(selectedRow.Cells["Qty"].Value);
                decimal disc = Convert.ToDecimal(selectedRow.Cells["Disc"].Value);
                decimal total = Convert.ToDecimal(selectedRow.Cells["tot"].Value);

                // Populate the textboxes with the values
                txt_barcode.Text = id.ToString();
                txt_description.Text = name;
                txt_price.Text = price.ToString();
                txt_qty.Text = qty.ToString();
                txt_disc.Text = disc.ToString();
                txt_total.Text = total.ToString();
            }
        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Call the logic to fetch product information and display it in textboxes
                FetchAndDisplayProductInfo();

                // Prevent the Enter key from being processed further (suppress beep)
                e.Handled = true;
            }
        }
        private void FetchAndDisplayProductInfo()
        {
            // Fetch product information based on the barcode entered
            List<Product> productList = t.GetProductInfo(Convert.ToInt32(txt_barcode.Text));

            // Display product information in textboxes
            foreach (Product product in productList)
            {
                txt_barcode.Text = $"{product.ID}";
                txt_description.Text = $"{product.Name}";
                txt_price.Text = $"{product.Price}";
                txt_qty.Text = "1";
                txt_disc.Text = $"%{0}";
                decimal txtprice = Convert.ToDecimal(txt_price.Text);
                int txtqty = Convert.ToInt32(txt_qty.Text);
                decimal txttotal = txtprice * txtqty;
                txt_total.Text = txttotal.ToString();
            }
        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dgvbill.SelectedRows.Count > 0)
            {
                // Remove the selected row from the DataGridView
                dgvbill.Rows.Remove(dgvbill.SelectedRows[0]);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvbill.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvbill.SelectedRows[0];

                // Update the selected row with the new values from textboxes
                selectedRow.Cells["Name"].Value = txt_description.Text;
                selectedRow.Cells["Price"].Value = txt_price.Text;
                selectedRow.Cells["Qty"].Value = txt_qty.Text;
                selectedRow.Cells["Disc"].Value = txt_disc.Text;

                // Recalculate the total for the updated row
                RecalculateTotal(selectedRow);
            }
        }

        private void RecalculateTotal(DataGridViewRow row)
        {
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int qty = Convert.ToInt32(row.Cells["Qty"].Value);
            decimal disc = Convert.ToDecimal(row.Cells["Disc"].Value);

            decimal total = price * qty;

            // Apply discount if present
            if (disc > 0 && disc <= 50)
            {
                decimal discountAmount = total * disc / 100;
                total -= discountAmount;
            }

            row.Cells["tot"].Value = total;
        }
        private void pos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Add item
                btn_add.PerformClick(); // Assuming button1 is your "Add" button
            }
            else if (e.KeyCode == Keys.F2)
            {
                // Delete item
                button5.PerformClick(); // Assuming btn_remove is your "Delete" button
            }
            else if (e.KeyCode == Keys.F3)
            {
                // Update item
                button6.PerformClick(); // Assuming btn_edit is your "Update" button
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvbill.SelectedRows.Count > 0)
            {
                // Remove the selected row from the DataGridView
                dgvbill.Rows.Remove(dgvbill.SelectedRows[0]);
                CalculateTotalPrice();
                ComputeTotals();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvbill.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvbill.SelectedRows[0];

                // Update the selected row with the new values from textboxes
                selectedRow.Cells["Name"].Value = txt_description.Text;
                selectedRow.Cells["Price"].Value = txt_price.Text;
                selectedRow.Cells["Qty"].Value = txt_qty.Text;
                selectedRow.Cells["Disc"].Value = txt_disc.Text;

                // Recalculate the total for the updated row
                RecalculateTotal(selectedRow);
                CalculateTotalPrice();
                ComputeTotals();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = printDocument1; // Set the document to be previewed
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float margin = 60;
            Font f = new Font("Arial", 18, FontStyle.Bold);
            string invoiceNumber = t.GetInvoiceNumber().ToString();
            string strNO = "INVOICE NO " + invoiceNumber;
            string invoicedate = formattedDate;
            DateTime currentDate = DateTime.Today;
            invoicedate = currentDate.ToString("MM/dd/yyyy");
            string strtdate = "Date: " + invoicedate;

            SizeF fontSizeNO = e.Graphics.MeasureString(strNO, f);
            SizeF fontSizeDate = e.Graphics.MeasureString(strtdate, f);
            e.Graphics.DrawImage(Properties.Resources.input_onlinepngtools, margin - 60, margin - 70, 250, 200);
            e.Graphics.DrawString(strNO, f, Brushes.Red, (e.PageBounds.Width - fontSizeNO.Width) / 2, margin + 95);
            e.Graphics.DrawString(strtdate, f, Brushes.Black, e.PageBounds.Width - fontSizeDate.Width - margin, margin + 95);

            float preHeights = margin + fontSizeNO.Height + fontSizeDate.Height + 95;
            e.Graphics.DrawRectangle(Pens.Black, margin, preHeights, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin * 1 - preHeights);

            float colHeight = 50;
            float col1Width = 670;
            float col2Wdidth = 125 + col1Width;
            float col3Width = 125 + col2Wdidth;
            float col4Width = 125 + col3Width;
            float col5Width = 125 + col4Width;

            e.Graphics.DrawLine(Pens.Black, margin, preHeights + colHeight, e.PageBounds.Width - margin, preHeights + colHeight);
            e.Graphics.DrawString("Item Description", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 620, preHeights + 10);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - col1Width + 165, preHeights, e.PageBounds.Width - col1Width + 165, e.PageBounds.Height - margin);
            e.Graphics.DrawString("Unit Price", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 380, preHeights + 10);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - col1Width + 295, preHeights, e.PageBounds.Width - col1Width + 295, e.PageBounds.Height - margin);
            e.Graphics.DrawString("Qty", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 250, preHeights + 10);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - col1Width + 350, preHeights, e.PageBounds.Width - col1Width + 350, e.PageBounds.Height - margin);
            e.Graphics.DrawString("%Discount", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 190, preHeights + 10);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - col1Width + 500, preHeights, e.PageBounds.Width - col1Width + 500, e.PageBounds.Height - margin);
            e.Graphics.DrawString("Total", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 30, preHeights + 10);

            //////////////INVOICE CONTENTS////////////////////////////

            float rowsHeight = 40;
            for (int i = 0; i < dgvbill.Rows.Count; i++)
            {
                if (dgvbill.Rows[i].Cells[0].Value != null)
                {
                    e.Graphics.DrawString(dgvbill.Rows[i].Cells[1].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 620, preHeights + 10 + rowsHeight);
                    e.Graphics.DrawString(dgvbill.Rows[i].Cells[2].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 380, preHeights + 10 + rowsHeight);
                    e.Graphics.DrawString(dgvbill.Rows[i].Cells[3].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 240, preHeights + 10 + rowsHeight);
                    e.Graphics.DrawString(dgvbill.Rows[i].Cells[4].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 130, preHeights + 10 + rowsHeight);
                    e.Graphics.DrawString(dgvbill.Rows[i].Cells[5].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 40, preHeights + 10 + rowsHeight);

                    e.Graphics.DrawLine(Pens.Black, margin, preHeights + rowsHeight + 40, e.PageBounds.Width - margin, preHeights + rowsHeight + 40);
                }
                rowsHeight += 40;
            }
            e.Graphics.DrawString("Total Price", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 190, preHeights + 10 + rowsHeight);//-50 removed
            e.Graphics.DrawString(lbl_balance.Text, f, Brushes.Black, e.PageBounds.Width - margin * 2 - 40, preHeights + 10 + rowsHeight);//-50 removed


        }
        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dgvbill.Rows)
            {
                // Check if the cell value is not null and convert it to decimal
                if (row.Cells["tot"].Value != null)
                {
                    totalPrice += Convert.ToDecimal(row.Cells["tot"].Value);
                }
            }

            // Display the total price
            lbl_balance.Text = totalPrice.ToString();
        }
        private void ComputeTotals()
        {
            decimal totalOriginalPrice = 0;
            decimal totalDiscountedPrice = 0;
            int totalQuantity = 0;
            decimal totalDiscountAmount = 0;

            foreach (DataGridViewRow row in dgvbill.Rows)
            {
                if (row.Cells["Price"].Value != null && row.Cells["Qty"].Value != null && row.Cells["Disc"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal disc = Convert.ToDecimal(row.Cells["Disc"].Value);

                    // Calculate original price
                    decimal originalPrice = price * qty;
                    totalOriginalPrice += originalPrice;

                    // Calculate discounted price
                    decimal discountedPrice = originalPrice * (1 - (disc / 100));
                    totalDiscountedPrice += discountedPrice;

                    // Calculate total quantity
                    totalQuantity += qty;

                    // Calculate total discount amount
                    decimal discountAmount = originalPrice - discountedPrice;
                    totalDiscountAmount += discountAmount;
                }
            }

            // Update labels with calculated values
            lbl_original.Text = totalOriginalPrice.ToString();
            lbl_discounted.Text = totalDiscountedPrice.ToString();
            if (totalOriginalPrice != 0)
            {
                lbl_discRate.Text = (totalDiscountAmount / totalOriginalPrice * 100).ToString("0.###");
            }
            else
            {
                lbl_discRate.Text = "0"; // or any default value you want to display when totalOriginalPrice is zero
            }
            lbl_totqty.Text = totalQuantity.ToString();
        }
        private void lbl_balance_Click(object sender, EventArgs e)
        {

        }

        private void txt_customerName_TextChanged(object sender, EventArgs e)
        {
            string enteredName = txt_customerName.Text;

            // Call the GetCustomerInfo method to fetch customers based on the entered name
            List<Models.pos.Customer> customers = t.GetCustomerInfo(enteredName);

            // Clear the existing items in the ComboBox
            cmb_customer.Items.Clear();

            // Add the names of the fetched customers to the ComboBox
            foreach (Models.pos.Customer customer in customers)
            {
                cmb_customer.Items.Add(customer.CName);
            }

            // Show the ComboBox if there are any items, otherwise hide it
            cmb_customer.Visible = cmb_customer.Items.Count > 0;


        }

        private void cmb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_customer.SelectedItem != null)
            {
                txt_customerName.Text = cmb_customer.SelectedItem.ToString();
                List<Models.pos.Customer> customers = t.GetCustomerInfo(txt_customerName.Text);
                foreach (Models.pos.Customer customer in customers)
                {
                    txt_contactinfo.Text = customer.CInfo;
                    txt_address.Text = customer.CAddress;
                }


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cmb_customer.SelectedItem != null)
            {
                DateTime date = DateTime.Now;
                List<Models.pos.Customer> customers = t.GetCustomerInfo(txt_customerName.Text);
                if (customers.Count > 0) // Ensure customers exist
                {
                    int customerId = customers[0].CID; // Access the first customer in the list
                    int invoiceId;
                    string USERNAME = lbl_name.Text;
                    if (int.TryParse(lbl_invoice.Text, out invoiceId))
                    {
                        // Set the invoice first
                        t.SetInvoice(customerId, date, USERNAME);

                        // Now insert the bill
                        foreach (DataGridViewRow row in dgvbill.Rows)
                        {
                            int productId = Convert.ToInt32(row.Cells["ID"].Value);
                            int quantity = Convert.ToInt32(row.Cells["Qty"].Value);
                            decimal amount = Convert.ToDecimal(row.Cells["tot"].Value);
                            string username = lbl_name.Text;

                            // Now you can pass invoiceId to the Setbill method
                            t.Setbill(productId, invoiceId, customerId, quantity, amount, username);
                        }
                        MessageBox.Show("Bill has been Settled");
                        ResetForm();
                    }
                    else
                    {
                        // Handle the case where lbl_invoice.Text is not a valid integer
                        MessageBox.Show("Invalid invoice ID");
                    }
                }
                else
                {
                    // Handle case where no customer is found
                    MessageBox.Show("Customer not found.");
                }
            }
            else
            {
                // Handle case where no customer is selected
                MessageBox.Show("Please select a customer.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.Document = printDocument1; // Set the document to be previewed
            printPreviewDialog1.ShowDialog();
        }
        private void ResetForm()
        {
            // Clear DataGridView
            dgvbill.Rows.Clear();

            // Clear textboxes
            txt_barcode.Clear();
            txt_description.Clear();
            txt_price.Clear();
            txt_qty.Clear();
            txt_disc.Clear();
            txt_total.Clear();
            txt_customerName.Clear();
            txt_contactinfo.Clear();
            txt_address.Clear();

            // Reset labels
            lbl_balance.Text = "0";
            lbl_original.Text = "0";
            lbl_discounted.Text = "0";
            lbl_discRate.Text = "0";
            lbl_totqty.Text = "0";

            // Reset invoice number
            lbl_invoice.Text = t.GetInvoiceNumber().ToString();

            // Reset comboBox
            cmb_customer.SelectedIndex = -1;
            cmb_customer.SelectedItem = null;
            // Optionally, set focus to the first input control
            txt_barcode.Focus();
        }
    }
}