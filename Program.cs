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
            decimal value = 0.00m;
            Bank b = new Bank();
            b.Name = ".ko";
            while (!shouldExit)
            {
                //Welcome Screen
                Console.Clear();
                Console.WriteLine($"Welcome to {b.Name}");
                switch (ShowMenu("Register", "Login", "Exit"))
                {
                    //Registration
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
                        //Login
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
                            //If successful Login
                            bool shouldLogOut = false;
                            while (!shouldLogOut)
                            {
                                Console.Clear();
                                Console.WriteLine($"Welcome {account.Username}");
                                Console.WriteLine($"User Account ID: {account.Id}");
                                Console.WriteLine($"Available Balance {account.Balance}");
                                switch (ShowMenu("Deposit", "Withdraw", "Transfer", "Transactions", "Exit"))
                                {
                                    case '1':
                                        //Error Handling needed
                                        Console.Clear();
                                        Console.WriteLine("DEPOSIT");
                                        Console.Write("Enter Deposit Amount: ");
                                        if (decimal.TryParse(Console.ReadLine(), out value))
                                        {
                                            if (value > 0.00m)
                                                account.Deposit(value);
                                            else
                                            {
                                                Console.Write("Please Enter a Valid Amount");
                                                Console.ReadLine();
                                            }
                                        }
                                        break;
                                    case '2':
                                        //Error Handling needed
                                        Console.Clear();
                                        Console.WriteLine("WITHDRAW");
                                        Console.Write("Enter Withdrawal Amount: ");
                                        if (decimal.TryParse(Console.ReadLine(), out value))
                                        {
                                            if (value < account.Balance)
                                                account.Withdraw(value);
                                            else
                                            {
                                                Console.Write("Insufficient Funds/Incorrect Input");
                                                Console.ReadLine();
                                            }
                                        }
                                        break;
                                    case '3':
                                        //Transfer Funds - need to optimize
                                        Console.Clear();
                                        Console.WriteLine("TRANSFER");
                                        Console.Write("Enter Account ID #: ");
                                        int receiverId = -1;
                                        if (int.TryParse(Console.ReadLine(), out receiverId))
                                        {
                                            Console.Write("Enter Amount to be Transfered: ");
                                            if (decimal.TryParse(Console.ReadLine(), out value))
                                            {
                                                if (value < account.Balance && value > 0)
                                                {
                                                    b.Transfer(account, value, receiverId);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Amount Entered is not Possible for Transfer");
                                                    Console.ReadLine();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter a Valid Account ID #");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case '4':
                                        //Check Transaction History - need to optimize
                                        Console.Clear();
                                        Console.WriteLine("TRANSACTIONS");
                                        Console.WriteLine("Type\tDate & Time\t\tAmount\tBalance");
                                        foreach (Transaction record in account.DuplicateArray())
                                        {
                                            Console.WriteLine($"{record.Type}\t{record.Date}\t{record.Amount}\t{record.Balance}");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case '5':
                                        //Logout Logged-in User
                                        shouldLogOut = true;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            //If unsuccessful Login
                            Console.WriteLine("Incorrect Username/Password!");
                            Console.ReadLine();
                        }
                        break;
                    case '3':
                        //Program Terminate
                        Console.WriteLine("Thank you for your Patronage!!!");
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