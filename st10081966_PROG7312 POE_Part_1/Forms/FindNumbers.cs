using st10081966_PROG7312_POE_Part_1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static st10081966_PROG7312_POE_Part_1.Classes.RedBlackTree;

namespace st10081966_PROG7312_POE_Part_1.Forms
{
    public partial class FindNumbers : Form
    {
        //Variables for reading from file and timer
        private string[] lines;
        private string filePath;
        System.Timers.Timer timer;
        int h, m, s;

        //Constructo
        public FindNumbers()
        {
            InitializeComponent();

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sampleData.txt");
            lines = File.ReadAllLines(filePath);

            buttons.Add(btnOption1);
            buttons.Add(btnOption2);
            buttons.Add(btnOption3);
            buttons.Add(btnOption4);

            ShuffleButtons(buttons);
            
            readFileAndAddToTree();
            stopwatch.Start();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            txtTimer.Enabled = false;
        }

        //Variables for stopwatch and trees
        Stopwatch stopwatch = new Stopwatch();

        RedBlackTree tree = new RedBlackTree();
        List<Button> buttons = new List<Button>();
        List<int> usedKeys = new List<int>();
       
        //Variables for master key and level of the game
        int masterKey = 0;
        int level = 1;


        //Read file and add the numbers and descriptions to the tree.
        public void readFileAndAddToTree()
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split('.');

                if (parts.Length == 3 && int.TryParse(parts[0], out int data) && int.TryParse(parts[2], out int level))
                {
                    string desc = parts[1];
                    tree.Insert(data, desc, level);
                }
                else
                {
                    Console.WriteLine("Error " + line);
                }
            }
            Random random = new Random();
            Node treeNode = null;
            int labelKey = -1;

            while (treeNode == null)
            {
                labelKey = random.Next(101, 555);
                if (labelKey % 10 != 0)
                {
                    treeNode = tree.Find(labelKey);
                    masterKey = labelKey;
                }
            }

            // Set the text for the label
            lblDescription.Text = treeNode.desc.Replace("&", "&&");

            

            Node buttonNode = null;
            buttonNode = tree.Find(int.Parse(labelKey.ToString()[0] + "00"));
            

            buttons.First().Text = buttonNode.data.ToString() + ", " + buttonNode.desc.Replace("&", "&&");
            buttons.Remove(buttons[0]);
            usedKeys.Add(buttonNode.data);

