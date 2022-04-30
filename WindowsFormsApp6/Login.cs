using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            this.titleLabel.Parent = pictureBox1;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
        }
        
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonLogin_Click(object sender, EventArgs e)
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

            if (isDone)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineArr = line.Split('\t');
                        if (lineArr[0] == loginBox.Text.Trim().ToLower() && lineArr[1] == passBox.Text.Trim())
                        {
                            Global.setName(lineArr[2]);
                            Global.setLogin(lineArr[0]);
                            
                            Form1 form1 = new Form1();
                            form1.Left =
                                this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                            form1.Top = this
                                .Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                            form1.Show(); // отображаем Form2
                            this.Hide(); // скрываем Form1 (this - текущая форма)
                            isExist = true;

                            

                            loginBox.Text = "";
                            passBox.Text = "";
                        }
                    }
                }
            }

            if (!isExist && isDone)
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}