using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class Account
    {
        protected int userID;
        protected int accNum;
        protected string accHolder;
        protected float balance;
        protected string accType;
        protected List<Transaction> history;

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

        //public virtual bool Withdraw(int amount) { }
        public void Deposit(int amount) { }
        public void CreateStatement() { }

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
        public float Balance
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