            lblDescription.Text = treeNode.desc.Replace("&", "&&");
            AssignDescriptionsToButtons(buttons, 3);
        }
        //List of randomly generated nodes for level 1. used in AssignDescriptionsToButtons method
        private List<Node> TopLevelNodes(int count, List<int> usedKeys)
        {
            List<Node> topLevelNodes = new List<Node>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                Node treeNode = null;
                int key = -1;

                while (treeNode == null)
                {
                    key = random.Next(100, 501); // Adjusted range to be between 100 and 500 (inclusive)

                    // Check if the key is divisible by 100 and not in the usedKeys list
                    if (key % 100 == 0 && !usedKeys.Contains(key))
                    {
                        treeNode = tree.Find(key);
                    }
                }

                topLevelNodes.Add(treeNode);
                usedKeys.Add(key); // Add the key to the usedKeys list
            }

            return topLevelNodes;
        }
        //List of randomly generated nodes for level 2. used in AssignDescriptionsToButtonsLevel2 method
        private List<Node> SecondLevelNodes(int count, List<int> usedKeys)
        {
            List<Node> secondLevelNodes = new List<Node>();
            Random random = new Random();

            string categoryStart = masterKey.ToString()[0].ToString(); // Convert to string explicitly

            for (int i = 0; i < count; i++)
            {
                Node treeNode = null;
                int key = -1;

                while (treeNode == null)
                {
                    key = int.Parse($"{categoryStart}{random.Next(10, 51)}"); // Adjusted range to be between 10 and 50 (inclusive)

                    // Check if the key is divisible by 10 and not in the usedKeys list
                    if (key % 10 == 0 && !usedKeys.Contains(key))
                    {
                        treeNode = tree.Find(key);
                    }
                }

                secondLevelNodes.Add(treeNode);
                usedKeys.Add(key); // Add the key to the usedKeys list
            }

            return secondLevelNodes;
        }

        //List of randomly generated nodes for level 3. used in AssignDescriptionsToButtonsLevel3 method
        private List<Node> ThirdLevelNodes(int count, List<int> usedKeys)
        {
            List<Node> secondLevelNodes = new List<Node>();
            Random random = new Random();

            string categoryStart = masterKey.ToString().Substring(0, 2);

            for (int i = 0; i < count; i++)
            {
                Node treeNode = null;
                int key = -1;

                while (treeNode == null)
                {
                    key = int.Parse($"{categoryStart}{random.Next(1, 9)}"); // Adjusted range to be between 1 and 9 (inclusive)

                    // Check if the key is divisible by 10 and not in the usedKeys list
                    if (!usedKeys.Contains(key))
                    {
                        treeNode = tree.Find(key);
                    }
                }

                secondLevelNodes.Add(treeNode);
                usedKeys.Add(key); // Add the key to the usedKeys list
            }

            return secondLevelNodes;
        }

        //Assign remaining, incorrect descriptions to buttons for level 1.
        private void AssignDescriptionsToButtons(List<Button> buttons, int count)
        {
            List<Node> topLevelNodes = TopLevelNodes(count, usedKeys);

            for (int i = 0; i < count; i++)
            {
                if (i < buttons.Count && topLevelNodes[i] != null)
                {
                    buttons[i].Text = topLevelNodes[i].data.ToString() + ", " + topLevelNodes[i].desc.Replace("&", "&&");
                }
                else
                {
                    // Handle the case where there are fewer buttons or the node is null
                    // You can set a default text or take appropriate action
                    buttons[i].Text = "Default Text";
                }
            }
        }

        //Assign remaining, incorrect descriptions to buttons for level 2.
        private void AssignDescriptionsToButtonsLevel2(List<Button> buttons, int count)
        {
            List<Node> secondLevelNodes = SecondLevelNodes(count, usedKeys);

            for (int i = 0; i < count; i++)
            {
                if (i < buttons.Count && secondLevelNodes[i] != null)
                {
                    buttons[i].Text = secondLevelNodes[i].data.ToString() + ", " + secondLevelNodes[i].desc.Replace("&", "&&");
                }
                else
                {
                    // Handle the case where there are fewer buttons or the node is null
                    // You can set a default text or take appropriate action
                    buttons[i].Text = "Default Text";
                }
            }
        }
        //Assign remaining, incorrect descriptions to buttons for level 3.
        private void AssignDescriptionsToButtonsLevel3(List<Button> buttons, int count)
        {
            List<Node> thirdLevelNodes = ThirdLevelNodes(count, usedKeys);

            for (int i = 0; i < count; i++)
            {
                if (i < buttons.Count && thirdLevelNodes[i] != null)
                {
                    buttons[i].Text = thirdLevelNodes[i].data.ToString() + ", " + thirdLevelNodes[i].desc.Replace("&", "&&");
                }
                else
                {
                    // Handle the case where there are fewer buttons or the node is null
                    // You can set a default text or take appropriate action
                    buttons[i].Text = "Default Text";
                }
            }
        }

        //Shuffle the buttons in list buttons
        private void ShuffleButtons(List<Button> buttons)
        {
            Random random = new Random();

            int n = buttons.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Button value = buttons[k];
                buttons[k] = buttons[n];
                buttons[n] = value;
            }
        }
        //Assign the correct value to a button for level two.
        private void assignCorrectButton()
        {
            Node buttonNode = null;
            int correctLevelTwoKey = int.Parse($"{masterKey.ToString()[0]}{masterKey.ToString()[1]}0");
            buttonNode = tree.Find(correctLevelTwoKey);
            if (buttonNode != null)
            {
                buttons[0].Text = buttonNode.data.ToString() + ", " + buttonNode.desc;
                buttons.RemoveAt(0);
                usedKeys.Add(correctLevelTwoKey);
            }
        }
        //Assign the correct value to a button for level three.
        private void assignCorrectButtonLevel3()
        {
            Node buttonNode = null;
            
            buttonNode = tree.Find(masterKey);
            if (buttonNode != null)
            {
                buttons[0].Text = buttonNode.data.ToString() + ", " + buttonNode.desc;
                buttons.RemoveAt(0);
                usedKeys.Add(masterKey);
            }
        }
        //On Click handler for button 1, checks what the current level is and checks if the user has gotten the question right.
        private void btnOption1_Click(object sender, EventArgs e)
        {
             if(level == 1)
             {
                if (checkButtonOption(btnOption1.Text.ToString())){
                    setUpLevel2();
                }

             }
            else if (level == 2)
            {
                if (checkButtonOptionLevel2(btnOption1.Text.ToString()))
                {
                    setUpLevel3();
                }
            }
            else if (level == 3)
            {
                if (checkButtonOptionLevel3(btnOption1.Text.ToString()))
                {
                    informWin();

                }
            }
        }

        //On Click handler for button 2, checks what the current level is and checks if the user has gotten the question right.
        private void btnOption2_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                if (checkButtonOption(btnOption2.Text.ToString())){
                    setUpLevel2();
                }

            }
            else if (level == 2)
            {
                if (checkButtonOptionLevel2(btnOption2.Text.ToString()))
                {
                    setUpLevel3();
                }
            }
            else if(level == 3)
            {
                if (checkButtonOptionLevel3(btnOption2.Text.ToString()))
                {
                    informWin();
                }
            }
        }
        //On Click handler for button 3, checks what the current level is and checks if the user has gotten the question right.
        private void btnOption3_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                if (checkButtonOption(btnOption3.Text.ToString())){
                    setUpLevel2();
                }

            }
            else if (level == 2)
            {
                if (checkButtonOptionLevel2(btnOption3.Text.ToString()))
                {
                    setUpLevel3();
                }
            }
            else if (level == 3)
            {
                if (checkButtonOptionLevel3(btnOption3.Text.ToString()))
                {
                    informWin();
                }
            }
        }
        //On Click handler for button 4, checks what the current level is and checks if the user has gotten the question right.
        private void btnOption4_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                if (checkButtonOption(btnOption4.Text.ToString())){
                    setUpLevel2();
                }

            }
            else if(level == 2)
            {
                if (checkButtonOptionLevel2(btnOption4.Text.ToString())) { 
                    setUpLevel3();
                }
            }
            else if (level == 3)
            {
                if (checkButtonOptionLevel3(btnOption4.Text.ToString()))
                {
                    informWin();
                }
            }
        }
        
        //Setup level 2 of game, re shuffle buttons and assign descriptions to buttons.
        private void setUpLevel2()
        {
            buttons.Clear();
            buttons.Add(btnOption1);
            buttons.Add(btnOption2);
            buttons.Add(btnOption3);
            buttons.Add(btnOption4);
            ShuffleButtons(buttons);
            assignCorrectButton();
            AssignDescriptionsToButtonsLevel2(buttons, 3);
            level = 2;
        }
        //Setup level 3 of game, re shuffle buttons and assign descriptions to buttons.
        private void setUpLevel3()
        {
            buttons.Clear();
            buttons.Add(btnOption1);
            buttons.Add(btnOption2);
            buttons.Add(btnOption3);
            buttons.Add(btnOption4);
            ShuffleButtons(buttons);
            assignCorrectButtonLevel3();
            AssignDescriptionsToButtonsLevel3(buttons, 3);
            level = 3;
        }

        //Inform user of win, disable buttons for game options, restart and quit still enabled
        //Inform user how long they took to complete the game as well as different, encouraging messages based on how fast they complete the game.
        private void informWin()
        {
            
            stopwatch.Stop();

            timer.Stop();
            Application.DoEvents();

            double elapsedSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 2, MidpointRounding.AwayFromZero);

            if (elapsedSeconds > 60)
            {
                MessageBox.Show($"Nice! you completed the game in {elapsedSeconds} seconds, do you think you can go faster?");
            }
            else if (30 <= elapsedSeconds && elapsedSeconds <= 60)
            {
                MessageBox.Show($"Not bad! you completed the game in only {elapsedSeconds} seconds, do you think it can be done any quicker?");
            }
            else if(15 <= elapsedSeconds && elapsedSeconds <= 29)
            {
                MessageBox.Show($"Getting pretty quick! it only took you {elapsedSeconds} seconds to complete the game! \r\n Do you think it can be done any quicker?");
            }
            else if (6 <= elapsedSeconds && elapsedSeconds <= 14)
            {
                MessageBox.Show($"Im impressed! only {elapsedSeconds} seconds to complete the game! \r\n Surely it cannot be done any faster than that!");
            }
            else if (elapsedSeconds < 5)
            {
                MessageBox.Show($"Unbelieveable!!! {elapsedSeconds} seconds to complete the game! \r\n If I could give you a gold medal I would");
            }

            btnOption1.Enabled = false;
            btnOption2.Enabled = false;
            btnOption3.Enabled = false;
            btnOption4.Enabled = false;

            btnPlayAgain.BackColor = Color.Green;
            btnQuit.BackColor = Color.Red;

            
        }

        //Inform user of loss, restart the game
        private void informLoss()
        {

            timer.Stop();
            Application.DoEvents();

            MessageBox.Show("Unlucky! that was not the correct answer \r\n" +
                "Keep it up and try again! I am sure you will get it next time!");

            FindNumbers newNumbers = new FindNumbers();

            // Attach the FormClosing event handler
            newNumbers.FormClosing += NewNumbers_FormClosing;

            // Hide the current form
            this.Hide();

            // Show the new form
            newNumbers.Show();
        }
        //Check button Level 1 method, checks if the level 1 item selected is correct.
        private bool checkButtonOption(string text)
        {
            if (masterKey.ToString()[0] == text[0])
            {
                
                return true;
                
            }
            else 
            {
                informLoss();
                return false; 
            }

        }
        //Check button Level 2 method, checks if the level 2 item selected is correct.
        private bool checkButtonOptionLevel2(string text)
        {
            if (masterKey.ToString().Substring(0, 2) == text.Substring(0, 2))
            {
                
                return true;

            }
            else
            {
                informLoss();
                return false;
            }

        }
        //Check button Level 3 method, checks if the level 3 item selected is correct.
        private bool checkButtonOptionLevel3(string text)
        {
            if (masterKey.ToString() == text.Substring(0, 3))
            {
                
                return true;

            }
            else
            {
                informLoss();
                return false;
            }

        }
        //Form load event, starts timer
        private void FindNumbers_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimeEvent;
            timer.Start();
        }

        //https://www.youtube.com/watch?v=0cnM8LypCnA&ab_channel=FoxLearn
        //On Time Event, used to update the timer on the screen
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (IsHandleCreated && !IsDisposed && Visible)  // Check if the form is still visible
                {
                    s += 1;
                    if (s == 60)
                    {
                        s = 0;
                        m += 1;
                    }
                    if (m == 60)
                    {
                        m = 0;
                        h += 1;
                    }
                    txtTimer.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'),
                        m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                }
            }));
        }
        //Quit button, closes the game.
        private void btnQuit_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            this.Close();
        }

        private void FindNumbers_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        //Help button, creates messagebox with instructions and information for playing the game.
        private void btnHelp_Click(object sender, EventArgs e)
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

            MessageBox.Show(rules, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            FindNumbers newNumbers = new FindNumbers();

            // Attach the FormClosing event handler
            newNumbers.FormClosing += NewNumbers_FormClosing;

            // Hide the current form
            this.Hide();

            // Show the new form
            newNumbers.Show();
        }

        private void NewNumbers_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer.Stop();
            timer.Dispose();
            // Unsubscribe from the FormClosing event to prevent memory leaks
            ((FindNumbers)sender).FormClosing -= NewNumbers_FormClosing;

            // Close the current form when the new form is closing
            Application.Exit();

            
        }
    }
}
