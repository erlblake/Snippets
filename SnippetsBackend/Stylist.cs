using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
   public class Stylist : Person
    {
        public double HourlyRate;
        public Stylist(string FirstName, string LastName, string Email, Int64 PhoneNumber, double HourlyRate) : base(FirstName, LastName, Email, PhoneNumber)
        {
            this.HourlyRate = HourlyRate;
        }
    }
}
