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
        private float amount;
        private float balanceBefore;
        private float balanceAfter;

        [JsonConstructor]
        public Transaction(string type, float amount, float balanceBefore, float balanceAfter)
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
        public float Amount
        {
            get { return amount; }
        }
        [JsonInclude]
        public float BalanceBefore
        {
            get { return balanceBefore; }
        }
        [JsonInclude]
        public float BalanceAfter
        {
            get { return balanceAfter; }
        }
    }
}
