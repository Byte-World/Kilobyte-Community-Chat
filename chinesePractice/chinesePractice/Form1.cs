using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            charFilePath = @"C:\Users\Steven\Documents\Steven's Stuff\Coding Things\Repositories\Kilobyte-Community-Chat\chinesePractice\chinesePractice\Database\characterData.txt";
            statFilePath = @"C:\Users\Steven\Documents\Steven's Stuff\Coding Things\Repositories\Kilobyte-Community-Chat\chinesePractice\chinesePractice\Database\statisticData.txt";
        }

        Question currentQuestion;
        string charFilePath;
        string statFilePath;
        Random r = new Random();


        public int randomNumber(int min, int max)
        {
            return r.Next(min, max);
        }
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
            addNewCharacter(a, b);
        }

        public void addScoreChar()
        {

        }

        public void resetScoreChar()
        {

        }

        public void addNewCharacter(string chineseCharacter, string pinyin)
        {
            string[] currentLoadedText = File.ReadAllLines(charFilePath);
            string[] newLoadingText = new string[currentLoadedText.Length + 1];
            string addString = chineseCharacter + ":" + pinyin + ":" + "0";

            for (int i = 0; i < newLoadingText.Length; i++)
            {
                if (i == newLoadingText.Length - 1)
                {
                    newLoadingText[i] = addString;
                }
                else
                {
                    newLoadingText[i] = currentLoadedText[i];
                }
            }

            File.WriteAllLines(charFilePath, newLoadingText);
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
            testInput.Text = "";
            newQuestion();
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
            DateTime dateStats = datePicker.Value;
            String dateStatsString = dateStats.ToString();
            String[] splitStats = dateStatsString.Split(new char[] {' '});
            String dateOnly = splitStats[0];
            String[] splitDayItems = dateOnly.Split(new char[] {'/'});
            currentStats.month = Int32.Parse(splitDayItems[0]);
            currentStats.day = Int32.Parse(splitDayItems[1]);
            currentStats.year = Int32.Parse(splitDayItems[2]);
            
            Stats fullDisplayStats = retrieveStats(currentStats);
            problemsAttInt.Text = fullDisplayStats.problemsAttempted.ToString();
            correctInt.Text = fullDisplayStats.correct.ToString();
            incorrectInt.Text = fullDisplayStats.incorrect.ToString();
            string timeDisplayString = fullDisplayStats.hours.ToString() + ":" + fullDisplayStats.minutes.ToString();
            timeSpentInt.Text = timeDisplayString;
        }

        public Stats retrieveStats(Stats partialStats)
        {
            Stats completeStats = new Stats();


            return completeStats;
        }

        public void newQuestion()
        {
            int itemInt = randomValidNumber();
            itemInt--;
            string[] allWords = File.ReadAllLines(charFilePath);
            string specificItem = allWords[itemInt];
            string[] specificItems = specificItem.Split(new char[] {':'});
            string finalCharacter = specificItems[0];
            string finalPinyin = specificItems[1];
            setCurrentQuestion(finalCharacter, finalPinyin);
        }

        public int randomValidNumber()
        {
            string[] allWords = File.ReadAllLines(charFilePath);
            int randomGenNumber = randomNumber(1, allWords.Length + 1);
            string specificItem = allWords[randomGenNumber - 1];
            string[] specificItems = specificItem.Split(new char[] {':'});
            int score = Int32.Parse(specificItems[2]);
            if (score < 3)
            {
                return randomGenNumber;
            }
            else
            {
                return randomValidNumber();
            }
        }

        private void inputModeRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
        }

        private void testModeRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
            if (testModeRB.Checked)
            {
                newQuestion();
            }
            /*
            if (testModeRB.Checked == true)
            {
                for (int i = 0; i < 50; i++)
                {
                    int test = randomNumber(1, 3);
                    System.Windows.Forms.MessageBox.Show(test.ToString());
                }
            }
            */
        }

        private void statisticsRB_CheckedChanged(object sender, EventArgs e)
        {
            updateMode();
        }
    }
}


//Questions follow below:


//How do I edit a certain line of text in a text file?