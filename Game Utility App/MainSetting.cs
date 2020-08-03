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
            this.button1.Click += new System.EventHandler(this.exit_Click);
        }
        private void Form2_Load(object sender, EventArgs e)  //프로그램 로딩
        { 
            button1.Text = "닫기";
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            checkBox1.Text = "Windows 시작시 실행";
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
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

        private void Winstart_Click(object sender, EventArgs e)
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            
            if (checkBox1.Checked == true)
            {
                if (reg.GetValue(appname) == null)
                {
                    reg.SetValue(appname, Application.ExecutablePath.ToString());
                    //MessageBox.Show("등록");
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

        private void exit_Click(object sender,EventArgs e) //닫기 버튼
        {
            this.Close();
        }

    }
}
