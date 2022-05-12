using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int old_h_size = 0;

        private int variant = 0;

        public Form1()
        {
            InitializeComponent();

            old_h_size = this.Height;

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.InitialDirectory = "c:\\";

            openFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                this.Size = new System.Drawing.Size(this.Width, old_h_size - 100);

                this.toolStripStatusLabel1.Text = "Загрузка...";

                string fn = openFileDialog.FileName;

                this.webBrowser1.Url = new Uri(String.Format("file:///{0}", fn));


            }



        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            X_numericUpDown.Maximum = decimal.MaxValue;
            X_numericUpDown.Minimum = decimal.MinValue;
            Y_numericUpDown.Maximum = decimal.MaxValue;
            Y_numericUpDown.Minimum = decimal.MinValue;
            this.Size = new System.Drawing.Size(this.Width , old_h_size - 100);


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            var webBrowser = sender as WebBrowser;
            if (webBrowser == null)
            {
                return;
            }

            if (webBrowser.Document.Encoding != "utf-8")
            {
                webBrowser.Document.Encoding = "utf-8";



            }
            bool pageFound = false;

            var txt = webBrowser.DocumentText;



            if (txt.Contains("Вариант №1"))
            {

                pageFound = true;

                this.Size = new System.Drawing.Size(this.Width, old_h_size);

                this.variant = 1;

                this.toolStripStatusLabel1.Text = "Вариант №1";



            }

            if (txt.Contains("Вариант №2"))
            {

                pageFound = true;

                this.Size = new System.Drawing.Size(this.Width, old_h_size);

                this.variant = 1;

                this.toolStripStatusLabel1.Text = "Вариант №2";

            }


            if (!pageFound)
            {

                MessageBox.Show("Ошибка! Неверная страница!!!", "Результат расчёта");
                this.toolStripStatusLabel1.Text = "Ошибка! Неверная страница!!!";

            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Данилов Степан Александрович" + "\n" + "Курс: ПКсп-118" + "\n" + "Вариант: 11", "О программе");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cheak_button_Click(object sender, EventArgs e)
        {

            bool border = false;

            switch (variant) {

                case 1:

                    border = false;
                    if (X_numericUpDown.Value >= -1 * X_numericUpDown.Value)
                    {
                        border = true;
                    }
                    else if (Y_numericUpDown.Value > 4 * X_numericUpDown.Value)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (Y_numericUpDown.Value == -4 * X_numericUpDown.Value)
                    {
                        border = true;
                    }
                    else if (Y_numericUpDown.Value > -4 * X_numericUpDown.Value)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (Y_numericUpDown.Value == X_numericUpDown.Value * X_numericUpDown.Value - 5)
                    {
                        border = true;
                    }
                    else if (Y_numericUpDown.Value < X_numericUpDown.Value * X_numericUpDown.Value - 5)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (border == true)
                    {
                        MessageBox.Show("Точка находится на границе", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка находится на границе";
                    }
                    else
                    {
                        MessageBox.Show("Точка принадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка принадлежности области";
                    }

                    break;




                case 2:

                    border = false;

                    if (Y_numericUpDown.Value == 1)
                    {
                        border = true;
                    }
                    else if (Y_numericUpDown.Value > 1)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (Y_numericUpDown.Value == Math.Abs(X_numericUpDown.Value))
                    {
                        border = true;
                    }
                    else if (Y_numericUpDown.Value < Math.Abs(X_numericUpDown.Value))
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (X_numericUpDown.Value == 1)
                    {
                        border = true;
                    }
                    else if (X_numericUpDown.Value > 1)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (X_numericUpDown.Value == -1)
                    {
                        border = true;
                    }
                    else if (X_numericUpDown.Value < -1)
                    {
                        MessageBox.Show("Точка непринадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка непринадлежности области";
                        return;
                    }
                    if (border == true)
                    {
                        MessageBox.Show("Точка находится на границе", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка находится на границе";
                    }
                    else
                    {
                        MessageBox.Show("Точка принадлежности области", "Результат расчёта");
                        this.toolStripStatusLabel1.Text = "Точка принадлежности области";
                    }

                    break;

            }

            
            
        }
    }
}
