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
        public List<SnippetsBackend.Stylist> ListofStylists = SnippetsBackend.Reading.ReadStylist();
        public void ReadInTextFile()
        {
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            string RPhoneNumber = "";
            double RHourlyRate = 0;
            int i = 0;
            for (i = 0; i < ListofStylists.Count; i++)
            {
                string splitstylist = ListofStylists[i].ToString();
                oneline = splitstylist.Split(',');
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
                //If edit selected stylist has been selected, check they do not have the same first name and last name
                if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }
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
                    }
                }
            }
        }

        public void ReadTransaction()
        {
            try
            {
                //Finds the stylist and adds transactions 
                List<SnippetsBackend.Transaction> ReadingList = SnippetsBackend.Reading.ReadTransaction();
                string RFirstName = "";
                string RLastname = "";
                string RChairorAppointment = "";
                string RDate = "";
                string Rate = "";
                for (int i = 0; i < ReadingList.Count; i++)
                {
                    string newstring = ReadingList[i].ToString();
                    string[] line = newstring.Split(',');
                    for (int y = 0; y < line.Length; y++)
                    {
                        switch (y)
                        {
                            case 0:
                                RFirstName = line[y];
                                break;
                            case 1:
                                RLastname = line[y];
                                break;
                            case 2:
                                RChairorAppointment = line[y];
                                break;
                            case 3:
                                RDate = line[y];
                                break;
                            case 5:
                                Rate = line[y];
                                break;
                        }

                    }
                    if (RFirstName == FirstNameTextBox.Text && RLastname == SurnameText.Text)
                    {
                        StylistTransactions.Items.Add(RChairorAppointment + " " + RDate + " £" + Rate);
                    }
                }
            }
            catch
            {
                StylistTransactions.Items.Add("This stylist has no transactions");
            }
        }

        //Need to delete them from the list?
        public void EditStylistClicked()
        {
            if (StylistSelectionForm.edit == true)
            {
                ReadInTextFile();
                //Call the transactions for that stylist
                ReadTransaction();
                string stylistinfo = FirstNameTextBox.Text + " " + SurnameText.Text + " " + EmailText.Text + " " + PhoneNumberText.Text + " " + HourlyRateText.Text;
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
            IsValidEmail(EmailText.Text);
            IsValidName(FirstNameTextBox.Text);
            IsValidName(SurnameText.Text); 
            if (PhoneNumberText.Text.Length != 11)
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

                    }
                    tw.Close();
                }
                MessageBox.Show("Stylist has been added/edited");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
                EmailText.Clear();
                PhoneNumberText.Clear();
                HourlyRateText.Clear();
                StylistTransactions.Items.Clear();
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
        public void IsValidName(string name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("The First name and Last name must only contain letters");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
