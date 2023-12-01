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
        }

    }
}
