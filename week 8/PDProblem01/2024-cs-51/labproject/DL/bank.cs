using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labproject.DL;

namespace BankAccountManagementSystem.DL
{
    public class Bank
    {
        private readonly List<BankAccount> _accounts;

        public Bank()
        {
            _accounts = new List<BankAccount>();
        }

        public IReadOnlyList<BankAccount> Accounts => _accounts.AsReadOnly();

        public void AddAccount(BankAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (_accounts.Any(a => a.AccountNumber == account.AccountNumber))
                throw new InvalidOperationException("Account already exists.");

            _accounts.Add(account);
        }

        public BankAccount GetAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber)
                ?? throw new ArgumentException("Account not found.");
        }

        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            var source = GetAccount(fromAccount);
            var destination = GetAccount(toAccount);

            source.Withdraw(amount);
            destination.Deposit(amount);
        }
    }
}