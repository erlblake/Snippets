using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
    public class Customers : Person
    {
        public Customers(string FirstName, string LastName, string Email, int PhoneNumber) : base(FirstName, LastName, Email, PhoneNumber)
        {

        }
    }
}
