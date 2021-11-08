using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorLibrary;

namespace ValidatorLibraryConsoleApp
{
    public class ConsoleIO
    {
        public List<User> users;
        private PhoneValidator phoneValidator = new PhoneValidator();
        private EmailValidator emailValidator = new EmailValidator();
        private PasswordChecker passwordChecker = new PasswordChecker();

        public ConsoleIO(List<User> Users)
        {
            users = Users;
            ReadFile();
        }
        public ConsoleIO()
        {
            users = new List<User>();
            ReadFile();
        }

        public void ConsoleMenu()
        {
            Console.WriteLine("Choose what you want to do:\n");
            Console.WriteLine("Write 'get all' to get a user");
            Console.WriteLine("Write 'get {user id}' to get a user");
            Console.WriteLine("Write 'delete {user id}' to delete a user");
            Console.WriteLine("Write 'edit {user id}' to edit a user");
            Console.WriteLine("Write 'add user' to add a new user");
            Console.WriteLine("Write 'exit' to terminate the session");
            var input = Console.ReadLine();

            CallMethodsByInitialInput(input);
        }

        public void CallMethodsByInitialInput(string input)
        {
            try
            {
                if (input.ToLower().Trim().Equals("get all"))
                {
                    GetAllUsers(users);
                }
                else if (input.ToLower().StartsWith("get"))
                {
                    PrintUser(GetUser(input));
                }
                else if (input.ToLower().StartsWith("delete"))
                {
                    DeleteUser(input);
                }
                else if (input.ToLower().StartsWith("edit"))
                {
                    EditUser(input);
                }
                else if (input.ToLower().Trim().Equals("add user"))
                {
                    AddUser();
                }
                else if (input.ToLower().Equals("exit"))
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
            }
            catch
            {
                Console.WriteLine("Something went wrong, try again");
            }
        }

        private void GetAllUsers(List<User> users)
        {
            if(users == null || users.Count == 0)
            {
                Console.WriteLine("No users in the system\n");
                return;
            }

            PrintUsers(users);
        }

        public User GetUser(string input)
        {
            var user = GetUserFromFile(input);
            if (user == null)
            {
                Console.WriteLine("Invalid userID");
                return null;
            }

            return user;
        }

        public void DeleteUser(string input)
        {
            var user = GetUserFromFile(input);
            if(user == null)
            {
                Console.WriteLine("Invalid userID");
                return;
            }

            DeleteLine(user.UserId);

            Console.WriteLine("User deleted successfully");
        }

        public void EditUser(string input)
        {
            var user = GetUserFromFile(input);

            if(user == null)
            {
                Console.WriteLine("Cannot edit user with this id");
                return;
            }

            EditUserIO(user);

            Console.WriteLine();
        }

        private void EditUserIO(User user)
        {
            Console.WriteLine($"\nCurrent UserId: {user.UserId}. Write new value to edit:");
            var newUserId = Console.ReadLine();

            Console.WriteLine($"Current Name: {user.Name}. Write new value to edit:");
            var newName = Console.ReadLine();

            Console.WriteLine($"Current Surname: {user.Surname}. Write new value to edit:");
            var newSurname = Console.ReadLine();

            Console.WriteLine($"Current PhoneNumber: {user.PhoneNumber}. Write new value to edit:");
            string newPhoneNumber = Console.ReadLine();

            while (true)
            {
                if (newPhoneNumber.Trim().Equals("exit"))
                {
                    return;
                } else if (phoneValidator.Validate(newPhoneNumber))
                {
                    break;
                } else
                {
                    Console.WriteLine($"Incorrect Phone Number. Write new value to edit or 'exit' to terminate editing:");
                    newPhoneNumber = Console.ReadLine();
                }
            }

            Console.WriteLine($"Current Email: {user.Email}. Write new value to edit:");
            var newEmail = Console.ReadLine();

            while (true)
            {
                if (newEmail.Trim().Equals("exit"))
                {
                    return;
                }
                else if (emailValidator.Validate(newEmail))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect Email. Write new value to edit or 'exit' to terminate editing:");
                    newEmail = Console.ReadLine();
                }
            }

            Console.WriteLine($"Current Adress: {user.Adress}. Write new value to edit:");
            var newAdress = Console.ReadLine();

