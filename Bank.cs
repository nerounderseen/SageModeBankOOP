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
        public Account Login(string username, string password)
        {
            if (IsAccountExist(username))
            {
                foreach (Account account in Accounts)
                {
                    if (account != null && account.Username == username && account.Password == password)
                        return account;
                }
            }
            return null;
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
        public void Transfer(Account srcAccnt, decimal value, int trgtAccntID)
        {
            Account dstAccnt = Accounts[trgtAccntID];
            srcAccnt.Balance -= value;
            dstAccnt.Balance += value;
        }
    }
}