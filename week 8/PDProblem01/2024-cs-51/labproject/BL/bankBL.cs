
using BankAccountManagementSystem.DL;
using labproject.DL;
using System;

namespace BankAccountManagementSystem.BL
{
    public class BankAccountService
    {
        private readonly Bank _bank;
        private object ex;

        public BankAccountService(Bank bank)
        {
            _bank = bank ?? throw new ArgumentNullException(nameof(bank));
        }

        public string CreateAccount(string accountNumber, string ownerName, decimal initialDeposit)
        {
            try
            {
                var account = new BankAccount(accountNumber, ownerName, initialDeposit);
                _bank.AddAccount(account);
                return $"Account created successfully.\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"Error creating account: {ex.Message}";
            }
        }

        public string Deposit(string accountNumber, decimal amount)
        {
            try
            {
                var account = _bank.GetAccount(accountNumber);
                account.Deposit(amount);
                return $"Deposit successful.\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"Error during deposit: {ex.Message}";
            }
        }

        public string Withdraw(string accountNumber, decimal amount)
        {
            try
            {
                var account = _bank.GetAccount(accountNumber);
                account.Withdraw(amount);
                return $"Withdrawal successful.\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"Error during withdrawal: {ex.Message}";
            }
        }

        public string Transfer(string fromAccount, string toAccount, decimal amount)
        {
            try
            {
                _bank.Transfer(fromAccount, toAccount, amount);
                return $"Transfer of {amount:C} completed successfully.";
                if(fromAccount == toAccount)
                {
                    return $"Error during transfer: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error during transfer: {ex.Message}";
            }
        }

        public string GetAccountDetails(string accountNumber)
        {
            try
            {
                return _bank.GetAccount(accountNumber).GetAccountDetails();
            }
            catch (Exception ex)
            {
                return $"Error retrieving account: {ex.Message}";
            }
        }
    }
}