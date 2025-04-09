using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Input for Bicycle ---
            Console.WriteLine("----- Create Bicycle -----");
            Console.Write("Enter Bicycle Cadence (int): ");
            int cadence = int.Parse(Console.ReadLine());
            Console.Write("Enter Bicycle Speed (int): ");
            int speed = int.Parse(Console.ReadLine());
            Console.Write("Enter Bicycle Gear (int): ");
            int gear = int.Parse(Console.ReadLine());

            Bicycle bike = new Bicycle(cadence, speed, gear);
            Console.WriteLine("Your Bicycle: " + bike.ToString());
            Console.WriteLine();

            // --- Input for MountainBike ---
            Console.WriteLine("----- Create MountainBike -----");
            Console.Write("Enter MountainBike Seat Height (int): ");
            int seatHeight = int.Parse(Console.ReadLine());
            Console.Write("Enter MountainBike Cadence (int): ");
            int mtCadence = int.Parse(Console.ReadLine());
            Console.Write("Enter MountainBike Speed (int): ");
            int mtSpeed = int.Parse(Console.ReadLine());
            Console.Write("Enter MountainBike Gear (int): ");
            int mtGear = int.Parse(Console.ReadLine());

            MountainBike mtBike = new MountainBike(seatHeight, mtCadence, mtSpeed, mtGear);
            Console.WriteLine("Your MountainBike: " + mtBike.ToString());

            // Optionally demonstrate changing the state.
            Console.Write("Increase MountainBike speed by (int): ");
            int increase = int.Parse(Console.ReadLine());
            mtBike.SpeedUp(increase);
            Console.Write("Apply brake decrement on MountainBike by (int): ");
            int decrement = int.Parse(Console.ReadLine());
            mtBike.ApplyBrake(decrement);
            Console.WriteLine("MountainBike after speed adjustments: " + mtBike.ToString());

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
