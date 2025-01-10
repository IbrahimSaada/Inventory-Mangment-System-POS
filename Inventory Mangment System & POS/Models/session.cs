using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardApp.Db;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Mangment_System___POS.Models
{
    public class Session : DbConnection
    {
        public string InputUsername { get; }
        public string InputPassword { get; }
        public string DbUsername { get; private set; }
        public string DbPassword { get; private set; }
        public string UserRole { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public Session(string username, string password)
        {
            InputUsername = username;
            InputPassword = password;
        }
        public Session() { }
        public bool CheckAccount()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT l.Username, l.Password, r.RoleName 
                                     FROM Login l
                                     INNER JOIN Role r ON l.RoleID = r.RoleID
                                     WHERE l.Username = @uname AND l.Password = @psw";
                    command.Parameters.AddWithValue("@uname", InputUsername);
                    command.Parameters.AddWithValue("@psw", InputPassword);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DbUsername = reader["Username"].ToString();
                            DbPassword = reader["Password"].ToString();
                            UserRole = reader["RoleName"].ToString();
                            IsAuthenticated = true;
                        }
                        else
                        {
                            IsAuthenticated = false;
                        }
                    }
                }
            }
            return IsAuthenticated;
        }
    }
}
