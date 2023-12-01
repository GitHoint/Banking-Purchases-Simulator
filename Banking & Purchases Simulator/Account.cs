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
        public int userID { get; protected set; }
        public int accNum { get; protected set; }
        public string accHolder { get; protected set; }
        public float balance { get; protected set; }
        public string accType { get; protected set; }
        public List<Transaction> history { get; protected set; }

        [JsonConstructor] private Account(int userID, int accNum, string accHolder, int balance, string accType, List<Transaction> history)
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
    }
}
