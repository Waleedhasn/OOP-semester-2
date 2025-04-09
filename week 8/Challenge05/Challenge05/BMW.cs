using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class BMW : Car
    {
        public BMW(string model, string color, double price)
            : base(model, color, price)
        { }

        public override double CalculateFuelConsumption(double distance)
        {
            // BMW-specific consumption: 0.12 liters per km.
            return distance * 0.12;
        }

        public override void DisplayInfo(double distance)
        {
            System.Console.WriteLine($"BMW - Model: {model}, Color: {color}, Price: {price}");
            System.Console.WriteLine($"Fuel Consumption for {distance} km: {CalculateFuelConsumption(distance):F2} liters");
        }
    }
}
