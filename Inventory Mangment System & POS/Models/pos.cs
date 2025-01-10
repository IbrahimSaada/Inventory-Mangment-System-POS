using DashboardApp.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS.Models
{
    public class pos : DbConnection
    {
        private int invoice;
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public string CategoryName { get; set; }
            public string BrandName { get; set; }
            public int bid { get; set; }
            public string bdesc { get; set; }



        }
        public class Customer
        {
            public int CID { get; set; }
            public string CName { get; set; }
            public string CInfo { get; set; }
            public string CAddress { get; set; }
            public string RegisterDate { get; set; }
        }


        public pos()
        {
            //constructor
        }

        public List<Product> GetProductInfo(int id)
        {
            List<Product> productList = new List<Product>();
            using(var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"select ProductID, ProductName, Price " +
                                          "from Product " + 
                                          "where ProductID= @idvalue";
                    command.Parameters.Add("@idvalue", SqlDbType.Int).Value = id;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = Convert.ToInt32(reader["ProductID"]);
                        product.Name = reader["ProductName"].ToString();
                        product.Price = Convert.ToDecimal(reader["Price"]);
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
        public int GetInvoiceNumber()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 InvoiceID FROM Invoice ORDER BY InvoiceID DESC";
                    object result = command.ExecuteScalar();
                    return result == null ? 1 : ((int)result) + 1;
                }
            }
        }
        public List<Customer> GetCustomerInfo(string name)
        {
            List<Customer> customerList = new List<Customer>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT CustomerID, CustomerName, ContactInformation, Address, RegisterDate " +
                                            "FROM Customer " +
                                            "WHERE CustomerName LIKE @name";
                    command.Parameters.AddWithValue("@name", "%" + name + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CID = Convert.ToInt32(reader["CustomerID"]);
                        customer.CName = reader["CustomerName"].ToString();
                        customer.CInfo = reader["ContactInformation"].ToString();
                        customer.CAddress = reader["Address"].ToString();
                        customer.RegisterDate = reader["RegisterDate"].ToString();
                        customerList.Add(customer);
                    }
                }
            }

            return customerList;
        }
        public void SetInvoice(int CID,DateTime date, string username)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"insert into Invoice (CustomerID,EmployeeID,Date) values (@cid,@eid,@date)";
                    command.Parameters.AddWithValue("@cid",CID);
                    command.Parameters.AddWithValue("@eid",GetEmployeeID(username));
                    command.Parameters.AddWithValue("@date",date);
                    command.ExecuteNonQuery();

                }
            }
        }
        public void Setbill(int PID, int IID, int CID, int Quantity, decimal Amount, string USERNAME)
        {
            empclass emp = new empclass();
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO Bill (ProductID, InvoiceID, EmployeeID, RoleID, CustomerID, Quantity, Amount) 
                           VALUES (@pid, @iid, @eid, @rid, @cid, @qty, @amount)";
                        command.Parameters.AddWithValue("@pid", PID);
                        command.Parameters.AddWithValue("@iid", IID);
                        command.Parameters.AddWithValue("@eid", GetEmployeeID(USERNAME));
                        command.Parameters.AddWithValue("@rid", GetRoleID(USERNAME));
                        command.Parameters.AddWithValue("@cid", CID);
                        command.Parameters.AddWithValue("@qty", Quantity);
                        command.Parameters.AddWithValue("@amount", Amount);

                        // Execute the command to insert the record
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            command.CommandText = @"UPDATE Product 
                                                   SET Quantity = Quantity - @qty 
                                                   WHERE ProductID = @pid";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@qty", Quantity);
                            command.Parameters.AddWithValue("@pid", PID);
                            command.ExecuteNonQuery();
                            Console.WriteLine("inserted!!!!!");
                            // You can display a message box or any other appropriate action here
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                foreach (SqlError error in ex.Errors)
                {
                    Console.WriteLine("Error Number: {0}", error.Number);
                    Console.WriteLine("Error Message: {0}", error.Message);
                }

                // You can also handle specific error numbers
                if (ex.Number == 547) // Foreign key violation
                {
                    // Handle foreign key violation
                    Console.WriteLine("Foreign key violation occurred.");
                }
                else
                {
                    // Handle other types of SQL exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private int GetEmployeeID(string username)
        {
            int employeeID = -1; // Default value if not found
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT e.EmployeeID
                                    FROM Employee e
                                    INNER JOIN Login l ON e.EmployeeID = l.EmployeeID
                                    WHERE l.Username = @uname";
                    command.Parameters.AddWithValue("@uname", username);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        employeeID = Convert.ToInt32(result);
                    }
                }
            }
            return employeeID;
        }
        private int GetRoleID(string username)
        {
            int roleID = -1;
            using (var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select RoleID from Login where Username = @uname";
                    command.Parameters.AddWithValue("uname", username);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        roleID = Convert.ToInt32(result);
                    }
                }
            }
            return roleID;
        }
    }

}
