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
        public Stylist(string FirstName, string LastName, string Email, string PhoneNumber, double HourlyRate) : base(FirstName, LastName, Email, PhoneNumber)
        {
            this.HourlyRate = HourlyRate;
        }

        public override string ToString()
        {
            string stylistinformation = FirstName + " " + LastName + " " + Email + " " + PhoneNumber + " " + HourlyRate;
            return stylistinformation;
        }
    }
}
