using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ValidatorLibraryConsoleApp;

namespace ValidatorLibraryConsoleAppTests
{
    [TestClass]
    public class ConsoleIOTests
    {
        [TestMethod]
        public void DeleteUser_CorrectInput_DeletesUserFromTheList()
        {
            //Arrange
            var userList = new List<User>();
            var user = new User("1", "vardas", "Pavarde", "+37061111111", "email@gmail.com", "adresas g. 15", "Password1!");
            userList.Add(user);
            var consoleIO = new ConsoleIO(userList);
            var countBeforeDeletion = consoleIO.users.Count;
            
            //Act
            consoleIO.DeleteUser("delete 1");

            //Assert
            Assert.AreEqual(consoleIO.users.Count, countBeforeDeletion - 1);
        }

        [TestMethod]
        public void DeleteUser_IncorrectInput_DoesNotDeleteUserFromTheList()
        {
            //Arrange
            var userList = new List<User>();
            var user = new User("1", "vardas", "Pavarde", "+37061111111", "email@gmail.com", "adresas g. 15", "Password1!");
            userList.Add(user);
            var consoleIO = new ConsoleIO(userList);
            var countBeforeDeletion = consoleIO.users.Count;

            //Act
            consoleIO.DeleteUser("delete @");

            //Assert
            Assert.AreEqual(consoleIO.users.Count, countBeforeDeletion);
        }

        [TestMethod]
        public void AddNewUser_AddsUserToTheList()
        {
            //Arrange
            var userList = new List<User>();
            var user = new User("1", "vardas", "Pavarde", "+37061111111", "email@gmail.com", "adresas g. 15", "Password1!");
            var newUser = new User("2", "vardas2", "Pavarde2", "+37061111112", "email2@gmail.com", "adresas g. 152", "Password2!");
            userList.Add(user);
            var consoleIO = new ConsoleIO(userList);
            var countBeforeDeletion = consoleIO.users.Count;

            //Act
            consoleIO.AddLine(newUser);

            //Assert
            Assert.AreEqual(consoleIO.users.Count, countBeforeDeletion + 1);
            Assert.AreEqual(consoleIO.users[^1].Name, "vardas2");
        }


        [TestMethod]
        public void EditUser_EditsUserDataFromTheUsersList()
        {
            //Arrange
            var userList = new List<User>();
            var user = new User("1", "vardas", "Pavarde", "+37061111111", "email@gmail.com", "adresas g. 15", "Password1!");
            var newUser = new User("2", "vardas2", "Pavarde2", "+37061111112", "email2@gmail.com", "adresas g. 152", "Password2!");
            userList.Add(user);
            var consoleIO = new ConsoleIO(userList);
            var countBeforeDeletion = consoleIO.users.Count;
            var indexOfEditableUser = consoleIO.users.FindIndex(u => u.UserId == "1");

            //Act
            consoleIO.SaveEditedUser(newUser, "1");

            //Assert
            Assert.AreEqual(consoleIO.users.Count, countBeforeDeletion);
            Assert.AreEqual(consoleIO.users[indexOfEditableUser].Name, "vardas2");
        }
    }
}
