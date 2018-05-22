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
            Stylist.Closed += (s, args) => this.Close();
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
        public void ReadInTextFile()
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Get the first three characters of the string that has been entered
            char[] stylistsearchsplit = StylistSearch.Text.ToCharArray();
            string threecharsofstylist = "";
            for (int i = 0; i < 3; i++)
            {
                threecharsofstylist += stylistsearchsplit[i];
            }

            //Go through readinginstylists to see if any of the strings contain these three chars
           //Add the matches to the listbox
        }
    }
}
