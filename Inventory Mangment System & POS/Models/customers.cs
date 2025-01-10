using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using DashboardApp.Db;

namespace Inventory_Mangment_System___POS.Models
{
    public class customers : DbConnection
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<customers> GetCustomers()
        {
            List<customers> CustomersList = new List<customers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM Customer";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers cus = new customers();
                            cus.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            cus.CustomerName = reader["CustomerName"].ToString();
                            cus.CustomerEmail = reader["ContactInformation"].ToString();
                            cus.Address = reader["Address"].ToString();
                            cus.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
                            CustomersList.Add(cus);
                        }
                    }
                }
            }
            return CustomersList;
        }
        public List<customers> GetCustomers(string name)
        {
            List<customers> customersList = new List<customers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT CustomerID, CustomerName, ContactInformation, Address, RegisterDate
                                     FROM Customer
                                     WHERE CustomerName LIKE @name";
                    command.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers customer = new customers();
                            customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                            customer.CustomerName = reader["CustomerName"].ToString();
                            customer.CustomerEmail = reader["ContactInformation"].ToString();
                            customer.Address = reader["Address"].ToString();
                            customer.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);

                            customersList.Add(customer);
                        }
                    }
                }
            }
            return customersList;
        }
        public void SetCustomer(int id, string cname, string info, string address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Customer 
                                    SET CustomerName = @cname, 
                                        ContactInformation = @info,
                                        Address = @address
                                    WHERE CustomerID = @cid";
                    command.Parameters.AddWithValue("@cid", id);
                    command.Parameters.AddWithValue("@cname", cname);
                    command.Parameters.AddWithValue("@info", info);
                    command.Parameters.AddWithValue("@address", address);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer edit successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to to update Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void AddCustomers(string cname, string info, string address, string registerdate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Customer (CustomerName, ContactInformation, Address, RegisterDate) VALUES (@cname, @info, @address, @rdate)";
                    command.Parameters.AddWithValue("@cname", cname);
                    command.Parameters.AddWithValue("@info", info);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@rdate", registerdate);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}