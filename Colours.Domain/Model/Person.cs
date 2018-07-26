using Colours.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colours.Models
{
    public class Person
    {
       public Person() { }
        public Person(int id, string firstName, string lastName, bool isAuthorised, bool isValid, bool isEnabled)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsAuthorised = isAuthorised;
            IsValid = isValid;
            IsEnabled = isEnabled;
            
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public IList<Colour> FaveColours { get; set; }
    }
}
