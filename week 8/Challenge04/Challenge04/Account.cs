using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    namespace InheritanceChallenge4
    {
        public class Account
        {
            protected string accountTitle;
            protected string accountNumber;
            protected double balance;

            public Account(string title, string number, double balance)
            {
                this.accountTitle = title;
                this.accountNumber = number;
                this.balance = balance;
            }

            public virtual void Credit(double amount) => balance += amount;

            public virtual void Debit(double amount)
            {
                if (balance >= amount)
                    balance -= amount;
                else
                    System.Console.WriteLine("Insufficient funds.");
            }

            public double GetBalance() => balance;

            public override string ToString() =>
                $"Account[title={accountTitle}, number={accountNumber}, balance={balance}]";
        }
    }

}
