using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    namespace InheritanceChallenge4
    {
        public class StudentAccount : Account
        {
            private const double CreditLimit = 500000;

            public StudentAccount(string title, string number, double balance)
                : base(title, number, balance)
            { }

            public override void Debit(double amount)
            {
                if ((balance - amount) >= -CreditLimit)
                    balance -= amount;
                else
                    System.Console.WriteLine("Exceeded student credit limit.");
            }

            public override string ToString() =>
                $"StudentAccount[title={accountTitle}, number={accountNumber}, balance={balance}, CreditLimit={CreditLimit}]";
        }
    }

}
