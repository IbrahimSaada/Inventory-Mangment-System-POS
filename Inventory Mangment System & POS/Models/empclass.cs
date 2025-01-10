using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using DashboardApp.Db;
using System.Windows;

namespace Inventory_Mangment_System___POS.Models
{
    public class empclass : DbConnection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public string RoleId { get; set; }

        public string roleName { get; set; }
        public List<empclass> GetEmployees()
        {
            List<empclass> employeesList = new List<empclass>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" select EmployeeID, EmployeeName, ContactInformation, r.RoleName
                                             from Employee e,Role r
                                             where r.RoleID=e.RoleID ";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empclass employee = new empclass();
                            employee.Id = Convert.ToInt32(reader["EmployeeID"]);
                            employee.Name = reader["EmployeeName"].ToString();
                            employee.ContactInformation = reader["ContactInformation"].ToString();
                            employee.RoleId = reader["RoleName"].ToString();

                            employeesList.Add(employee);
                        }
                    }
                }
            }
            return employeesList;
        }
        public List<empclass> GetEmployees(string name)
        {
            List<empclass> employeesList = new List<empclass>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @" select EmployeeID, EmployeeName, ContactInformation, r.RoleName
                                             from Employee e,Role r
                                             where r.RoleID=e.RoleID and EmployeeName Like @name ";
                    command.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empclass employee = new empclass();
                            employee.Id = Convert.ToInt32(reader["EmployeeID"]);
                            employee.Name = reader["EmployeeName"].ToString();
                            employee.ContactInformation = reader["ContactInformation"].ToString();
                            employee.RoleId = reader["RoleName"].ToString();

                            employeesList.Add(employee);
                        }
                    }
                }
            }
            return employeesList;
        }
        public void SetEmployee(int id, string ename, string info)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Employee 
                                    SET EmployeeName = @ename, 
                                        ContactInformation = @info
                                    WHERE EmployeeID = @eid";
                    command.Parameters.AddWithValue("@eid", id);
                    command.Parameters.AddWithValue("@ename", ename);
                    command.Parameters.AddWithValue("@info", info);
                    command.ExecuteNonQuery();
                }
            }
        }
        public int getRoleID(string rolename)
        {
            int roleID = -1;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select RoleID from Role where RoleName=@rname";
                    command.Parameters.AddWithValue("@rname", rolename);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            roleID = Convert.ToInt32(reader["RoleID"]);
                        }
                    }
                }
            }

            return roleID;
        }
        public List<string> GetAllRolesNames()
        {
            List<string> roleNames = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT RoleName FROM Role";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string roleName = reader["RoleName"].ToString();
                            roleNames.Add(roleName);
                        }
                    }
                }
            }
            return roleNames;
        }
        public int GetRoleID(string roleName)
        {
            int roleId = -1;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT RoleID FROM Role WHERE RoleName = @roleName";
                    command.Parameters.AddWithValue("@roleName", roleName);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            roleId = Convert.ToInt32(reader["RoleID"]);
                        }
                    }
                }
            }

            return roleId;
        }
        public void AddEmployee(string employeename, string contactinfo,int roleid)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Employee (EmployeeName, ContactInformation, RoleID) 
                                    VALUES (@employeename, @contactinfo, @roleid)";
                    command.Parameters.AddWithValue("@employeename", employeename);
                    command.Parameters.AddWithValue("@contactinfo", contactinfo);
                    command.Parameters.AddWithValue("@roleid", roleid);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RegisterEmployee(string username, string password, int RoleID, int eid)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Login (Username, Password, RoleID, EmployeeID) VALUES (@uname, @pass, @roleID, @eid)";
                    command.Parameters.AddWithValue("@uname", username);
                    command.Parameters.AddWithValue("@pass", password);
                    command.Parameters.AddWithValue("@roleID", RoleID);
                    command.Parameters.AddWithValue("@eid", eid);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Registration successful.");
        }
        public int GetLastEmployeeID()
        {
            int lastEmployeeID = -1; 

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 EmployeeID FROM Employee ORDER BY EmployeeID DESC";

                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastEmployeeID = Convert.ToInt32(result);
                    }
                }
            }

            return lastEmployeeID;
        }
    }
}
