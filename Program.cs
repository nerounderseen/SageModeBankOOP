using System;
using System.Collections.Generic;

namespace SageModeBankOOP
{
    class Program
    {
        static List<Bank> bankList = new List<Bank>();
        static bool shouldExit = false;
        static string tempBankName = string.Empty;
        static string tempBankID = string.Empty;
        static string tempSelectBank = string.Empty;
        static string tempUsername = string.Empty;
        static string tempPassword = string.Empty;
        static void Main(string[] args)
        {
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("Banking Terminal\n");
                Console.WriteLine("Please select an Option");
                switch (ShowMenu("[Register a Bank]", "[Register/Login an Account]", "[Display Bank List]", "[Exit]"))
                {
                    case '1':
                        {
                            Console.Clear();
                            Console.WriteLine("[Generate a Bank]\n");
                            Console.Write("Enter Bank Name: ");
                            tempBankName = Console.ReadLine().ToUpper();
                            Console.Write("Create a Unique Identifier Key: ");
                            tempBankID = Console.ReadLine();
                            bankList.Add(new Bank { _name = tempBankName, _id = tempBankID });
                        }
                        break;
                    case '2':
                        {
                            Console.Clear();
                            Console.WriteLine("[Register/Login an Account]\n");
                            Console.Write("Enter Name Bank: ");
                            tempSelectBank = Console.ReadLine().ToUpper();
                            var bEntity = GetBank(tempSelectBank);
                            if (bEntity != null)
                            {
                                bool shouldExit = false;
                                while (!shouldExit)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"[Welcome to {bEntity._name}]\n");
                                    switch (ShowMenu("[Register an Account]", "[Login]", "Exit"))
                                    {
                                        case '1':
                                            Console.Clear();
                                            Console.WriteLine("[Registration]");
                                            Console.Write("Enter username: ");
                                            tempUsername = Console.ReadLine();
                                            Console.Write("Enter password: ");
                                            tempPassword = Console.ReadLine();
                                            Console.Write("Register - Firstname: ");
                                            bEntity.Registration(tempUsername, tempPassword);
                                            break;
                                        case '2':
                                            Console.Clear();
                                            Console.WriteLine("[Login]");
                                            Console.Write("Enter username: ");
                                            tempUsername = Console.ReadLine();
                                            Console.Write("Enter password: ");
                                            tempPassword = Console.ReadLine();
                                            var account = bEntity.Login(tempUsername, tempPassword);
                                            if (account != null)
                                            {
                                                bool shouldLogout = false;
                                                while (!shouldLogout)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine($"Welcome {account.username}");
                                                    Console.WriteLine($"User Account ID: {account.id}");
                                                    Console.WriteLine($"Available Balance: {account.balance}\n\n");
                                                    switch (ShowMenu("Deposit", "Withdraw", "Transfer", "Transactions", "Logout"))
                                                    {
                                                        case '1':
                                                            break;
                                                        case '2':
                                                            break;
                                                        case '3':
                                                            break;
                                                        case '4':
                                                            break;
                                                        case '5':
                                                            shouldLogout = true;
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                        case '3':
                                            shouldExit = true;
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Banking Terminal\n");
                        Console.WriteLine("Bank Name\t\tBank ID");
                        if (bankList.Count > 0)
                        {
                            foreach (var bank in bankList)
                            {
                                Console.WriteLine($"{bank._name}\t\t\t{bank._id}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Banking Terminal\n");
                            Console.Write("No Registered Bank Available to Display...");
                        }
                        Console.ReadLine();
                        break;
                    case '4':
                        shouldExit = true;
                        break;
                }
            }
        }
        static char ShowMenu(params string[] items)
        {
            string menuString = "Press ";
            for (int i = 0; i < items.Length; i++)
            {
                string postFix = i == items.Length - 1 ? string.Empty : ", ";
                menuString += $"{i + 1} to {items[i]}{postFix}";
            }
            Console.Write($"{menuString}: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            return key.KeyChar;
        }
        static Bank GetBank(string bankname)
        {
            foreach (Bank bank in bankList)
            {
                if (bank._name != null && bank._name == bankname)
                    return bank;
            }
            return null;
        }
    }
}
