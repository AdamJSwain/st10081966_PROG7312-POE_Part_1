using st10081966_PROG7312_POE_Part_1.Classes;
using st10081966_PROG7312_POE_Part_1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace st10081966_PROG7312_POE_Part_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set form properties
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void btnReOrderBooks_Click(object sender, EventArgs e)
        {
            DeweyGame game = new DeweyGame();
            game.FormClosed += (s, args) => this.Close(); // Close the menu form after the game form is closed
            game.Show();
            this.Hide(); // Hide the menu form instead of closing it
        }

        private void btnFindNumbers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet implemented, Please check back later!");
        }

        private void btnIdentifyAreas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet implemented, Please check back later!");
        }
    }
}
