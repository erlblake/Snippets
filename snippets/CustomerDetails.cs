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
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
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
            if (FirstNameTextBox.Text != "" && SurnameText.Text != "" && EmailText.Text != "" && PhoneNumberText.Text != "")
            {
                if (CustomersSelectionFormcs.edit == false)
                {
                    ReadInTextFile();
                }
                ListofCustomers.Add(new SnippetsBackend.Customers((FirstNameTextBox.Text), SurnameText.Text, EmailText.Text, PhoneNumberText.Text));
                //Add to textfile
                using (StreamWriter tw = new StreamWriter("ListofCustomers.txt", false))
                {

                    foreach (SnippetsBackend.Customers s in ListofCustomers)
                    {
                        tw.WriteLine(s.FirstName + "," + s.LastName + "," + s.Email + "," + s.PhoneNumber);
                    }
                    tw.Close();
                }
                MessageBox.Show("Customer has been added/edited");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
                EmailText.Clear();
                PhoneNumberText.Clear();
                CustomerAppointments.Items.Clear();
            }
        }

        public List<SnippetsBackend.Customers> ListofCustomers = SnippetsBackend.Reading.ReadCustomers();
        public void ReadInTextFile()
        {
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string REmail = "";
            string RPhoneNumber = "";
            int i = 0;
            for (i = 0; i < ListofCustomers.Count; i++)
            {
                string customerstring = ListofCustomers[i].ToString();
                oneline = customerstring.Split(',');
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
                //If edit selected customer has been selected, check they do not have the same first name and last name
                if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }
                //If the edit customer button has been clicked
                if (CustomersSelectionFormcs.edit == true)
                {
                    string SelectedCustomerFirstName = CustomersSelectionFormcs.CustomerFirstName;
                    string SelectedCustomerLastName = CustomersSelectionFormcs.CustomerLastName;
                    if (RFirstName == SelectedCustomerFirstName && RLastName == SelectedCustomerLastName)
                    {
                        FirstNameTextBox.Text = SelectedCustomerFirstName;
                        SurnameText.Text = SelectedCustomerLastName;
                        EmailText.Text = REmail;
                        PhoneNumberText.Text = RPhoneNumber.ToString();
                    }
                }

            }

        }

        public void EditCustomerClicked()
        {
            if (CustomersSelectionFormcs.edit == true)
            {
                ReadInTextFile();
                //Call the transactions for that stylist
                ReadTransaction();
                string stylistinfo = FirstNameTextBox.Text + "," + SurnameText.Text + "," + EmailText.Text + "," + PhoneNumberText.Text;
                for (int i = 0; i < ListofCustomers.Count; i++)
                {
                    if (ListofCustomers[i].ToString() == stylistinfo)
                    {
                        ListofCustomers.RemoveAt(i);
                    }
                }
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
            if(Regex.IsMatch(name, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("The First name and Last name must only contain letters");
                FirstNameTextBox.Clear();
                SurnameText.Clear();
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
                        CustomerAppointments.Items.Add(RDate + " " + RChairorAppointment);
                    }
                }
            }
            catch
            {
                CustomerAppointments.Items.Add("Customer has no appointments");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomersSelectionFormcs CSF = new CustomersSelectionFormcs();
            CSF.Show();
            CSF.Closed += (s, args) => Close();
        }
    }
}
