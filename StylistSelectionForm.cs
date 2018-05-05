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
    public partial class StylistSelectionForm : Form
    {
        public StylistSelectionForm()
        {
            InitializeComponent();
        }
        public static bool edit;
        private void EditStylistButton_Click(object sender, EventArgs e)
        {
            edit = true;
        }
    }
}
