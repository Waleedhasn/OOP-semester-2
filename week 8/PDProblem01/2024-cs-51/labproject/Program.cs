using System;
using BankAccountManagementSystem.BL;
using BankAccountManagementSystem.DL;
using labproject.DL;

namespace labproject
{
    internal class Program
    {
        private static BankAccountService _bankService;
        private static Bank _bank;

        static void Main()
        {
            _bank = new Bank();
            _bankService = new BankAccountService(_bank);
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("💳 Bank Account Management System");
                Console.WriteLine("1️⃣ Create Account");
                Console.WriteLine("2️⃣ Deposit");
                Console.WriteLine("3️⃣ Withdraw");
                Console.WriteLine("4️⃣ Transfer");
                Console.WriteLine("5️⃣ View Account");
                Console.WriteLine("6️⃣ Exit");
                Console.Write("👉 Select option: ");

                switch (Console.ReadLine())
                {
                    case "1": CreateAccount(); break;
                    case "2": Deposit(); break;
                    case "3": Withdraw(); break;
                    case "4": Transfer(); break;
                    case "5": ViewAccount(); break;
                    case "6": return;
                    default: Console.WriteLine("❌ Invalid option. Press any key to continue..."); Console.ReadKey(); break;
                }
            }
        }

        // CreateAccount, Deposit, Withdraw, Transfer, ViewAccount methods remain unchanged.
    }
}
