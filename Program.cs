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
            bool shouldLogOut = false;
            decimal value = 0.00m;
            Bank b = new Bank();
            b.Name = "BANK.ko";
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to {b.Name}");
                switch (ShowMenu("Register", "Login", "Exit"))
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("[Registration]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        if (b.IsAccountExist(tempUsername))
                        {
                            Console.WriteLine("Account already exist...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("Please enter your password: ");
                            tempPassword = Console.ReadLine();
                            b.Register(tempUsername, tempPassword);
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("[Login]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        Console.Write("Please enter your password: ");
                        tempPassword = Console.ReadLine();
                        var account = b.Login(tempUsername, tempPassword);
                        if (account != null)
                        {
                            while (!shouldLogOut)
                            {
                                Console.Clear();
                                Console.WriteLine($"Welcome {account.Username}");
                                Console.WriteLine($"Available Balance {account.Balance}");
                                switch (ShowMenu("Deposit", "Withdraw", "Transfer", "Transactions", "Exit"))
                                {
                                    case '1':
                                        Console.Clear();
                                        Console.WriteLine("DEPOSIT");
                                        Console.Write("Enter Deposit Amount: ");
                                        if (decimal.TryParse(Console.ReadLine(), out value))
                                        {
                                            if (value > 0.00m)
                                                account.Deposit(value);
                                        }
                                            Console.Write("Invalid Amount");
                                            Console.ReadLine();
                                        break;
                                    case '2':
                                        Console.Clear();
                                        Console.WriteLine("WITHDRAW");
                                        Console.Write("Enter Withdrawal Amount: ");
                                        if (decimal.TryParse(Console.ReadLine(), out value))
                                        {
                                            if (value < account.Balance)
                                                account.Withdraw(value);
                                        }
                                            Console.Write("Insufficient Funds");
                                            Console.ReadLine();
                                        break;
                                    case '3':
                                        Console.WriteLine("TRANSFER");
                                        break;
                                    case '4':
                                        Console.WriteLine("TRANSACTIONS");
                                        break;
                                    case '5':
                                        shouldLogOut = true;
                                        break;
                                    default:
                                        break;
                                }
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

            /*             static decimal InputValue()
                        {

                        } */
        }
    }
}