using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class CurrentAccount : Account
    {
        public int overdraftLimit { get; private set; }

        [JsonConstructor]
        public CurrentAccount(int accNum, string accHolder, int overdraftLimit) : base(accNum, accHolder)
        {
            this.overdraftLimit = overdraftLimit;
            this.accNum = accNum;
            this.accHolder = accHolder;
            accType = "Current Account";
        }

        //Functions

        //public override bool Withdraw(int amount) { }
    }
}
