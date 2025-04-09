using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge04.InheritanceChallenge4;

namespace Challenge04
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(string title, string number, double balance)
            : base(title, number, balance)
        { }

        public override void Debit(double amount)
        {
            if (balance >= amount)
                balance -= amount;
            else
                System.Console.WriteLine("Insufficient funds in salary account.");
        }

        public void ApplyTax(double percentage)
        {
            double tax = balance * (percentage / 100);
            balance -= tax;
        }

        public override string ToString() =>
            $"SalaryAccount[title={accountTitle}, number={accountNumber}, balance={balance}]";
    }
}
