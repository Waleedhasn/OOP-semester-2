using System;

namespace labproject.DL
{
    public class BankAccount
    {
        private string _accountNumber;
        private string _ownerName;
        private decimal _balance;

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
                if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
                    throw new ArgumentException("Account number must be exactly 10 digits.");
                _accountNumber = value;
            }
        }

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new ArgumentException("Owner name must be between 1-50 characters.");
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
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }

        public string GetAccountDetails()
        {
            return $"Account: {AccountNumber}\nOwner: {OwnerName}\nBalance: {Balance:C}";
        }
    }
}
