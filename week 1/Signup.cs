using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Login
{
    internal class Signup
    {
        static void Main(string[] args)
        {
            string[] userName = new string[10];
            string[] passWord = new string[10];
            string[] Name = new string[10];
            string[] Age = new string[10];
            int count = 0;
            int option;
            while (true)
            {
                int i = 0, j = 0;
                string username, password;
                bool isUserName = false, isPassWord = false;
                Console.WriteLine("Choose one of the following...");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Signup");
                Console.Write("Your option...");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    loadData(userName, passWord, Name, Age, ref count);
                    Console.Write("UserName: ");
                    username = Console.ReadLine();
                    while (i < userName.Length)
                    {
                        if (userName[i] == username)
                        {
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            while (j < passWord.Length)
                            {
                                if (passWord[j] == password)
                                {
                                    isUserName = true;
                                    isPassWord = true;
                                    Console.WriteLine("Login Successful...");
                                }
                                j++;
                            }

                            if (isPassWord)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Password!!!");
                            }
                            isUserName = true;
                        }
                        i++;
                    }
                    if (isUserName == false)
                    {
                        Console.WriteLine("Invalid UserName!!!");
                    }
                }
                else if (option == 2)
                {
                    Console.Write("Enter Name: ");
                    Name[count] = Console.ReadLine();
                    string name = Name[count];
                    while (checkName(name))
                    {
                        Console.WriteLine("Invalid Name...");
                        Console.Write("Enter Name: ");
                        Name[count] = Console.ReadLine();
                        name = Name[count];
                    }
                    Console.Write("Enter age: ");
                    Age[count] = Console.ReadLine();
                    string age = Age[count];
                    while (checkAge(age))
                    {
                        Console.WriteLine("Invalid age...");
                        Console.Write("Enter age: ");
                        Age[count] = Console.ReadLine();
                        age = Age[count];
                    }
                    Console.Write("Enter UserName: ");
                    userName[count] = Console.ReadLine();
                    string chkUserName = userName[count];
                    while (checkUserName(chkUserName))
                    {
                        Console.WriteLine("Invalid username...");
                        Console.Write("Enter UserName: ");
                        userName[count] = Console.ReadLine();
                        chkUserName = userName[count];
                    }
                    Console.Write("Enter password: ");
                    passWord[count] = Console.ReadLine();
                    string pasword = passWord[count];
                    while (checkPassword(pasword))
                    {
                        Console.WriteLine("Invalid PassWord: ");
                        Console.Write("Enter PassWord: ");
                        passWord[count] = Console.ReadLine();
                        pasword = passWord[count];
                    }
                    storeData(Name, Age, userName, passWord, ref count);
                    Console.WriteLine("SignUp Successful...");
                    count += 1;
                }
                else
                {
                    Console.Error.WriteLine("You cannot choose any other number but 1 or 2");
                }
            }
        }
        static void loadData(string[] userName, string[] passWord, string[] Name, string[] Age, ref int count)
        {
            StreamReader fileRead = new StreamReader("data.txt");
            int n = 1;
            string data, word = "";

            while ((data = fileRead.ReadLine()) != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != '~')
                    {
                        word += data[i];
                    }
                    else
                    {
                        if (n == 1)
                        {
                            Name[count] = word;
                        }
                        else if (n == 2)
                        {
                            Age[count] = word;
                        }
                        else if (n == 3)
                        {
                            userName[count] = word;
                        }
                        if (n < 4)
                        {
                            word = "";
                        }
                        n++;
                    }
                }
                passWord[count] = word;
                n = 1;
                word = "";
                count++;
            }
            fileRead.Close();
        }

        static void storeData(String[] Name, string[] Age, string[] userName, string[] passWord, ref int count)
        {
            StreamWriter fileWrite = new StreamWriter("data.txt", true);
            string dataToWrite = Name[count] + "~" + Age[count] + "~" + userName[count] + "~" + passWord[count];
            fileWrite.WriteLine(dataToWrite);
            //fileWrite.Flush();
            fileWrite.Close();

        }
        static bool checkName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '0' || name[i] == '1' || name[i] == '2' || name[i] == '3' || name[i] == '4' || name[i] == '5' || name[i] == '6' || name[i] == '7' || name[i] == '8' || name[i] == '9')
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkAge(string age)
        {
            int age1 = int.Parse(age);
            if (age1 > 100 || age1 <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool checkUserName(string chkUserName)
        {
            for (int i = 0; i < chkUserName.Length; i++)
            {
                if (chkUserName[i] == '0' || chkUserName[i] == '1' || chkUserName[i] == '2' || chkUserName[i] == '3' || chkUserName[i] == '4' || chkUserName[i] == '5' || chkUserName[i] == '6' || chkUserName[i] == '7' || chkUserName[i] == '8' || chkUserName[i] == '9')
                {
                    return false;
                }
            }
            return true;
        }
        static bool checkPassword(string pasword)
        {
            for (int i = 0; i < pasword.Length; i++)
            {
                if (pasword[i] == '0' || pasword[i] == '1' || pasword[i] == '2' || pasword[i] == '3' || pasword[i] == '4' || pasword[i] == '5' || pasword[i] == '6' || pasword[i] == '7' || pasword[i] == '8' || pasword[i] == '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
