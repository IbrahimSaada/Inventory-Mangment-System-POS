using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using DashboardApp.Db;
using static Inventory_Mangment_System___POS.Models.pos;

namespace Inventory_Mangment_System___POS.Models
{
    public class Suppliers : DbConnection
    {
        public int sid { get; set; }
        public string sname { get; set; }
        public string sinfo { get; set; }
        public string address { get; set; }
        public DateTime sdate { get; set; }

        public string epname { get; set; }
        public decimal esellprice { get; set; }
        public decimal ebuyprice { get; set; }
        public string esname { get; set; }


        public List<Suppliers> GetSupplierInfo()
        {
            List<Suppliers> suppliersList = new List<Suppliers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM Supplier";
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Suppliers supplier = new Suppliers();
                        supplier.sid = Convert.ToInt32(reader["SupplierID"]);
                        supplier.sname = reader["SupplierName"].ToString();
                        supplier.sinfo = reader["ContactInformation"].ToString();
                        supplier.address = reader["Address"].ToString();
                        supplier.sdate = Convert.ToDateTime(reader["RegisterDate"]);

                        suppliersList.Add(supplier);
                    }
                }
            }

            return suppliersList;
        }

        public List<Suppliers> GetSupplierInfo(string name)
        {
            List<Suppliers> supplierList = new List<Suppliers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"select SupplierID, SupplierName, ContactInformation, Address,RegisterDate  
                                          from Supplier 
                                          where SupplierName Like @pname";
                    command.Parameters.AddWithValue("@pname", "%" + name + "%");
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Suppliers supplier = new Suppliers();
                        supplier.sid = Convert.ToInt32(reader["SupplierID"]);
                        supplier.sname = reader["SupplierName"].ToString();
                        supplier.sinfo = reader["ContactInformation"].ToString();
                        supplier.address = reader["Address"].ToString();
                        supplier.sdate = Convert.ToDateTime(reader["RegisterDate"]);
                        supplierList.Add(supplier);
                    }
                }
            }
            return supplierList;
        }

        public void UpdateSupplierInfo(int id, string sname, string sinfo, string address, DateTime registerdate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Supplier 
                                            SET SupplierName = @sname, 
                                                ContactInformation = @sinfo, 
                                                Address = @address, 
                                                RegisterDate = @registerdate 
                                            WHERE SupplierID = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@sname", sname);
                    command.Parameters.AddWithValue("@sinfo", sinfo);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@registerdate", registerdate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Supplier information updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update supplier information.");
                    }
                }
            }
        }
        public List<Suppliers> GetExpenses()
        {
            List<Suppliers> expensesList = new List<Suppliers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"SELECT p.ProductName, p.Price, e.BuyingPrice, s.SupplierName
                                    FROM Product p, Expenses e, Supplier s
                                    WHERE p.ProductID = e.ProductID AND s.SupplierID = e.SupplierID";
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Suppliers suppliers = new Suppliers();
                        suppliers.epname = reader["ProductName"].ToString();
                        suppliers.esellprice = Convert.ToInt32(reader["Price"]);
                        suppliers.ebuyprice = Convert.ToInt32(reader["BuyingPrice"]);
                        suppliers.esname = reader["SupplierName"].ToString();

                        expensesList.Add(suppliers);
                    }
                }
            }
            return expensesList;
        }
        public List<Suppliers> GetExpenses(string name)
        {
            List<Suppliers> expensesList = new List<Suppliers>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"SELECT p.ProductName, p.Price, e.BuyingPrice, s.SupplierName
                                    FROM Product p, Expenses e, Supplier s
                                    WHERE p.ProductID = e.ProductID AND s.SupplierID = e.SupplierID and p.ProductName Like @pname ";
                    command.Parameters.AddWithValue("@pname", "%" + name + "%");
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Suppliers suppliers = new Suppliers();
                        suppliers.epname = reader["ProductName"].ToString();
                        suppliers.esellprice = Convert.ToInt32(reader["Price"]);
                        suppliers.ebuyprice = Convert.ToInt32(reader["BuyingPrice"]);
                        suppliers.esname = reader["SupplierName"].ToString();

                        expensesList.Add(suppliers);
                    }
                }
            }
            return expensesList;
        }
        public void SetNewSupplier(string sname, string info, string address, DateTime registerdate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Supplier (SupplierName, ContactInformation, Address, RegisterDate) 
                                    VALUES (@sname, @info, @address, @date)";
                    command.Parameters.AddWithValue("@sname", sname);
                    command.Parameters.AddWithValue("@info", info);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@date", registerdate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New supplier added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add new supplier.");
                    }
                }
            }
        }
    }
}
