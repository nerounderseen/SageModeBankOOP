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
        static decimal tAmount = 0.0M;
        static Account account;
        static Bank bEntity;
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
                        BankGen();
                        break;
                    case '2':
                        RegisterLogin();
                        break;
                    case '3':
                        DisplayBank();
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
        static void BankGen()
        {
            Console.Clear();
            Console.WriteLine("[Generate a Bank]\n");
            Console.Write("Enter Bank Name: ");
            tempBankName = Console.ReadLine().ToUpper().Trim();
            Console.Write("Create a Unique Identifier Key: ");
            tempBankID = Console.ReadLine().Trim();
            if ((bankList.Exists(x => x.name == null)) && (bankList.Exists(x => x.id == null)))
            {
                Console.Clear();
                Console.WriteLine("[Generate a Bank]\n");
                Console.Write("Bank Name/ID Empty");
                Console.ReadLine();
            }
            else if ((bankList.Exists(x => x.name == tempBankName)) || (bankList.Exists(x => x.id == tempBankID)))
            {
                Console.Clear();
                Console.WriteLine("[Generate a Bank]\n");
                Console.Write("Bank Name/ID Exists");
                Console.ReadLine();
            }
            else
            {
                bankList.Add(new Bank { name = tempBankName, id = tempBankID });
                Console.Clear();
                Console.WriteLine("[Generate a Bank]\n");
                Console.Write("Added Bank in Terminal");
                Console.ReadLine();
            }
        }
        static void RegisterLogin()
        {
            if (bankList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("[Register/Login an Account]\n");
                Console.Write("Enter Name Bank: ");
                tempSelectBank = Console.ReadLine().ToUpper();
                bEntity = GetBank(tempSelectBank);
                if (bEntity != null)
                {
                    bool shouldExit = false;
                    while (!shouldExit)
                    {
                        Console.Clear();
                        Console.WriteLine($"[Welcome to {bEntity.name}]\n");
                        switch (ShowMenu("[Register an Account]", "[Login]", "Exit"))
                        {
                            case '1':
                                RegisterAcc();
                                break;
                            case '2':
                                LoginAcc();
                                break;
                            case '3':
                                shouldExit = true;
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Banking Terminal\n");
                    Console.Write("ERROR: SELECTED BANK NOT FOUND");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Banking Terminal\n");
                Console.Write("Register a Bank before Registering/Logging in to an Account...");
                Console.ReadKey();
            }
        }
        static void RegisterAcc()
        {
            Console.Clear();
            Console.WriteLine("[Registration]");
            Console.Write("Enter username: ");
            tempUsername = Console.ReadLine().Trim();
            if (bEntity.IsAccountExist(tempUsername))
            {
                Console.Clear();
                Console.WriteLine($"[Welcome to {bEntity.name}]\n");
                Console.Write("[Username already in use...]");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Enter password: ");
                tempPassword = Console.ReadLine().Trim();
                bEntity.Registration(tempUsername, tempPassword);
            }
        }
        static void LoginAcc()
        {
            Console.Clear();
            Console.WriteLine("[Login]");
            Console.Write("Enter username: ");
            tempUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            tempPassword = Console.ReadLine();
            account = bEntity.Login(tempUsername, tempPassword);
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
                            ShowDeposit();
                            break;
                        case '2':
                            ShowWithdrawal();
                            break;
                        case '3':
                            ShowTransfer();
                            break;
                        case '4':
                            ShowTransHist();
                            break;
                        case '5':
                            shouldLogout = true;
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("[Login]");
                Console.Write("ERROR: INCORRECT USERNAME/PASSWORD");
                Console.ReadKey();
            }
        }
        static void ShowDeposit()
        {
            Console.Clear();
            Console.WriteLine("DEPOSIT");
            Console.Write("Enter Deposit Amount: ");
            if (decimal.TryParse(Console.ReadLine(), out tAmount))
            {
                if (tAmount > 0.00m)
                    account.Deposit(tAmount);
                else
                {
                    Console.Write("ERROR: NOT A VALID AMOUNT");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("DEPOSIT");
                Console.Write("ERROR: INPUT NOT A DECIMAL VALUE");
                Console.ReadKey();
            }
        }
        static void ShowWithdrawal()
        {
            Console.Clear();
            Console.WriteLine("WITHDRAW");
            Console.Write("Enter Withdrawal Amount: ");
            if (decimal.TryParse(Console.ReadLine(), out tAmount))
            {
                if (tAmount < account.balance)
                    account.Withdraw(tAmount);
                else
                {
                    Console.Write("ERROR: INSUFFICIENT FUNDS");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("WITHDRAW");
                Console.Write("ERROR: INPUT NOT A DECIMAL VALUE");
                Console.ReadKey();
            }
        }
        static void ShowTransfer()
        {
            Console.Clear();
            Console.WriteLine("TRANSFER");
            Console.Write("Enter Account ID #: ");
            int receiverId;
            if (int.TryParse(Console.ReadLine(), out receiverId))
            {
                Console.Write("Enter Amount to be Transfered: ");
                if (decimal.TryParse(Console.ReadLine(), out tAmount))
                {
                    if (tAmount < account.balance && tAmount > 0)
                    {
                        bEntity.Transfer(account, tAmount, receiverId);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("TRANSFER");
                        Console.WriteLine("ERROR: AMOUNT NOT POSSIBLE FOR TRANSFER");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("TRANSFER");
                    Console.Write("ERROR: INPUT NOT A DECIMAL VALUE");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("TRANSFER");
                Console.Write("ERROR: ID NOT FOUND...");
                Console.ReadKey();
            }
        }
        static void ShowTransHist()
        {
            Console.Clear();
            Console.WriteLine("TRANSACTIONS");
            Console.WriteLine("Type\tDate & Time\t\tAmount\tBalance\tUser\tBank");
            foreach (Transaction record in account.ShowTx())
            {
                string convertName = (record.Target != null ? record.Target.username : "");
                Console.WriteLine($"{record.Type}\t{record.Date}\t{record.Amount}\t{record.Balance}\t{convertName}");
            }
            Console.ReadKey();
        }
        static void DisplayBank()
        {
            Console.Clear();
            Console.WriteLine("Banking Terminal\n");
            Console.WriteLine("Bank Name\t\tBank ID");
            if (bankList.Count > 0)
            {
                foreach (var bank in bankList)
                {
                    Console.Write($"{bank.name}\t\t\t{bank.id}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Banking Terminal\n");
                Console.Write("No Registered Bank Available to Display...");
            }
            Console.ReadKey();
        }
        static Bank GetBank(string bankname)
        {
            foreach (Bank bank in bankList)
            {
                if (bank.name != null && bank.name == bankname)
                    return bank;
            }
            return null;
        }
    }
}
