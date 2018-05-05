using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snippets
{
    public partial class StylistInfo : Form
    {
        public StylistInfo()
        {
            InitializeComponent();

        }

        public void ReadInTextFile()
        {
            string[] line = File.ReadAllLines("Listofinfo.txt");
            List<stylistsandcustomers> ReadingInListOfStylists = new List<stylistsandcustomers>();
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            int RPhoneNumber = 0;
            double RHourlyRate = 0;

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
                            REmail = oneline[x];
                            break;
                        case 3:
                            RPhoneNumber = int.Parse(oneline[x]);
                            break;
                        case 4:
                            RHourlyRate = double.Parse(oneline[x]);
                            break;
                    }
                }
                ReadingInListOfStylists.Add(new stylistsandcustomers(RFirstName, RLastName, REmail, RPhoneNumber, RHourlyRate));

                //If edit selected stylist has been selected
                if (StylistSelectionForm.edit == true)
                {
                    //Find the selected stylist in the list
                    //Call the transactions for that stylist
                }
                //Check they do not have the same first name and last name
                else if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }
            }

        }

        public void ReadInTransactionsTextFile()
        {
            string[] line = File.ReadAllLines("Transactions.txt");
            List<Transaction> ReadingInListOfTransactions = new List<Transaction>();
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string RChairorAppointment = "";
            string RDateandTime = "";
            int RDuration = 0;
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
                            RDateandTime = (oneline[x]);
                            break;
                        case 4:
                            RDuration = int.Parse(oneline[x]);
                            break;
                        case 5:
                            RRate = int.Parse(oneline[x]);
                            break;
                    }
                }
                ReadingInListOfTransactions.Add(new Transaction(RFirstName, RLastName, RChairorAppointment, RDateandTime, RDuration, RRate));
                try
                {
                    //Finds the stylist in the list of transactions
                    ReadingInListOfTransactions.Find(x => x.FirstName.Contains(RFirstName) && x.LastName.Contains(RLastName));
                    
                }
                catch
                {
                    MessageBox.Show("This stylist has no transactions");
                }
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(EmailText.Text))
            {
                MessageBox.Show("Email address is not valid");
                EmailText.Clear();
            }
            else if (PhoneNumberText.Text.Length != 11)
            {
                MessageBox.Show("The length of your phone number must be 11 digits");
                PhoneNumberText.Clear();
            }
            if (FirstNameTextBox.Text != " " || SurnameText.Text != " " || EmailText.Text != " " || PhoneNumberText.Text != " " || HourlyRateText.Text != " ")
            {
                ReadInTextFile();
                //have to search through the list find the surname and last name 
                //delete that record, then re-add it with the new information
                List<stylistsandcustomers> ListofStylists = new List<stylistsandcustomers>();
                ListofStylists.Add(new stylistsandcustomers((FirstNameTextBox.Text), SurnameText.Text, EmailText.Text, int.Parse(PhoneNumberText.Text), double.Parse(HourlyRateText.Text)));
                //For Transactions:
                ReadInTransactionsTextFile();
                //read textfile
                //Search through transactions list and find that person
                //
            }
            else
            {
                MessageBox.Show("Please fill in all the textboxes");
            }


        }
        //Re do it!!
        //Make sure email is valid
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
