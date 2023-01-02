using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TxtShredding
{
    public partial class TxtShredding : Form
    {
        public TxtShredding()
        {
            InitializeComponent();
        }

        void fileReader(int lineGap, int startLine, string filePath, string savePath)
        {

            if (startLine == 0)
            {
                string[] dizi = new string[lineGap];
                int i = 0, j = 0;
                StreamReader streamReader = new StreamReader(filePath);
                string line = streamReader.ReadLine();
                while (line != null)
                {

                    if (i < lineGap)
                    {

                        dizi[i] = line;
                        line = streamReader.ReadLine();
                        i++;

                    }
                    else
                    {
                        fileWriter(savename.Split(".").First() + j.ToString() + ".txt", dizi);
                        i = 0;
                        j++;
                    }
                }

                fileWriter(savename.Split(".").First() + j.ToString() + ".txt", dizi, i);
                streamReader.Close();

            }
            else
            {

            }


        }
        void fileWriter(string path, string[] data, int lastFile = 0)
        {
            StreamWriter streamWriter = new StreamWriter(savePath + @"\" + path);
            if (lastFile == 0)
            {
                foreach (string line in data)
                {
                    streamWriter.WriteLine(line);
                }
            }
            else
            {
                for (int i = 0; i < lastFile; i++)
                {
                    streamWriter.WriteLine(data[i]);
                }
            }


            streamWriter.Close();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fileReader(int.Parse(toolStripTextBox1.Text), int.Parse(toolStripTextBox2.Text), filePath, savePath);

        }
        string filePath, savePath, savename;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt";
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            savename = filePath.Split(@"\").Last();
            listBox1.Items.Add(savename);

            MessageBox.Show("Parçalanan dosyaların kaydedileceği konumu seçin");
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            savePath = folderBrowserDialog.SelectedPath;

        }
    }
}
