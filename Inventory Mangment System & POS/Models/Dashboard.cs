using DashboardApp.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Mangment_System___POS.Models
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Dashboard : DbConnection
    {
        //Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        //Constructor
        public Dashboard()
        {

        }

        //Private methods
        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //Get Total Number of Customers
                    command.CommandText = "select count(CustomerID) from Customer";
                    NumCustomers = (int)command.ExecuteScalar();

                    //Get Total Number of Suppliers
                    command.CommandText = "select count(SupplierID) from Supplier";
                    NumSuppliers = (int)command.ExecuteScalar();

                    //Get Total Number of Products
                    command.CommandText = "select count(ProductID) from Product";
                    NumProducts = (int)command.ExecuteScalar();

                    //Get Total Number of Orders
                    command.CommandText = @"select count(ProductID)" +
                                           "from Bill b,Invoice i " +
                                           "where b.InvoiceID=i.InvoiceID AND  i.Date between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
        }
        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    // Get Top 5 products
                    command.CommandText = @"SELECT TOP 5
                                        p.ProductName,
                                        SUM(b.Quantity) AS Q
                                    FROM
                                        bill b,
                                        Product p,
                                        Invoice i
                                    WHERE
                                        b.ProductID = p.ProductID
                                        AND i.InvoiceID = b.InvoiceID
                                        AND i.Date BETWEEN @fromDate AND @toDate
                                    GROUP BY
                                        p.ProductName
                                    ORDER BY
                                        Q DESC";

                    command.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", SqlDbType.DateTime).Value = endDate;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int quantity = reader.GetInt32(1); // Retrieve quantity directly as an int
                        TopProductsList.Add(new KeyValuePair<string, int>(productName, quantity));
                    }

                    reader.Close();

                    // Get Understock
                    command.CommandText = @"SELECT
                                        ProductName,
                                        Quantity
                                    FROM
                                        Product
                                    WHERE
                                        Quantity <= 10";

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int quantity = reader.GetInt32(1); // Retrieve quantity directly as an int
                        UnderstockList.Add(new KeyValuePair<string, int>(productName, quantity));
                    }

                    reader.Close();
                }
            }
        }
        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevenue = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select i.Date,sum(b.Quantity*b.Amount) as totalAmount " +
                                           "from Bill b, Invoice i " +
                                           "where i.InvoiceID=b.InvoiceID and i.Date between @fromDate and @toDate " +
                                           "group by i.Date";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        TotalRevenue += (decimal)reader[1];
                    }
                    reader.Close();
                    command.CommandText = @"SELECT SUM(b.Amount - (b.Quantity * e.BuyingPrice)) as TotalProfit
                        from Expenses e, Product p, Bill b, Invoice i
                        where p.ProductID = e.ProductID AND p.ProductID = b.ProductID and i.InvoiceID = b.InvoiceID
                        AND i.Date BETWEEN @StartDate AND @EndDate;";
                    command.Parameters.Add("@StartDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@EndDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader1 = command.ExecuteReader();
                    var resultTable1 = new List<KeyValuePair<DateTime, decimal>>(); // Rename resultTable1
                    while (reader1.Read())
                    {
                        if (!reader1.IsDBNull(0))
                        {
                            decimal amount = Convert.ToDecimal(reader1[0]);
                            resultTable1.Add(new KeyValuePair<DateTime, decimal>(DateTime.Now, amount));
                            TotalProfit += amount;
                        }
                    }
                    reader1.Close();

                    //Group by Hours
                    if (numberDays <= 1)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("hh tt")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Days
                    else if (numberDays <= 30)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Weeks
                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Months
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Years
                    else
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }

        //Public methods
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalisys();
                GetOrderAnalisys();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }
    }
}



