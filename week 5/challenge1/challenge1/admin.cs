using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge1
{
        public class Admin
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public void AddProduct(List<Product> products, Product product)
            {
                products.Add(product);
            }

            public void ViewAllProducts(List<Product> products)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Stock: {product.AvailableStock}");
                }
            }

            public Product FindProductWithHighestPrice(List<Product> products)
            {
                return products.OrderByDescending(p => p.Price).FirstOrDefault();
            }

            public void ViewSalesTaxOfAllProducts(List<Product> products)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Sales Tax: {product.GetSalesTax()}");
                }
            }

            public List<Product> ProductsToBeOrdered(List<Product> products)
            {
                return products.Where(p => p.AvailableStock < p.MinimumStockThreshold).ToList();
            }
        }
}

