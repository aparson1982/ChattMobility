using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattMob
{
    internal class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Date { get; private set; }
        public string Product { get; private set; }
        public string Manufacturer { get; private set; }
        public string Description { get; private set; }

        public Person(string firstName, string lastName, string email, string phone, string date, string product,
            string manufacturer, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Date = date;
            Product = product;
            Manufacturer = manufacturer;
            Description = description;
        }
    }
}