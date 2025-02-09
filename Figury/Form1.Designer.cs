namespace Figury
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
            panel1 = new Panel();
            zasobnikFigur = new ComboBox();
            label1 = new Label();
            p0 = new Label();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            p1 = new Label();
            numericUpDown3 = new NumericUpDown();
            p3 = new Label();
            numericUpDown4 = new NumericUpDown();
            p2 = new Label();
            numericUpDown5 = new NumericUpDown();
            p5 = new Label();
            numericUpDown6 = new NumericUpDown();
            p4 = new Label();
            numericUpDown8 = new NumericUpDown();
            p6 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 484);
            panel1.TabIndex = 0;
            // 
            // zasobnikFigur
            // 
            zasobnikFigur.DropDownStyle = ComboBoxStyle.DropDownList;
            zasobnikFigur.FormattingEnabled = true;
            zasobnikFigur.Location = new Point(58, 5);
            zasobnikFigur.Name = "zasobnikFigur";
            zasobnikFigur.Size = new Size(101, 23);
            zasobnikFigur.TabIndex = 1;
            zasobnikFigur.SelectedIndexChanged += zasobnikFigur_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Figura";
            // 
            // p0
            // 
            p0.AutoSize = true;
            p0.Location = new Point(165, 8);
            p0.Name = "p0";
            p0.Size = new Size(44, 15);
            p0.TabIndex = 3;
            p0.Text = "param:";
            p0.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(957, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(215, 5);
            numericUpDown1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Visible = false;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(327, 5);
            numericUpDown2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(56, 23);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.Visible = false;
            // 
            // p1
            // 
            p1.AutoSize = true;
            p1.Location = new Point(277, 8);
            p1.Name = "p1";
            p1.Size = new Size(44, 15);
            p1.TabIndex = 6;
            p1.Text = "param:";
            p1.Visible = false;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Enabled = false;
            numericUpDown3.Location = new Point(551, 4);
            numericUpDown3.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(56, 23);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Visible = false;
            // 
            // p3
            // 
            p3.AutoSize = true;
            p3.Location = new Point(501, 7);
            p3.Name = "p3";
            p3.Size = new Size(44, 15);
            p3.TabIndex = 10;
            p3.Text = "param:";
            p3.Visible = false;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Enabled = false;
            numericUpDown4.Location = new Point(439, 4);
            numericUpDown4.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(56, 23);
            numericUpDown4.TabIndex = 9;
            numericUpDown4.Visible = false;
            // 
            // p2
            // 
            p2.AutoSize = true;
            p2.Location = new Point(389, 7);
            p2.Name = "p2";
            p2.Size = new Size(44, 15);
            p2.TabIndex = 8;
            p2.Text = "param:";
            p2.Visible = false;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Enabled = false;
            numericUpDown5.Location = new Point(775, 5);
            numericUpDown5.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(56, 23);
            numericUpDown5.TabIndex = 15;
            numericUpDown5.Visible = false;
            // 
            // p5
            // 
            p5.AutoSize = true;
            p5.Location = new Point(725, 8);
            p5.Name = "p5";
            p5.Size = new Size(44, 15);
            p5.TabIndex = 14;
            p5.Text = "param:";
            p5.Visible = false;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Enabled = false;
            numericUpDown6.Location = new Point(663, 5);
            numericUpDown6.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(56, 23);
            numericUpDown6.TabIndex = 13;
            numericUpDown6.Visible = false;
            // 
            // p4
            // 
            p4.AutoSize = true;
            p4.Location = new Point(613, 8);
            p4.Name = "p4";
            p4.Size = new Size(44, 15);
            p4.TabIndex = 12;
            p4.Text = "param:";
            p4.Visible = false;
            // 
            // numericUpDown8
            // 
            numericUpDown8.Enabled = false;
            numericUpDown8.Location = new Point(887, 5);
            numericUpDown8.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(56, 23);
            numericUpDown8.TabIndex = 17;
            numericUpDown8.Visible = false;
            // 
            // p6
            // 
            p6.AutoSize = true;
            p6.Location = new Point(837, 8);
            p6.Name = "p6";
            p6.Size = new Size(44, 15);
            p6.TabIndex = 16;
            p6.Text = "param:";
            p6.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1, 38);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 19;
            label8.Text = "Dodane";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(58, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(101, 23);
            comboBox1.TabIndex = 18;
            // 
            // button2
            // 
            button2.Location = new Point(165, 33);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "Usuń";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 584);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown8);
            Controls.Add(p6);
            Controls.Add(numericUpDown5);
            Controls.Add(p5);
            Controls.Add(numericUpDown6);
            Controls.Add(p4);
            Controls.Add(numericUpDown3);
            Controls.Add(p3);
            Controls.Add(numericUpDown4);
            Controls.Add(p2);
            Controls.Add(numericUpDown2);
            Controls.Add(p1);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(p0);
            Controls.Add(label1);
            Controls.Add(zasobnikFigur);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox zasobnikFigur;
        private Label label1;
        private Label p0;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label p1;
        private NumericUpDown numericUpDown3;
        private Label p3;
        private NumericUpDown numericUpDown4;
        private Label p2;
        private NumericUpDown numericUpDown5;
        private Label p5;
        private NumericUpDown numericUpDown6;
        private Label p4;
        private NumericUpDown numericUpDown8;
        private Label p6;
        private Label label8;
        private ComboBox comboBox1;
        private Button button2;
    }
}
