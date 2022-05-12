using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class Login : Form
    {
        private static Login instance;
        private Login()
        {
            InitializeComponent();
            
            this.titleLabel.Parent = pictureBox1;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
        }
        
        public static Login getInstance()
        {
            if (instance == null)
                instance = new Login();
            return instance;
        }
        
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonLogin_Click(object sender, EventArgs e)
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

            if (isDone)
            {
                DB db = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @l AND `password` = @p", db.getConnection());
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = loginBox.Text.Trim().ToLower();
                command.Parameters.Add("@p", MySqlDbType.VarChar).Value = passBox.Text.Trim();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    Global.setName(table.Rows[0]["name"].ToString());
                    Global.setLogin(table.Rows[0]["login"].ToString());

                    isExist = true;

                    loginBox.Text = "";
                    passBox.Text = "";
                            
                    Form1 form1 = Form1.getInstance();
                    form1.Left =
                        this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                    form1.Top = this
                        .Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    form1.Show(); // отображаем Form2
                    this.Hide(); // скрываем Form1 (this - текущая форма)
                }
            }

            if (!isExist && isDone)
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}