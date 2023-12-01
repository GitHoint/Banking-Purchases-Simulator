using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class LoginActions
    {
        public static User EnterCredentials()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine().Trim();
            if (username == "-q")
            {
                return null;
            }
            Console.Write("Enter your password: ");
            string password = Console.ReadLine().Trim();
            if (password == "-q")
            {
                return null;
            }
            User query = new User(username, password);
            return query;
        }

        public static bool CheckLoginCredentials(User credentials, List<User> users)
        {
            foreach (var user in users)
            {
                if (user.username == credentials.username)
                {
                    if (user.password == credentials.password)
                    {
                        return true;
                    }
                    Console.Write("Incorrect Password. Press Enter to Continue...");
                    Console.ReadLine();
                    return false;
                }
            }
            Console.WriteLine("Unrecognised User. Press Enter to Continue...");
            Console.ReadLine();
            return false;
        }

        public static User LoadUser(User credentials, List<User> users)
        {
            foreach (var user in users)
            {
                if (user.username == credentials.username && user.password == credentials.password)
                {
                    return user;
                }
            }
            return null;
        }

        public static User EnterNewUserCredentials()
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine().Trim();
            if (username == "-q")
            {
                return null;
            }
            Console.Write("Enter a password: ");
            string password = Console.ReadLine().Trim();
            if (password == "-q")
            {
                return null;
            }
            User query = new User(username, password);
            return query;
        }

        public static bool CheckUserAlreadyExits(User query, List<User> users)
        {
            foreach (var user in users)
            {
                if (query.username == user.username)
                {
                    Console.WriteLine("A User already exists with this username, please pick another.");
                    Console.ReadLine();
                    return true;
                }
            }
            return false;
        }
    }
}
