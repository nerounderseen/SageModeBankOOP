namespace SageModeBankOOP
{
    class Account
    {
        private int _xCounter = 0;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        private Transaction[] Transactions { get; set; }
        public Account()
        {
            Transactions = new Transaction[1000];
            Balance = Balance;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            AddTransactions("DPST", amount);
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            AddTransactions("WTHDRW", amount);
        }
        public void AddTransactions(string type, decimal amount)
        {
            Transactions[_xCounter] = new Transaction
            {
                Type = type,
                Amount = amount,
                Balance = Balance
            };
            _xCounter++;
        }

        public Transaction[] DuplicateArray()
        {
            Transaction[] CopiedTransArray = new Transaction[_xCounter];
            for (int i = 0; i < _xCounter; i++)
            {
                CopiedTransArray[i] = Transactions[i];
            }
            return CopiedTransArray;
        }
    }
}