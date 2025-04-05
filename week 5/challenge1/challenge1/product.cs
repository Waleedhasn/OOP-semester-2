using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge1
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int AvailableStock { get; set; }
        public int MinimumStockThreshold { get; set; }

        public double GetSalesTax()
        {
            if (Category == "Grocery")
                return 0.10 * Price;
            else if (Category == "Fruit")
                return 0.05 * Price;
            else
                return 0.15 * Price;
        }
    }
}
