using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using StockManagement.BL;
using StockManagement.DL;

namespace StockManagement.UI
{
    class Program
    {
        static string loggedInUser = null;
        static string userRole = null;
        static int loggedInUserId = 0;
        // In-memory cart: key = product name, value = (price, quantity)
        static Dictionary<string, (float price, int quantity)> cart = new Dictionary<string, (float, int)>();

        static void Main(string[] args)
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Stock Management System");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        SignUpUI();
                        break;
                    case "2":
                        LoginUI();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (option != "3");
        }

        static void SignUpUI()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Enter role (Admin/Customer): ");
            string roleName = Console.ReadLine();

            string result = UserManager.SignUp(username, email, password, roleName);
            Console.WriteLine(result);
        }

        static void LoginUI()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string result = UserManager.Login(username, password);
            Console.WriteLine(result);

            if (result.StartsWith("Login successful!"))
            {
                loggedInUser = username;
                // Expected format: "Login successful! Welcome <username>, Role: <roleName>, UserId: <id>"
                string[] parts = result.Split(',');
                if (parts.Length >= 3)
                {
                    string rolePart = parts[1].Trim(); // e.g., "Role: Admin"
                    if (rolePart.StartsWith("Role:"))
                        userRole = rolePart.Substring("Role:".Length).Trim();
                    string userIdPart = parts[2].Trim(); // e.g., "UserId: 1"
                    if (userIdPart.StartsWith("UserId:"))
                        int.TryParse(userIdPart.Substring("UserId:".Length).Trim(), out loggedInUserId);
                }
                else
                {
                    Console.WriteLine("Login result format unexpected.");
                }

                if ("Admin".Equals(userRole, StringComparison.OrdinalIgnoreCase))
                    AdminMenu();
                else if ("Customer".Equals(userRole, StringComparison.OrdinalIgnoreCase))
                    CustomerMenu();
                else
                    Console.WriteLine("User role could not be determined. Please check login result format.");
            }
        }

        // ---------------------
        // Admin Menu Functions
        // ---------------------
        static void AdminMenu()
        {
            string adminOption;
            do
            {
                Console.Clear();
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Check Stock");
                Console.WriteLine("3. Add New Stock");
                Console.WriteLine("4. Online Order Confirmation");
                Console.WriteLine("5. View Reviews from Customers");
                Console.WriteLine("6. Logout");
                Console.Write("Select an option: ");
                adminOption = Console.ReadLine();

                switch (adminOption)
                {
                    case "1":
                        AddProductUI();
                        break;
                    case "2":
                        CheckStockUI();
                        break;
                    case "3":
                        AddNewStockUI();
                        break;
                    case "4":
                        OnlineOrderConfirmationUI();
                        break;
                    case "5":
                        ViewReviewsUI_Admin();
                        break;
                    case "6":
                        Console.WriteLine("Logging out...");
                        loggedInUser = null;
                        userRole = null;
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (adminOption != "6");
        }

        static void AddProductUI()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter product stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter category (Fruits, Vegetables, Dairy): ");
            string category = Console.ReadLine();

            string result = ProductManager.AddProduct(name, price, stock, category);
            Console.WriteLine(result);
        }

        static void CheckStockUI()
        {
            Console.Write("Enter category (Fruits, Vegetables, Dairy) or 'all': ");
            string input = Console.ReadLine();
            DataTable products;
            if (input.Equals("all", StringComparison.OrdinalIgnoreCase))
                products = ProductManager.ViewAllProducts();
            else
                products = ProductManager.ViewProducts(input);

            if (products.Rows.Count == 0)
                Console.WriteLine("No products found.");
            else
            {
                Console.WriteLine("Products Stock:");
                foreach (DataRow row in products.Rows)
                    Console.WriteLine($"Name: {row["product_name"]}, Price: {row["price"]}, Stock: {row["stock"]}");
            }
        }

        static void AddNewStockUI()
        {
            Console.Write("Enter product name to update stock: ");
            string productName = Console.ReadLine();
            Console.Write("Enter additional stock quantity: ");
            int additionalStock = int.Parse(Console.ReadLine());

            string result = ProductManager.AddStock(productName, additionalStock);
            Console.WriteLine(result);
        }

        static void OnlineOrderConfirmationUI()
        {
            DataTable orders = OrderManager.ViewPendingOrders();
            if (orders.Rows.Count == 0)
                Console.WriteLine("No pending orders.");
            else
            {
                Console.WriteLine("Pending Orders:");
                foreach (DataRow row in orders.Rows)
                    Console.WriteLine($"Order ID: {row["order_id"]}, User ID: {row["user_id"]}, Status: {row["status"]}, Date: {row["order_date"]}, Delivery: {row["delivery_address"]}");
                Console.Write("Enter Order ID to process: ");
                int orderId = int.Parse(Console.ReadLine());
                Console.Write("Enter action (confirm/decline): ");
                string action = Console.ReadLine();
                string result = OrderManager.ConfirmOrDeclineOrder(orderId, action);
                Console.WriteLine(result);
            }
        }

        static void ViewReviewsUI_Admin()
        {
            DataTable reviews = ReviewManager.ViewReviews();
            if (reviews.Rows.Count == 0)
                Console.WriteLine("No reviews found.");
            else
            {
                Console.WriteLine("Customer Reviews:");
                foreach (DataRow row in reviews.Rows)
                    Console.WriteLine($"Review ID: {row["review_id"]}, User: {row["username"]}, Message: {row["message"]}, Submitted at: {row["submitted_at"]}");
            }
        }

        // ---------------------
        // Customer Menu Functions
        // ---------------------
        static void CustomerMenu()
        {
            string customerOption;
            do
            {
                Console.Clear();
                Console.WriteLine("Customer Menu");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Purchase Items / Apply for Online Delivery");
                Console.WriteLine("5. Calculate Bill");
                Console.WriteLine("6. Add Review");
                Console.WriteLine("7. Logout");
                Console.Write("Select an option: ");
                customerOption = Console.ReadLine();

                switch (customerOption)
                {
                    case "1":
                        ViewProductsUI();
                        break;
                    case "2":
                        AddToCartUI();
                        break;
                    case "3":
                        ViewCartUI();
                        break;
                    case "4":
                        PurchaseAndDeliveryUI();
                        break;
                    case "5":
                        CalculateBillUI();
                        break;
                    case "6":
                        AddReviewUI();
                        break;
                    case "7":
                        Console.WriteLine("Logging out...");
                        loggedInUser = null;
                        userRole = null;
                        cart.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (customerOption != "7");
        }

        static void ViewProductsUI()
        {
            Console.Write("Enter category to view (Fruits, Vegetables, Dairy): ");
            string category = Console.ReadLine();

            DataTable products = ProductManager.ViewProducts(category);
            if (products.Rows.Count == 0)
                Console.WriteLine("No products found in this category.");
            else
            {
                Console.WriteLine("Products:");
                foreach (DataRow row in products.Rows)
                    Console.WriteLine($"Name: {row["product_name"]}, Price: {row["price"]}, Stock: {row["stock"]}");
            }
        }

        static void AddToCartUI()
        {
            Console.Write("Enter product name to add to cart: ");
            string productName = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            // Retrieve the product information (price) using ViewAllProducts
            DataTable dt = ProductManager.ViewAllProducts();
            DataRow[] found = dt.Select($"product_name = '{productName.Replace("'", "''")}'");
            if (found.Length > 0)
            {
                float price = Convert.ToSingle(found[0]["price"]);
                if (cart.ContainsKey(productName))
                {
                    var existing = cart[productName];
                    cart[productName] = (price, existing.quantity + quantity);
                }
                else
                {
                    cart.Add(productName, (price, quantity));
                }
                Console.WriteLine("Product added to cart.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void ViewCartUI()
        {
            if (cart.Count == 0)
                Console.WriteLine("Your cart is empty.");
            else
            {
                Console.WriteLine("Your Cart:");
                foreach (var item in cart)
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value.price}, Quantity: {item.Value.quantity}");
            }
        }

        static void CalculateBillUI()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                float total = 0;
                Console.WriteLine("Bill Details:");
                foreach (var item in cart)
                {
                    float subtotal = item.Value.price * item.Value.quantity;
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value.price}, Quantity: {item.Value.quantity}, Subtotal: {subtotal}");
                    total += subtotal;
                }
                Console.WriteLine($"Total Bill Amount: {total}");
            }
        }

        static void PurchaseAndDeliveryUI()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Please add items before purchasing.");
                return;
            }
            Console.Write("Enter delivery address (or leave empty): ");
            string deliveryAddress = Console.ReadLine();
            string result = OrderManager.PlaceOrder(loggedInUserId, cart, deliveryAddress);
            if (result.StartsWith("Order placed"))
            {
                cart.Clear();
                Console.WriteLine("Your order has been placed. Please wait for delivery confirmation.");
            }
            else
            {
                Console.WriteLine("Failed to place order.");
            }
        }

        static void AddReviewUI()
        {
            Console.Write("Enter your review: ");
            string review = Console.ReadLine();
            Console.Write("Enter your user ID: ");
            int userId = int.Parse(Console.ReadLine());

            string result = ReviewManager.AddReview(userId, review);
            Console.WriteLine(result);
        }
    }
}
