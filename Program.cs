using System;
using System.Collections.Generic;

namespace SageModeBankOOP
{
    class Program
    {
        static List<Bank> bankList = new List<Bank>();
        static bool shouldexit = false;
        static string tempBankName = string.Empty;
        static string tempBankID = string.Empty;
        static void Main(string[] args)
        {
            while (!shouldexit)
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
    }
}
