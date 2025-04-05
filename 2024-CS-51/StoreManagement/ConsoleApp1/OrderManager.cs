using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StockManagement.DL;

namespace StockManagement.BL
{
    public class OrderManager
    {
        // Place an order along with its items
        public static string PlaceOrder(int userId, Dictionary<string, (float price, int quantity)> cart, string deliveryAddress)
        {
            // Insert order record. Delivery address is stored.
            string orderQuery = "INSERT INTO orders (user_id, status, delivery_address) VALUES (@userId, 'pending', @deliveryAddress)";
            var orderParams = new[]
            {
                new MySqlParameter("@userId", userId),
                new MySqlParameter("@deliveryAddress", deliveryAddress)
            };

            int orderResult = DataLayer.ExecuteNonQuery(orderQuery, orderParams);
            if (orderResult <= 0)
                return "Failed to place order.";

            // Retrieve the last inserted order_id
            object o = DataLayer.ExecuteScalar("SELECT LAST_INSERT_ID();");
            int orderId = Convert.ToInt32(o);

            // For each item in the cart, insert a record into order_items
            foreach (var item in cart)
            {
                string productName = item.Key;
                float price = item.Value.price;
                int quantity = item.Value.quantity;

                // Retrieve the product_id based on product_name
                string productQuery = "SELECT product_id FROM products WHERE product_name = @productName";
                var productParams = new[]
                {
                    new MySqlParameter("@productName", productName)
                };
                object pid = DataLayer.ExecuteScalar(productQuery, productParams);
                if (pid == null)
                    continue;
                int productId = Convert.ToInt32(pid);

                // Insert order item record
                string itemQuery = "INSERT INTO order_items (order_id, product_id, quantity, price) VALUES (@orderId, @productId, @quantity, @price)";
                var itemParams = new[]
                {
                    new MySqlParameter("@orderId", orderId),
                    new MySqlParameter("@productId", productId),
                    new MySqlParameter("@quantity", quantity),
                    new MySqlParameter("@price", price)
                };
                DataLayer.ExecuteNonQuery(itemQuery, itemParams);
            }
            return "Order placed successfully!";
        }

        public static System.Data.DataTable ViewPendingOrders()
        {
            string query = "SELECT order_id, user_id, status, order_date, delivery_address FROM orders WHERE status = 'pending'";
            return DataLayer.ExecuteQuery(query);
        }

        public static string ConfirmOrDeclineOrder(int orderId, string action)
        {
            string status = "";
            if (action.Equals("confirm", StringComparison.OrdinalIgnoreCase))
                status = "confirmed";
            else if (action.Equals("decline", StringComparison.OrdinalIgnoreCase))
                status = "declined";
            else
                return "Invalid action.";

            string query = "UPDATE orders SET status = @status WHERE order_id = @orderId";
            var parameters = new[]
            {
                new MySqlParameter("@status", status),
                new MySqlParameter("@orderId", orderId)
            };

            int result = DataLayer.ExecuteNonQuery(query, parameters);
            return result > 0 ? $"Order {orderId} {status} successfully!" : "Failed to update order.";
        }
    }
}
