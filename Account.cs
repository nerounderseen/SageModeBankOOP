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
            Balance = 0;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Transfer()
        {

        }
    }
}