using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_with_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // открытие в центре экрана
            this.StartPosition = FormStartPosition.CenterScreen;
            //button1.Click += button1_Click;
            // button2.Click += button2_Click;
            
            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        // сохранение файла
        void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog2.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }
        // открытие файла
        void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
               

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    {
                        progressBar1.Maximum = 100;
                        for (int i = 100; i > 0; i--)
                        {
                            progressBar1.Visible = true;
                            progressBar1.Value = progressBar1.Maximum - i;
                            System.Threading.Thread.Sleep(10);
                            if (i == 1)
                                progressBar1.Visible = false;
                        }
                        //читаем файл в строку
                        var fileStream = openFileDialog.OpenFile();

                        using (TextReader reader = new StreamReader(fileStream))
                        {
                            textBox1.Text = reader.ReadToEnd();
                        }
                        //string fileText = System.IO.File.ReadAllText(filename);
                        //textBox1.Text = fileText;

                        MessageBox.Show("Файл открыт");
                    }
                }
            

                // получаем выбранный файл
                // string filename = openFileDialog2.FileName;
            }
                


        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно желаете выйти?", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
    }
}
