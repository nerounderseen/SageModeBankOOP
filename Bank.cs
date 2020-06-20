using System;
using System.Collections.Generic;

namespace SageModeBankOOP

{
    class Bank
    {
        private int _totalAccountsRegistered = 0;
        private int _sizeIncrease = 5;
        public string name { get; set; }
        public string id { get; set; }
        private Account[] newAccounts { get; set; }
        public Bank()
        {
            newAccounts = new Account[2];
            _totalAccountsRegistered = 0;
        }
        public void Registration(string uname, string pword)
        {
            if (_totalAccountsRegistered < newAccounts.Length)
            {
                newAccounts[_totalAccountsRegistered] = new Account
                {
                    id = _totalAccountsRegistered,
                    username = uname,
                    password = pword,
                    balance = 0
                };
            }
            else
            {
                Account[] TempAccounts = new Account[newAccounts.Length + _sizeIncrease];
                for (int x = 0; x < _totalAccountsRegistered; x++)
                {
                    TempAccounts[x] = newAccounts[x];
                }
                newAccounts = TempAccounts;
                newAccounts[_totalAccountsRegistered] = new Account
                {
                    id = _totalAccountsRegistered,
                    username = uname,
                    password = pword,
                    balance = 0
                };
            }
            _totalAccountsRegistered++;
        }
        public Account Login(string lUsername, string lPassword)
        {
            foreach (Account accnt in newAccounts)
            {
                if (accnt != null && accnt.username == lUsername && accnt.password == lPassword)
                    return accnt;
            }
            return null;
        }
        public bool IsAccountExist(string xUsername)
        {
            foreach (Account accnt in newAccounts)
            {
                if (accnt != null && accnt.username == xUsername)
                    return true;
            }
            return false;
        }
        public void Transfer(Account srcAccnt, decimal amount, int trgtAccntID)
        {
            Account dstAccnt = newAccounts[trgtAccntID];
            srcAccnt.balance -= amount;
            srcAccnt.AddTransactions("OUT", amount, dstAccnt);
            dstAccnt.balance += amount;
            dstAccnt.AddTransactions("IN", amount, srcAccnt);
        }
    }
}