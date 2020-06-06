using System;

namespace SageModeBankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempUsername = string.Empty;
            string tempPassword = string.Empty;
            bool shouldExit = false;
            Bank A = new Bank();
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to Bank");
                switch (ShowMenu("Register", "Login", "Exit"))
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("[Registration]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        if (A.IsAccountExist(tempUsername))
                        {
                            Console.WriteLine("Account already exist...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("Please enter your password: ");
                            tempPassword = Console.ReadLine();
                            A.Register(tempUsername, tempPassword);
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("[Login]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        Console.Write("Please enter your password: ");
                        tempPassword = Console.ReadLine();
                        if (A.Login(tempUsername, tempPassword))
                        {
                            switch (ShowMenu("Deposit", "Withdraw", "Transfer", "Exit"))
                            {
                                case '1':
                                    Console.Write("Enter Deposit Amount: ");
                                    decimal value = 0;
                                    if (decimal.TryParse(Console.ReadLine(), out value))
                                    {
                                        balances[currentAccountIndex] += dAmount;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed!");
                            Console.ReadLine();
                        }
                        break;
                    case '3':
                        Console.WriteLine("Good bye!!!");
                        shouldExit = true;
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
        }
    }
}
