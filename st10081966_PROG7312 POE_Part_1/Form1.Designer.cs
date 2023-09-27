namespace st10081966_PROG7312_POE_Part_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnReOrderBooks = new System.Windows.Forms.Button();
            this.btnIdentifyAreas = new System.Windows.Forms.Button();
            this.btnFindNumbers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReOrderBooks
            // 
            this.btnReOrderBooks.Location = new System.Drawing.Point(57, 94);
            this.btnReOrderBooks.Name = "btnReOrderBooks";
            this.btnReOrderBooks.Size = new System.Drawing.Size(95, 56);
            this.btnReOrderBooks.TabIndex = 0;
            this.btnReOrderBooks.Text = "Replace Books";
            this.btnReOrderBooks.UseVisualStyleBackColor = true;
            this.btnReOrderBooks.Click += new System.EventHandler(this.btnReOrderBooks_Click);
            // 
            // btnIdentifyAreas
            // 
            this.btnIdentifyAreas.Location = new System.Drawing.Point(57, 198);
            this.btnIdentifyAreas.Name = "btnIdentifyAreas";
            this.btnIdentifyAreas.Size = new System.Drawing.Size(95, 56);
            this.btnIdentifyAreas.TabIndex = 2;
            this.btnIdentifyAreas.Text = "Identify Areas";
            this.btnIdentifyAreas.UseVisualStyleBackColor = true;
            this.btnIdentifyAreas.Click += new System.EventHandler(this.btnIdentifyAreas_Click);
            // 
            // btnFindNumbers
            // 
            this.btnFindNumbers.Location = new System.Drawing.Point(57, 301);
            this.btnFindNumbers.Name = "btnFindNumbers";
            this.btnFindNumbers.Size = new System.Drawing.Size(95, 56);
            this.btnFindNumbers.TabIndex = 3;
            this.btnFindNumbers.Text = "Find Numbers";
            this.btnFindNumbers.UseVisualStyleBackColor = true;
            this.btnFindNumbers.Click += new System.EventHandler(this.btnFindNumbers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 451);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.DeweyPicture;
            this.pictureBox2.Location = new System.Drawing.Point(236, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(522, 344);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnFindNumbers);
            this.Controls.Add(this.btnIdentifyAreas);
            this.Controls.Add(this.btnReOrderBooks);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReOrderBooks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIdentifyAreas;
        private System.Windows.Forms.Button btnFindNumbers;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

