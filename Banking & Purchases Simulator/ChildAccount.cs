using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class ChildAccount : Account
    {
        public Account parentAccount { get; private set; }
       
        [JsonConstructor]
        public ChildAccount(Account parentAccount, int accNum, string accHolder) : base(accNum, accHolder) 
        {
            this.parentAccount = parentAccount;
            this.accNum = accNum;
            this.accHolder = accHolder;
            accType = "Child Account";
        }

    }
}
