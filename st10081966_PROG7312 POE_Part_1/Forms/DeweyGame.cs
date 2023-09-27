using st10081966_PROG7312_POE_Part_1.Classes;
using st10081966_PROG7312_POE_Part_1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace st10081966_PROG7312_POE_Part_1.Forms
{
    public partial class DeweyGame : Form
    {
        // List to store PictureBox controls
        private List<PictureBox> PictureList = new List<PictureBox>();

        // Instance of the Generator class
        Generator generator = new Generator();

        // FlowLayoutPanel for arranging PictureBox controls
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

        // Variables for tracking the currently dragged PictureBox
        private PictureBox currentlyDraggedPictureBox = null;
        private Point originalMousePosition;
        private Point originalPictureBoxPosition;
        private FlowLayoutPanel sourcePanel;

        // Correct order list
        private List<string> correctOrder = new List<string>();

        // Constructor
        public DeweyGame()
        {
            InitializeComponent();

            // Set AllowDrop property for Drag and Drop functionality
            fpBot.AllowDrop = true;
            fpTop.AllowDrop = true;
            fpTop.SendToBack();
            pbBookShelf.SendToBack();

            // Initialize PictureList with PictureBox controls
            PictureList.Add(Book1);
            PictureList.Add(Book2);
            PictureList.Add(Book3);
            PictureList.Add(Book4);
            PictureList.Add(Book5);
            PictureList.Add(Book6);
            PictureList.Add(Book7);
            PictureList.Add(Book8);
            PictureList.Add(Book9);
            PictureList.Add(Book10);

            txtHealth.Text = "Health: 100";
            txtHealth.ReadOnly = true;
            txtHealth.Enabled = false;

            // Configure event handlers and labels for each PictureBox
            foreach (PictureBox pictureBox in PictureList)
            {
                pictureBox.AllowDrop = true;

                // Register event handlers
                pictureBox.MouseDown += PictureBox_MouseDown;
                PictureBox_SetupEvents(pictureBox);

                // Generate a random Dewey Decimal number
                string deweyNumber = generator.GenerateRandomDeweyDecimal();
                correctOrder.Add(deweyNumber);

                // Create and configure a label for the PictureBox
                Label label = new Label
                {
                    Text = deweyNumber,
                    BackColor = Color.White,
                    Font = pictureBox.Font
                };

                // Set the label size based on the text and font
                Size textSize = TextRenderer.MeasureText(label.Text, label.Font);
                label.Size = textSize;

                // Center the label within the PictureBox
                int centerX = (pictureBox.Width - textSize.Width) / 2;
                int centerY = (pictureBox.Height - textSize.Height) / 2;
                label.Location = new Point(centerX, centerY);

                // Add the label to the PictureBox
                pictureBox.Controls.Add(label);
                correctOrder.Sort(new DeweyDecimalComparer());
            }

            // Configure DragEnter and DragDrop event handlers for FlowLayoutPanel
            fpBot.DragEnter += FlowLayoutPanel_DragEnter;
            fpBot.DragDrop += FlowLayoutPanel_DragDrop;

            // Set form properties
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        // Event handler for PictureBox MouseUp event
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentlyDraggedPictureBox != null && sourcePanel != null)
            {
                // Get the destination FlowLayoutPanel
                FlowLayoutPanel destinationPanel = (FlowLayoutPanel)sender;

                if (destinationPanel != sourcePanel)
                {
                    // Move the PictureBox from the source panel to the destination panel
                    sourcePanel.Controls.Remove(currentlyDraggedPictureBox);
                    destinationPanel.Controls.Add(currentlyDraggedPictureBox);

                    // Reset Z-order to ensure proper ordering of PictureBoxes
                    ResetPictureBoxZOrder(destinationPanel);

                    if (destinationPanel == fpBot)
                    {
                        // Reassign DragDrop event handlers to the PictureBox
                        currentlyDraggedPictureBox.MouseDown -= PictureBox_MouseDown;
                        currentlyDraggedPictureBox.MouseMove -= PictureBox_MouseMove;
                        currentlyDraggedPictureBox.MouseUp -= PictureBox_MouseUp;
                        currentlyDraggedPictureBox.MouseDown += PictureBox_MouseDown;
                        currentlyDraggedPictureBox.MouseMove += PictureBox_MouseMove;
                        currentlyDraggedPictureBox.MouseUp += PictureBox_MouseUp;
                    }
                }
            }

            currentlyDraggedPictureBox = null;
        }

        // Reset the Z-order of PictureBoxes in the destination FlowLayoutPanel
        private void ResetPictureBoxZOrder(FlowLayoutPanel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                panel.Controls.SetChildIndex(panel.Controls[i], i);
            }
        }

        // Event handlers for Drag and Drop operations
        private void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(PictureBox)) is PictureBox pictureBox)
            {
                // Get the source and destination panels
                sourcePanel = (FlowLayoutPanel)pictureBox.Parent;
                FlowLayoutPanel destinationPanel = (FlowLayoutPanel)sender;

                if (destinationPanel == fpBot && destinationPanel != sourcePanel)
                {
                    // Bring the PictureBox to the front (in terms of Z-order)
                    pictureBox.BringToFront();
                    currentlyDraggedPictureBox = pictureBox;
                    pictureBox.Parent = destinationPanel;
                }
                else
                {
                    currentlyDraggedPictureBox = null;
                }
            }
        }

        // Event handler when the mouse is moving
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentlyDraggedPictureBox != null && e.Button == MouseButtons.Left)
            {
                if (!currentlyDraggedPictureBox.Visible)
                {
                    // Show the PictureBox when dragging starts
                    currentlyDraggedPictureBox.Visible = true;
                }

                // Calculate the new position of the PictureBox based on the mouse movement
                int deltaX = e.X - originalMousePosition.X;
                int deltaY = e.Y - originalMousePosition.Y;
                currentlyDraggedPictureBox.Left = originalPictureBoxPosition.X + deltaX;
                currentlyDraggedPictureBox.Top = originalPictureBoxPosition.Y + deltaY;

                if (currentlyDraggedPictureBox.Parent == fpBot)
                {
                    // Update the Z-order during the drag operation within the fpBot panel
                    int targetIndex = GetTargetIndex(fpBot, currentlyDraggedPictureBox);
                    currentlyDraggedPictureBox.Parent.Controls.SetChildIndex(currentlyDraggedPictureBox, targetIndex);
                }
            }
        }

        // Get the target index for reordering PictureBoxes in the fpBot panel
        private int GetTargetIndex(FlowLayoutPanel panel, PictureBox pictureBox)
        {
            int targetIndex = -1;

            Point pictureBoxLocation = pictureBox.PointToScreen(Point.Empty);
            Point panelLocation = panel.PointToScreen(Point.Empty);

            for (int i = 0; i < panel.Controls.Count; i++)
            {
                PictureBox currentPictureBox = (PictureBox)panel.Controls[i];
                Point currentPictureBoxLocation = currentPictureBox.PointToScreen(Point.Empty);

                if (pictureBoxLocation.Y < currentPictureBoxLocation.Y &&
                    pictureBoxLocation.Y < panelLocation.Y)
                {
                    targetIndex = 0; // Place PictureBox at the beginning
                    break;
                }
                else if (pictureBoxLocation.Y >= currentPictureBoxLocation.Y &&
                         pictureBoxLocation.Y + pictureBox.Height <
                         currentPictureBoxLocation.Y + currentPictureBox.Height)
                {
                    targetIndex = i; // Place PictureBox at the current index
                    break;
                }
                else if (i == panel.Controls.Count - 1)
                {
                    targetIndex = panel.Controls.Count; // Place PictureBox at the end
                }
            }

            return targetIndex;
        }

        // Event handler for PictureBox MouseDown event
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                currentlyDraggedPictureBox = pictureBox;
                originalMousePosition = e.Location;
                originalPictureBoxPosition = pictureBox.Location;
                pictureBox.DoDragDrop(pictureBox, DragDropEffects.Move);
            }
        }

        // Setup event handlers for PictureBox controls
        private void PictureBox_SetupEvents(PictureBox pictureBox)
        {
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.AllowDrop = true;
        }

        // Number of attempts made
        int NumberOfAttempts = 0;

        // Event handler for Submit button click
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fpBot.Controls.Count != 10)
            {
                MessageBox.Show("Please place all the books in the bottom shelf before submitting.");
                return;
            }

            if (CheckOrder())
            {
                MessageBox.Show("Congratulations, you ordered the books correctly!");
                this.Close();
                

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
                    MessageBox.Show("You have run out of health, Game Over");
                    this.Close();
                }
            }
        }

       

        // Event handler for Reset button click
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Move all PictureBox controls back to fpTop from fpBot
            foreach (PictureBox pictureBox in fpBot.Controls.OfType<PictureBox>().ToList())
            {
                fpBot.Controls.Remove(pictureBox);
                fpTop.Controls.Add(pictureBox);
            }
        }

        private bool CheckOrder()
        {
            // Get the sorted Dewey Decimal numbers from correctOrder list
            List<string> sortedOrder = new List<string>(correctOrder);

            // Compare the book order with the sorted order
            foreach (PictureBox pictureBox in fpBot.Controls.OfType<PictureBox>())
            {
                Label label = pictureBox.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                {
                    string deweyNumber = label.Text;

                    if (!sortedOrder.Contains(deweyNumber) || sortedOrder[0] != deweyNumber)
                    {
                        return false; // Books are not in correct order
                    }

                    sortedOrder.Remove(deweyNumber);
                }
            }

            return true; // Books are in correct order
        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
