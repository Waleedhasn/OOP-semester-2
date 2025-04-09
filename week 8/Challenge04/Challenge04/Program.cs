using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge04.InheritanceChallenge4;

namespace Challenge04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Student Account Section ---
            Console.WriteLine("----- Create Student Account -----");
            Console.Write("Enter account title: ");
            string stuTitle = Console.ReadLine();
            Console.Write("Enter account number: ");
            string stuNumber = Console.ReadLine();
            Console.Write("Enter initial balance (double): ");
            double stuBalance = double.Parse(Console.ReadLine());
            StudentAccount stuAcc = new StudentAccount(stuTitle, stuNumber, stuBalance);

            Console.Write("Enter debit amount for Student Account (double): ");
            double stuDebit = double.Parse(Console.ReadLine());
            stuAcc.Debit(stuDebit);
            Console.WriteLine("StudentAccount after debit: " + stuAcc.ToString());
            Console.WriteLine();

            // --- Salary Account Section ---
            Console.WriteLine("----- Create Salary Account -----");
            Console.Write("Enter account title: ");
            string salTitle = Console.ReadLine();
            Console.Write("Enter account number: ");
            string salNumber = Console.ReadLine();
            Console.Write("Enter initial balance (double): ");
            double salBalance = double.Parse(Console.ReadLine());
            SalaryAccount salAcc = new SalaryAccount(salTitle, salNumber, salBalance);

            Console.Write("Enter debit amount for Salary Account (double): ");
            double salDebit = double.Parse(Console.ReadLine());
            salAcc.Debit(salDebit);
            Console.WriteLine("SalaryAccount after debit: " + salAcc.ToString());

            Console.Write("Enter tax percentage to apply on Salary Account (double): ");
            double taxPercent = double.Parse(Console.ReadLine());
            salAcc.ApplyTax(taxPercent);
            Console.WriteLine("SalaryAccount after tax deduction: " + salAcc.ToString());

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
