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
            string rules = "Game Rules:\n\n" +
            "1. Objective:\n" +
            "   - Re order the books into the correct order.\n\n" +
            "2. How to Play:\n" +
            "   - Drag the books from the top shelf to the bottom shelf\n" +
            "   - Order the books in ascending order (smallest to biggest) based on the call numbers on the back of the books.\n\n" +
            "3. Winning the game:\n" +
            "   - You win the game by placing the books in the correct order on the bottom shelf and clicking the submit button\n" +
            "4. Rules:\n" +
            "   - If you drag books into the wrong order and submit you will lose health." +
            "   - If you run out of health you will lose the game and the game will close.";
            DeweyGame game = new DeweyGame();
            game.FormClosed += (s, args) => this.Close(); // Close the menu form after the game form is closed
            this.Hide(); // Hide the menu form instead of closing it
            MessageBox.Show(rules, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
            game.Show();
        }

        private void btnFindNumbers_Click(object sender, EventArgs e)
        {

            string rules = "Game Rules:\n\n" +
            "1. Objective:\n" +
            "   - Correctly navigate to the description through the categories.\n\n" +
            "2. How to Play:\n" +
            "   - Click on the button which corresponds to the top level category of the description listed\n" +
            "   - If you have chosen the correct category another, four more lower level categories will appear.\n\n" +
            "   - Click the correct level 2 category that corresponds to the listed description.\n\n" +
             "   - If you have chosen the correct category another, four descriptions with call numbers will appear, click the description that matches the top description.\n\n" +
            "3. Winning the game:\n" +
            "   - You win the game by navigating to the matching description as the one shown\n" +
            "4. Rules:\n" +
            "   - If you click the wrong button you lose." + 
            "   - You can click the play again button to play again";
            FindNumbers findNumbers = new FindNumbers();
            findNumbers.FormClosed += (s, args) => this.Close(); // Close the menu form after the game form is closed
            this.Hide(); //Hide the menu form instead of closing it
            MessageBox.Show(rules, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
            findNumbers.Show();
        }

        private void btnIdentifyAreas_Click(object sender, EventArgs e)
        {
            string rules = "Game Rules:\n\n" +
            "1. Objective:\n" +
            "   - Match the call numbers to their correct descriptions.\n\n" +
            "2. How to Play:\n" +
            "   - Drag a book with a call number / description to the gap in the bookshelf with the corresponding desctiption / call number\n" +
            "   - Click the button when you have placed all the books in their corresponding gaps.\n\n" +
            "3. Winning the game:\n" +
            "   - You win the game by clicking the submit button when all the books are in the correct gaps\n" +
            "4. Rules:\n" +
            "   - If you click the submit button when the books are not in the correct places you lose health.\n" + 
            "   - You lose the game when you run out of health, you can click the play again button to play again. "; 
            MatchColumns matchColumns = new MatchColumns();
            matchColumns.FormClosed += (s, args) => this.Close(); // Close the menu form after the game form is closed
            this.Hide(); //Hide the menu form instead of closing it
            MessageBox.Show(rules, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
            matchColumns.Show();
        }
    }
}
