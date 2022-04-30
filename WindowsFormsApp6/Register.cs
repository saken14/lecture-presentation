using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            
            this.pictureBox2.Parent = pictureBox1;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            
            this.pictureBox3.Parent = pictureBox1;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            
            this.label1.Parent = pictureBox1;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            
            this.label2.Parent = pictureBox1;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            
            this.titleLabel.Parent = pictureBox1;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
        }
        
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
            Form welcome = Application.OpenForms[0];
            welcome.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            welcome.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            welcome.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            welcome.Show(); // отображаем Form1
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool isExist = false;
            bool isDone = true;
            string path = @"C:\Users\Asus\RiderProjects\test2\content.txt";
            if (loginBox.Text == "")
            {
                MessageBox.Show("Enter login...");
                isDone = false;
            }
            else if (passBox.Text == "")
            {
                MessageBox.Show("Enter password...");
                isDone = false;
            }
            else if (nameBox.Text == "")
            {
                MessageBox.Show("Enter name...");
                isDone = false;
            }
            else if (lastNameBox.Text == "")
            {
                MessageBox.Show("Enter last name...");
                isDone = false;
            }

            if (isDone)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineArr = line.Split('\t');
                        if (lineArr[0] == loginBox.Text)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует!");
                            isExist = true;
                            break;
                        }
                    }
                }
            }

            if (!isExist && isDone)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write($"{loginBox.Text.Trim().ToLower()}\t");
                    writer.Write($"{passBox.Text.Trim()}\t");
                    writer.Write($"{nameBox.Text.Trim()}\t");
                    writer.WriteLine($"{lastNameBox.Text.Trim()}");
                }
                MessageBox.Show("Регистрация прошла успешна!");
                loginBox.Text = "";
                passBox.Text = "";
                nameBox.Text = "";
                lastNameBox.Text = "";
                
                Login login = new Login();
                login.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                login.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                login.Show(); // отображаем Form2
                this.Hide(); // скрываем Form1 (this - текущая форма)
            }
        }
    }
}