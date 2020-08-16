using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class reset : Form
    {
        public reset()
        {
            InitializeComponent();
            Application.Idle += reset_Start;
            
        }

        private void reset_Start(object sender, EventArgs e)
        {
            Application.Idle -= reset_Start;
            textBox1.Text += "초기화를 시작합니다.\r\n";
            textbox1Scroll();
            try
            {
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

                try
                {
                    string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

                    textBox1.Text += "내 문서에 파일 여부를 확인합니다.\r\n";
                    textbox1Scroll();

                    DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                    if (Documents_App_Directory.Exists == true)
                    {
                        textBox1.Text += "폴더를 확인했습니다. 폴더를 삭제합니다.";
                        textbox1Scroll();

                        DirectoryInfo folder = new DirectoryInfo(path);
                        folder.Delete(true);

                        textBox1.Text += "폴더를 삭제했습니다.\r\n";
                        textbox1Scroll();

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("문서 내 파일을 삭제하는데 문제가 생겼습니다.", "초기화 오류");
                }

                textBox1.Text += "저장된 설정값을 삭제합니다.\r\n";
                textbox1Scroll();

                string appname = "GameUtilityGame";
                textBox1.Text += "부팅 실행 검사\r\n";
                textbox1Scroll();

                RegistryKey reg;
                reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                textBox1.Text += "부팅 옵션을 확인합니다.\r\n";
                textbox1Scroll();


                if (reg.GetValue(appname) != null || Convert.ToString(reg.GetValue(appname)) != "")
                {
                    textBox1.Text += "부팅 옵션을 감지했습니다.\r\n";
                    textbox1Scroll();

                    reg.DeleteValue(appname, false);
                    textBox1.Text += "부팅 옵션을 삭제했습니다.\r\n";
                    textbox1Scroll();

                }
                else
                {
                    textBox1.Text += "부팅 옵션이 없습니다.\r\n";
                    textbox1Scroll();

                }
                textBox1.Text += "기본 설정값을 제거합니다.\r\n";
                textbox1Scroll();

                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Game Utility App\setting", false);
                Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Game Utility App", false);

                MessageBox.Show("초기화가 완료되었습니다.");
                reg.Close();
                Application.Exit();
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("초기화중 오류가 발생하였습니다.", "초기화 오류");
                Application.Exit();
                this.Close();
            }

        }

        private void textbox1Scroll()
        {
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
        }

        private void reset_Load(object sender, EventArgs e)
        {
        }
    }
}
