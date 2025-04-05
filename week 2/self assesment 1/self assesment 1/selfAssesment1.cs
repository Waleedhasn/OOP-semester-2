using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment_1
{
    class Transaction
    {
        public int TransactionId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


        public Transaction(int transactionId, string productName, double amount, string date, string time)
        {
            TransactionId = transactionId;
            ProductName = productName;
            Amount = amount;
            Date = date;
            Time = time;
        }


        public Transaction(Transaction existingTransaction)
        {
            TransactionId = existingTransaction.TransactionId;
            ProductName = existingTransaction.ProductName;
            Amount = existingTransaction.Amount;
            Date = existingTransaction.Date;
            Time = existingTransaction.Time;
        }


        public void DisplayTransaction()
        {
            Console.WriteLine($"Transaction ID: {TransactionId}, Product: {ProductName}, Amount: {Amount}, Date: {Date}, Time: {Time}");
        }
    }

    class selfteast1
    {
        static void Main()
        {

            Transaction originalTransaction = new Transaction(101, "Laptop", 1200.50, "2025-01-29", "14:30");


            Transaction copiedTransaction = new Transaction(originalTransaction);


            originalTransaction.ProductName = "Gaming Laptop";
            originalTransaction.Amount = 1500.75;
            copiedTransaction.ProductName = "Ultrabook";
            copiedTransaction.Amount = 1100.25;


            Console.WriteLine("Original Transaction:");
            originalTransaction.DisplayTransaction();

            Console.WriteLine("\nCopied Transaction:");
            copiedTransaction.DisplayTransaction();

        }
    }
}