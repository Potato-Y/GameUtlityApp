using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class KeyboardSpeed_win10 : Form
    {
        public KeyboardSpeed_win10()
        {
            InitializeComponent();
        }

        private void KeyboardSpeed_win10_Load(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    RegistryKey reg;
                    reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App").OpenSubKey("setting", true);
                    reg.SetValue("keyboardspeed win10", 1);
                    reg.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("설정값을 저장할 수 없습니다.","저장 오류");
                }
                
            }
            this.Close();
        }
    }
}
