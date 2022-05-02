using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {
        private static Form3 instance;
        private List<string> questionList = new List<string>()
        {
            "1. Когда началась Вторая мировая война?",
            "2. Что такое страны «оси»?",
            "3. Сколько стран приняло участие в войне?",
            "4. Когда закончилась Вторая мировая война?",
            "5. Страна не входившая в союз стран «оси»"
        };
        private List<string> answerList = new List<string>()
        {
            "1 сентября 1939",
            "Страны поддерживающие Гитлера",
            "62",
            "2 сентября 1945",
            "Дания"
        };
        private List<string> varList = new List<string>()
        {
            "1 сентября 1939",
            "1 августа 1941",
            "22 июня 1941",
            "8 сентября 1939",
            
            "Страны не поддерживающие Гитлера",
            "Страны поддерживающие Гитлера",
            "Страны нейтралитеты",
            "Части Польши после раздела страны СССР и Германией",
            
            "75",
            "30",
            "84",
            "62",
            
            "9 мая 1945",
            "1 мая 1945",
            "2 сентября 1945",
            "1 августа 1945",
            
            "Словакия",
            "Норвегия",
            "Хорватия",
            "Дания",
        };

        private List<bool> resultBools = new List<bool>();
        private int globalC = 1;
        private int c = 4;
        private int lengthOfQuestionList = 5;

        private Form3()
        {
            InitializeComponent();
            
            label1.Text = questionList[0];
            
            radioButton1.Text = varList[0];
            radioButton2.Text = varList[1];
            radioButton3.Text = varList[2];
            radioButton4.Text = varList[3];
            
            for (int i = 0; i < lengthOfQuestionList; i++)
            {
                resultBools.Add(false);
            }
            
            label2.Hide(); 
            
            
            this.label1.Parent = pictureBox1;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            
            
            this.label2.Parent = pictureBox1;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            
            this.panel1.Parent = pictureBox1;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
        }
        public static Form3 getInstance()
        {
            if (instance == null)
                instance = new Form3();
            instance.restore();
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (globalC == lengthOfQuestionList)
            {
                globalC = 0;
                int sum = 0;
                for (int i = 0; i < lengthOfQuestionList; i++)
                {
                    if (resultBools[i])
                        sum++;
                }

                label2.Text = "Правильных ответов: " + sum;
                MessageBox.Show("Правильных ответов: " + sum);
                label2.Show();
                button1.Hide();
                panel1.Hide();
                label1.Hide();
                
                
                string path = @"C:\Users\Asus\RiderProjects\test2\scores.txt"; 
                
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{Global.getLogin()}:\t{sum}");
                }

                
                // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
                Form form1 = Form1.getInstance();
                form1.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
                form1.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                form1.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                form1.Show(); // отображаем Form1
            }

            if (globalC == lengthOfQuestionList - 1)
            {
                button1.Text = "Финиш";
            }
            else
            {
                button1.Text = "Далее";
            }

            if (c == lengthOfQuestionList*4)
            {
                c = 0;
            }

            label1.Text = questionList[globalC];
            
            radioButton1.Text = varList[c];
            radioButton2.Text = varList[c+1];
            radioButton3.Text = varList[c+2];
            radioButton4.Text = varList[c+3];
            
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            globalC++;
            c += 4;
        }
        
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {

                if (radioButton.Text == answerList[globalC - 1])
                {
                    resultBools[globalC - 1] = true;
                    //MessageBox.Show("Ура правильно");
                }
                else
                {
                    //MessageBox.Show("Вы выбрали " + radioButton.Text);
                }
            }
        }
        
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form welcome = Welcome.getInstance();
            welcome.Close();
        }

        private void restore()
        {
        resultBools.Clear();
        globalC = 1;
        c = 4;
        
        label1.Text = questionList[0];
            
        radioButton1.Text = varList[0];
        radioButton2.Text = varList[1];
        radioButton3.Text = varList[2];
        radioButton4.Text = varList[3];
            
        for (int i = 0; i < lengthOfQuestionList; i++)
        {
            resultBools.Add(false);
        }
            
        label2.Hide(); 
        button1.Show();
        panel1.Show();
        label1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
            Form form1 = Form1.getInstance();
            form1.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            form1.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            form1.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            form1.Show(); // отображаем Form1
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }
    }
}