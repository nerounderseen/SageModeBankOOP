using System;

namespace SageModeBankOOP
{
    class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public Transaction[] Transactions { get; set; }


        public Account()
        {
            Transactions = new Transaction[1000];
        }

        public void Withdraw(decimal amount)
        {
            /*              if (decimal.TryParse(Console.ReadLine(), out wAmount))
                        {
                            if (wAmount > balances[currentAccountIndex])
                            {
                                Console.WriteLine("Not enough funds!");
                                Console.ReadKey();
                            }
                            else
                            {
                                balances[currentAccountIndex] -= wAmount;
                                ledger[currentAccountIndex] += $"WTH\t\t{DateTime.Now}\t\tP {wAmount}\tP {balances[currentAccountIndex]}\n";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Amount!");
                            Console.ReadKey();
                        } */
        }

        public void Deposit(decimal amount)
        {
            balances[currentAccountIndex] += dAmount;
        }

        public void Transfer(Account receiverAcc)
        {
            /*             Console.WriteLine("[Transfer to another account]");
                        Console.Write("Enter Account Id: ");
                        int receiverId = -1;
                        if (int.TryParse(Console.ReadLine(), out receiverId))
                        {
                            if (receiverId >= 0 && receiverId < MAX_ACCOUNTS && usernames[receiverId] != null)
                            {
                                Console.Write("Enter the amount to transfer: ");
                                decimal tAmount = 0;
                                if (decimal.TryParse(Console.ReadLine(), out tAmount))
                                {
                                    balances[currentAccountIndex] -= tAmount;
                                    ledger[currentAccountIndex] += $"TRO\t\t{DateTime.Now}\t\tP {tAmount}\tP {balances[currentAccountIndex]}\n";
                                    balances[receiverId] += tAmount;
                                    ledger[receiverId] += $"TRI\t\t{DateTime.Now}\t\tP {tAmount}\tP {balances[receiverId]}\n";
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Amount!");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Account Id");
                                Console.ReadKey();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Account Id");
                            Console.ReadKey();
                        } */
        }
    }
}