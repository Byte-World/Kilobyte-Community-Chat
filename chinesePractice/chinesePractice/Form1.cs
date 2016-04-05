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
            setCurrentQuestion(a, b);
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
    }
}
