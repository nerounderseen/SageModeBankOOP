namespace SageModeBankOOP
{
    class Account
    {
        private int _counter;
        private int _sizeIncrease = 2;
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public decimal balance { get; set; }
        private Transaction[] Transactions { get; set; }
        public Account()
        {
            Transactions = new Transaction[2];
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
            if (_counter < Transactions.Length)
            {
                Transactions[_counter] = new Transaction
                {
                    Type = type,
                    Amount = amount,
                    Balance = balance,
                    Target = target
                };
            }
            else
            {
                Transaction[] TempTransaction = new Transaction[Transactions.Length + _sizeIncrease];
                for (int x = 0; x < _counter; x++)
                {
                    TempTransaction[x] = Transactions[x];
                }
                Transactions = TempTransaction;
                Transactions[_counter] = new Transaction
                {
                    Type = type,
                    Amount = amount,
                    Balance = balance,
                    Target = target
                };
            }
            _counter++;
        }
        public Transaction[] ShowTx()
        {
            Transaction[] CopiedTransArray = new Transaction[_counter];
            for (int i = 0; i < _counter; i++)
            {
                CopiedTransArray[i] = Transactions[i];
            }
            return CopiedTransArray;
        }
    }
}