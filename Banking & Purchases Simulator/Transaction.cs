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
        private double amount;
        private double balanceBefore;
        private double balanceAfter;

        [JsonConstructor]
        public Transaction(string type, double amount, double balanceBefore, double balanceAfter)
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
        public double Amount
        {
            get { return amount; }
        }
        [JsonInclude]
        public double BalanceBefore
        {
            get { return balanceBefore; }
        }
        [JsonInclude]
        public double BalanceAfter
        {
            get { return balanceAfter; }
        }
    }
}
