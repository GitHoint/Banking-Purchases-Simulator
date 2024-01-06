using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class Account
    {
        protected int userID;
        protected int accNum;
        protected string accHolder;
        protected double balance;
        protected string accType;
        protected List<Transaction> history = new List<Transaction>();

        [JsonConstructor]
        private Account(int userID, int accNum, string accHolder, int balance, string accType, List<Transaction> history)
        {
            this.userID = userID;
            this.accNum = accNum;
            this.accHolder = accHolder;
            this.balance = balance;
            this.accType = accType;
            this.history = history;
        }

        //General Constructor
        public Account(int accNum, string accHolder, string accType)
        {
            this.accNum = accNum;
            this.accHolder = accHolder;
            this.accType = accType;
        }
        //Child Class Constructor
        protected Account(int accNum, string accHolder)
        {
            this.accNum = accNum;
            this.accHolder = accHolder;
        }

        //Functions

        public virtual bool Withdraw(double amount) 
        {
            if (balance < amount) return false;
            double pre = balance;
            balance -= amount;
            history.Add(new Transaction("Withdraw", amount, pre, balance));
            return true;
        }
        public void Deposit(double amount) 
        {
            double pre = balance;
            balance += amount;
            history.Add(new Transaction("Deposit", amount, pre, balance));
            
        }
        public void CreateStatement() 
        {
            Console.Clear();
            Console.Write("<[=----------");
            Console.Write("(" + AccType + ")");
            Console.Write("----------=]>\n");
            foreach (Transaction transaction in history)
            {
                Console.WriteLine(transaction.Type + " Amount: " + transaction.Amount.ToString("C", CultureInfo.CurrentCulture) + ".");
                Console.WriteLine("Balance Before: " + transaction.BalanceBefore.ToString("C", CultureInfo.CurrentCulture) + ". Balance After: " + transaction.BalanceAfter.ToString("C", CultureInfo.CurrentCulture) + ".\n");
            }
            Console.WriteLine("<[=--------------------=]>");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        //Get & Set

        [JsonInclude]
        public int UserID
        {
            get { return userID; }
        }
        [JsonInclude]
        public int AccNum
        {
            get { return accNum; }
        }
        [JsonInclude]
        public string AccHolder
        {
            get { return accHolder; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string AccType
        {
            get { return accType; }
            set { accType = value; }
        }
        public List<Transaction> History
        {
            get { return history; }
            set { history = value; }
        }
    }
}
