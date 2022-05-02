using System;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Welcome : Form
    {
        private static Welcome instance;
        private Welcome()
        {
            InitializeComponent();
        }
        public static Welcome getInstance()
        {
            if (instance == null)
                instance = new Welcome();
            return instance;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Register register = Register.getInstance();
            register.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            register.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            register.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = Login.getInstance();
            login.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            login.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            login.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }
    }
}