            Console.WriteLine($"Current Password: {user.Password}. Write new value to edit:");
            var newPassword = Console.ReadLine();

            while (true)
            {
                if (newPassword.Trim().Equals("exit"))
                {
                    return;
                }
                else if (passwordChecker.Validate(newPassword))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect Password. Write new value to edit or 'exit' to terminate editing:");
                    newPassword = Console.ReadLine();
                }
            }

            SaveEditedUser(new User(newUserId, newName, newSurname, newPhoneNumber, newEmail, newAdress, newPassword), user.UserId);
        }

        public void SaveEditedUser(User user, string oldUserId)
        {
            DeleteLine(oldUserId);
            AddLine(user);

            Console.WriteLine($"New values for the user with old id {oldUserId} are saved:");
            Console.WriteLine(user.UserId + "|" + user.Name + "|" + user.Surname +
                    "|" + user.PhoneNumber + "|" + user.Email + "|" + user.Adress + "|" + user.Password + "\n");
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

        private void AddUser()
        {
            Console.WriteLine($"Write UserId:");
            var newUserId = Console.ReadLine();

            Console.WriteLine($"Write User's Name:");
            var newName = Console.ReadLine();

            Console.WriteLine($"Write User's Surname:");
            var newSurname = Console.ReadLine();

            Console.WriteLine($"Write User's PhoneNumber");
            string newPhoneNumber = Console.ReadLine();

            while (true)
            {
                if (newPhoneNumber.Trim().Equals("exit"))
                {
                    return;
                }
                else if (phoneValidator.Validate(newPhoneNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect Phone Number. Write new value or 'exit' to terminate creation of a new user:");
                    newPhoneNumber = Console.ReadLine();
                }
            }

            Console.WriteLine($"Write User's Email");
            var newEmail = Console.ReadLine();

            while (true)
            {
                if (newEmail.Trim().Equals("exit"))
                {
                    return;
                }
                else if (emailValidator.Validate(newEmail))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect Email. Write new value or 'exit' to terminate creation of a new user:");
                    newEmail = Console.ReadLine();
                }
            }

            Console.WriteLine($"Write User's Adress");
            var newAdress = Console.ReadLine();

            Console.WriteLine($"Write User's Password");
            var newPassword = Console.ReadLine();

            while (true)
            {
                if (newPassword.Trim().Equals("exit"))
                {
                    return;
                }
                else if (passwordChecker.Validate(newPassword))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Incorrect Password. Write new value or 'exit' to terminate creation of a new user:");
                    newPassword = Console.ReadLine();
                }
            }

            AddLine(new User(newUserId, newName, newSurname, newPhoneNumber, newEmail, newAdress, newPassword));

            Console.WriteLine($"\nNew user with id {newUserId} was added successfully");
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
            if(users.Count == 0)
            {
                Console.WriteLine("No users with a provided user id\n");
                return;
            }
            foreach (var user in users)
            {
                Console.WriteLine(user.UserId + "|" + user.Name + "|" + user.Surname +
                    "|" + user.PhoneNumber + "|" + user.Email + "|" + user.Adress + "|" + user.Password + "\n");
            }
        }

        private void PrintUser(User user)
        {
            if (user == null)
            {
                Console.WriteLine("No users with a provided user id\n");
                return;
            }

            Console.WriteLine(user.UserId + "|" + user.Name + "|" + user.Surname +
                "|" + user.PhoneNumber + "|" + user.Email + "|" + user.Adress + "|" + user.Password + "\n");
        }

        private User GetUserFromFile(string input)
        {
            var userId = GetSecondWord(input);
            if (userId == null)
            {
                Console.WriteLine("User id was not provided");
                return null;
            }

            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine($"No user with id = {userId} was found");
                return null;
            }

            return user;
        }

        private void DeleteLine(string userId)
        {
            var path = @"data.txt";
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith(userId + ","))
                        sw.WriteLine(line);
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);

            users.RemoveAt(users.FindIndex(u => u.UserId == userId));
        }

        public void AddLine(User user)
        {
            var path = @"data.txt";
            var textToWrite = $"{user.UserId},{user.Name},{user.Surname},{user.PhoneNumber},{user.Email},{user.Adress},{user.Password}";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(textToWrite);
            }

            users.Add(user);
        }
    }
}
