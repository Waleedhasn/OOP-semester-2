using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labproject.DL
{
   
        public class BankAccount
        {
            
            private string _accountNumber;
            private string _ownerName;
            private decimal _balance;

            
            public BankAccount()
            {
                
            }

            public BankAccount(string accountNumber, string ownerName, decimal initialBalance)
            {
                AccountNumber = accountNumber; 
                OwnerName = ownerName;
                Balance = initialBalance;
            }

            
            public string AccountNumber
            {
                get => _accountNumber;
                private set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Account number cannot be empty.");
                    if (value.Length != 10)
                        throw new ArgumentException("Account number must be 10 digits.");
                    _accountNumber = value;
                }
            }

            public string OwnerName
            {
                get => _ownerName;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Owner name cannot be empty.");
                    if (value.Length > 50)
                        throw new ArgumentException("Owner name too long.");
                    _ownerName = value;
                }
            }

            public decimal Balance
            {
                get => _balance;
                private set
                {
                    if (value < 0)
                        throw new ArgumentException("Balance cannot be negative.");
                    _balance = value;
                }
            }

           
            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Deposit amount must be positive.");

                Balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be positive.");
                if (Balance - amount < 0)
                    throw new InvalidOperationException("Insufficient funds.");

                Balance -= amount;
            }

            public string GetAccountDetails()
            {
                return $"Account: {AccountNumber}\nOwner: {OwnerName}\nBalance: {Balance:C}";
            }
        }
    }

    
   



