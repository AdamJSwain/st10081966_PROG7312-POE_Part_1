using st10081966_PROG7312_POE_Part_1.Classes;
using st10081966_PROG7312_POE_Part_1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace st10081966_PROG7312_POE_Part_1.Forms
{
    public partial class MatchColumns : Form
    {
        // Dictionary to store Dewey Decimal System information
        Dictionary<string, string> deweyInfo = new Dictionary<string, string>
    {
        {"000", "General Knowledge"},
        {"100", "Philosophy & Psychology"},
        {"200", "Religion"},
        {"300", "Social Science"},
        {"400", "Languages"},
        {"500", "Science"},
        {"600", "Technology"},
        {"700", "Arts and Recreation"},
        {"800", "Literature"},
        {"900", "History & Geography"}
    };

        // Two additional dictionaries to store Dewey Decimal System information
        Dictionary<string, string> deweyInfo2 = new Dictionary<string, string>
    {
        {"General Knowledge", "000"},
        {"Philosophy & Psychology", "100"},
        {"Religion", "200"},
        {"Social Science", "300"},
        {"Languages", "400"},
        {"Science", "500"},
        {"Technology", "600"},
        {"Arts and Recreation", "700"},
        {"Literature", "800"},
        {"History & Geography", "900"}
    };

        Dictionary<string, string> deweyInfo3 = new Dictionary<string, string>
    {
        {"000", "General Knowledge"},
        {"100", "Philosophy & Psychology"},
        {"200", "Religion"},
        {"300", "Social Science"},
        {"400", "Languages"},
        {"500", "Science"},
        {"600", "Technology"},
        {"700", "Arts and Recreation"},
        {"800", "Literature"},
        {"900", "History & Geography"}
    };

        // Variables to keep track of the number of correct picture boxes and attempts
        int HowManyPictureBoxesAreInTheRightPlace = 0;
        int NumberOfAttempts;

        Random random = new Random();
        List<PictureBox> bookList = new List<PictureBox>();
        List<FlowLayoutPanel> flowLayoutList = new List<FlowLayoutPanel>();
        List<string> correctAnswers = new List<string>();
        private PictureBox currentDraggedPictureBox;


        public MatchColumns()
        {
            // Choose one of the two dictionaries randomly
            bool result = random.Next(2) == 0;
            if (result)
            {
                deweyInfo = deweyInfo2;
            }
            else
            {
                deweyInfo = deweyInfo3;
            }

            InitializeComponent();

            // Set initial value for health indicator text box
            txtHealth.Text = "Health: 100";
            txtHealth.Enabled = false;

            // Add picture boxes and flow layout panels to lists
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);

            flowLayoutList.Add(fpBot1);
            flowLayoutList.Add(fpBot2);
            flowLayoutList.Add(fpBot3);
            flowLayoutList.Add(fpBot4);
            flowLayoutList.Add(fpBot5);
            flowLayoutList.Add(fpBot6);
            flowLayoutList.Add(fpBot7);

            // Shuffle flow layout panels and generate picture box labels and flow layout labels
            ShuffleFlowLayoutPanels();
            GeneratePictureBoxLabels();
            GenerateFlowLayoutLabels();
            AttachDragDropEvents();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        // Event handler for form load event
        private void MatchColumns_Load(object sender, EventArgs e)
        {

        }

        // Attach drag and drop events to picture boxes and flow layout panels
        private void AttachDragDropEvents()
        {
            foreach (PictureBox pictureBox in bookList)
            {
                pictureBox.MouseDown += PictureBox_MouseDown;
                pictureBox.MouseUp += PictureBox_MouseUp;
            }

            foreach (FlowLayoutPanel panel in flowLayoutList)
            {
                panel.AllowDrop = true;
                panel.DragEnter += FlowLayoutPanel_DragEnter;
                panel.DragDrop += FlowLayoutPanel_DragDrop;
            }
        }

        // Event handler for picture box mouse down event
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            currentDraggedPictureBox = (PictureBox)sender;
            currentDraggedPictureBox.DoDragDrop(currentDraggedPictureBox, DragDropEffects.Move);
        }

        // Event handler for picture box mouse up event
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            currentDraggedPictureBox = null;
        }

        // Event handler for flow layout panel drag enter event
        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a PictureBox
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // Event handler for flow layout panel drag drop event
        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel destinationFlowPanel = (FlowLayoutPanel)sender;
            PictureBox draggedPictureBox = (PictureBox)e.Data.GetData(typeof(PictureBox));

            // Check if the destination FlowLayoutPanel already contains a PictureBox
            if (destinationFlowPanel.Controls.Count > 0)
            {
                PictureBox existingPictureBox = (PictureBox)destinationFlowPanel.Controls[0];
                // Move the existing PictureBox back to its original parent
                ContainerControl originalParent = (ContainerControl)existingPictureBox.Tag;
                originalParent.Controls.Add(existingPictureBox);
            }

            // Move the dragged PictureBox to the destination FlowLayoutPanel
            destinationFlowPanel.Controls.Add(draggedPictureBox);
            draggedPictureBox.Tag = destinationFlowPanel; // Store the new parent in the PictureBox's Tag property

            // Compare the label text with the FlowLayoutPanel name
            System.Windows.Forms.Label label = (System.Windows.Forms.Label)draggedPictureBox.Controls[0];

            string expectedDescription;
            if (deweyInfo.TryGetValue(label.Text.ToString(), out expectedDescription))
            {
                if (destinationFlowPanel.Name == expectedDescription)
                {
                    HowManyPictureBoxesAreInTheRightPlace++;
                }
            }
        }

        // Generate labels for picture boxes
        private void GeneratePictureBoxLabels()
        {
            List<string> selectedNumbers = new List<string>(deweyInfo.Keys);

            foreach (PictureBox pictureBox in bookList)
            {
                pictureBox.AllowDrop = true;

                string deweyNumber = GetRandomUniqueDeweyNumber(selectedNumbers);
                correctAnswers.Add(deweyNumber);

                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                {
                    Text = deweyNumber,
                    BackColor = Color.White,
                    Font = pictureBox.Font
                };

                Size textSize = TextRenderer.MeasureText(label.Text, label.Font);
                label.Size = textSize;

                int centerX = (pictureBox.Width - textSize.Width) / 2;
                int centerY = (pictureBox.Height - textSize.Height) / 2;
                label.Location = new Point(centerX, centerY);

                pictureBox.Controls.Add(label);
            }
        }

        // Generate labels for flow layout panels
        private void GenerateFlowLayoutLabels()
        {
            List<string> selectedNumbers = new List<string>(deweyInfo.Keys);

            List<string> correctDescriptions = correctAnswers.Select(answer => deweyInfo[answer]).ToList();
            List<string> incorrectDescriptions = deweyInfo.Values.Except(correctDescriptions).ToList();
            ShuffleStrings(incorrectDescriptions);

            int correctIndex = 0;
            int incorrectIndex = 0;

            foreach (FlowLayoutPanel panel in flowLayoutList)
            {
                panel.AllowDrop = true;

                System.Windows.Forms.Label label;

                if (correctIndex < correctAnswers.Count)
                {
                    string deweyNumber = correctAnswers[correctIndex];
                    string description = deweyInfo[deweyNumber];
                    label = CreateAndPositionLabel(description, panel);
                    correctIndex++;
                    panel.Name = label.Text;
                }
                else
                {
                    string description = incorrectDescriptions[incorrectIndex];
                    label = CreateAndPositionLabel(description, panel);
                    incorrectIndex++;
                    panel.Name = label.Text;
                }
            }
        }

        // Create and position flow layout panel label
        private System.Windows.Forms.Label CreateAndPositionLabel(string text, FlowLayoutPanel panel)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = text;
            label.AutoSize = true;

            Point panelLocation = panel.Location;
            Point labelLocation = new Point(panelLocation.X, panelLocation.Y + panel.Height + 3);
            label.Location = labelLocation;

            this.Controls.Add(label); // Add label to the form

            label.BringToFront();

            return label;
        }

        private string GetRandomUniqueDeweyNumber(List<string> selectedNumbers)
        {
            if (selectedNumbers.Count > 0)
            {
                // Get a random index within the range of selectedNumbers count
                int randomIndex = random.Next(selectedNumbers.Count);
                // Get the string at the random index position
                string deweyNumber = selectedNumbers[randomIndex];
                // Remove the selected number from the list
                selectedNumbers.RemoveAt(randomIndex);
                // Return the selected and removed deweyNumber
                return deweyNumber;
            }
            else
            {
                // Return a default string indicating no numbers are available
                return "No number available";
            }
        }

        public static void Shuffle(List<FlowLayoutPanel> list)
        {
            Random random = new Random();
            int n = list.Count;

            // Shuffle the list by swapping elements randomly
            while (n > 1)
            {
                n--;
                // Get a random index within the range of remaining unshuffled elements
                int k = random.Next(n + 1);
                // Swap the value at index k with the value at index n
                FlowLayoutPanel value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void ShuffleFlowLayoutPanels()
        {
            List<FlowLayoutPanel> fpBotPanels = new List<FlowLayoutPanel>
    {
        fpBot1, fpBot2, fpBot3, fpBot4, fpBot5, fpBot6, fpBot7
    };

            Shuffle(fpBotPanels);

            // Update the flowLayoutList with the shuffled panels
            for (int i = 0; i < flowLayoutList.Count; i++)
            {
                flowLayoutList[i] = fpBotPanels[i];
            }
        }

        public static List<string> ShuffleStrings(List<string> list)
        {
            Random random = new Random();
            int n = list.Count;

            // Shuffle the list by swapping elements randomly
            while (n > 1)
            {
                n--;
                // Get a random index within the range of remaining unshuffled elements
                int k = random.Next(n + 1);
                // Swap the value at index k with the value at index n
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            // Return the shuffled list
            return list;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MatchColumns newColumns = new MatchColumns();

            // Attach the FormClosed event handler
            newColumns.FormClosed += NewColumns_FormClosed;

            // Hide the current form (instead of closing it immediately)
            this.Hide();

            // Wait for a short delay (you can adjust the milliseconds as needed)
            await Task.Delay(100);

            // Show the new form
            newColumns.Show();
        }

        private void NewColumns_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Unsubscribe from the FormClosed event to prevent memory leaks
            ((MatchColumns)sender).FormClosed -= NewColumns_FormClosed;

            // Close the new form when it's closed
            ((MatchColumns)sender).Close();
            // Close the current form after the new form is closed
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (HowManyPictureBoxesAreInTheRightPlace == 4)
            {
                // Display a message indicating the user won
                MessageBox.Show("You win!");
            }
            else
            {
                NumberOfAttempts++;
                // Update the health indicator image based on the number of attempts
                if (NumberOfAttempts == 1)
                {
                    PBHealthIndicator.Image = Resources.icons8_heart_48__1_;
                    txtHealth.Text = "Health: 66";
                }
                else if (NumberOfAttempts == 2)
                {
                    PBHealthIndicator.Image = Resources.icons8_heart_48__2_;
                    txtHealth.Text = "Health: 33";
                }
                else if (NumberOfAttempts == 3)
                {
                    PBHealthIndicator.Image = Resources.icons8_heart_48__3_;
                    txtHealth.Text = "Health: 0";
                    // Display a message indicating the user ran out of health
                    MessageBox.Show("You have run out of health, Game Over");
                    // Disable the submit button
                    btnSubmit.Enabled = false;
                }
            }
        }
    }
}
