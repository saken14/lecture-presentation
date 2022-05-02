using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private static Form1 instance;
        private Form1()
        {
            InitializeComponent();
            this.nameLabel.Parent = pictureBox1;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            
            nameLabel.Text = Global.getName();
        }
        public static Form1 getInstance()
        {
            if (instance == null)
                instance = new Form1();
            instance.nameLabel.Text = Global.getName();
            return instance;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = Form2.getInstance();
            form2.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            form2.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            form2.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = Form3.getInstance();
            form3.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            form3.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            form3.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form welcome = Welcome.getInstance();
            welcome.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form welcome = Welcome.getInstance();
            
            welcome.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            welcome.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            welcome.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            welcome.Show(); // отображаем Form1
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }
    }
}