using GameUtilityApp.Notice;
using GameUtilityApp.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp
{
    public partial class MainSetting : Form
    {
        string appname = "GameUtilityGame";
        public MainSetting()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)  //프로그램 로딩
        {
            loadtooltip();
            button1.Text = "닫기";
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            linkLabel1.Left = (this.ClientSize.Width - linkLabel1.Width) / 2;
            checkBox1.Text = "Windows 시작시 실행";
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if(reg.GetValue(appname)==null||Convert.ToString(reg.GetValue(appname)) == "")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            reg.Close();
            UpdateCheck();
        }
       
        private void loadtooltip()
        {
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(checkBox1, "windows가 실행될때 프로그램이 자동으로 시작됩니다.");
            toolTip1.SetToolTip(button2, "프로그램 설정값을 pc에서 제거합니다.");
            toolTip1.SetToolTip(button3, "업데이트 내역을 확인합니다.");
            toolTip1.SetToolTip(button4, "업데이트를 합니다.");
        }

        private void Winstart_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                if (checkBox1.Checked == true)
                {
                    if (reg.GetValue(appname) == null)
                    {
                        reg.SetValue(appname, Application.ExecutablePath.ToString());
                        MessageBox.Show("프로그램 파일을 이동하거나, 삭제하기 전에는 꼭 해제 부탁드립니다.\n그렇지 않으면 PC를 부팅할때마다 오류가 발생할 수 있습니다.","안내");
                    }
                }
                else
                {
                    if (reg.GetValue(appname) != null)
                    {
                        reg.DeleteValue(appname, false);
                        //MessageBox.Show("취소");
                    }
                }
                reg.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("설정을 적용할 수 없습니다.", "오류");
                if (checkBox1.Checked == true)
                {
                    checkBox1.Checked = false;
                }else if (checkBox1.Checked == false)
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private void exit_Click(object sender,EventArgs e) //닫기 버튼
        {
            this.Close();
        }

        private void reset_click(object sender, EventArgs e)
        {
            if(MessageBox.Show("정말 설정값을 초기화하고 프로그램을 종료하시겠습니까?", "초기화", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reset newForm = new reset();
                newForm.ShowDialog();
            }
        }

        private void patch_Click(object sender, EventArgs e)
        {
            Patch_notes newForm = new Patch_notes();
            newForm.ShowDialog();
        }

        private void UpdateCheck()
        {
            button4.Enabled = false;
            //서버 페이지 연결 
            try
            {
                Basic_Check newCheck = new Basic_Check();
                int lastReleseVer = newCheck.LatestVersionCheck();
                int minReleseVer = newCheck.MinimumVersionCheck();
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App");
                int thisrelese = Convert.ToInt32(reg.GetValue("ver release"));
                label3.Text += Convert.ToString(thisrelese);
                label4.Text += Convert.ToString(lastReleseVer);

                if (thisrelese < lastReleseVer)
                {
                    if (thisrelese < minReleseVer)
                    {
                        if (MessageBox.Show("현재 최신 버전이 아닙니다. 업데이트를 하시겠습니까?\n아니요를 누르면 종료됩니다." + "\n\n" + "버전 정보\n" + "최신 릴리즈 날짜 : " + lastReleseVer + "\n" + "최소 실행 릴리즈 날짜 : " + minReleseVer + "\n본 앱 릴리즈 날짜 : " + thisrelese, "업데이트 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            AppUpadateForm newForm = new AppUpadateForm();
                            newForm.ShowDialog();
                        }
                        else
                        {
                            Application.Exit();
                        }

                    }
                    else if (minReleseVer <= thisrelese)
                    {
                        label2.Text = "업데이트가 있습니다.";
                        button4.Enabled = true;
                    }
                }
                reg.Close();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("업데이트 확인 서버에 연결할 수 없습니다.\n\n홈페이지로 연결하시겠습니까?\n" + ex, "서버에 연결할 수 없습니다.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                    Application.Exit();
                    this.Close();
                }
                else
                {
                    Application.Exit();
                    this.Close();
                }
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            AppUpadateForm newForm = new AppUpadateForm();
            newForm.ShowDialog();
        }
        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

        private void OpenSource_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var client = new HttpClient(); //웹으로부터 다운로드 받을 수 있는 클래스의 인스턴스를 제작 한다.
                var response = client.GetAsync("https://raw.githubusercontent.com/Potato-Y/Game-Utility-App/master/Open%20source%20used/README.md").Result; //웹으로부터 다운로드 
                var html = response.Content.ReadAsStringAsync().Result; //다운로드 결과를 html 로 받아 온다. 
                DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                if (Documents_App_Directory.Exists == false)
                {
                    Documents_App_Directory.Create();
                }

                System.IO.File.WriteAllText(path + @"\Open source used.html", html, Encoding.UTF8);
                System.Diagnostics.Process.Start(path + @"\Open source used.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("업데이트 정보를 불러오는 중에 문제가 생겼습니다"+ex,"오류");
            }

        }

        private void FontLicense_Link_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Font_License newForm = new Font_License();
            newForm.ShowDialog();
        }
    }
}
