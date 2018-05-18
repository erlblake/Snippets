using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
   public class Transaction
    {
        public string FirstName;
        public string LastName;
        public string ChairOrAppointment;
        public string DateandTime;
        public int Duration;
        public double Rate;

        public Transaction(string FirstName, string LastName, string ChairOrAppointment, string DateandTime, int Duration, double Rate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ChairOrAppointment = ChairOrAppointment;
            this.DateandTime = DateandTime;
            this.Duration = Duration;
            this.Rate = Rate;
        }
    }
}
