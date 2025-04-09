using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Input for Circle ---
            Console.WriteLine("----- Create Circle -----");
            Console.Write("Enter Circle radius (double): ");
            double circleRadius = double.Parse(Console.ReadLine());
            Console.Write("Enter Circle color (string): ");
            string circleColor = Console.ReadLine();

            Circle circle = new Circle(circleRadius, circleColor);
            Console.WriteLine("Your Circle: " + circle.ToString());
            Console.WriteLine("Circle Area: " + circle.GetArea());
            Console.WriteLine();

            // --- Input for Cylinder ---
            Console.WriteLine("----- Create Cylinder -----");
            Console.Write("Enter Cylinder radius (double): ");
            double cylRadius = double.Parse(Console.ReadLine());
            Console.Write("Enter Cylinder height (double): ");
            double cylHeight = double.Parse(Console.ReadLine());
            Console.Write("Enter Cylinder color (string): ");
            string cylColor = Console.ReadLine();

            Cylinder cylinder = new Cylinder(cylRadius, cylHeight, cylColor);
            Console.WriteLine("Your Cylinder: " + cylinder.ToString());
            Console.WriteLine("Cylinder Volume: " + cylinder.GetVolume());

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
