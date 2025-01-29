#include <iostream>
using namespace std;

int bankBalance = 1000000; 
int customerBalance = 5000; 

void costumer();
void bank();
void bankAccount();
void deposit();
void loan();
void withdraw();
void zakat();
main()
{
    int option;
    while(true)
    {
    cout << "1. Costumer menu" << endl;
    cout << "2. Bank menu" << endl;
    cout << "Enter your option: ";
    cin >> option;
    if (option == 1)
    {
        costumer();
    }
    if (option == 2)
    {
        bank();
    }
        if (option == 3)
    {
        break;
    }
}

}
void costumer()
{
  system("cls");
  int option;
  cout <<"1. View Bank Account"<<endl;
  cout <<"2. Deposit money "<<endl;
  cout <<"3. Withdraw money "<<endl;
  cout <<"4. Get Loan"<<endl;
  cin >> option;
      if (option == 1)
    {
        bankAccount();
    }
    if (option == 2)
    {
        deposit();
    }
        if (option == 3)
    {
        withdraw();
    }
    if (option == 4)
    {
        loan();
    }

}
void bank()
{
  system("cls");
  int option;
   cout <<"1. View Bank Money"<<endl;
   cout <<"2. Give Loan"<<endl;
   cout <<"3. Deduct Zakat"<<endl;
   cin >> option;
       if (option == 1)
    {
       bankAccount();
    }
    if (option == 2)
    {
        loan();
    }
        if (option == 3)
    {
        zakat();
    }
    if (option == 4)
    {
        bank();
    }

}
void deposit()
{
    double amount;
    cout << "Enter amount to deposit: ";
    cin >> amount;

    if (amount <= 0)
    {
        cout << "Invalid amount. Deposit failed." << endl;
        return;
    }

    customerBalance += amount;
    bankBalance += amount;
    cout << "Deposit successful. Your new balance is: $" << customerBalance << endl;
}

void loan()
{
    double loanAmount;
    cout << "Enter loan amount: ";
    cin >> loanAmount;

    if (loanAmount <= 0 || loanAmount > bankBalance / 2)
    {
        cout << "Loan cannot be granted. Insufficient bank funds or invalid amount." << endl;
        return;
    }

    customerBalance += loanAmount;
    bankBalance -= loanAmount;
    cout << "Loan approved. Your new balance is: $" << customerBalance << endl;
}

void withdraw()
{
    double amount;
    cout << "Enter amount to withdraw: ";
    cin >> amount;

    if (amount <= 0 || amount > customerBalance)
    {
        cout << "Invalid amount or insufficient balance. Withdrawal failed." << endl;
        return;
    }

    customerBalance -= amount;
    bankBalance -= amount;
    cout << "Withdrawal successful. Your new balance is: $" << customerBalance << endl;
}

void zakat()
{
    double zakatAmount = customerBalance * 0.025;
    if (zakatAmount > customerBalance)
    {
        cout << "Insufficient balance to deduct Zakat." << endl;
        return;
    }

    customerBalance -= zakatAmount;
    bankBalance += zakatAmount;
    cout << "Zakat deducted: $" << zakatAmount << endl;
    cout << "Your new balance is: $" << customerBalance << endl;
}
void bankAccount()
{
  system("cls");
  cout << "$"<< customerBalance << endl;
}

