namespace SageModeBankOOP
{
    class Account
    {
        private int _counter = 0;
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public decimal balance { get; set; }
        private Transaction[] Transactions { get; set; }
        public Account()
        {
            Transactions = new Transaction[10];
            balance = balance;
        }
        public void Deposit(decimal amount)
        {
            balance += amount;
            AddTransactions("DPST", amount, this);
        }
        public void Withdraw(decimal amount)
        {
            balance -= amount;
            AddTransactions("WTHDRW", amount);
        }
        public void AddTransactions(string type, decimal amount, Account target = null)
        {
            Transactions[_counter] = new Transaction
            {
                Type = type,
                Amount = amount,
                Balance = balance,
                Target = target
            };
            _counter++;
        }
    }
}