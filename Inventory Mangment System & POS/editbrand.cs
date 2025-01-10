using Microsoft.VisualBasic;
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
    public partial class editbrand : Form
    {
        Models.view_inventory viewbrands = new Models.view_inventory();

        public editbrand()
        {
            InitializeComponent();
 
        }

        private void editbrand_Load(object sender, EventArgs e)
        {
            if (dgveditbrand.Columns.Count == 0)
            {
                dgveditbrand.Columns.Add("ID", "Brand No#");
                dgveditbrand.Columns.Add("Name", "Brand Info");
                dgveditbrand.Columns.Add("Description", "Brand Desc");

                // Add the "Edit" button column
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.HeaderText = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dgveditbrand.Columns.Add(editButtonColumn);
            }
            dgveditbrand.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgveditbrand.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgveditbrand.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgveditbrand.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            PopulateBrandInfo();
        }

        private void PopulateBrandInfo()
        {
            dgveditbrand.Rows.Clear();
            List<string> brandInfoList = viewbrands.GetBrandInfo();

            for (int i = 0; i < brandInfoList.Count; i += 3)
            {
                dgveditbrand.Rows.Add(brandInfoList[i], brandInfoList[i + 1], brandInfoList[i + 2]);
            }
        }

        private void dgveditbrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgveditbrand.Columns.Count - 1)
            {  
                int brandId = Convert.ToInt32(dgveditbrand.Rows[e.RowIndex].Cells["ID"].Value);
                string BrandName = dgveditbrand.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string Description = dgveditbrand.Rows[e.RowIndex].Cells["Description"].Value.ToString();
              
                viewbrands.EditBrand(brandId, BrandName, Description);

                PopulateBrandInfo();
            }
        }

    }
}