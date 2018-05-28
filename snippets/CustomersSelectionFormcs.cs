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
    public partial class CustomersSelectionFormcs : Form
    {
        public CustomersSelectionFormcs()
        {
            InitializeComponent();
            AddingCustomersToList();
        }
        public static string CustomerSelected = "";
        private void BookAppointmentButton_Click(object sender, EventArgs e)
        {
            if(CustomerSelectionListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer that would like to book an appointment");
            }
            else
            {
            Hide();
            BookingInformation Booking = new BookingInformation();
            Booking.Closed += (s, args) => this.Show();
            Booking.Show();
            //Cusomter Selection on the listbox
            CustomerSelected = CustomerSelectionListBox.SelectedItem.ToString();
            }
        }

        public void AddingCustomersToList()
        {
            ReadInTextFile();
            for (int i = 0; i < ReadinginListofCustomers.Count; i++)
            {
                CustomerSelectionListBox.Items.Add(ReadinginListofCustomers[i]);
            }
        }
        public static bool edit;
        public static string CustomerFirstName;
        public static string CustomerLastName;
        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            string[] name = CustomerSelectionListBox.Text.Split(' ');

            for (int i = 0; i < name.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        CustomerFirstName = name[i];
                        break;
                    case 1:
                        CustomerLastName = name[i];
                        break;
                }
            }
            edit = true;
            Hide();
            CustomerDetails Customer = new CustomerDetails();
            Customer.EditCustomerClicked();
            Customer.Closed += (s, args) => this.Close();
            Customer.Show();
            edit = true;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDetails Customer = new CustomerDetails();
            Customer.Closed += (s, args) => this.Close();
            Customer.Show();
        }

        public List<string> ReadinginListofCustomers = new List<string>();
        public void ReadInTextFile()
        {
            string[] line = File.ReadAllLines("ListofCustomers.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
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
                    }
                }
                string CustomersName = RFirstName + " " + RLastName;
                ReadinginListofCustomers.Add(CustomersName);
            }
        }

        private void CustomerSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            CustomerSelectionListBox.Items.Clear();
            char[] customersearchsplit = CustomerSearch.Text.ToLower().ToCharArray();
            string customer = CustomerSearch.Text;
            //add list to the method
            List<string> newlist = new List<string>();
            newlist = StylistSelectionForm.SearchMethod(customersearchsplit, customer, ReadinginListofCustomers);
            for (int i = 0; i < newlist.Count; i++)
            {
                CustomerSelectionListBox.Items.Add(newlist[i]);
            }
        }
    }
}
