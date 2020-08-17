using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class Terms_of_Use : Form
    {
        int termsOfUseRelese = 20200818;

        public Terms_of_Use()
        {
            InitializeComponent();
            this.ActiveControl = button1;
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        
        private void Start_Button_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
            reg.CreateSubKey("setting", true).SetValue("Terms of user", termsOfUseRelese);
            
            this.Close();
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Terms_of_Use_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                Application.Exit();
            }
        }
    }
}
