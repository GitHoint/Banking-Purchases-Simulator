using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class Transaction
    {
        private string type;
        private int amount;
        private int balanceBefore;
        private int balanceAfter;

        [JsonConstructor]
        public Transaction(string type, int amount, int balanceBefore, int balanceAfter)
        {
            this.type = type;
            this.amount = amount;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
        }

        [JsonInclude]
        public string Type
        {
            get { return type; }
        }
        [JsonInclude]
        public int Amount
        {
            get { return amount; }
        }
        [JsonInclude]
        public int BalanceBefore
        {
            get { return balanceBefore; }
        }
        [JsonInclude]
        public int BalanceAfter
        {
            get { return balanceAfter; }
        }
    }
}
