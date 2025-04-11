using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountManagementSystem.BL;
using BankAccountManagementSystem.DL;

namespace labproject
{
    internal class Program
    {
            private static BankAccountService _bankService;
            private static Bank _bank;

            static void Main(string[] args)
            {
                InitializeSystem();
                ShowMainMenu();
            }

            private static void InitializeSystem()
            {
                _bank = new Bank();
                _bankService = new BankAccountService(_bank);
            }

            private static void ShowMainMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Bank Account Management System");
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. View Account");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select option: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateAccount();
                            break;
                        case "2":
                            Deposit();
                            break;
                        case "3":
                            Withdraw();
                            break;
                        case "4":
                            Transfer();
                            break;
                        case "5":
                            ViewAccount();
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private static void CreateAccount()
            {
                Console.Clear();
                Console.WriteLine("Create New Account");

                Console.Write("Enter account number (10 digits): ");
                var accountNumber = Console.ReadLine();

                Console.Write("Enter owner name: ");
                var ownerName = Console.ReadLine();

                Console.Write("Enter initial deposit: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
                {
                    Console.WriteLine("Invalid amount. Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                var result = _bankService.CreateAccount(accountNumber, ownerName, initialDeposit);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static void Deposit()
            {
                Console.Clear();
                Console.WriteLine("Deposit Funds");

                Console.Write("Enter account number: ");
                var accountNumber = Console.ReadLine();

                Console.Write("Enter amount to deposit: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount. Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                var result = _bankService.Deposit(accountNumber, amount);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static void Withdraw()
            {
                Console.Clear();
                Console.WriteLine("Withdraw Funds");

                Console.Write("Enter account number: ");
                var accountNumber = Console.ReadLine();

                Console.Write("Enter amount to withdraw: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount. Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                var result = _bankService.Withdraw(accountNumber, amount);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static void Transfer()
            {
                Console.Clear();
                Console.WriteLine("Transfer Funds");

                Console.Write("Enter source account number: ");
                var fromAccount = Console.ReadLine();

                Console.Write("Enter destination account number: ");
                var toAccount = Console.ReadLine();

                Console.Write("Enter amount to transfer: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount. Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                var result = _bankService.Transfer(fromAccount, toAccount, amount);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static void ViewAccount()
            {
                Console.Clear();
                Console.WriteLine("View Account Details");

                Console.Write("Enter account number: ");
                var accountNumber = Console.ReadLine();

                var result = _bankService.GetAccountDetails(accountNumber);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
    }
}

