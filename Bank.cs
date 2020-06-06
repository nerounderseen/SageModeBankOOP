using System;

namespace SageModeBankOOP
{
    class Bank
    {
        private int _TotalAccountsRegistered { get; set; }

        private Account[] Accounts { get; set; }

        public Bank()
        {
            Accounts = new Account[100];
            _TotalAccountsRegistered = 0;
        }

        public void Register(string username, string password)
        {
            Accounts[_TotalAccountsRegistered] = new Account
            {
                Id = _TotalAccountsRegistered,
                Username = username,
                Password = password,
                Balance = 0
            };
            _TotalAccountsRegistered++;
        }

        public bool Login(string username, string password)
        {
            foreach (Account account in Accounts)
            {
                if (account.Username == username && account.Password == password)
                    return true;
            }
            return false;
        }

        public bool IsAccountExist(string username)
        {
            foreach (Account account in Accounts)
            {
                if (account != null && account.Username == username)
                    return true;
            }
            return false;
        }

        public void Transfer()
        {

        }
    }
}