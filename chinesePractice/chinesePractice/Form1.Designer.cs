namespace chinesePractice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.statisticsRB = new System.Windows.Forms.RadioButton();
            this.testModeRB = new System.Windows.Forms.RadioButton();
            this.inputModeRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.inputModePanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.inputPinYin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputChar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testModePanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.testInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statisticsPanel = new System.Windows.Forms.Panel();
            this.timeSpentInt = new System.Windows.Forms.Label();
            this.incorrectInt = new System.Windows.Forms.Label();
            this.correctInt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.problemsAttInt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.findStatistics = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.inputModePanel.SuspendLayout();
            this.testModePanel.SuspendLayout();
            this.statisticsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.statisticsRB);
            this.panel1.Controls.Add(this.testModeRB);
            this.panel1.Controls.Add(this.inputModeRB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 117);
            this.panel1.TabIndex = 0;
            // 
            // statisticsRB
            // 
            this.statisticsRB.AutoSize = true;
            this.statisticsRB.Location = new System.Drawing.Point(8, 86);
            this.statisticsRB.Name = "statisticsRB";
            this.statisticsRB.Size = new System.Drawing.Size(85, 21);
            this.statisticsRB.TabIndex = 3;
            this.statisticsRB.TabStop = true;
            this.statisticsRB.Text = "Statistics";
            this.statisticsRB.UseVisualStyleBackColor = true;
            this.statisticsRB.CheckedChanged += new System.EventHandler(this.statisticsRB_CheckedChanged);
            // 
            // testModeRB
            // 
            this.testModeRB.AutoSize = true;
            this.testModeRB.Location = new System.Drawing.Point(8, 58);
            this.testModeRB.Name = "testModeRB";
            this.testModeRB.Size = new System.Drawing.Size(96, 21);
            this.testModeRB.TabIndex = 2;
            this.testModeRB.TabStop = true;
            this.testModeRB.Text = "Test Mode";
            this.testModeRB.UseVisualStyleBackColor = true;
            this.testModeRB.CheckedChanged += new System.EventHandler(this.testModeRB_CheckedChanged);
            // 
            // inputModeRB
            // 
            this.inputModeRB.AutoSize = true;
            this.inputModeRB.Location = new System.Drawing.Point(8, 30);
            this.inputModeRB.Name = "inputModeRB";
            this.inputModeRB.Size = new System.Drawing.Size(99, 21);
            this.inputModeRB.TabIndex = 1;
            this.inputModeRB.TabStop = true;
            this.inputModeRB.Text = "Input Mode";
            this.inputModeRB.UseVisualStyleBackColor = true;
            this.inputModeRB.CheckedChanged += new System.EventHandler(this.inputModeRB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 11F);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode:";
            // 
            // inputModePanel
            // 
            this.inputModePanel.BackColor = System.Drawing.Color.White;
            this.inputModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputModePanel.Controls.Add(this.button1);
            this.inputModePanel.Controls.Add(this.label4);
            this.inputModePanel.Controls.Add(this.inputPinYin);
            this.inputModePanel.Controls.Add(this.label3);
            this.inputModePanel.Controls.Add(this.inputChar);
            this.inputModePanel.Controls.Add(this.label2);
            this.inputModePanel.Location = new System.Drawing.Point(392, 44);
            this.inputModePanel.Name = "inputModePanel";
            this.inputModePanel.Size = new System.Drawing.Size(275, 124);
            this.inputModePanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pin yin:";
            // 
            // inputPinYin
            // 
            this.inputPinYin.Font = new System.Drawing.Font("Calibri", 19F);
            this.inputPinYin.Location = new System.Drawing.Point(108, 58);
            this.inputPinYin.Name = "inputPinYin";
            this.inputPinYin.Size = new System.Drawing.Size(155, 46);
            this.inputPinYin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Character:";
            // 
            // inputChar
            // 
            this.inputChar.Font = new System.Drawing.Font("KaiTi", 20F);
            this.inputChar.Location = new System.Drawing.Point(8, 58);
            this.inputChar.Name = "inputChar";
            this.inputChar.Size = new System.Drawing.Size(84, 46);
            this.inputChar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 11F);
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input Mode";
            // 
            // testModePanel
            // 
            this.testModePanel.BackColor = System.Drawing.Color.White;
            this.testModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testModePanel.Controls.Add(this.button2);
            this.testModePanel.Controls.Add(this.testInput);
            this.testModePanel.Controls.Add(this.label8);
            this.testModePanel.Controls.Add(this.label7);
            this.testModePanel.Controls.Add(this.label6);
            this.testModePanel.Controls.Add(this.label5);
            this.testModePanel.Location = new System.Drawing.Point(370, 184);
            this.testModePanel.Name = "testModePanel";
            this.testModePanel.Size = new System.Drawing.Size(322, 124);
            this.testModePanel.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // testInput
            // 
            this.testInput.Font = new System.Drawing.Font("Calibri", 10F);
            this.testInput.Location = new System.Drawing.Point(73, 76);
            this.testInput.Name = "testInput";
            this.testInput.Size = new System.Drawing.Size(160, 28);
            this.testInput.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Answer:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("KaiTi", 16F);
            this.label7.Location = new System.Drawing.Point(256, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "a";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Type in the correct pin yin for the word:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 11F);
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Test Mode";
            // 
            // statisticsPanel
            // 
            this.statisticsPanel.BackColor = System.Drawing.Color.White;
            this.statisticsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statisticsPanel.Controls.Add(this.timeSpentInt);
            this.statisticsPanel.Controls.Add(this.incorrectInt);
            this.statisticsPanel.Controls.Add(this.correctInt);
            this.statisticsPanel.Controls.Add(this.label14);
            this.statisticsPanel.Controls.Add(this.label13);
            this.statisticsPanel.Controls.Add(this.label12);
            this.statisticsPanel.Controls.Add(this.problemsAttInt);
            this.statisticsPanel.Controls.Add(this.label10);
            this.statisticsPanel.Controls.Add(this.findStatistics);
            this.statisticsPanel.Controls.Add(this.datePicker);
            this.statisticsPanel.Controls.Add(this.label9);
            this.statisticsPanel.Location = new System.Drawing.Point(404, 361);
            this.statisticsPanel.Name = "statisticsPanel";
            this.statisticsPanel.Size = new System.Drawing.Size(288, 177);
            this.statisticsPanel.TabIndex = 3;
            // 
            // timeSpentInt
            // 
            this.timeSpentInt.AutoSize = true;
            this.timeSpentInt.Location = new System.Drawing.Point(98, 155);
            this.timeSpentInt.Name = "timeSpentInt";
            this.timeSpentInt.Size = new System.Drawing.Size(31, 17);
            this.timeSpentInt.TabIndex = 10;
            this.timeSpentInt.Text = "N/A";
            // 
            // incorrectInt
            // 
            this.incorrectInt.AutoSize = true;
            this.incorrectInt.Location = new System.Drawing.Point(77, 131);
            this.incorrectInt.Name = "incorrectInt";
            this.incorrectInt.Size = new System.Drawing.Size(31, 17);
            this.incorrectInt.TabIndex = 9;
            this.incorrectInt.Text = "N/A";
            // 
            // correctInt
            // 
            this.correctInt.AutoSize = true;
            this.correctInt.Location = new System.Drawing.Point(66, 110);
            this.correctInt.Name = "correctInt";
            this.correctInt.Size = new System.Drawing.Size(31, 17);
            this.correctInt.TabIndex = 8;
            this.correctInt.Text = "N/A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Time Spent:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Incorrect:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Correct:";
            // 
            // problemsAttInt
            // 
            this.problemsAttInt.AutoSize = true;
            this.problemsAttInt.Location = new System.Drawing.Point(149, 89);
            this.problemsAttInt.Name = "problemsAttInt";
            this.problemsAttInt.Size = new System.Drawing.Size(31, 17);
            this.problemsAttInt.TabIndex = 4;
            this.problemsAttInt.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Problems Attempted:";
            // 
            // findStatistics
            // 
            this.findStatistics.Location = new System.Drawing.Point(3, 59);
            this.findStatistics.Name = "findStatistics";
            this.findStatistics.Size = new System.Drawing.Size(117, 23);
            this.findStatistics.TabIndex = 2;
            this.findStatistics.Text = "Find Statistics";
            this.findStatistics.UseVisualStyleBackColor = true;
            this.findStatistics.Click += new System.EventHandler(this.findStatistics_Click);
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(3, 30);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Constantia", 11F);
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Statistics";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 576);
            this.Controls.Add(this.statisticsPanel);
            this.Controls.Add(this.testModePanel);
            this.Controls.Add(this.inputModePanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.inputModePanel.ResumeLayout(false);
            this.inputModePanel.PerformLayout();
            this.testModePanel.ResumeLayout(false);
            this.testModePanel.PerformLayout();
            this.statisticsPanel.ResumeLayout(false);
            this.statisticsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton statisticsRB;
        private System.Windows.Forms.RadioButton testModeRB;
        private System.Windows.Forms.RadioButton inputModeRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel inputModePanel;
        private System.Windows.Forms.TextBox inputChar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputPinYin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel testModePanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox testInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel statisticsPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label timeSpentInt;
        private System.Windows.Forms.Label incorrectInt;
        private System.Windows.Forms.Label correctInt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label problemsAttInt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button findStatistics;
    }
}

