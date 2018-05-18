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
{
    public partial class CustomersSelectionFormcs : Form
    {
        public CustomersSelectionFormcs()
        {
            InitializeComponent();
        }
        public static string CustomerSelected = "";
        private void BookAppointmentButton_Click(object sender, EventArgs e)
        {
            Application.Run(new BookingInformation());
            //Cusomter Selection on the listbox
            CustomerSelected = CustomerSelectionListBox.SelectedIndex.ToString();

        }
        public static bool edit;
        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            edit = true;
        }
    }
}
