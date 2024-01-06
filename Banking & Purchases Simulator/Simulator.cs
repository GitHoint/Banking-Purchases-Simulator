using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class Simulator
    {
        public static User LoadSimulator(User user)
        {
            int key = 0;
            Dictionary<int, Account> userAccounts = user.UserAccounts.ToDictionary(acc => key++);
            while (true)
            {
                Console.Clear();
                Display.SimulationPage(userAccounts);
                Console.Write("Select an account: ");
                string command = Console.ReadLine().Trim().ToLower();
                if (command == "-q")
                {
                    user.UserAccounts = userAccounts.Values.ToList();
                    return user;
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    if (userAccounts.ContainsKey(code))
                    {
                        RunSimulatorWithAccount(userAccounts, code);
                    }
                    else
                    {
                        Console.Write("Error: There is no account tied to that selection, press enter to continue...");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Display.ErrorReport();
                }
            }
        }


        public static Dictionary<int, Account> RunSimulatorWithAccount(Dictionary<int, Account> userAccounts, int ID)
        {
            List<Product> products = LoadProducts();
            while (true)
            {
                Console.Clear();
                Display.SimulatorActive(userAccounts[ID]);
                Product currentProduct = SelectProduct(products);
                Console.WriteLine(currentProduct.Name + " :: £" + currentProduct.Price);
                Console.Write("Enter a command: ");
                string command = Console.ReadLine();
                if (command == "-q")
                {
                    return userAccounts;
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    switch (code)
                    {
                        case 1:
                            if (userAccounts[ID].Balance < currentProduct.Price)
                            {
                                Console.Write("Insufficient Funds. Press enter to continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                            double pre = userAccounts[ID].Balance;
                            userAccounts[ID].Balance -= currentProduct.Price;
                            userAccounts[ID].History.Add(new Transaction("Purchase", currentProduct.Price, pre, userAccounts[ID].Balance));
                            }
                            break;
                        case 2:
                            break;
                    }
                }
                catch
                {
                    Display.ErrorReport();
                }
            }
        }

        private static List<Product> LoadProducts()
        {
            string[] fromFile = File.ReadLines("products.txt").ToArray();
            List<Product> products = new List<Product>();
            foreach (string line in fromFile)
            {
                string[] parts = line.Split(": ");
                products.Add(new Product(parts[0], Convert.ToDouble(parts[1])));
            }
            return products;
        }
        private static Product SelectProduct(List<Product> products)
        {
            Random rng = new Random();
            int selected = rng.Next(0, products.Count - 1);
            return products[selected];
        }
    }
}
