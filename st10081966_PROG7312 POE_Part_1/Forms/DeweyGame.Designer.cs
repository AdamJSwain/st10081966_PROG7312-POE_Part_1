using System;
using System.Windows.Forms;

namespace st10081966_PROG7312_POE_Part_1.Forms
{
    partial class DeweyGame
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
            this.fpTop = new System.Windows.Forms.FlowLayoutPanel();
            this.fpBot = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtHealth = new System.Windows.Forms.TextBox();
            this.Book1 = new System.Windows.Forms.PictureBox();
            this.Book2 = new System.Windows.Forms.PictureBox();
            this.Book3 = new System.Windows.Forms.PictureBox();
            this.Book4 = new System.Windows.Forms.PictureBox();
            this.Book5 = new System.Windows.Forms.PictureBox();
            this.Book6 = new System.Windows.Forms.PictureBox();
            this.Book7 = new System.Windows.Forms.PictureBox();
            this.Book8 = new System.Windows.Forms.PictureBox();
            this.Book9 = new System.Windows.Forms.PictureBox();
            this.Book10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.PBHealthIndicator = new System.Windows.Forms.PictureBox();
            this.pbBookShelf = new System.Windows.Forms.PictureBox();
            this.fpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Book1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBHealthIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookShelf)).BeginInit();
            this.SuspendLayout();
            // 
            // fpTop
            // 
            this.fpTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.fpTop.Controls.Add(this.Book1);
            this.fpTop.Controls.Add(this.Book2);
            this.fpTop.Controls.Add(this.Book3);
            this.fpTop.Controls.Add(this.Book4);
            this.fpTop.Controls.Add(this.Book5);
            this.fpTop.Controls.Add(this.Book6);
            this.fpTop.Controls.Add(this.Book7);
            this.fpTop.Controls.Add(this.Book8);
            this.fpTop.Controls.Add(this.Book9);
            this.fpTop.Controls.Add(this.Book10);
            this.fpTop.Controls.Add(this.pictureBox8);
            this.fpTop.Controls.Add(this.pictureBox9);
            this.fpTop.Controls.Add(this.pictureBox10);
            this.fpTop.Controls.Add(this.pictureBox11);
            this.fpTop.Location = new System.Drawing.Point(12, 21);
            this.fpTop.Name = "fpTop";
            this.fpTop.Size = new System.Drawing.Size(613, 105);
            this.fpTop.TabIndex = 2;
            // 
            // fpBot
            // 
            this.fpBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.fpBot.Location = new System.Drawing.Point(12, 265);
            this.fpBot.Name = "fpBot";
            this.fpBot.Size = new System.Drawing.Size(613, 106);
            this.fpBot.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(713, 406);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(551, 406);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(104, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset Books";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtHealth
            // 
            this.txtHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHealth.Location = new System.Drawing.Point(645, 24);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(89, 22);
            this.txtHealth.TabIndex = 6;
            this.txtHealth.TextChanged += new System.EventHandler(this.txtHealth_TextChanged);
            // 
            // Book1
            // 
            this.Book1.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.red_with_sun;
            this.Book1.Location = new System.Drawing.Point(3, 3);
            this.Book1.Name = "Book1";
            this.Book1.Size = new System.Drawing.Size(55, 103);
            this.Book1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book1.TabIndex = 1;
            this.Book1.TabStop = false;
            // 
            // Book2
            // 
            this.Book2.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.orange_with_stripes;
            this.Book2.Location = new System.Drawing.Point(64, 3);
            this.Book2.Name = "Book2";
            this.Book2.Size = new System.Drawing.Size(55, 103);
            this.Book2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book2.TabIndex = 10;
            this.Book2.TabStop = false;
            // 
            // Book3
            // 
            this.Book3.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.blue_with_egg;
            this.Book3.Location = new System.Drawing.Point(125, 3);
            this.Book3.Name = "Book3";
            this.Book3.Size = new System.Drawing.Size(55, 103);
            this.Book3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book3.TabIndex = 11;
            this.Book3.TabStop = false;
            // 
            // Book4
            // 
            this.Book4.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.Dark_blue_with_stripes;
            this.Book4.Location = new System.Drawing.Point(186, 3);
            this.Book4.Name = "Book4";
            this.Book4.Size = new System.Drawing.Size(55, 103);
            this.Book4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book4.TabIndex = 12;
            this.Book4.TabStop = false;
            // 
            // Book5
            // 
            this.Book5.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.green;
            this.Book5.Location = new System.Drawing.Point(247, 3);
            this.Book5.Name = "Book5";
            this.Book5.Size = new System.Drawing.Size(55, 103);
            this.Book5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book5.TabIndex = 13;
            this.Book5.TabStop = false;
            // 
            // Book6
            // 
            this.Book6.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.Light_blue;
            this.Book6.Location = new System.Drawing.Point(308, 3);
            this.Book6.Name = "Book6";
            this.Book6.Size = new System.Drawing.Size(55, 103);
            this.Book6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book6.TabIndex = 14;
            this.Book6.TabStop = false;
            // 
            // Book7
            // 
            this.Book7.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.orange_with_egg;
            this.Book7.Location = new System.Drawing.Point(369, 3);
            this.Book7.Name = "Book7";
            this.Book7.Size = new System.Drawing.Size(55, 103);
            this.Book7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book7.TabIndex = 15;
            this.Book7.TabStop = false;
            // 
            // Book8
            // 
            this.Book8.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.Red_book;
            this.Book8.Location = new System.Drawing.Point(430, 3);
            this.Book8.Name = "Book8";
            this.Book8.Size = new System.Drawing.Size(55, 103);
            this.Book8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book8.TabIndex = 16;
            this.Book8.TabStop = false;
            // 
            // Book9
            // 
            this.Book9.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.Blue_and_Orange;
            this.Book9.Location = new System.Drawing.Point(491, 3);
            this.Book9.Name = "Book9";
            this.Book9.Size = new System.Drawing.Size(55, 103);
            this.Book9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book9.TabIndex = 17;
            this.Book9.TabStop = false;
            // 
            // Book10
            // 
            this.Book10.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.brown;
            this.Book10.Location = new System.Drawing.Point(552, 3);
            this.Book10.Name = "Book10";
            this.Book10.Size = new System.Drawing.Size(55, 103);
            this.Book10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Book10.TabIndex = 18;
            this.Book10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(3, 112);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(0, 0);
            this.pictureBox8.TabIndex = 6;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(9, 112);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(0, 0);
            this.pictureBox9.TabIndex = 7;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(15, 112);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(0, 0);
            this.pictureBox10.TabIndex = 8;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Location = new System.Drawing.Point(21, 112);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(0, 0);
            this.pictureBox11.TabIndex = 9;
            this.pictureBox11.TabStop = false;
            // 
            // PBHealthIndicator
            // 
            this.PBHealthIndicator.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.icons8_heart_48;
            this.PBHealthIndicator.Location = new System.Drawing.Point(740, 12);
            this.PBHealthIndicator.Name = "PBHealthIndicator";
            this.PBHealthIndicator.Size = new System.Drawing.Size(48, 45);
            this.PBHealthIndicator.TabIndex = 1;
            this.PBHealthIndicator.TabStop = false;
            // 
            // pbBookShelf
            // 
            this.pbBookShelf.Image = global::st10081966_PROG7312_POE_Part_1.Properties.Resources.bookshelves;
            this.pbBookShelf.Location = new System.Drawing.Point(12, 12);
            this.pbBookShelf.Name = "pbBookShelf";
            this.pbBookShelf.Size = new System.Drawing.Size(613, 370);
            this.pbBookShelf.TabIndex = 0;
            this.pbBookShelf.TabStop = false;
            // 
            // DeweyGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtHealth);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.fpBot);
            this.Controls.Add(this.fpTop);
            this.Controls.Add(this.PBHealthIndicator);
            this.Controls.Add(this.pbBookShelf);
            this.Name = "DeweyGame";
            this.Text = "DeweyGame";
            this.fpTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Book1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Book10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBHealthIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookShelf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.PictureBox pbBookShelf;
        private System.Windows.Forms.PictureBox PBHealthIndicator;
        private System.Windows.Forms.FlowLayoutPanel fpTop;
        private System.Windows.Forms.FlowLayoutPanel fpBot;
        private System.Windows.Forms.PictureBox Book1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox Book2;
        private System.Windows.Forms.PictureBox Book3;
        private System.Windows.Forms.PictureBox Book4;
        private System.Windows.Forms.PictureBox Book5;
        private System.Windows.Forms.PictureBox Book6;
        private System.Windows.Forms.PictureBox Book7;
        private System.Windows.Forms.PictureBox Book8;
        private System.Windows.Forms.PictureBox Book9;
        private System.Windows.Forms.PictureBox Book10;
        private Button btnReset;
        private TextBox txtHealth;
    }
}