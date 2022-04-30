using System;
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
            throw new System.NotImplementedException();
        }
    }
}