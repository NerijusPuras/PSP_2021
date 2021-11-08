using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibraryConsoleApp
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }

        public User(string userId, string name, string surname, string phoneNumber, string email, string adress, string password)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Adress = adress;
            Password = password;
        }
    }
}
