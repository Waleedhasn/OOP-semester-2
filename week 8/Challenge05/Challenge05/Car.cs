using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Car
    {
        protected string model;
        protected string color;
        protected double price;

        public Car(string model, string color, double price)
        {
            this.model = model;
            this.color = color;
            this.price = price;
        }

        public virtual double CalculateFuelConsumption(double distance)
        {
            // Default consumption rate: 0.1 liters per km.
            return distance * 0.1;
        }

        public virtual void DisplayInfo(double distance)
        {
            System.Console.WriteLine($"Car - Model: {model}, Color: {color}, Price: {price}");
            System.Console.WriteLine($"Fuel Consumption for {distance} km: {CalculateFuelConsumption(distance):F2} liters");
        }
    }
}
