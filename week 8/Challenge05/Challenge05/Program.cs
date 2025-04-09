using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Create BMW ---
            Console.WriteLine("----- Create BMW -----");
            Console.Write("Enter BMW model: ");
            string bmwModel = Console.ReadLine();
            Console.Write("Enter BMW color: ");
            string bmwColor = Console.ReadLine();
            Console.Write("Enter BMW price (double): ");
            double bmwPrice = double.Parse(Console.ReadLine());
            BMW bmw = new BMW(bmwModel, bmwColor, bmwPrice);

            // --- Create Audi ---
            Console.WriteLine("\n----- Create Audi -----");
            Console.Write("Enter Audi model: ");
            string audiModel = Console.ReadLine();
            Console.Write("Enter Audi color: ");
            string audiColor = Console.ReadLine();
            Console.Write("Enter Audi price (double): ");
            double audiPrice = double.Parse(Console.ReadLine());
            Audi audi = new Audi(audiModel, audiColor, audiPrice);

            // --- Create GLI ---
            Console.WriteLine("\n----- Create GLI -----");
            Console.Write("Enter GLI model: ");
            string gliModel = Console.ReadLine();
            Console.Write("Enter GLI color: ");
            string gliColor = Console.ReadLine();
            Console.Write("Enter GLI price (double): ");
            double gliPrice = double.Parse(Console.ReadLine());
            GLI gli = new GLI(gliModel, gliColor, gliPrice);

            // --- Ask for distance for fuel consumption calculation ---
            Console.Write("\nEnter distance in km for fuel consumption calculation (double): ");
            double distance = double.Parse(Console.ReadLine());
            Console.WriteLine();

            // Display information and fuel consumption for each car.
            bmw.DisplayInfo(distance);
            Console.WriteLine();
            audi.DisplayInfo(distance);
            Console.WriteLine();
            gli.DisplayInfo(distance);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
