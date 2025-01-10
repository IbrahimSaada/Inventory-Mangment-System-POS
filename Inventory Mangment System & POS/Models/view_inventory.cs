using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static Inventory_Mangment_System___POS.Models.pos;
using Microsoft.VisualBasic;
using PdfSharp.Pdf.Content.Objects;
using iText.Layout.Properties;
using System.Dynamic;

namespace Inventory_Mangment_System___POS.Models
{
    public class view_inventory : DbConnection
    {

        public view_inventory()
        {
        }
        public class Supplier
        {
            public string SupplierName { get; set; }
            public string ContactInformation { get; set; }
            public string Address { get; set; }
        }
        public List<Product> GetProductInfo()
        {
            List<Product> productList = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"select p.ProductID, p.ProductName, p.Description, p.Price, p.Quantity, c.CategoryName,b.BrandName  " +
                                          "from Product p,Brand b,Category c " +
                                          "where  c.CategoryID=p.CategoryID and b.BrandID=p.BrandID ";
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = Convert.ToInt32(reader["ProductID"]);
                        product.Name = reader["ProductName"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = Convert.ToDecimal(reader["Price"]);
                        product.Quantity = Convert.ToInt32(reader["Quantity"]);
                        product.CategoryName = reader["CategoryName"].ToString();
                        product.BrandName = reader["BrandName"].ToString();
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
        public List<Product> GetProductInfo(string name)
        {
            List<Product> productList = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;

                    command.Connection = connection;
                    command.CommandText = @"select p.ProductID, p.ProductName, p.Description, p.Price, p.Quantity, c.CategoryName,b.BrandName  " +
                                          "from Product p,Brand b,Category c " +
                                          "where  c.CategoryID=p.CategoryID and b.BrandID=p.BrandID and p.ProductName Like @pname";
                    command.Parameters.AddWithValue("@pname", "%" + name + "%");
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = Convert.ToInt32(reader["ProductID"]);
                        product.Name = reader["ProductName"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = Convert.ToDecimal(reader["Price"]);
                        product.Quantity = Convert.ToInt32(reader["Quantity"]);
                        product.CategoryName = reader["CategoryName"].ToString();
                        product.BrandName = reader["BrandName"].ToString();
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
        public List<Product> UpdateProductInfo(int productId, string productName, int quantity, decimal price, string description, string oldCategoryName, string categoryName, string brandName)
        {
            List<Product> productList = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Product
                                    SET ProductName = @ProductName,
                                        Quantity = @Quantity,
                                        Price = @Price,
                                        Description = @Description
                                    WHERE ProductID = @ProductID;";
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Description", description);
                    UpdateCategory(oldCategoryName, categoryName);

                    // Execute the SQL command to update the product information
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // If the update was successful, reload the updated product list
                        productList = GetProductInfo();
                    }
                }
            }
            return productList;
        }
        public void UpdateCategory(string oldCategoryName, string newCategoryName)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Category
                                    SET CategoryName = @NewCategoryName
                                    WHERE CategoryName = @OldCategoryName";
                    command.Parameters.AddWithValue("@NewCategoryName", newCategoryName);
                    command.Parameters.AddWithValue("@OldCategoryName", oldCategoryName);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category not found.");
                    }
                }
            }
        }
        public List<string> GetCategoryNames()
        {
            List<string> categoryNames = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CategoryName FROM Category";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryNames.Add(reader["CategoryName"].ToString());
                        }
                    }
                }
            }
            return categoryNames;
        }
        public List<string> GetBrandInfo()
        {
            List<string> brandinfo = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * from Brand";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brandinfo.Add(reader["BrandID"].ToString());
                            brandinfo.Add(reader["BrandName"].ToString());
                            brandinfo.Add(reader["Description"].ToString());
                        }
                    }
                }
            }
            return brandinfo;
        }
        public List<string> GetBrandName()
        {
            List<string> brandname = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT BrandName from Brand";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brandname.Add(reader["BrandName"].ToString());
                        }
                    }
                }
            }
            return brandname;
        }
        public List<string> GetCategoryInfo()
        {
            List<string> cateinfo = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * from Category";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cateinfo.Add(reader["CategoryID"].ToString());
                            cateinfo.Add(reader["CategoryName"].ToString());
                            cateinfo.Add(reader["Description"].ToString());
                        }
                    }
                }
            }
            return cateinfo;
        }
        public int getCategoryID(string cname)
        {
            int categoryId = -1; // Default value if category ID is not found
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT CategoryID FROM Category
                                    WHERE CategoryName = @cname";
                    command.Parameters.AddWithValue("@cname", cname);
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        categoryId = Convert.ToInt32(result);
                    }
                }
            }
            return categoryId;
        }
        public int getBrandID(string cname)
        {
            int brandid = -1; // Default value if category ID is not found
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT BrandID FROM Brand
                                    WHERE BrandName = @bname";
                    command.Parameters.AddWithValue("@bname", cname);
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        brandid = Convert.ToInt32(result);
                    }
                }
            }
            return brandid;
        }
        public void AddBrand(string bname, string bdesc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Brand (BrandName, Description) values (@bname,@bdesc)";
                    command.Parameters.AddWithValue("@bname", bname);
                    command.Parameters.AddWithValue("@bdesc", bdesc);
                    command.ExecuteNonQuery();

                }
            }
        }
        public void AddCateg(string cname, string cdesc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Category (CategoryName, Description) values (@cname,@cdesc)";
                    command.Parameters.AddWithValue("@cname", cname);
                    command.Parameters.AddWithValue("@cdesc", cdesc);
                    command.ExecuteNonQuery();

                }
            }
        }
        public void EditBrand(int brandId, string newBrandName, string newDescription)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Brand
                                    SET BrandName = @NewBrandName,
                                        Description = @NewDescription
                                    WHERE BrandID = @BrandID;";
                    command.Parameters.AddWithValue("@BrandID", brandId);
                    command.Parameters.AddWithValue("@NewBrandName", newBrandName);
                    command.Parameters.AddWithValue("@NewDescription", newDescription);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Brand updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Brand not found.");
                    }
                }
            }
        }
        public void EditCategory(int categoryId, string newCategoryName, string newDescription)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Category SET CategoryName = @NewCategoryName, Description = @NewDescription WHERE CategoryID = @CategoryId";
                    command.Parameters.AddWithValue("@NewCategoryName", newCategoryName);
                    command.Parameters.AddWithValue("@NewDescription", newDescription);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category not found.");
                    }
                }
            }
        }
        public void AddProduct(string pname, string pdesc, decimal pp, int qny, int cid, int bid)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Product (ProductName, Description, Price, Quantity, CategoryID, BrandID) VALUES (@ProductName, @Description, @Price, @Quantity, @CategoryID, @BrandID)";
                    command.Parameters.AddWithValue("@ProductName", pname);
                    command.Parameters.AddWithValue("@Description", pdesc);
                    command.Parameters.AddWithValue("@Price", pp);
                    command.Parameters.AddWithValue("@Quantity", qny);
                    command.Parameters.AddWithValue("@CategoryID", cid);
                    command.Parameters.AddWithValue("@BrandID", bid);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product.");
                    }
                }
            }
        }
        public void addExpenses(int pid, int sid, decimal buyprice)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =@"INSERT INTO Expenses (ProductID, SupplierID, BuyingPrice) VALUES (@ProductID, @SupplierID, @BuyingPrice)";
                    command.Parameters.AddWithValue("@ProductID",pid);
                    command.Parameters.AddWithValue("@SupplierID", sid);
                    command.Parameters.AddWithValue("@BuyingPrice", buyprice);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Expenses added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add expenses.");
                    }
                }
            }
        }
        public int getPid()
        {
            int lastInsertedId = -1;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =@"SELECT MAX(ProductID) AS LastInsertedId FROM Product";
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastInsertedId = Convert.ToInt32(result);
                    }
                }
            }
            return lastInsertedId;
        }
        public List<Supplier> GetSupplierInfo()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT SupplierName, ContactInformation, Address FROM Supplier";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();
                            supplier.SupplierName = reader["SupplierName"].ToString();
                            supplier.ContactInformation = reader["ContactInformation"].ToString();
                            supplier.Address = reader["Address"].ToString();
                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            return suppliers;
        }
        public List<string> GetSuppliersNames()
        {
            List<string> SupplierNames = new List<string>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT SupplierName FROM Supplier";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SupplierNames.Add(reader["SupplierName"].ToString());
                        }
                    }
                }
            }
            return SupplierNames;
        }
        public int GetSupplierID(string supplierName)
        {
            int id = -1;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT SupplierID FROM Supplier
                       where SupplierName = @sname";
                    command.Parameters.AddWithValue("@sname", supplierName);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        id = Convert.ToInt32(result);
                    }
                }
            }
            return id;
        }
        public Supplier GetSupplierInfo(string supplierName)
        {
            Supplier supplierInfo = null;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT ContactInformation, Address FROM Supplier WHERE SupplierName = @SupplierName";
                    command.Parameters.AddWithValue("@SupplierName", supplierName);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplierInfo = new Supplier
                            {
                                SupplierName = supplierName,
                                ContactInformation = reader["ContactInformation"].ToString(),
                                Address = reader["Address"].ToString()
                            };
                        }
                    }
                }
            }

            return supplierInfo;
        }

    }
}
