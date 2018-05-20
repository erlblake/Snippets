using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;

        public Person(string FirstName, string LastName, string Email, string PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }
    }
    
}
