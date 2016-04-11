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
            string appPath = Application.StartupPath;
            
            currentQuestion = new Question();
            charFilePath = appPath + "\\Database\\characterData.txt";
            statFilePath = appPath + "\\Database\\statisticData.txt";
            specialNumber = 437293847;
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
                addNewCharacter(a, b);
            }

            inputChar.Text = "";
            inputPinYin.Text = "";
            //setCurrentQuestion(a, b);
        }

        public void addScoreChar()
        {
            string chineseCharacterFind = currentQuestion.chineseCharacter;
            int correctLine = 0;
            string[] wholeFile = File.ReadAllLines(charFilePath);

            for (int i = 0; i < wholeFile.Length; i++)
            {
                string testString = wholeFile[i];
                string[] testStrings = testString.Split(new char[] {':'});
                string testCharacter = testStrings[0];

                if (testCharacter == chineseCharacterFind)
                {
                    correctLine = i;
                }
            }

            string[] newWholeFile = new string[wholeFile.Length];
            string lineToEdit = wholeFile[correctLine];
            string[] linesToEdit = lineToEdit.Split(new char[] { ':' });
            string currentScore = linesToEdit[2];
            int currentScoreInt = Int32.Parse(currentScore);
            currentScoreInt++;
            string newUploadString = linesToEdit[0] + ":" + linesToEdit[1] + ":" + currentScoreInt.ToString();

            for (int i = 0; i < wholeFile.Length; i++)
            {
                if (correctLine == i)
                {
                    newWholeFile[i] = newUploadString;
                }
                else
                {
                    newWholeFile[i] = wholeFile[i];
                }
            }

            File.WriteAllLines(charFilePath, newWholeFile);
        }

        public void resetScoreChar()
        {
            string chineseCharacterFind = currentQuestion.chineseCharacter;
            int correctLine = 0;
            string[] wholeFile = File.ReadAllLines(charFilePath);

            for (int i = 0; i < wholeFile.Length; i++)
            {
                string testString = wholeFile[i];
                string[] testStrings = testString.Split(new char[] { ':' });
                string testCharacter = testStrings[0];

                if (testCharacter == chineseCharacterFind)
                {
                    correctLine = i;
                }
            }

            string[] newWholeFile = new string[wholeFile.Length];
            string lineToEdit = wholeFile[correctLine];
            string[] linesToEdit = lineToEdit.Split(new char[] { ':' });
            string newUploadString = linesToEdit[0] + ":" + linesToEdit[1] + ":" + "0";

            for (int i = 0; i < wholeFile.Length; i++)
            {
                if (correctLine == i)
                {
                    newWholeFile[i] = newUploadString;
                }
                else
                {
                    newWholeFile[i] = wholeFile[i];
                }
            }
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
                addScoreChar();
                string test = DateTime.Now.ToString("M/d/yyyy");
                string[] tests = test.Split(new char[] {'/'});
                addStatistics(Int32.Parse(tests[0]), Int32.Parse(tests[1]), Int32.Parse(tests[2]), 0, 1, 0, 0);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Wrong." + " The answer was: " + currentQuestion.pinYin);
                resetScoreChar();
                string test = DateTime.Now.ToString("M/d/yyyy");
                string[] tests = test.Split(new char[] { '/' });
                addStatistics(Int32.Parse(tests[0]), Int32.Parse(tests[1]), Int32.Parse(tests[2]), 1, 0, 0, 0);
            }
            testInput.Text = "";
            newQuestion();
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
        }

        public Stats retrieveStats(Stats partialStats)
        {
            Stats completeStats = new Stats();

            completeStats.month = partialStats.month;
            completeStats.day = partialStats.day;
            completeStats.year = partialStats.year;
            string strungDate = completeStats.month.ToString() + "/" + completeStats.day.ToString() + "/" + completeStats.year.ToString();

            string[] wholeFile = File.ReadAllLines(statFilePath);
            Boolean lineFound = false;
            int lineOfDate = 0;

            for (int i = 0; i < wholeFile.Length; i++)
            {
                string[] currentSplitLine = wholeFile[i].Split(new char[] {':'});
                if (strungDate == currentSplitLine[0])
                {
                    lineOfDate = i;
                    lineFound = true;
                }
            }

            if (lineFound == false)
            {
                completeStats.problemsAttempted = 0;
                completeStats.correct = 0;
                completeStats.incorrect = 0;
                completeStats.hours = 0;
                completeStats.minutes = 0;
            }
            else
            {
                string[] correctLine = wholeFile[lineOfDate].Split(new char[] {':'});
                string[] correctTime = correctLine[4].Split(new char[] {'/'});

                completeStats.problemsAttempted = Int32.Parse(correctLine[1]);
                completeStats.correct = Int32.Parse(correctLine[2]);
                completeStats.incorrect = Int32.Parse(correctLine[3]);
                completeStats.hours = Int32.Parse(correctTime[0]);
                completeStats.minutes = Int32.Parse(correctTime[1]);
            }

            return completeStats;
        }

        public void newQuestion()
        {
            int itemInt = randomValidNumber();
            if (itemInt == specialNumber)
            {
                System.Windows.Forms.MessageBox.Show("There are no more valid words in the Database.");
            }
            else
            {
                itemInt--;
                string[] allWords = File.ReadAllLines(charFilePath);
                string specificItem = allWords[itemInt];
                string[] specificItems = specificItem.Split(new char[] { ':' });
                string finalCharacter = specificItems[0];
                string finalPinyin = specificItems[1];
                setCurrentQuestion(finalCharacter, finalPinyin);
            }
        }

        public void addStatistics(int month, int day, int year, int addIncorrect, int addCorrect, int addMinSpent, int addHoursSpent)
        {
            string dateTogether = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            string[] wholeFile = File.ReadAllLines(statFilePath);
            Boolean dayExists = false;
            int dateLine = 0;

            for (int i = 0; i < wholeFile.Length; i++)
            {
                string[] entireLine = wholeFile[i].Split(new char[] {':'});

                if (entireLine[0] == dateTogether)
                {
                    dayExists = true;
                    dateLine = i;
                }
            }

            string[] newWholeFile = new string[wholeFile.Length];
            string newEntireLine = "";

            if (dayExists == true)
            {
                string editLine = wholeFile[dateLine];
                string[] editLineSplit = editLine.Split(new char[] { ':' });
                int newProblemsAttempted = Int32.Parse(editLineSplit[1]) + addIncorrect + addCorrect;
                int newCorrect = Int32.Parse(editLineSplit[2]) + addCorrect;
                int newIncorrect = Int32.Parse(editLineSplit[3]) + addIncorrect;
                string[] editLineSplitSplit = editLineSplit[4].Split(new char[] { '/' });
                int newMinutes = Int32.Parse(editLineSplitSplit[1]) + addMinSpent;
                int newHours = Int32.Parse(editLineSplitSplit[0]) + addHoursSpent;

                newEntireLine = month.ToString() + "/" + day.ToString() + "/" + year.ToString() + ":" + newProblemsAttempted.ToString() + ":" + newCorrect.ToString() + ":" + newIncorrect.ToString() + ":" + newHours + "/" + newMinutes;

                for (int i = 0; i < wholeFile.Length; i++)
                {
                    if (dateLine == i)
                    {
                        newWholeFile[i] = newEntireLine;
                    }
                    else
                    {
                        newWholeFile[i] = wholeFile[i];
                    }
                }
            }
            else
            {
                newEntireLine = month.ToString() + "/" + day.ToString() + "/" + year.ToString() + ":" + (addCorrect + addIncorrect).ToString() + ":" + addCorrect.ToString() + ":" + addIncorrect.ToString() + ":" + addHoursSpent + "/" + addMinSpent;
                newWholeFile = new string[wholeFile.Length + 1];

                for (int i = 0; i < newWholeFile.Length; i++)
                {
                    if (i == newWholeFile.Length)
                    {
                        newWholeFile[i] = newEntireLine;
                    }
                    else
                    {
                        newWholeFile[i] = wholeFile[i];
                    }
                }
            }

            File.WriteAllLines(statFilePath, newWholeFile);
        }


        public int randomValidNumber()
        {
            string[] allWords = File.ReadAllLines(charFilePath);
            string[] allScores = new string[allWords.Length];

            for (int i = 0; i < allWords.Length; i++)
            {
                string[] stringSplit = allWords[i].Split(new char[] { ':' });
                allScores[i] = stringSplit[2];
            }

            int[] allScoresInt = new int[allWords.Length];

            for (int i = 0; i < allWords.Length; i++)
            {
                allScoresInt[i] = Int32.Parse(allScores[i]);
            }

            Boolean allNotPossible = true;
            for (int i = 0; i < allWords.Length; i++)
            {
                if (allScoresInt[i] < 3) {
                    allNotPossible = false;
                }
            }

            if (allNotPossible == false)
            {
                int randomGenNumber = randomNumber(1, allWords.Length + 1);
                string specificItem = allWords[randomGenNumber - 1];
                string[] specificItems = specificItem.Split(new char[] { ':' });
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
            else
            {
                return specialNumber;
            }
        }

        int specialNumber = new int();

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