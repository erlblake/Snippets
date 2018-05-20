using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
    public class Customers : Person
    {
        public Customers(string FirstName, string LastName, string Email, string PhoneNumber) : base(FirstName, LastName, Email, PhoneNumber)
        {

        }
    }
}
