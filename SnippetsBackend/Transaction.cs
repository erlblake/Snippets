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
        public string Duration;
        public double Rate;

        public Transaction(string FirstName, string LastName, string ChairOrAppointment, string DateandTime, string Duration, double Rate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ChairOrAppointment = ChairOrAppointment;
            this.DateandTime = DateandTime;
            this.Duration = Duration;
            this.Rate = Rate;
        }
        public override string ToString()
        {
            string Transactioninformation = FirstName + "," + LastName + "," + ChairOrAppointment + "," + DateandTime + "," + Duration + "," + Rate;
            return Transactioninformation;
        }
    }
}
