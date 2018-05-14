using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public List<SnippetsBackend.Stylist> ReadingInListOfStylists = new List<SnippetsBackend.Stylist>();
        public void ReadInTextFile()
        {
            string[] line = File.ReadAllLines("ListofStylists.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            Int64 RPhoneNumber = 0;
            double RHourlyRate = 0;
            int i = 0;
            for (i = 0; i < line.Length; i++)
            {
                oneline = line[i].Split(',');
            }
                
                    for (int x = 0; x < line.Length; x++)
                    {
                        switch (x)
                        {
                            case 0:
                                RFirstName = line[x];
                                break;
                            case 1:
                                RLastName = line[x];
                                break;
                            case 2:
                                REmail = line[x];
                                break;
                            case 3:
                                RPhoneNumber = Int64.Parse(line[x]);
                                break;
                            case 4:
                                RHourlyRate = double.Parse(line[x]);
                                break;
                        }
                    }         
                ReadingInListOfStylists.Add(new SnippetsBackend.Stylist(RFirstName, RLastName, REmail, RPhoneNumber, RHourlyRate));
                //If edit selected stylist has been selected, check they do not have the same first name and last name
                if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }
            }
        
        public void ReadInTransactionsTextFile()
        {
            string[] line = File.ReadAllLines("Transactions.txt");
            List<SnippetsBackend.Transaction> ReadingInListOfTransactions = new List<SnippetsBackend.Transaction>();
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
                ReadingInListOfTransactions.Add(new SnippetsBackend.Transaction(RFirstName, RLastName, RChairorAppointment, RDateandTime, RDuration, RRate));
                try
                {
                    //Finds the stylist and adds transactions 
                   StylistTransactions.Items.Add(ReadingInListOfTransactions.Find(x => x.FirstName.Contains(RFirstName) && x.LastName.Contains(RLastName)));          
                }
                catch
                {
                    MessageBox.Show("This stylist has no transactions");
                }
            }
        }
        public void EditStylistClicked()
        {
            if (StylistSelectionForm.edit == true)
            {
                ReadInTextFile();
                string SelectedStylistFirstName = StylistSelectionForm.StylistFirstName;
                string SelectedStylistLastName = StylistSelectionForm.StylistLastName;
                //Find the selected stylist in the list of stylists                 
                for (int i = 0; i < ReadingInListOfStylists.Count; i++)
                {
                    if (ReadingInListOfStylists[i].ToString() == SelectedStylistFirstName && ReadingInListOfStylists[i++].ToString() == SelectedStylistLastName)
                    {
                        FirstNameTextBox.Text = SelectedStylistFirstName;
                        SurnameText.Text = SelectedStylistFirstName;
                        EmailText.Text = ReadingInListOfStylists[i + 2].ToString();
                        PhoneNumberText.Text = ReadingInListOfStylists[i + 3].ToString();
                        HourlyRateText.Text = ReadingInListOfStylists[i + 4].ToString();
                    }
                }
                //Call the transactions for that stylist
                ReadInTransactionsTextFile();
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (StylistSelectionForm.edit == true)
            {
                string SelectedStylistFirstName = StylistSelectionForm.StylistFirstName;
                string SelectedStylistLastName = StylistSelectionForm.StylistLastName;
                //Find the selected stylist in the list of stylists                 
                for (int i = 0; i < ReadingInListOfStylists.Count; i++)
                {
                    if(ReadingInListOfStylists[i].ToString() == SelectedStylistFirstName && ReadingInListOfStylists[i++].ToString() == SelectedStylistLastName)
                    {
                        FirstNameTextBox.Text = SelectedStylistFirstName;
                        SurnameText.Text = SelectedStylistFirstName;
                        EmailText.Text = ReadingInListOfStylists[i + 2].ToString();
                        PhoneNumberText.Text = ReadingInListOfStylists[i + 3].ToString();
                        HourlyRateText.Text = ReadingInListOfStylists[i + 4].ToString();
                    }
                }
                //Call the transactions for that stylist
                ReadInTransactionsTextFile();
            }
            if (IsValidEmail(EmailText.Text) == false)
            {
                EmailText.Clear();
                MessageBox.Show("Email address is not valid");
            }
            else if (PhoneNumberText.Text.Length != 11)
            {
                MessageBox.Show("The length of your phone number must be 11 digits");
                PhoneNumberText.Clear();
            }
            if (FirstNameTextBox.Text != "" && SurnameText.Text != "" && EmailText.Text != "" && PhoneNumberText.Text != "" && HourlyRateText.Text != "")
            {
                ReadInTextFile();
                List<SnippetsBackend.Stylist> ListofStylists = new List<SnippetsBackend.Stylist>();
                ListofStylists.Add(new SnippetsBackend.Stylist((FirstNameTextBox.Text), SurnameText.Text, EmailText.Text, Int64.Parse(PhoneNumberText.Text), double.Parse(HourlyRateText.Text)));
                //Add to textfile
                using (StreamWriter tw = new StreamWriter("ListofStylists.txt", true))
                {

                    foreach (SnippetsBackend.Stylist s in ListofStylists)
                    {
                        tw.WriteLine(s.FirstName + "," + s.LastName+ "," + s.Email + "," + s.PhoneNumber + "," + s.HourlyRate);
                        tw.Close();
                    }
                }
                MessageBox.Show("Stylist has been added/edited");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
                EmailText.Clear();
                PhoneNumberText.Clear();
                HourlyRateText.Clear();
            }
            else if(FirstNameTextBox.Text == "" || SurnameText.Text == "" || EmailText.Text == "" || PhoneNumberText.Text == "" || HourlyRateText.Text == "")
            {
                MessageBox.Show("Please fill in all the textboxes");
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                int indexofat = EmailText.Text.IndexOf("@");
                int indexofdot = EmailText.Text.IndexOf(".");
                {
                    if(Regex.IsMatch(email, @"^[^0-9]+$") == false)
                    {
                        MessageBox.Show("An email should only contain numbers");
                        EmailText.Clear();
                    }
                    if (indexofat > indexofdot)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
