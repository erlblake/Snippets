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
            }
        }

        public List<SnippetsBackend.Customers> ListofCustomers = new List<SnippetsBackend.Customers>();
        public void ReadInTextFile()
        {
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
                bool textboxesfilled = false;

                //If edit selected customer has been selected, check they do not have the same first name and last name
                if (RFirstName == FirstNameTextBox.Text && RLastName == SurnameText.Text)
                {
                    MessageBox.Show("This person already exists please enter a different firstname and lastname");
                    FirstNameTextBox.Clear();
                    SurnameText.Clear();
                }

                //If the edit customer button has been clicked
                if (textboxesfilled == false)
                {
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
                            textboxesfilled = true;
                        }
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
                //ReadInTransactionsTextFile();
                string stylistinfo = FirstNameTextBox.Text + " " + SurnameText.Text + " " + EmailText.Text + " " + PhoneNumberText.Text + " ";
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
    }
}
