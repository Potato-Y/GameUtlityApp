using GameUtilityApp.Notice;
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
        }
       
        private void loadtooltip()
        {
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(checkBox1, "windows가 실행될때 프로그램이 자동으로 시작됩니다.");
            toolTip1.SetToolTip(button2, "프로그램 설정값을 pc에서 제거합니다.");
            toolTip1.SetToolTip(button3, "업데이트 내역을 확인합니다.");
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
    }
}
