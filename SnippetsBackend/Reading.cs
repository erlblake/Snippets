using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
    public class Reading
    {
        public static List<Transaction> ReadTransaction()
        {
            string[] line = File.ReadAllLines("Transactions.txt");
            List<Transaction> ReadingInListOfTransactions = new List<Transaction>();
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string RChairorAppointment = "";
            string RDateandTime = "";
            string RDuration = "";
            int RRate = 0;

            for (int i = 0; i < line.Length; i++)
            {
                oneline = line[i].Split(',');
                for (int x = 0; x < oneline.Length; x++)
                {
                    switch (x)
                    {
                        case 0:
                            RFirstName = oneline[x];
                            break;
                        case 1:
                            RLastName = oneline[x];
                            break;
                        case 2:
                            RChairorAppointment = oneline[x];
                            break;
                        case 3:
                            RDateandTime = oneline[x];
                            break;
                        case 4:
                            RDuration = oneline[x];
                            break;
                        case 5:
                            RRate = int.Parse(oneline[x]);
                            break;
                    }
                }
                ReadingInListOfTransactions.Add(new Transaction(RFirstName, RLastName, RChairorAppointment, RDateandTime, RDuration, RRate));
            }
            return ReadingInListOfTransactions;
        }

        public static List<Stylist> ReadStylist()
        {
            List<Stylist> ListofStylists = new List<Stylist>();
            string[] line = File.ReadAllLines("ListofStylists.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            string RPhoneNumber = "";
            double RHourlyRate = 0;
            int i = 0;
            for (i = 0; i < line.Length; i++)
            {
                oneline = line[i].Split(',');

                for (int x = 0; x < oneline.Length; x++)
                {
                    switch (x)
                    {
                        case 0:
                            RFirstName = oneline[x];
                            break;
                        case 1:
                            RLastName = oneline[x];
                            break;
                        case 2:
                            REmail = oneline[x];
                            break;
                        case 3:
                            RPhoneNumber = oneline[x];
                            break;
                        case 4:
                            RHourlyRate = double.Parse(oneline[x]);
                            break;
                    }
                }
                ListofStylists.Add(new SnippetsBackend.Stylist(RFirstName, RLastName, REmail, RPhoneNumber, RHourlyRate));
            }
            return ListofStylists;
        }
        public static List<Customers> ReadCustomers()
        {
            List<Customers> ListofCustomers = new List<Customers>();
            string[] line = File.ReadAllLines("ListofCustomers.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            string RPhoneNumber = "";
            int i = 0;
            for (i = 0; i < line.Length; i++)
            {
                oneline = line[i].Split(',');

                for (int x = 0; x < oneline.Length; x++)
                {
                    switch (x)
                    {
                        case 0:
                            RFirstName = oneline[x];
                            break;
                        case 1:
                            RLastName = oneline[x];
                            break;
                        case 2:
                            REmail = oneline[x];
                            break;
                        case 3:
                            RPhoneNumber = oneline[x];
                            break;
                    }
                }
                ListofCustomers.Add(new SnippetsBackend.Customers(RFirstName, RLastName, REmail, RPhoneNumber));
            }
            return ListofCustomers;
        }
    }
}
