using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS
{
    public partial class editcateg : Form
    {
        Models.view_inventory v = new Models.view_inventory();
        public editcateg()
        {
            InitializeComponent();
        }

        private void editcateg_Load(object sender, EventArgs e)
        {
            if (dgveditcategory.Columns.Count == 0)
            {
                dgveditcategory.Columns.Add("ID", "Categ No#");
                dgveditcategory.Columns.Add("Name", "Categ Info");
                dgveditcategory.Columns.Add("Description", "Categ Desc");

                // Add the "Edit" button column
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgveditcategory.Columns.Add(editButtonColumn);
            }
            dgveditcategory.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgveditcategory.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgveditcategory.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgveditcategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PopulateBrandInfo();
        }
        private void PopulateBrandInfo()
        {
            dgveditcategory.Rows.Clear();
            List<string> cateinfoList = v.GetCategoryInfo();

            for (int i = 0; i < cateinfoList.Count; i += 3)
            {
                dgveditcategory.Rows.Add(cateinfoList[i], cateinfoList[i + 1], cateinfoList[i + 2]);
            }
        }

        private void dgveditbrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgveditcategory.Columns.Count - 1)
            {
                int categoryId = Convert.ToInt32(dgveditcategory.Rows[e.RowIndex].Cells["ID"].Value);
                string CategoryName = dgveditcategory.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string Description = dgveditcategory.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                // Perform the update
                v.EditCategory(categoryId, CategoryName, Description);

                // Refresh the DataGridView to reflect the changes
                PopulateBrandInfo();
            }
        }
    }
}
