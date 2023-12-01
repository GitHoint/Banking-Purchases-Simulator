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
        public string type { get; }
        public int amount { get; }
        public int balanceBefore { get; }
        public int balanceAfter { get; }

        [JsonConstructor]
        public Transaction(string type, int amount, int balanceBefore, int balanceAfter)
        {
            this.type = type;
            this.amount = amount;
            this.balanceBefore = balanceBefore;
            this.balanceAfter = balanceAfter;
        }
    }
}
