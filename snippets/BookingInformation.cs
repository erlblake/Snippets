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

            if (dateTimePicker1.MinDate > DateTime.Today)
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
           string[] stylist =  DropDownListofStylists.SelectedItem.ToString().Split(' ');
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
            if(StylistandRate.ContainsKey(DropDownListofStylists.SelectedItem.ToString()))
            {
                StylistandRate.TryGetValue(DropDownListofStylists.SelectedItem.ToString(), out rate);
            }
            //add information to transaction list
            List<SnippetsBackend.Transaction> ListofTransactions = new List<SnippetsBackend.Transaction>();
            //Adding transaction of customer 
            ListofTransactions.Add(new SnippetsBackend.Transaction(FirstName, LastName, " with " + DropDownListofStylists.SelectedItem.ToString(), dateTimePicker1.Text, DurationList.SelectedItem.ToString(), rate));
            //Adding information of stylist
            ListofTransactions.Add(new SnippetsBackend.Transaction(StylistFirstName, StylsitLastName, "Appointment with " + CustomerName, dateTimePicker1.Text, DurationList.SelectedItem.ToString(), rate));
            //write the information to a textile
            using (StreamWriter tw = new StreamWriter("Transactions.txt", true))
            {
                foreach(SnippetsBackend.Transaction t in ListofTransactions)
                {
                    tw.WriteLine(t.FirstName + "," + t.LastName + ", " + t.ChairOrAppointment + "," + t.DateandTime + "," + t.Duration + "," + t.Rate);
                   
                } tw.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int number_of_slots = 15;
            int interval = 30; // in minuites

            //Clears the previous selection
            listBox1.Items.Clear();

            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            DateTime time = new DateTime(year, month, day, 9, 0, 0);

            for (int i = 0; i < number_of_slots; i++)
            {
                //check time here if stylist is taken

                listBox1.Items.Add(time.ToLocalTime().ToString());
                time = time.AddMinutes(interval);
            }

            StylistDropDownList();
        }
       
        public void DropDownListInfo()
        {
            DurationList.Items.Add("30 mins");
            DurationList.Items.Add("60 mins");
        }

        public void StylistDropDownList()
        {
            string[] line = File.ReadAllLines("Transactions.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string RDate = "";
            int HourlyRate = 0;
            string NA = "";

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
                        case 3:
                            RDate = oneline[x];
                            break;
                        case 4:
                            NA = oneline[x];
                            break;
                        case 5:
                            HourlyRate = int.Parse(oneline[x]);
                            break;
                    }
                }
                if (NA == "NA")
                {
                    if (RDate == dateTimePicker1.Value.ToShortDateString())
                    {
                        string name = RFirstName + " " + RLastName;
                        DropDownListofStylists.Items.Add(name);

                        StylistandRate.Add(name, HourlyRate);
                    }
                }

            }

        }
        //Check if stylist by checking there is appointment


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

        private void DropDownListofStylists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ReadInTransactionsTextFile()
        {
            string[] stylist = DropDownListofStylists.SelectedItem.ToString().Split(' ');
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
            string[] line = File.ReadAllLines("Transactions.txt");
            List<SnippetsBackend.Transaction> ReadingInListOfTransactions = new List<SnippetsBackend.Transaction>();
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
                ReadingInListOfTransactions.Add(new SnippetsBackend.Transaction(RFirstName, RLastName, RChairorAppointment, RDateandTime, RDuration, RRate));
            }
            
            //Need to:
            //Read in list of transactions
            //Make sure that stylist has not already booked an appointment on that day
            //only have the stylists in the list that have already booked a chair
            //remove the times that the stylist in unavailable for 
        }

    }
    }


