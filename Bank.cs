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
                _name = value + " Bank";
            }
        }
        private Account[] newAccounts { get; set; }
        public Bank()
        {
            newAccounts = new Account[100];
            _TotalAccountsRegistered = 0;
        }
        public void Register(string rUsername, string rPassword)
        {
            newAccounts[_TotalAccountsRegistered] = new Account
            {
                Id = _TotalAccountsRegistered,
                Username = rUsername,
                Password = rPassword,
                Balance = 0
            };
            _TotalAccountsRegistered++;
        }
        public Account Login(string rUsername, string rPassword)
        {
            if (IsAccountExist(rUsername))
            {
                foreach (Account accnt in newAccounts)
                {
                    if (accnt != null && accnt.Username == rUsername && accnt.Password == rPassword)
                        return accnt;
                }
            }
            return null;
        }
        public bool IsAccountExist(string rUsername)
        {
            foreach (Account accnt in newAccounts)
            {
                if (accnt != null && accnt.Username == rUsername)
                    return true;
            }
            return false;
        }
        public void Transfer(Account srcAccnt, decimal value, int trgtAccntID)
        {
            Account dstAccnt = newAccounts[trgtAccntID];
            srcAccnt.Balance -= value;
            dstAccnt.Balance += value;
        }
    }
}