using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snippets
{
    public class stylistsandcustomers
    {
        public List<stylistsandcustomers> ListofStylists = new List<stylistsandcustomers>();
        public List<stylistsandcustomers> ListofCustomers = new List<stylistsandcustomers>();

        public string FirstName;
        public string LastName;
        public string Email;
        public int PhoneNumber;
        public double HourlyRate;

        public stylistsandcustomers(string newFirstName, string newLastName, string newEmail, int newPhoneNumber, double newHourlyRate)
        {
            FirstName = newFirstName;
            LastName = newLastName;
            Email = newEmail;
            PhoneNumber = newPhoneNumber;
            HourlyRate = newHourlyRate;
        }

        
    }
}
