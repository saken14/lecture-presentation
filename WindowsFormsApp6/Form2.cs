using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        readonly Dictionary<int, string> Pict = new Dictionary<int, string>();
        int NumPict = 1;
        string Picture = "";
        public Form2()
        {
            InitializeComponent();
            
            GetDictPict();

            FirstPict();  
        }
        
        public Dictionary<int, string> GetDictPict()
        {
            int x = 1;
            
            foreach (var Files in new DirectoryInfo(@"C:\Users\Asus\RiderProjects\WindowsFormsApp4\WindowsFormsApp4\imagesjpg").GetFiles("*.jpg").OrderBy(_ => _.LastWriteTime))
            {
                Pict.Add(x, Files.FullName);

                x++;
            }
            return Pict;
        }

        public void FirstPict()
        {
            Picture = Pict.Where(_ => _.Key == NumPict).FirstOrDefault().Value;

            pictureBox1.Image = Image.FromFile(Picture);

            label1.Text = $"Картинка {NumPict} : {Path.GetFileName(Picture)}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumPict--;

            if (NumPict < Pict.Keys.Min())
            {
                NumPict = Pict.Keys.Max();
            }
            FirstPict();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumPict++;

            if (NumPict > Pict.Keys.Max())
            {
                NumPict = Pict.Keys.Min();
            }
            FirstPict();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
            Form form1 = Application.OpenForms[2];
            form1.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            form1.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            form1.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            form1.Show(); // отображаем Form1
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
            Form form1 = Application.OpenForms[2];
            form1.StartPosition = FormStartPosition.Manual; // меняем параметр StartPosition у Form1, иначе она будет использовать тот, который у неё прописан в настройках и всегда будет открываться по центру экрана
            form1.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            form1.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            form1.Show(); // отображаем Form1
        }
    }
}