using Microsoft.Win32;
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

namespace GameUtilityApp.Notice
{
    public partial class reset : Form
    {
        public reset()
        {
            InitializeComponent();
            
        }

        private void reset_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

                    DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                    if (Documents_App_Directory.Exists == true)
                    {
                        DirectoryInfo folder = new DirectoryInfo(path);
                        folder.Delete(true);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("문서 내 파일을 삭제하는데 문제가 생겼습니다.", "초기화 오류");
                }


                string appname = "GameUtilityGame";
                textBox1.Text += "부팅 실행 검사\r\n";
                RegistryKey reg;
                reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg.GetValue(appname) != null || Convert.ToString(reg.GetValue(appname)) != "")
                {
                    textBox1.Text += "부팅 옵션을 감지했습니다.\r\n";
                    reg.DeleteValue(appname, false);
                    textBox1.Text += "부팅 옵션을 삭제했습니다.\r\n";
                }
                textBox1.Text += "기본 설정값을 제거합니다.\r\n";
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
    }
}
