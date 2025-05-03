using System;
using BankAccountManagementSystem.DL;
using labproject.DL;

namespace BankAccountManagementSystem.BL
{
    public class BankAccountService
    {
        private readonly Bank _bank;

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
                return $"✅ Account created successfully!\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
            }
        }

        public string Deposit(string accountNumber, decimal amount)
        {
            try
            {
                var account = _bank.GetAccount(accountNumber);
                account.Deposit(amount);
                return $"✅ Deposit successful!\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
            }
        }

        public string Withdraw(string accountNumber, decimal amount)
        {
            try
            {
                var account = _bank.GetAccount(accountNumber);
                account.Withdraw(amount);
                return $"✅ Withdrawal successful!\n{account.GetAccountDetails()}";
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
            }
        }

        public string Transfer(string fromAccount, string toAccount, decimal amount)
        {
            try
            {
                _bank.TransferFunds(fromAccount, toAccount, amount);
                return $"✅ Transfer of {amount:C} completed successfully!";
            }
            catch (Exception ex)
            {
                return $"❌ Error: {ex.Message}";
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
                return $"❌ Error: {ex.Message}";
            }
        }
    }
}
