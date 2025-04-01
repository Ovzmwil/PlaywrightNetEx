using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNetEx.Models
{
    class User
    {
        public char Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }
        public bool Newsletter { get; set; }
        public bool SpecialOffers { get; set; }
        public string MobilePhone { get; set; }
        public Adress Adress { get; set; }

        public User(char gender, string firstName, string lastName, string email,
            string password, string birthdate, bool newsletter, bool specialOffers, string
            mobilePhone, Adress adress)
        {
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Birthdate = birthdate;
            Newsletter = newsletter;
            SpecialOffers = specialOffers;
            MobilePhone = mobilePhone;
            Adress = adress;
        }
    }
}
