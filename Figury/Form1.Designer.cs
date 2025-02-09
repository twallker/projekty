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
            v0 = new NumericUpDown();
            v1 = new NumericUpDown();
            p1 = new Label();
            v3 = new NumericUpDown();
            p3 = new Label();
            v2 = new NumericUpDown();
            p2 = new Label();
            v5 = new NumericUpDown();
            p5 = new Label();
            v4 = new NumericUpDown();
            p4 = new Label();
            v6 = new NumericUpDown();
            p6 = new Label();
            label8 = new Label();
            userFig = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)v0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)v6).BeginInit();
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
            button1.Click += button1_Click;
            // 
            // v0
            // 
            v0.Location = new Point(215, 5);
            v0.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v0.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v0.Name = "v0";
            v0.Size = new Size(56, 23);
            v0.TabIndex = 5;
            v0.Visible = false;
            // 
            // v1
            // 
            v1.Location = new Point(327, 5);
            v1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v1.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v1.Name = "v1";
            v1.Size = new Size(56, 23);
            v1.TabIndex = 7;
            v1.Visible = false;
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
            // v3
            // 
            v3.Location = new Point(551, 4);
            v3.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v3.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v3.Name = "v3";
            v3.Size = new Size(56, 23);
            v3.TabIndex = 11;
            v3.Visible = false;
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
            // v2
            // 
            v2.Location = new Point(439, 4);
            v2.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v2.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v2.Name = "v2";
            v2.Size = new Size(56, 23);
            v2.TabIndex = 9;
            v2.Visible = false;
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
            // v5
            // 
            v5.Location = new Point(775, 5);
            v5.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v5.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v5.Name = "v5";
            v5.Size = new Size(56, 23);
            v5.TabIndex = 15;
            v5.Visible = false;
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
            // v4
            // 
            v4.Location = new Point(663, 5);
            v4.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v4.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v4.Name = "v4";
            v4.Size = new Size(56, 23);
            v4.TabIndex = 13;
            v4.Visible = false;
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
            // v6
            // 
            v6.Location = new Point(887, 5);
            v6.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            v6.Minimum = new decimal(new int[] { 2000, 0, 0, int.MinValue });
            v6.Name = "v6";
            v6.Size = new Size(56, 23);
            v6.TabIndex = 17;
            v6.Visible = false;
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
            // userFig
            // 
            userFig.DropDownStyle = ComboBoxStyle.DropDownList;
            userFig.FormattingEnabled = true;
            userFig.Location = new Point(58, 34);
            userFig.Name = "userFig";
            userFig.Size = new Size(101, 23);
            userFig.TabIndex = 18;
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
            Controls.Add(userFig);
            Controls.Add(v6);
            Controls.Add(p6);
            Controls.Add(v5);
            Controls.Add(p5);
            Controls.Add(v4);
            Controls.Add(p4);
            Controls.Add(v3);
            Controls.Add(p3);
            Controls.Add(v2);
            Controls.Add(p2);
            Controls.Add(v1);
            Controls.Add(p1);
            Controls.Add(v0);
            Controls.Add(button1);
            Controls.Add(p0);
            Controls.Add(label1);
            Controls.Add(zasobnikFigur);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)v0).EndInit();
            ((System.ComponentModel.ISupportInitialize)v1).EndInit();
            ((System.ComponentModel.ISupportInitialize)v3).EndInit();
            ((System.ComponentModel.ISupportInitialize)v2).EndInit();
            ((System.ComponentModel.ISupportInitialize)v5).EndInit();
            ((System.ComponentModel.ISupportInitialize)v4).EndInit();
            ((System.ComponentModel.ISupportInitialize)v6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox zasobnikFigur;
        private Label label1;
        private Label p0;
        private Button button1;
        private NumericUpDown v0;
        private NumericUpDown v1;
        private Label p1;
        private NumericUpDown v3;
        private Label p3;
        private NumericUpDown v2;
        private Label p2;
        private NumericUpDown v5;
        private Label p5;
        private NumericUpDown v4;
        private Label p4;
        private NumericUpDown v6;
        private Label p6;
        private Label label8;
        private ComboBox userFig;
        private Button button2;
    }
}
