namespace SageModeBankOOP
{
    class Bank
    {
        private int _TotalAccountsRegistered { get; set; }
        private string _name = "Bank";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = "BANK" + value;
            }
        }
        private Account[] newAccounts { get; set; }
        public Bank()
        {
            newAccounts = new Account[100];
            _TotalAccountsRegistered = 0;
        }
        public void Register(string rUsername, string rPassword, string rFirstname, string rLastname)
        {
            newAccounts[_TotalAccountsRegistered] = new Account
            {
                Id = _TotalAccountsRegistered,
                Username = rUsername,
                Password = rPassword,
                Firstname = rFirstname,
                Lastname = rLastname,
                Balance = 0
            };
            _TotalAccountsRegistered++;
        }
        public Account Login(string lUsername, string lPassword)
        {
            foreach (Account accnt in newAccounts)
            {
                if (accnt != null && accnt.Username == lUsername && accnt.Password == lPassword)
                    return accnt;
            }
            return null;
        }
        public bool IsAccountExist(string xUsername)
        {
            foreach (Account accnt in newAccounts)
            {
                if (accnt != null && accnt.Username == xUsername)
                    return true;
            }
            return false;
        }
        public void Transfer(Account srcAccnt, decimal value, int trgtAccntID)
        {
            Account dstAccnt = newAccounts[trgtAccntID];
            srcAccnt.Balance -= value;
            srcAccnt.AddTransactions("OUT", value, dstAccnt);
            dstAccnt.Balance += value;
            dstAccnt.AddTransactions("IN", value, srcAccnt);
        }
    }
}