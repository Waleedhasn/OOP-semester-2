using System;
using System.Collections.Generic;
using labproject.DL;

namespace BankAccountManagementSystem.DL
{
    public class Bank
    {
        private readonly BankRepository _repository;

        public Bank()
        {
            _repository = new BankRepository();
        }

        public void AddAccount(BankAccount account) => _repository.AddAccount(account);

        public BankAccount GetAccount(string accountNumber) => _repository.GetAccount(accountNumber);

        public void TransferFunds(string fromAccount, string toAccount, decimal amount)
        {
            var source = GetAccount(fromAccount);
            var destination = GetAccount(toAccount);

            if (source == null || destination == null)
                throw new ArgumentException("One or both accounts not found.");

            source.Withdraw(amount);
            destination.Deposit(amount);
        }

        public IReadOnlyList<BankAccount> GetAllAccounts() => _repository.GetAllAccounts();
    }
}
