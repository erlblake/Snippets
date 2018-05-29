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
//Need to read in the list of stylists from listofinfo
{
    public partial class StylistSelectionForm : Form
    {
        public StylistSelectionForm()
        {
            InitializeComponent();
            //Populating list box of stylists
            AddingStylistsToList();
        }
        public static bool edit;
        public static string StylistFirstName;
        public static string StylistLastName;
        private void EditStylistButton_Click(object sender, EventArgs e)
        {
            string[] name = ListofStylists.Text.Split(' ');
            
            for (int i = 0; i < name.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        StylistFirstName = name[i];
                        break;
                    case 1:
                        StylistLastName = name[i];
                        break;
                }

            }
            edit = true;
            Hide();
            StylistInfo Stylist = new StylistInfo();
            Stylist.EditStylistClicked();
            Stylist.Closed += (s, args) => this.Show();
            Stylist.Show();
        }

        public void AddingStylistsToList()
        {
            ReadInTextFile();
            for (int i = 0; i < ReadingInListOfStylists.Count; i++)
            {
                ListofStylists.Items.Add(ReadingInListOfStylists[i]);
            }
        }
        private void ListofStylists_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        public List<string> ReadingInListOfStylists = new List<string>();
        public Dictionary<string, double> StylistRate = new Dictionary<string, double>();
        public void ReadInTextFile()          
        {
            string[] line = File.ReadAllLines("ListofStylists.txt");
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
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
                        case 4:
                            RHourlyRate = int.Parse(oneline[x]);
                            break;
                    }
                }
             string StylistsName = RFirstName +" " + RLastName;
            ReadingInListOfStylists.Add(StylistsName);
                //Cannot add a stylist twice e.g. Amelia Shep
            StylistRate.Add(StylistsName, RHourlyRate);
            }  
        }

        private void NewStylist_Click(object sender, EventArgs e)
        {
            this.Hide();
            StylistInfo Stylist = new StylistInfo();
            Stylist.Closed += (s, args) => this.Close();            
            Stylist.Show();            
        }
        public static List<string> SearchMethod(char[] search, string searchlength, List<string> list)
        {
            int lengthofstring = 0;
            string threecharsofstylist = "";
            if (searchlength.Length < 3)
            {
                lengthofstring = search.Length;
            }
            else
            {
                lengthofstring = 3;
            }
            for (int i = 0; i < lengthofstring; i++)
            {
                threecharsofstylist += search[i];
            }
             List<string> addtotextbox = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower().Contains(threecharsofstylist))
                {
                    addtotextbox.Add(list[i]);
                }
            }
            return addtotextbox;
            //add values to another list
        }
        //Make this into a method that can be called from both stylist and customer
        private void SearchButton_Click(object sender, EventArgs e)                                    
        {
            ListofStylists.Items.Clear();
            char[] stylistsearchsplit = StylistSearch.Text.ToLower().ToCharArray();
            string stylist = StylistSearch.Text;
            //add list to the method
            List<string> newlist = new List<string>();
            newlist = SearchMethod(stylistsearchsplit, stylist, ReadingInListOfStylists);
            for (int i = 0; i < newlist.Count; i++)
            {
            ListofStylists.Items.Add(newlist[i]);
            }
            
        }
        bool date = false;
        private void BookChairButton_Click(object sender, EventArgs e)
        {
            if (ListofStylists.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a stylist who would like to book");
            }
            else
            {
                ReadInTransaction();
                if (date == false)
                {
                    string[] selectedstylist = ListofStylists.SelectedItem.ToString().Split(' ');
                    string StylistFirstName = "";
                    string StylistLastName = "";
                    for (int i = 0; i < selectedstylist.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                StylistFirstName = selectedstylist[i];
                                break;
                            case 1:
                                StylistLastName = selectedstylist[i];
                                break;

                        }
                    }
                    double rate = 0;
                    //Gets the hourly rate of the stylist
                    if (StylistRate.ContainsKey(ListofStylists.SelectedItem.ToString()))
                    {
                        StylistRate.TryGetValue(ListofStylists.SelectedItem.ToString(), out rate);
                    }
                    ReadingInListOfTransactions.Add(new SnippetsBackend.Transaction(StylistFirstName, StylistLastName, "Chair Booking", dateTimePicker1.Value.ToShortDateString(), "NA", rate));

                    //Add to textfile
                    using (StreamWriter tw = new StreamWriter("Transactions.txt", false))
                    {

                        foreach (SnippetsBackend.Transaction s in ReadingInListOfTransactions)
                        {
                            tw.WriteLine(s.FirstName + "," + s.LastName + "," + s.ChairOrAppointment + "," + s.DateandTime + "," + s.Duration + "," + s.Rate);

                        }
                        tw.Close();

                    }
                    MessageBox.Show("Stylist has booked a chair");
                }
            }
        }
        List<SnippetsBackend.Transaction> ReadingInListOfTransactions = new List<SnippetsBackend.Transaction>();
        public void ReadInTransaction()
        {
            string[] line = File.ReadAllLines("Transactions.txt");        
            string[] oneline;
            string RFirstName = "";
            string RLastName = "";
            string RChairorAppointment = "";
            string RDateandTime = "";
            string RDuration = "";
            int RRate = 0;
            int count = 0;
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
                string stylistname = RFirstName + " "+ RLastName;

                if(ListofStylists.SelectedItem.ToString() == stylistname)
                {
                    if(RDateandTime.ToString() == dateTimePicker1.Value.ToShortDateString())
                    {
                        MessageBox.Show("Stylist has already booked a chair on this day, you can only book one chair per stylist per day");
                        date = true;
                    }
                }
                if(RDateandTime.ToString() == dateTimePicker1.Value.ToShortDateString())
                {
                    count++;
                    if(count == 4)
                    {
                        MessageBox.Show("There are already four chairs booked on this day");
                        date = true;
                    }
                }
            }
        }
            
    }
}
