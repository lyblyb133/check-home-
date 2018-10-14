using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";//初始显示目录

            //下次打开对话框是否定位到上次打开的目录
            openFileDialog1.RestoreDirectory = true;

            //过滤文件类型
            openFileDialog1.Filter = "txt文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";

            //FilterIndex 与 Filter 关联对应，用于设置默认显示的文件类型
            openFileDialog1.FilterIndex = 1;//默认是1，则默认显示的文件类型为*.txt；如果设置为2，则默认显示的文件类型是*.*

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //将选择的文件赋给文本框
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Path;
            Path = textBox1.Text;
            int i= Path.LastIndexOf("\\");
            string Path1= Path.Substring(0, i + 1);
            //textBox2.Text = i.ToString();
            //var files = Directory.GetFiles(Path1, "*.txt");
            //richTextBox1.Text = string.Join("\r\n",files);
            string line;
            string[] lines=new string[50];
            int iXH = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(textBox1.Text, Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                lines[iXH] = line;//这里的Line就是您要的的数据了
                iXH++;//计数,总共几行
            }
            file.Close();//关闭文件读取流
            textBox2.Text = lines[0];
            i = lines[0].IndexOf("手续费模板名称");
            if (i<1)
            {
                MessageBox.Show("此文件不是手续费模板！请重新选择！");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] s = { "111", "222", "333", "444" };
            string str1 = string.Join("\r\n", s);
            richTextBox1.Text = str1;
        }
    }
}
