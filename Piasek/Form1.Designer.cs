﻿namespace Piasek
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            obraz = new Panel();
            textBox1 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(591, 12);
            button1.Name = "button1";
            button1.Size = new Size(84, 23);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // obraz
            // 
            obraz.Location = new Point(12, 109);
            obraz.Name = "obraz";
            obraz.Size = new Size(776, 329);
            obraz.TabIndex = 1;
            obraz.Paint += obraz_Paint;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(132, 23);
            textBox1.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Interval = 300;
            timer2.Tick += timer2_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(591, 41);
            button2.Name = "button2";
            button2.Size = new Size(84, 23);
            button2.TabIndex = 3;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(obraz);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Sand";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel obraz;
        private TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Button button2;
    }
}