using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class AccountActions
    {
        public static Dictionary<int, Account> Withdraw(Dictionary<int, Account> accList, int ID)
        {
            while (true)
            {
                Console.Write("Enter amount to Withdraw: ");
                string command = Console.ReadLine();
                if (command == "-q")
                {
                    return accList;
                }
                try
                {
                    float value = Convert.ToInt32(command);
                    if(accList[ID].Withdraw(value) == false)
                    {
                        Console.WriteLine("Insufficient Funds.");
                    }
                    else
                    {
                        return accList;
                    }
                }
                catch
                {
                    Display.ErrorReport();
                }
            }
        }
        public static Dictionary<int, Account> Deposit(Dictionary<int, Account> accList, int ID) 
        {
            while (true)
            {
                Console.Write("Enter amount to Deposit: ");
                string command = Console.ReadLine();
                if (command == "-q")
                {
                    return accList;
                }
                try
                {
                    float value = Convert.ToInt32(command);
                    accList[ID].Deposit(value);
                }
                catch
                {
                    Display.ErrorReport();
                }
            }
            
        }
        public static Dictionary<int, Account> CreateStatement(Dictionary<int, Account> accList, int ID) 
        {
            accList[ID].CreateStatement();
            return accList;
        }
        public static Dictionary<int, Account> TransferToAccount(Dictionary<int, Account> accList, int ID) { }
        public static Dictionary<int, Account> CloseAccount(Dictionary<int, Account> accList, int ID) { }

    }
}
