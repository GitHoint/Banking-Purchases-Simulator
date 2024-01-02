using System;
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
            //To-Do
            //2 Options - Create new Account, Manage Account
            while (true)
            {
                int key = 0;
                Dictionary<int, Account> displayQuery = user.UserAccounts.ToDictionary(acc => key++);
                Console.Clear();
                Display.AccountsPage(displayQuery, user.Username);
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
                            user.UserAccounts = CreateNewAccount(user);
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

        private static List<Account> CreateNewAccount(User user)
        {
            while (true)
            {
                Console.Write("Enter the account type (type 'curr' for current account): ");
                string accType = Console.ReadLine().Trim();
                if (accType == "-q")
                {
                    return user.UserAccounts;
                }
                int newid = user.UserAccounts.Count + 1;
                if (accType == "curr")
                {
                    Console.Write("Enter overdraft limit: ");
                    try
                    {
                        int limit = Convert.ToInt32(Console.ReadLine());
                        user.UserAccounts.Add(new CurrentAccount(newid, user.Username, limit));
                        return user.UserAccounts;
                    }
                    catch
                    {
                        Display.ErrorReport();
                    }
                }
                else
                {
                    user.UserAccounts.Add(new Account(newid, user.Username, accType));
                    return user.UserAccounts;
                }
            }
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
