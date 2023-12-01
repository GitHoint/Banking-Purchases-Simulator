using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    [Serializable]
    class User
    {
        private int id;
        private string username;
        private string password;
        private List<Account> userAccounts;

        [JsonConstructor] private User(int id, string username, string password, List<Account> userAccounts)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.userAccounts = userAccounts;
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void GenerateNewUserID(List<User> users)
        {
            Random rand = new Random();
            int id = rand.Next(0, 999999);
            foreach (var user in users)
            {
                if (user.id == id)
                {
                    GenerateNewUserID(users);
                }
            }
            this.id = id;
        }

        //Get & Set
        [JsonInclude]
        public int ID
        {
            get { return id; }
        }
        [JsonInclude]
        public string Username
        {
            get { return username; }
        }
        [JsonInclude]
        public string Password
        {
            get { return password; }
        }
        public List<Account> UserAccounts
        {
            get { return userAccounts; }
            set { userAccounts = value; }
        }
    }
}
