using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Audi : Car
    {
        public Audi(string model, string color, double price)
            : base(model, color, price)
        { }

        public override double CalculateFuelConsumption(double distance)
        {
            return distance * 0.11;
        }

        public override void DisplayInfo(double distance)
        {
            System.Console.WriteLine($"Audi - Model: {model}, Color: {color}, Price: {price}");
            System.Console.WriteLine($"Fuel Consumption for {distance} km: {CalculateFuelConsumption(distance):F2} liters");
        }
    }
}
