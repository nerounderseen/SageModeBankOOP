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
        static decimal tAmount
         = 0.0M;
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
                                                            Console.Clear();
                                                            Console.WriteLine("DEPOSIT");
                                                            Console.Write("Enter Deposit Amount: ");
                                                            if (decimal.TryParse(Console.ReadLine(), out tAmount
                                                            ))
                                                            {
                                                                if (tAmount
                                                                 > 0.00m)
                                                                    account.Deposit(tAmount
                                                                    );
                                                                else
                                                                {
                                                                    Console.Write("Please Enter a Valid Amount");
                                                                    Console.ReadLine();
                                                                }
                                                            }
                                                            break;
                                                        case '2':
                                                            Console.Clear();
                                                            Console.WriteLine("WITHDRAW");
                                                            Console.Write("Enter Withdrawal Amount: ");
                                                            if (decimal.TryParse(Console.ReadLine(), out tAmount
                                                            ))
                                                            {
                                                                if (tAmount
                                                                 < account.balance)
                                                                    account.Withdraw(tAmount
                                                                    );
                                                                else
                                                                {
                                                                    Console.Write("Insufficient Funds/Incorrect Input");
                                                                    Console.ReadLine();
                                                                }
                                                            }
                                                            break;
                                                        case '3':
                                                            Console.Clear();
                                                            Console.WriteLine("TRANSFER");
                                                            Console.Write("Enter Account ID #: ");
                                                            int receiverId = -1;
                                                            if (int.TryParse(Console.ReadLine(), out receiverId))
                                                            {
                                                                Console.Write("Enter Amount to be Transfered: ");
                                                                if (decimal.TryParse(Console.ReadLine(), out tAmount
                                                                ))
                                                                {
                                                                    if (tAmount
                                                                     < account.balance && tAmount
                                                                     > 0)
                                                                    {
                                                                        bEntity.Transfer(account, tAmount
                                                                        , receiverId);
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Amount Entered is not Possible for Transfer");
                                                                        Console.ReadLine();
                                                                    }
                                                                }
                                                            }
                                                                break;
                                                        case '4':
                                                            Console.Clear();
                                                            Console.WriteLine("TRANSACTIONS");
                                                            Console.WriteLine("Type\tDate & Time\t\tAmount\tBalance\tUser");
                                                            foreach (Transaction record in account.ShowTx())
                                                            {
                                                                string convertName = (record.Target != null ? record.Target.username : "");
                                                                Console.WriteLine($"{record.Type}\t{record.Date}\t{record.Amount}\t{record.Balance}\t{convertName}");
                                                            }
                                                            Console.ReadKey();
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
                                Console.Write($"{bank._name}\t\t\t{bank._id}");
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
