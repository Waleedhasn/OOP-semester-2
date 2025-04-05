using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using StockManagement.DL;

namespace StockManagement.BL
{
    public class ProductManager
    {
        public static string AddProduct(string name, float price, int stock, string category)
        {
            string categoryQuery = "SELECT category_id FROM categories WHERE category_name = @categoryName";
            var categoryParameters = new[] { new MySqlParameter("@categoryName", category) };
            object categoryId = DataLayer.ExecuteScalar(categoryQuery, categoryParameters);

            if (categoryId == null)
                return "Invalid category!";

            string query = "INSERT INTO products (product_name, price, stock, category_id) VALUES (@name, @price, @stock, @category_id)";
            var parameters = new[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@price", price),
                new MySqlParameter("@stock", stock),
                new MySqlParameter("@category_id", categoryId)
            };

            int result = DataLayer.ExecuteNonQuery(query, parameters);
            return result > 0 ? "Product added successfully!" : "Failed to add product.";
        }

        public static DataTable ViewProducts(string categoryName)
        {
            string categoryQuery = "SELECT category_id FROM categories WHERE category_name = @categoryName";
            var categoryParameters = new[] { new MySqlParameter("@categoryName", categoryName) };
            object categoryId = DataLayer.ExecuteScalar(categoryQuery, categoryParameters);

            if (categoryId == null)
                return new DataTable();

            string query = "SELECT product_name, price, stock FROM products WHERE category_id = @category_id";
            var parameters = new[]
            {
                new MySqlParameter("@category_id", categoryId)
            };

            return DataLayer.ExecuteQuery(query, parameters);
        }

        public static DataTable ViewAllProducts()
        {
            string query = "SELECT product_name, price, stock FROM products";
            return DataLayer.ExecuteQuery(query);
        }

        public static string AddStock(string productName, int additionalStock)
        {
            string query = "UPDATE products SET stock = stock + @additionalStock WHERE product_name = @productName";
            var parameters = new[]
            {
                new MySqlParameter("@additionalStock", additionalStock),
                new MySqlParameter("@productName", productName)
            };

            int result = DataLayer.ExecuteNonQuery(query, parameters);
            return result > 0 ? "Stock updated successfully!" : "Product not found.";
        }
    }
}
