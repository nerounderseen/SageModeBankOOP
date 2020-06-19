using System;
using System.Collections.Generic;

namespace SageModeBankOOP

{
    class Bank
    {
        private int _totalAccountsRegistered = 0;
        public string _name { get; set; }
        public string _id { get; set; }
        private Account[] newAccounts { get; set; }
        public Bank()
        {
            newAccounts = new Account[10];
            _totalAccountsRegistered = 0;
        }
        public void Registration(string uname, string pword)
        {
            newAccounts[_totalAccountsRegistered] = new Account
            {
                id = _totalAccountsRegistered,
                username = uname,
                password = pword,
                balance = 0
            };
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
    }
}