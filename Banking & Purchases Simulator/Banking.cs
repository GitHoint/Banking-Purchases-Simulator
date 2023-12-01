﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class Banking
    {
        public static User LoadBankingPage(User user)
        {
            int key = 0;
            Dictionary<int, Account> displayQuery = user.UserAccounts.ToDictionary(acc => key++);
            Console.Clear();
            Display.AccountsPage(displayQuery, user.Username);
            //To-Do
            //2 Options - Create new Account, Manage Account
            while (true)
            {
                Console.Write("Enter A Command (1/2): ");
                string command = Console.ReadLine().Trim().ToLower();
                if (command == "-q")
                {
                    return user;
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    switch (code)
                    {
                        case 1:
                            CreateNewAccount();
                            break;
                        case 2:
                            user.UserAccounts = PickAccountToManage(displayQuery, user.Username);
                            break;
                    }
                }
                catch
                {
                    Display.ErrorReport();
                }
            }
        }

        private static void CreateNewAccount()
        {

        }

        private static List<Account> PickAccountToManage(Dictionary<int, Account> accDict, string username)
        { 
            while (true)
            {
                Console.Clear();
                Display.AccountsPage(accDict, username);
                Console.Write("Enter an Account to manage from the list above: ");
                string command = Console.ReadLine().Trim().ToLower();
                if (command == "-q")
                {
                    return accDict.Values.ToList();
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    foreach (var account in accDict)
                    {
                        if (account.Key == code)
                        {
                            accDict = AccountManagement(accDict, code);
                            return accDict.Values.ToList();
                        }
                    }
                    Display.ErrorReport();
                }
                catch
                {
                    Display.ErrorReport();
                }

            }
        }
        private static Dictionary<int, Account> AccountManagement(Dictionary<int, Account> accList, int ID)
        {
            while (true)
            {
                Console.Clear();
                Display.ManageAnAccount(accList[ID]);
                Console.Write("Enter a command: ");
                string command = Console.ReadLine().Trim().ToLower();
                if (command == "-q")
                {
                    return accList;
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    switch (code)
                    {
                        case 1:
                            accList = AccountActions.Deposit(accList, ID);
                            break;
                        case 2:
                            accList = AccountActions.Withdraw(accList, ID);
                            break;
                        case 3:
                            accList = AccountActions.CreateStatement(accList, ID);
                            break;
                        case 4:
                            accList = AccountActions.TransferToAccount(accList, ID);
                            break;
                        case 5:
                            accList = AccountActions.CloseAccount(accList, ID);
                            break;
                    }

                }
                catch
                {
                    Display.ErrorReport();
                }
            }
        }

    }
}
