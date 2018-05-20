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
        public List<SnippetsBackend.Stylist> ListofStylists = new List<SnippetsBackend.Stylist>();
        public void ReadInTextFile()
        {
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
                bool textboxesfilled = false;

                //If edit selected stylist has been selected, check they do not have the same first name and last name
                if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }

                if (textboxesfilled == false)
                {
                    if (StylistSelectionForm.edit == true)
                    {
                        string SelectedStylistFirstName = StylistSelectionForm.StylistFirstName;
                        string SelectedStylistLastName = StylistSelectionForm.StylistLastName;
                        if (RFirstName == SelectedStylistFirstName && RLastName == SelectedStylistLastName)
                        {
                            FirstNameTextBox.Text = SelectedStylistFirstName;
                            SurnameText.Text = SelectedStylistLastName;
                            EmailText.Text = REmail;
                            PhoneNumberText.Text = RPhoneNumber.ToString();
                            HourlyRateText.Text = RHourlyRate.ToString();
                            textboxesfilled = true;
                        }
                    }

                }

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
        //Need to delete them from the list?
        public void EditStylistClicked()
        {
            if (StylistSelectionForm.edit == true)
            {
                ReadInTextFile();
                //Call the transactions for that stylist
                ReadInTransactionsTextFile();
                string stylistinfo = FirstNameTextBox.Text + " " + SurnameText.Text + " "+ EmailText.Text + " "+ PhoneNumberText.Text + " " + HourlyRateText.Text;
                for (int i = 0; i < ListofStylists.Count; i++)
                {
                    if (ListofStylists[i].ToString() == stylistinfo)
                    {
                        ListofStylists.RemoveAt(i);
                    }
                }
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
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
                if (StylistSelectionForm.edit == false)
                {
                    ReadInTextFile();
                }
                ListofStylists.Add(new SnippetsBackend.Stylist((FirstNameTextBox.Text), SurnameText.Text, EmailText.Text, PhoneNumberText.Text, double.Parse(HourlyRateText.Text)));
                //Add to textfile
                using (StreamWriter tw = new StreamWriter("ListofStylists.txt", false))
                {

                    foreach (SnippetsBackend.Stylist s in ListofStylists)
                    {
                        tw.WriteLine(s.FirstName + "," + s.LastName + "," + s.Email + "," + s.PhoneNumber + "," + s.HourlyRate);
                        
                    }tw.Close();
                }
                MessageBox.Show("Stylist has been added/edited");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
                EmailText.Clear();
                PhoneNumberText.Clear();
                HourlyRateText.Clear();
            }
            else if (FirstNameTextBox.Text == "" || SurnameText.Text == "" || EmailText.Text == "" || PhoneNumberText.Text == "" || HourlyRateText.Text == "")
            {
                MessageBox.Show("Please fill in all the textboxes");
            }
        }
       public bool IsValidEmail(string email)
        {
            try
            {
                int indexofat = EmailText.Text.IndexOf("@");
                int indexofdot = EmailText.Text.IndexOf(".");
                {
                    if (Regex.IsMatch(email, @"^[^0-9]+$") == false)
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
