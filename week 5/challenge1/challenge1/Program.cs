using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge1
{
    class Program
        {
            static List<Admin> admins = new List<Admin>();
            static List<Customer> customers = new List<Customer>();
            static List<Product> products = new List<Product>();

            static void Main(string[] args)
            {
                // Pre-populate with sample admin
                admins.Add(new Admin { Username = "AAA", Password = "111" });

                MainMenu();
            }

            static void MainMenu()
            {
                while (true)
                {
                    Console.WriteLine("1. SignIn");
                    Console.WriteLine("2. SignUp");
                    Console.WriteLine("3. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            SignIn();
                            break;
                        case 2:
                            SignUp();
                            break;
                        case 3:
                            return;
                    }
                }
            }

            static void SignIn()
            {
                Console.WriteLine("Enter Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();

                Admin admin = admins.FirstOrDefault(a => a.Username == username && a.Password == password);
                if (admin != null)
                {
                    AdminMenu(admin);
                }
                else
                {
                    Customer customer = customers.FirstOrDefault(c => c.Username == username && c.Password == password);
                    if (customer != null)
                    {
                        CustomerMenu(customer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password.");
                    }
                }
            }

            static void SignUp()
            {
                Console.WriteLine("Are you an Admin or Customer? (Enter 'A' for Admin, 'C' for Customer)");
                char userType = char.Parse(Console.ReadLine().ToUpper());

                Console.WriteLine("Enter Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Address:");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Contact Number:");
                string contactNumber = Console.ReadLine();

                if (userType == 'A')
                {
                    admins.Add(new Admin { Username = username, Password = password });
                    Console.WriteLine("Admin registered successfully!");
                }
                else if (userType == 'C')
                {
                    customers.Add(new Customer { Username = username, Password = password, Email = email, Address = address, ContactNumber = contactNumber });
                    Console.WriteLine("Customer registered successfully!");
                }
            }

            static void AdminMenu(Admin admin)
            {
                while (true)
                {
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. View All Products");
                    Console.WriteLine("3. Find Product with Highest Unit Price");
                    Console.WriteLine("4. View Sales Tax of All Products");
                    Console.WriteLine("5. Products to be Ordered (less than threshold)");
                    Console.WriteLine("6. View Profile");
                    Console.WriteLine("7. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddProduct(admin);
                            break;
                        case 2:
                            admin.ViewAllProducts(products);
                            break;
                        case 3:
                            Product product = admin.FindProductWithHighestPrice(products);
                            if (product != null)
                            {
                                Console.WriteLine($"Highest Price Product: {product.Name}, Price: {product.Price}");
                            }
                            break;
                        case 4:
                            admin.ViewSalesTaxOfAllProducts(products);
                            break;
                        case 5:
                            List<Product> productsToOrder = admin.ProductsToBeOrdered(products);
                            foreach (var prod in productsToOrder)
                            {
                                Console.WriteLine($"Name: {prod.Name}, Stock: {prod.AvailableStock}");
                            }
                            break;
                        case 6:
                            Console.WriteLine($"Username: {admin.Username}, Password: {admin.Password}");
                            break;
                        case 7:
                            return;
                    }
                }
            }

            static void AddProduct(Admin admin)
            {
                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Product Category (Grocery/Fruit/Others):");
                string category = Console.ReadLine();
                Console.WriteLine("Enter Product Price:");
                double price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Available Stock:");
                int availableStock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minimum Stock Threshold:");
                int minimumStockThreshold = int.Parse(Console.ReadLine());

                Product product = new Product
                {
                    Name = name,
                    Category = category,
                    Price = price,
                    AvailableStock = availableStock,
                    MinimumStockThreshold = minimumStockThreshold
                };

                admin.AddProduct(products, product);
                Console.WriteLine("Product added successfully!");
            }

            static void CustomerMenu(Customer customer)
            {
                while (true)
                {
                    Console.WriteLine("1. View all the products");
                    Console.WriteLine("2. Buy the products");
                    Console.WriteLine("3. Generate invoice");
                    Console.WriteLine("4. View Profile");
                    Console.WriteLine("5. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ViewAllProducts();
                            break;
                        case 2:
                            BuyProduct(customer);
                            break;
                        case 3:
                            GenerateInvoice(customer);
                            break;
                        case 4:
                            Console.WriteLine($"Username: {customer.Username}, Password: {customer.Password}, Email: {customer.Email}, Address: {customer.Address}, Contact Number: {customer.ContactNumber}");
                            break;
                        case 5:
                            return;
                    }
                }
            }

            static void ViewAllProducts()
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Stock: {product.AvailableStock}");
                }
            }

            static void BuyProduct(Customer customer)
            {
                Console.WriteLine("Enter Product Name to Buy:");
                string productName = Console.ReadLine();

                Product product = products.FirstOrDefault(p => p.Name == productName);
                if (product != null && product.AvailableStock > 0)
                {
                    product.AvailableStock--;
                    Console.WriteLine("Product purchased successfully!");
                }
                else
                {
                    Console.WriteLine("Product is out of stock or does not exist.");
                }
            }
        static void GenerateInvoice(Customer customer)
        {
            double totalPrice = 0;
            Console.WriteLine("Purchased Products:");
            foreach (var product in products)
            {
                if (product.AvailableStock == 0) // Assuming products with AvailableStock = 0 are purchased
                {
                    double salesTax = product.GetSalesTax();
                    double finalPrice = product.Price + salesTax;
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Sales Tax: {salesTax}, Final Price: {finalPrice}");
                    totalPrice += finalPrice;
                }
            }
            Console.WriteLine($"Total Price (including sales tax): {totalPrice}");
        }
    }
}
