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
    public partial class Access_Control : Form
    {
        empclass emp = new empclass();
        public Access_Control()
        {
            InitializeComponent();
        }

        private void role_combo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Access_Control_Load(object sender, EventArgs e)
        {
            List<string> roleNames = emp.GetAllRolesNames();

            foreach (string roleName in roleNames)
            {
                role_combo.Items.Add(roleName);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string employeeName = txt_ename.Text.Trim();
            string contactInfo = txt_econtact.Text.Trim();
            string selectedRoleName = role_combo.SelectedItem?.ToString(); // Get selected role name, handle null case
            string uname = txt_username.Text.Trim();
            string pass = txt_pass.Text;
            string confirmPass = txt_confirmpass.Text;

            if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(contactInfo) ||
                string.IsNullOrWhiteSpace(selectedRoleName) || string.IsNullOrWhiteSpace(uname) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (pass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            int roleId = emp.GetRoleID(selectedRoleName);

            emp.AddEmployee(employeeName, contactInfo, roleId);
            int eid = emp.GetLastEmployeeID();
            emp.RegisterEmployee(uname, pass, roleId, eid);

            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            txt_ename.Clear();
            txt_econtact.Clear();
            txt_username.Clear();
            txt_pass.Clear();
            txt_confirmpass.Clear();
        }
    }
}
