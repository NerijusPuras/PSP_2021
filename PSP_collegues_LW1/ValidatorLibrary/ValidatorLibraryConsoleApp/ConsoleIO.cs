using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibraryConsoleApp
{
    public class ConsoleIO
    {
        private List<User> users = new List<User>();

        public ConsoleIO()
        {
            ReadFile();
        }

        public void ConsoleMenu()
        {
            Console.WriteLine("Choose what you want to do:");
            Console.WriteLine("(User id is an integer)\n");
            Console.WriteLine("Write 'get {user id}' to get a user");
            Console.WriteLine("Write 'delete {user id}' to delete a user");
            Console.WriteLine("Write 'edit {user id}' to delete a user");
            Console.WriteLine("Write 'exit' to terminate the session");
            var input = Console.ReadLine();

            try
            {
                if (input.ToLower().StartsWith("get"))
                {
                    GetUser(input);
                } else if (input.ToLower().StartsWith("delete"))
                {
                    DeleteUser(input);
                } else if (input.ToLower().StartsWith("edit"))
                {
                    EditUser(input);
                } else if (input.ToLower().Equals("exit"))
                {
                    Console.WriteLine("Terminating");
                    return;
                }
                else
                {
                    Console.WriteLine("No valid commands are found, try again");
                    ConsoleMenu();
                }

                ConsoleMenu();
            } catch
            {
                Console.WriteLine("Something went wrong, try again");
            }
            
        }

        private void GetUser(string input)
        {
            var userId = GetSecondWord(input);
            if (userId == null)
            {
                return;
            }

            var user = users.Where(u => u.UserId == userId).ToList();
            if(user == null)
            {
                return;
            }

            PrintUsers(user);
        }

        private void DeleteUser(string input)
        {

        }

        private void EditUser(string input)
        {

        }

        private int GetUserId(string str)
        {
            var userIdString = GetSecondWord(str);

            if (userIdString == null)
            {
                Console.WriteLine("User id was not provided");
                return -1;
            }

            try
            {
                int userId = Int32.Parse(userIdString);
                return userId;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Not valid user id: '{userIdString}'");
                return -1;
            }
        }

        private string GetSecondWord(string str)
        {
            var startIndex = str.IndexOf(' ') + 1;
            if (startIndex == 0 || startIndex == str.Length)
                return null;

            var endIndex = str.IndexOf(" ", startIndex, StringComparison.CurrentCulture);
            if (endIndex == -1)
                endIndex = str.Length - 1;
            return str.Substring(startIndex, endIndex - startIndex + 1).Trim();
        }

        private void ReadFile()
        {
            List<string[]> fileContent = new List<string[]>();
            var path = @"data.txt";

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path)) { };
            }

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    users.Add(new User(values[0], values[1], values[2], values[3], values[4], values[5], values[6]));
                }
            }
        }

        private void PrintUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.UserId + "|" + user.Name + "|" + user.Surname +
                    "|" + user.PhoneNumber + "|" + user.Email + "|" + user.Adress + "|" + user.Password);
            }
            
        }
    }
}
