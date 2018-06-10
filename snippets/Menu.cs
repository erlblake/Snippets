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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomersSelectionFormcs CSF = new CustomersSelectionFormcs();
            CSF.Closed += (s, args) => this.Show();
            CSF.Show(); 
        }

        private void StylistsButton_Click(object sender, EventArgs e)
        {
            Hide();
            StylistSelectionForm SSF = new StylistSelectionForm();
            SSF.Closed += (s, args) => this.Show();
            SSF.Show();
        }
    }
}
