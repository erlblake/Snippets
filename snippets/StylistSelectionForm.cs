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
        public                                                                                                                                                                                                 void ReadInTextFile()
        {
            string[] line = File.ReadAllLines("ListofStylists.txt");
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
             string StylistsName = RFirstName +" " + RLastName;
            ReadingInListOfStylists.Add(StylistsName);
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

        private void BookChairButton_Click(object sender, EventArgs e)
        {
            //
            //Get the date
            //Get the selected stylist
            //Book a chair
            //Add information to transaction class
            //Only 4 chairs allowed to be booked a day
            //only allowed to book one chair for one stylist per day
        }
    }
}
