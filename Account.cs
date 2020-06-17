namespace SageModeBankOOP
{
    class Account
    {
        private int _counter =0;
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public decimal balance { get; set; }
        private Transaction[] Transactions { get; set; }

    }
}