using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chinesePractice
{
    public partial class Form1 : Form
    {
        public class Stats
        {
            public int month;
            public int day;
            public int year;
            public int problemsAttempted;
            public int correct;
            public int incorrect;
            public int minutes;
            public int hours;

            public Stats()
            {
                month = new int();
                day = new int();
                year = new int();
                problemsAttempted = new int();
                correct = new int();
                incorrect = new int();
                minutes = new int();
                hours = new int();
            }

            public Stats(int Month, int Day, int Year, int ProblemsAttempted, int Correct, int Incorrect, int Minutes, int Hours)
            {
                month = new int();
                day = new int();
                year = new int();
                problemsAttempted = new int();
                correct = new int();
                incorrect = new int();
                minutes = new int();
                hours = new int();
                month = Month;
                day = Day;
                year = Year;
                problemsAttempted = ProblemsAttempted;
                correct = Correct;
                incorrect = Incorrect;
                minutes = Minutes;
                hours = Hours;
            }
        }
        public class Question
        {
            public string chineseCharacter;
            public string pinYin;

            public Question()
            {

            }

            public Question(string insertCharacter, string insertAnswer)
            {
                chineseCharacter = insertCharacter;
                pinYin = insertAnswer;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentQuestion = new Question();
        }

        Question currentQuestion;

        private void button1_Click(object sender, EventArgs e)
        {
            string a = inputChar.Text;
            string b = inputPinYin.Text;
            if (a == null || b == null || a == "" || b == "" || a == " " || b == " ")
            {
                System.Windows.Forms.MessageBox.Show("You must fill in both boxes.");
            }
            else
            {
                string chineseCharacter = a;
                string matchingPinYin = b;
            }

            inputChar.Text = "";
            inputPinYin.Text = "";
            //setCurrentQuestion(a, b);

        }

        public void setCurrentQuestion(string insertCharacter, string insertAnswer)
        {
            currentQuestion.chineseCharacter = insertCharacter;
            currentQuestion.pinYin = insertAnswer;
            label7.Text = currentQuestion.chineseCharacter;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (testInput.Text == currentQuestion.pinYin) {
                System.Windows.Forms.MessageBox.Show("Correct!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Wrong." + " The answer was: " + currentQuestion.pinYin);
            }
        }

        public void changeMode(int menuNo)
        {

        }

        public void updateMode()
        {
            Point defaultPoint = new Point(350, 50);
            Point firstBackup = new Point(380, 200);
            Point secondBackup = new Point(420, 370);
            inputModePanel.Visible = false;
            testModePanel.Visible = false;
            statisticsPanel.Visible = false;
            if (inputModeRB.Checked == true)
            {
                inputModePanel.Visible = true;
                inputModePanel.Location = defaultPoint;
                testModePanel.Location = firstBackup;
                statisticsPanel.Location = secondBackup;
            }
            else
            {
                if (testModeRB.Checked == true)
                {
                    testModePanel.Visible = true;
                    testModePanel.Location = defaultPoint;
                    statisticsPanel.Location = secondBackup;
                    inputModePanel.Location = firstBackup;
                }
                else
                {
                    if (statisticsRB.Checked == true)
                    {
                        statisticsPanel.Visible = true;
                        statisticsPanel.Location = defaultPoint;
                        inputModePanel.Location = firstBackup;
                        testModePanel.Location = secondBackup;
                    }
                }
            }
        }


        private void findStatistics_Click(object sender, EventArgs e)
        {
            Stats currentStats = new Stats();
        }

        public Stats retrieveStats(Stats partialStats)
        {
            Stats completeStats = new Stats();


            return completeStats;
        }

        private void inputModeRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
        }

        private void testModeRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
        }

        private void statisticsRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
        }
    }
}


//Questions follow below:


//How do I edit a certain line of text in a text file?