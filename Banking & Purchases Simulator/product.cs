using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
        }
        public double Price
        {
            get { return price; }
        }
    }
}
