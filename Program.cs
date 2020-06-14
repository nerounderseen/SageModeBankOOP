using System;
using System.Collections.Generic;

namespace SageModeBankOOP
{
    class Program
    {
        public static List<Bank> BankList = new List<Bank>();
        static bool ShouldTerminate = false;
        static string tempBankName = String.Empty;
        static string tempBankID = String.Empty;
        static void Main(string[] args)
        {

            while (!ShouldTerminate)
            {
                Console.Clear();
                Console.WriteLine("Banking Terminal\n");
                Console.WriteLine("Please select an Option");
                switch (ShowMenu("[Register a Bank]", "[Register/Login an Account]", "[Display Bank List]", "[Exit]"))
                {
                    case '1':
                        BankGenerate();
                        break;
                    case '2':
                        RegisterLogin();
                        break;
                    case '3':
                        ShowBankList();
                        break;
                    case '4':
                        ShouldTerminate = true;
                        break;
                    default:
                        break;
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

            static void BankGenerate()
            {
                Console.Clear();
                Console.WriteLine("[Generate a Bank]\n");
                Console.Write("Enter Bank Name: ");
                tempBankName = Console.ReadLine().ToUpper();
                Console.Write("Create a Unique Identifier Key: ");
                tempBankID = Console.ReadLine();
                if (BankList.Exists(x => x.BankName == tempBankName))
                {
                    Console.Clear();
                    Console.WriteLine("[Generate a Bank]\n");
                    Console.Write("Bank Name Exists");
                    Console.ReadLine();
                }
                else if (BankList.Exists(x => x.BankID == tempBankID))
                {
                    Console.Clear();
                    Console.WriteLine("[Generate a Bank]\n");
                    Console.Write("Bank ID Exists");
                    Console.ReadLine();
                }
                else
                {
                    RegisterBank();
                }
            }

            static void RegisterBank()
            {
                Console.Clear();
                BankList.Add(new Bank {BankName = tempBankName, BankID = tempBankID});
                Console.WriteLine("[Generate a Bank]\n");
                Console.WriteLine("Succefully Registered BankList Details");
                Console.ReadKey();
            }

            static void RegisterLogin()
            {
                if (BankList.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Banking Terminal\n");
                    Console.Write("Enter Bank ID: ");
                    tempBankID = Console.ReadLine();
                    if (BankList.Exists(x => x.BankID == tempBankID))
                    {
                        Console.Clear();
                        GetBank();
                        Console.WriteLine("Banking Terminal\n");
                        Console.WriteLine("Success!");
                        Console.WriteLine($"Welcome To ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Banking Terminal\n");
                        Console.WriteLine("Enter a Valid Bank Name or Bank ID");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Banking Terminal\n");
                    Console.Write("[Register a Bank] before [Registering an Account].");
                    Console.ReadKey();
                }
            }

            static void ShowBankList()
            {
                Console.Clear();
                Console.WriteLine("Banking Terminal\n");
                Console.WriteLine("Bank Name\t\tBank ID");
                if (BankList.Count > 0)
                {
                    foreach (var bank in BankList)
                    {
                        Console.WriteLine($"{bank.BankName}\t\t\t{bank.BankID}");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Banking Terminal\n");
                    Console.Write("No Registered Bank Available to Display...");
                }
                Console.ReadLine();
            }

            static Bank GetBank()
            {
                foreach (Bank bank in BankList)
                {
                    if (bank.BankID != null && bank.BankID == tempBankID)
                        return bank;
                }
                return null;
            }
        }
    }
}