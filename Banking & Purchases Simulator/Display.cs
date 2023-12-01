using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class Display
    {

        public static void ErrorReport()
        {
            Console.WriteLine("Error: Invalid command entered, please pick from the list above");
            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
        public static void MainMenu()
        {
            Console.WriteLine("Banking & Purchases Simulator: \n");
            Console.WriteLine(HeaderStart() + "(Main Menu)" +  HeaderEnd());
            Console.WriteLine("  Options:");
            Console.WriteLine("   1. Login.");
            Console.WriteLine("   2. Register.");
            Console.WriteLine("   Type '-q' to quit.");
            Console.WriteLine(HeaderStart() + "-----------" + HeaderEnd() + "\n");

        }
        public static void Login()
        {
            Console.WriteLine("Banking & Purchases Simulator: \n");
            Console.WriteLine(HeaderStart() + "(Login)" + HeaderEnd());
            Console.WriteLine("  Options:");
            Console.WriteLine("  Type '-q' to quit.");
            Console.WriteLine(HeaderStart() + "-------" + HeaderEnd() + "\n");
        }
        public static void Register()
        {
            Console.WriteLine("Banking & Purchases Simulator: \n");
            Console.WriteLine(HeaderStart() + "(Register)" + HeaderEnd());
            Console.WriteLine("  Options:");
            Console.WriteLine("  Type '-q' to quit.");
            Console.WriteLine(HeaderStart() + "----------" + HeaderEnd() + "\n");
        }

        public static void ProgramOptions(User user) 
        {
            Console.WriteLine("Banking & Purchases Simulator");
            Console.WriteLine(HeaderStart() + "(" + user.Username + ")" + HeaderEnd());
            Console.WriteLine("  Options:");
            Console.WriteLine("  1. View/Manage Your Accounts.");
            Console.WriteLine("  2. Simulate Spending.");
            Console.WriteLine("  Type '-q' to logout.");
            Console.WriteLine(HeaderStart() + HeaderFill(user.Username) + HeaderEnd() + "\n");
        }
        public static void AccountsPage(Dictionary<int, Account> accountsToDisplay, string username) 
        {
            Console.WriteLine("Banking & Purchases Simulator");
            Console.WriteLine(HeaderStart() + "(" + username + "'s Accounts)" + HeaderEnd());
            if (accountsToDisplay.Count == 0)
            {
                Console.WriteLine("  No Accounts.");
            }
            else
            {
                Console.WriteLine("  Your Accounts:");
                foreach (var account in accountsToDisplay)
                {
                    string accType = account.Value.AccType;
                    string balance = account.Value.Balance.ToString("C", CultureInfo.CurrentCulture);
                    Console.WriteLine("  " + account.Key + ". " + accType + " :: { Balance: " + balance + " }");
                }
            }
            Console.WriteLine(HeaderStart() + HeaderFill(username + "'s Accounts") + HeaderEnd());
            Console.WriteLine("  Options:");
            Console.WriteLine("  1. Open a new account.");
            Console.WriteLine("  2. Select an account to manage.");
            Console.WriteLine("  Enter '-q' to exit.");
            Console.WriteLine(HeaderStart() + HeaderFill(username + "'s Accounts") + HeaderEnd() + "\n");
            
        }
        public static void ManageAnAccount(Account acc) 
        {
            Console.WriteLine(HeaderStart() + "(" + acc.AccType + ")" + HeaderEnd());
            Console.WriteLine("  Details: ");
            Console.WriteLine("  - Current Balance: {" + acc.Balance.ToString("C", CultureInfo.CurrentCulture) + " }");
            Console.WriteLine("  Options: ");
            Console.WriteLine("  1. Withdraw.");
            Console.WriteLine("  2. Deposit.");
            Console.WriteLine("  3. Create A Statement.");
            Console.WriteLine("  4. Transfer funds to another account.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  5. Close Account.");
            Console.ResetColor();
            Console.WriteLine("  Enter '-q' to exit.");
            Console.WriteLine(HeaderStart() + HeaderFill(acc.AccType) + HeaderEnd() + "\n");
        }
        public static void SimulationPage(User user) { }
        private static string HeaderStart()
        {
            return "<[=----------";
        }
        private static string HeaderEnd() 
        {
            return "----------=]>";
        }
        private static string HeaderFill(string text) 
        {
            string output = "";
            foreach (char i in text)
            {
                output += "-";
            }
            output += "--"; //For brackets
            return output;
        }
    }
}
