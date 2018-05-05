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
    //This is intialised from the customer selection form
    public partial class BookingInformation : Form
    {
        public BookingInformation()
        {
            InitializeComponent();
            DropDownListInfo();
            StylistDropDownList();
            
    }
public Dictionary<string, int> StylistandRate = new Dictionary<string, int>();
        private void Bookingbutton_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.MinDate < DateTime.Today)
            {
                MessageBox.Show("Please enter a date on or after today");
            }
            else if (DropDownListofStylists.SelectedIndex < -1)
            {
                MessageBox.Show("Please select a stylist");
            }
            else if (DurationList.SelectedIndex < -1)
            {
                MessageBox.Show("Please select a duration for the appointment");
            }
            //Customer who is booking appointment
            string Customer = CustomersSelectionFormcs.CustomerSelected;
            string[] SplitnameofCustomer = Customer.Split(' ');
            string FirstName = "";
            string LastName = "";
            for (int i = 0; i < SplitnameofCustomer.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        FirstName = SplitnameofCustomer[i];
                        break;
                    case 1:
                        LastName = SplitnameofCustomer[i];
                        break;
                }
            }
            string CustomerName = FirstName + " " + LastName;

          //Selected Stylist
           string[] stylist =  DropDownListofStylists.SelectedIndex.ToString().Split(' ');
            string StylistFirstName = "";
            string StylsitLastName = "";
            for (int i = 0; i < stylist.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        StylistFirstName = stylist[i];
                        break;
                    case 1:
             StylsitLastName = stylist[i];
                        break;
                }
            }
            int rate = 0;
            //Gets the hourly rate of the stylist
            if(StylistandRate.ContainsKey(DropDownListofStylists.SelectedIndex.ToString()))
            {
                StylistandRate.TryGetValue(DropDownListofStylists.SelectedIndex.ToString(), out rate);
            }
            //add information to transaction list
            List<Transaction> ListofTransactions = new List<Transaction>();
            //Adding transaction of customer 
            ListofTransactions.Add(new Transaction(FirstName, LastName, "Appointment with " + DropDownListofStylists.SelectedIndex.ToString(), dateTimePicker1.Text, DurationList.SelectedIndex, rate));
            //Adding information of stylist
            ListofTransactions.Add(new Transaction(StylistFirstName, StylsitLastName, "Booking with " + CustomerName, dateTimePicker1.Text, DurationList.SelectedIndex, rate));
            //write the information to a textile
            using (StreamWriter tw = new StreamWriter("Transactions.txt", true))
            {
                foreach(Transaction t in ListofTransactions)
                {
                    tw.WriteLine(t.FirstName, t.LastName, t.ChairOrAppointment, t.DateandTime, t.Duration, t.Rate);
                    tw.Close();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Clears the previous selection
            listBox1.Items.Clear();
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 9:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 9:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 10:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 10:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 11:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 11:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 12:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 12:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 13:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 13:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 14:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 15:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 15:30");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 16:00");
            listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString() + " 16:30");
        }
       
        public void DropDownListInfo()
        {
            DurationList.Items.Add("15 mins");
            DurationList.Items.Add("30 mins");
            DurationList.Items.Add("45 mins");
            DurationList.Items.Add("60 mins");
        }

        public void StylistDropDownList()
        {
            string[] line = File.ReadAllLines("Listofinfo.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            int HourlyRate = 0;

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
                        case 4:
                            HourlyRate = int.Parse(oneline[x]);
                            break;
                    }
                }
                string name = RFirstName + RLastName;
                DropDownListofStylists.Items.Add(name);
               
                StylistandRate.Add(name, HourlyRate);
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void BookingInformation_Load(object sender, EventArgs e)
        {
         
        }
    }
}

