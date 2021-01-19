using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace GameUtilityApp.Essential.Reset
{
    public partial class AppReset : Form
    {
        public AppReset()
        {
            InitializeComponent();
            //가운데 정렬
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            textBox1.Left = (this.ClientSize.Width - textBox1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;

            Thread reset = new Thread(new ThreadStart(resetStart));
            reset.Start();

        }

        string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";
        void resetStart()
        {
            Thread.Sleep(100);
            textBox_Update("초기화를 시작합니다.\r\n");

            textBox_Update("dwmKiller 프로그램이 실행중인지 확인합니다.\r\n실행중일 경우 종료합니다.");
            Process[] processList = Process.GetProcessesByName("dwmKiller");
            try
            {
                if (processList.Length > 0)
                {
                    processList[0].Kill();
                }

            }
            catch (Exception)
            {
            }

            Thread.Sleep(50);
            textBox_Update("\r\n설정 값을 삭제 합니다.");
            System.IO.FileInfo file_info = new System.IO.FileInfo(path+ @"\MainDB.db");
            try
            {
                file_info.Delete();
            }
            catch (System.IO.IOException)
            {
                textBox_Update("\r\n설정 값을 삭제하지 못하였습니다.");
            }

            Thread.Sleep(50);
            textBox_Update("\r\n이용해 주셔서 감사합니다.");
            textBox_Update("ENDENDEND");
            
        }

        private void textBox_Update(string msg)
        {
            if (textBox1.InvokeRequired)
            {
                if (msg != "ENDENDEND")
                {
                    textBox1.BeginInvoke(new Action(() => textBox1.Text += msg)); 
                    textBox1.BeginInvoke(new Action(() => this.textBox1.SelectionStart = textBox1.Text.Length));
                    textBox1.BeginInvoke(new Action(() => this.textBox1.ScrollToCaret()));
                }
                else
                {
                    button1.BeginInvoke(new Action(() => this.button1.Enabled = true));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
