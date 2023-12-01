//Banking & Purchases Simulator

using Banking___Purchases_Simulator;
using Microsoft.VisualBasic;
using System.Diagnostics;

//Loads all User Data
List<User> accounts = Actions.LoadJsonData();
User currentUser = null;
Login();
//Login & Registration
void Login()
{
    while (currentUser == null)
    {
        int initialization = Actions.GetLoginOption();
        if (initialization == 1)
        {
            Console.Clear();
            Display.Login();
            User query = LoginActions.EnterCredentials();
            if (query != null)
            {
                if (LoginActions.CheckLoginCredentials(query, accounts) == true)
                {
                    currentUser = LoginActions.LoadUser(query, accounts);
                }
            }
        }
        else if (initialization == 2)
        {
            Console.Clear();
            Display.Register();
            User query = LoginActions.EnterNewUserCredentials();
            if (query != null)
            {
                if (LoginActions.CheckUserAlreadyExits(query, accounts) == false) 
                {
                    query.userAccounts = new List<Account>();
                    query.GenerateNewUserID(accounts);
                    accounts.Add(query);
                    currentUser = query;
                }
            }
        }
    }
}

//Main
bool session = true;
while (session)
{
    Console.Clear();
    Display.ProgramOptions(currentUser);
    Console.Write("Enter a Command: ");
    string command = Console.ReadLine().Trim().ToLower();
    if (command == "-q")
    {
        session = false;
        
    }
    try
    {
        int code = Convert.ToInt32(command);
        switch (code)
        {
            case 1:
                currentUser = Banking.LoadBankingPage(currentUser);
                break;
            case 2:
                currentUser = Simulator.LoadSimulator(currentUser);
                break;
        }
    }
    catch
    {
        Console.WriteLine("Error: Invalid command entered, please pick one from the list above ");
        Console.Write("Press enter to continue...");
        Console.ReadLine();
    }
}

