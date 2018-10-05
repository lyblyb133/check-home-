using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

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
            openFileDialog1.Filter = "dbf文件 (*.dbf)|*.dbf|所有文件 (*.*)|*.*";

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
            try
            {
                string strOledbCon = @"Provider=vfpoledb;Data Source=e:\check\dbf;Collating Sequence=machine;";//设置连接字符串
                using (OleDbConnection OledbCon = new OleDbConnection())
                {
                    OledbCon.ConnectionString = strOledbCon;
                    OledbCon.Open();
                    OleDbDataAdapter OledbDat = new OleDbDataAdapter("select * from zjlb.DBF", strOledbCon);
                    DataTable dt = new DataTable();
                    OledbDat.Fill(dt);
                    
                    //return mySet;
                }
            }
            catch (Exception y)
            {
                MessageBox.Show(y.Message);
            }
        }
    }
}
