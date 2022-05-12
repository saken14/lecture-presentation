using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class Register : Form
    {
        private static Register instance;
        private Register()
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
        public static Register getInstance()
        {
            if (instance == null)
                instance = new Register();
            return instance;
        }
        
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form welcome = Welcome.getInstance();
            welcome.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form welcome = Welcome.getInstance();
            welcome.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            welcome.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            welcome.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            welcome.Show(); // отображаем Form1
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool isExist = false;
            bool isDone = true;
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
            
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            if (isDone)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @l", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = loginBox.Text.Trim().ToLower();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    isExist = true;
                }
            }

            if (!isExist && isDone)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `last_name`) VALUES (@l, @p, @n, @ln)", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = loginBox.Text.Trim().ToLower();
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = passBox.Text.Trim();
                command.Parameters.Add("@n", MySqlDbType.VarChar).Value = nameBox.Text.Trim();
                command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastNameBox.Text.Trim();
                
                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Регистрация прошла успешна!");
                    loginBox.Text = "";
                    passBox.Text = "";
                    nameBox.Text = "";
                    lastNameBox.Text = "";
                
                    Login login = Login.getInstance();
                    login.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                    login.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    login.Show(); // отображаем Form2
                    this.Hide(); // скрываем Form1 (this - текущая форма)
                }
                else
                {
                    MessageBox.Show("Проблема с базой данных, попробуйте зарегистрироваться позже");
                }
                
                db.closeConnection();
            }
        }
    }
}