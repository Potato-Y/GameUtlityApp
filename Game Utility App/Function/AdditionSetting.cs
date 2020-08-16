using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.Calculation
{
    public partial class AdditionSetting : Form
    {
        string screenWidth;
        string screenHeigth;
        public AdditionSetting()
        {
            InitializeComponent();
            checkBox1.CheckStateChanged += screenSetting;
        }

        private void AdditionSetting_Load(object sender, EventArgs e)
        {
            ScreenPart_Load();
        }

        private void ScreenPart_Load()
        {
            checkBox1.Text = "1600 * 900 해상도로 변경";
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            LoadScreen();
            label3.Text = screenWidth + " * " + screenHeigth;
            if (screenWidth == "1600")
            {
                if (screenHeigth == "900")
                {
                    checkBox1.Checked = true;
                }
            }
            checkBox1.Enabled = false;
            dwmKillerPart_Load();

        }

        private void dwmKillerPart_Load()
        {
            checkBox2.Left = (this.ClientSize.Width - checkBox2.Width) / 2;
            OperatingSystem osVer = Environment.OSVersion;
            if (osVer.Version.Major == 6 && osVer.Version.Minor == 1)
            {
                checkBox2.Enabled = true;
                linkLabel1.Enabled = true;
            }

        }

        private void dwmKiller_CheckBox_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);

                try
                {
                    if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("dwmKiller Start")) == "")
                    {
                        reg.CreateSubKey("setting",true).SetValue("dwmKiller Start", 1); //0이면 작동 안함, 1이면 작동 함
                    }
                    else
                    {
                        reg.OpenSubKey("setting",true).SetValue("dwmKiller Start", 1); //0이면 작동 안함, 1이면 작동 함
                    }
                    MessageBox.Show("다음 프로그램 실행부터 작동합니다. \r\ndwmKiller.exe 실행 경고문이 뜨면 허용하여야 정상 작동합니다.\r\nAero테마가 비활성화되어 있어야 효과가 있습니다.", "안내");

                }
                catch (Exception)
                {
                    MessageBox.Show("설정중 오류가 발생하였습니다.", "오류 발생");
                    checkBox2.Checked = false;
                }
                reg.Close();
            }
        }

        private void screenSetting(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("아직 준비중 입니다.");
            }
            
        }
        
        private void LoadScreen()
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            screenHeigth = Screen.PrimaryScreen.Bounds.Height.ToString();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1~7개의 위험 확인은 오차 범위 이내 입니다.","안내");
            System.Diagnostics.Process.Start("https://www.virustotal.com/gui/file/c1001d325d43ec0179051fca29904c8c6797ba94705222fdae66a96d2b29bfdf/detection");
        }
    }
}
