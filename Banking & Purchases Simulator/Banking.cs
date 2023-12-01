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
            int key = 0;
            Dictionary<int, Account> displayQuery = user.userAccounts.ToDictionary(acc => key++);
            Console.Clear();
            Display.AccountsPage(displayQuery, user.username);
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
                            PickAccountToManage();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error: Invalid command entered, please pick from the list above");
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void CreateNewAccount()
        {

        }

        private static void PickAccountToManage()
        {

        }

    }
}
