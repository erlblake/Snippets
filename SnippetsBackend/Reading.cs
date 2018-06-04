using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsBackend
{
   public static class Reading
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
    }
}
