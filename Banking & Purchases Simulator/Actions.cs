using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Banking___Purchases_Simulator
{
    static class Actions
    {
        public static void UploadJsonData(List<User> users)
        {
            string jsonWrite = JsonSerializer.Serialize(users);
            File.WriteAllText("usersJson.txt", jsonWrite);
        }

        public static List<User> LoadJsonData()
        {
            string jsonRead = File.ReadAllText("usersJson.txt");
            try
            {
                List<User> result = JsonSerializer.Deserialize<List<User>>(jsonRead);
                return result;
            }
            catch
            {
                return new List<User>();
            }

        }
        public static int GetLoginOption()
        {
            Console.Clear();
            Display.MainMenu();
            bool state = false;
            while (!state)
            {
                Console.Write("Enter a command: ");
                string command = Console.ReadLine().Trim().ToLower();
                if (command == "-q")
                {
                    Environment.Exit(0);
                }
                try
                {
                    int code = Convert.ToInt32(command);
                    switch (code)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        default:
                            Console.WriteLine("Error: Invalid Command Entered, please select a command from list shown above.");
                            Console.Clear();
                            Display.MainMenu();
                            break;
                       

                    }
                }
                catch
                {
                    Console.WriteLine("Error: Invalid Command Entered, please select a command from list shown above.");
                    Console.Clear();
                    Display.MainMenu();
                }
            }
            return 0;
        }
    }
}
