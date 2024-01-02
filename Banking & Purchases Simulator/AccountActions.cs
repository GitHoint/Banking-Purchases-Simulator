﻿using System;
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
                    double value = Convert.ToDouble(command);
                    if(accList[ID].Withdraw(value) == false)
                    {
                        Console.WriteLine("Insufficient Funds.");
                        return accList;
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
                    double value = Convert.ToDouble(command);
                    accList[ID].Deposit(value);
                    return accList;
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
        public static Dictionary<int, Account> TransferToAccount(Dictionary<int, Account> accList, int ID)
        {
            while (true)
            {
                Console.WriteLine("");
            }
        }
        public static Dictionary<int, Account> CloseAccount(Dictionary<int, Account> accList, int ID) 
        {
            while (true)
            {
                Console.WriteLine("Are you sure you want to close this account?");
                Console.WriteLine("Remaining funds will be moved to another account, if no other accounts are avaliable, funds will be lost");
                Console.Write("Do you want to continue? (y/n): ");
                string code = Console.ReadLine().Trim().ToLower();
                if (code == "n")
                {
                    return accList;
                }
                if (code == "y")
                {
                    double funds = accList[ID].Balance;
                    accList.Remove(ID);
                    if (accList.Count < 1)
                    {
                        return accList;
                    }
                    else
                    {
                        accList.First().Value.Balance += funds;
                        return accList;
                    }
                }
                else
                {
                    Console.Write("Invalid Response Entered, Press enter to return...");
                    Console.ReadLine();
                    return accList;
                }
            }
        }

    }
}
