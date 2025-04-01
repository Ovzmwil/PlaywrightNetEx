using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNetEx.Models
{
    class Adress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public Adress(string street, string city, string state, string zip, string country)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
    }
}
