using DashboardApp.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Inventory_Mangment_System___POS.Models
{
    public class buissnessreport : DbConnection
    {
        public List<KeyValuePair<string, decimal>> TopCustomers { get; private set; }
        public List<KeyValuePair<string, decimal>> Revenue { get; private set; }
        public List<KeyValuePair<string, decimal>> Profit { get; private set; }
        public decimal TotalRevenue { get; private set; }
        public decimal TotalProfit { get; private set; }

        public class SalesRecord
        {
            public string ItemName { get; set; }
            public string InvoiceNO { get; set; }
            public string Date { get; set; }
            public string SoldBy { get; set; }
            public string Type { get; set; }
            public string PurchasedBy { get; set; }
            public int Quantity { get; set; }
            public decimal Amount { get; set; }
        }


        public buissnessreport()
        {
            //consturctor
            //TopCustomers = new List<KeyValuePair<string, decimal>>();
            //ProfitAnalysis = new List<KeyValuePair<string, decimal>>();
        }


        // Method to generate profit analysis data
        public void GenerateProfitAnalysisData()
        {
            // Implement logic to fetch data for profit analysis from the database
            // Fill the ProfitAnalysis list with time intervals (e.g., months) and corresponding profit amounts
        }
        public List<KeyValuePair<string, decimal>> GenerateTopCustomersData(DateTime startDate, DateTime endDate)
        {
            List<KeyValuePair<string, decimal>> topCustomers = new List<KeyValuePair<string, decimal>>();

            // Your connection string
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                SELECT TOP 5 c.CustomerName, SUM(b.Amount) AS TotalAmount
                FROM Customer c
                INNER JOIN Bill b ON c.CustomerID = b.CustomerID
                INNER JOIN Invoice i ON b.InvoiceID = i.InvoiceID
                WHERE CONVERT(date, i.Date) >= CONVERT(date, @StartDate) 
                AND CONVERT(date, i.Date) <= CONVERT(date, @EndDate)
                GROUP BY c.CustomerName
                ORDER BY TotalAmount DESC;";
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string customerName = reader["CustomerName"].ToString();
                            decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            topCustomers.Add(new KeyValuePair<string, decimal>(customerName, totalAmount));
                        }
                    }
                }
            }
            return topCustomers;
        }
        public List<SalesRecord> GenerateSalesOverviewData(DateTime startDate, DateTime endDate)
        {
            List<SalesRecord> salesOverview = new List<SalesRecord>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                                            SELECT 
                                                (SELECT ProductName FROM Product WHERE ProductID = b.ProductID) AS ItemName,
                                                (SELECT InvoiceID FROM Invoice WHERE InvoiceID = b.InvoiceID) AS InvoiceNO,
                                                (SELECT Date FROM Invoice WHERE InvoiceID = b.InvoiceID) AS InvoiceDate,
                                                (SELECT Username FROM Login WHERE EmployeeID = b.EmployeeID) AS SoldBy,
                                                (SELECT RoleName FROM Role WHERE RoleID = b.RoleID) AS Type,
                                                (SELECT CustomerName FROM Customer WHERE CustomerID = b.CustomerID) AS PurchasedBy,
                                                b.Quantity,
                                                b.Amount
                                            FROM Bill b
                                            JOIN Invoice i ON b.InvoiceID = i.InvoiceID
                                            WHERE CONVERT(date, i.Date) >= CONVERT(date, @StartDate) 
                                            AND CONVERT(date, i.Date) <= CONVERT(date, @EndDate)
                                            ORDER BY InvoiceDate DESC;";

                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesRecord salesRecord = new SalesRecord();
                            salesRecord.ItemName = reader["ItemName"].ToString();
                            salesRecord.InvoiceNO = reader["InvoiceNO"].ToString();
                            salesRecord.Date = reader["InvoiceDate"].ToString();
                            salesRecord.SoldBy = reader["SoldBy"].ToString();
                            salesRecord.Type = reader["Type"].ToString();
                            salesRecord.PurchasedBy = reader["PurchasedBy"].ToString();
                            salesRecord.Quantity = (int)reader["Quantity"];
                            salesRecord.Amount = (decimal)reader["Amount"];

                            salesOverview.Add(salesRecord);
                        }
                    }
                }
            }
            return salesOverview;
        }
        public List<KeyValuePair<string, decimal>> GenerateRevenue(DateTime startDate, DateTime endDate)
        {
            List<KeyValuePair<string, decimal>> revenue = new List<KeyValuePair<string, decimal>>();
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                     SELECT p.ProductName, SUM(b.Amount) AS Revenue
                     FROM Product p, Bill b, Invoice i
                     WHERE p.ProductID = b.ProductID AND i.InvoiceID = b.InvoiceID AND CONVERT(date, i.Date) BETWEEN @StartDate AND @EndDate	
                     GROUP BY p.ProductName;";
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productname = reader["ProductName"].ToString();
                            decimal revenueAmount = Convert.ToDecimal(reader["Revenue"]);
                            revenue.Add(new KeyValuePair<string, decimal>(productname, revenueAmount));
                        }
                    }
                }
                return revenue;
            }
        }
        public List<KeyValuePair<string, decimal>> GenerateProfit(DateTime startDate, DateTime endDate)
        {
            List<KeyValuePair<string, decimal>> profit = new List<KeyValuePair<string, decimal>>();
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                    SELECT p.ProductName, SUM(b.Amount - (b.Quantity * e.BuyingPrice)) AS Profit
                    FROM Product p, Bill b, Expenses e, Invoice i
                    Where p.ProductID = b.ProductID AND p.ProductID = e.ProductID AND b.InvoiceID = i.InvoiceID AND CONVERT(date, i.Date) BETWEEN @StartDate AND @EndDate
                    GROUP BY p.ProductName;";
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productname = reader["ProductName"].ToString();
                            decimal profitAmount = Convert.ToDecimal(reader["Profit"]);
                            profit.Add(new KeyValuePair<string, decimal>(productname, profitAmount));
                        }
                    }
                }
                return profit;
            }
        }
        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            decimal totalRevenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT SUM(TotalRevenue) AS TotalRevenue
                                    FROM (
                                        SELECT SUM(b.Amount) AS TotalRevenue
                                        FROM Bill b, Invoice i 
                                        WHERE b.InvoiceID = i.InvoiceID AND CONVERT(date, i.Date) BETWEEN @StartDate AND @EndDate
                                        GROUP BY b.ProductID
                                        ) AS ProductRevenues;";
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    // Execute the command and retrieve the result
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalRevenue = Convert.ToDecimal(result);
                    }
                }
            }
            return totalRevenue;
        }
        public decimal GetTotalProfit(DateTime startDate, DateTime endDate)
        {
            decimal totalProfit = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT SUM(b.Amount - (b.Quantity * e.BuyingPrice)) as TotalProfit
                from Expenses e, Product p, Bill b, Invoice i
                where p.ProductID = e.ProductID AND p.ProductID = b.ProductID and i.InvoiceID = b.InvoiceID
                AND CONVERT(date, i.Date) BETWEEN @StartDate AND @EndDate;";
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    // Execute the command and retrieve the result
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalProfit = Convert.ToDecimal(result);
                    }
                }
            }
            return totalProfit;
        }
    }
}
