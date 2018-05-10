using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            
        }
        public static bool edit;
        public static string StylistFirstName;
        public static string StylistLastName;
        private void EditStylistButton_Click(object sender, EventArgs e)
        {
            string[] name = ListofStylists.SelectedIndex.ToString().Split(' ');
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
            Application.Run(new StylistInfo());
        }
    }
}
