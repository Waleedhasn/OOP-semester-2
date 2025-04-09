using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Input for Person ---
            Console.WriteLine("----- Create Person -----");
            Console.Write("Enter person's name: ");
            string personName = Console.ReadLine();
            Console.Write("Enter person's address: ");
            string personAddress = Console.ReadLine();
            Person person = new Person(personName, personAddress);
            Console.WriteLine("Your Person: " + person.ToString());
            Console.WriteLine();

            // --- Input for Student ---
            Console.WriteLine("----- Create Student -----");
            Console.Write("Enter student's name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter student's address: ");
            string studentAddress = Console.ReadLine();
            Console.Write("Enter student's program: ");
            string program = Console.ReadLine();
            Console.Write("Enter student's year (int): ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter student's fee (double): ");
            double fee = double.Parse(Console.ReadLine());
            Student student = new Student(studentName, studentAddress, program, year, fee);
            Console.WriteLine("Your Student: " + student.ToString());
            Console.WriteLine();

            // --- Input for Staff ---
            Console.WriteLine("----- Create Staff -----");
            Console.Write("Enter staff's name: ");
            string staffName = Console.ReadLine();
            Console.Write("Enter staff's address: ");
            string staffAddress = Console.ReadLine();
            Console.Write("Enter staff's school: ");
            string school = Console.ReadLine();
            Console.Write("Enter staff's pay (double): ");
            double pay = double.Parse(Console.ReadLine());
            Staff staff = new Staff(staffName, staffAddress, school, pay);
            Console.WriteLine("Your Staff: " + staff.ToString());

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
