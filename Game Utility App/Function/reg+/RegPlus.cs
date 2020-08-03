using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.reg_
{
    public partial class RegPlus : Form
    {
        public RegPlus()
        {
            InitializeComponent();
        }

        private void RegPlus_Load(object sender, EventArgs e)
        {
            label1.Text = "InitialKeyboardIndicators";
            label2.Text = "KeyboardDelay";
            label3.Text = "KeyboardSpeed";

            label4.Text = "AutoRepeatDelay";
            label5.Text = "AutoRepeatRate";
            label6.Text = "BounceTime";
            label7.Text = "DelayBeforeAcceptance";
            label8.Text = "Flags";
            label10.Text = "Last BounceKey Setting";
            label11.Text = "Last Valid Delay";
            label12.Text = "Last Valid Repeat";
            label13.Text = "Last Valid Wait";

            label9.Text = "Flags";

            groupBox1.Text = "Keyboard Registry";
            groupBox2.Text = "Keyboard Response Registry";
            groupBox3.Text = "ToggleKeys Registry";
            groupBox5.Text = "Registry";

            button8.Text = "저장하기";

            /*
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            */
            
            

            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
            textBox9.BackColor = Color.White;
            textBox10.BackColor = Color.White;
            textBox11.BackColor = Color.White;
            textBox12.BackColor = Color.White;
            textBox13.BackColor = Color.White;

            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();

            comboBox1.Items.AddRange(new string[] { myset, "===매우 빠름 유명인===", LJD, LJS, BIS, BMS, RMG, SJM, KTH, IHG, neal, "===빠름 유명인===", Mschool, Rooki, chizz, rcl, ollf, dhgu, spmh });
            comboBox1.SelectedIndex = 0;
        }


        string myset = "내 설정";
        string LJD = "ㅇㅈㄷ 님"; 
        string LJS = "ㅇㅈㅅ 님";
        string BIS = "ㅂㅇㅅ 님"; 
        string BMS = "ㅂㅁㅅ 님"; 
        string RMG = "ㄹㅁㄱ 님"; 
        string SJM = "ㅅㅈㅁ 님"; 
        string KTH = "ㄱㅌㅎ 님"; 
        string neal = "neal 님"; 
        string IHG = "ㅇㅎㅈ 님  (정확하지 않음)";


        string Mschool = "ㅁㅇㅅㅋ 님"; 
        string Rooki = "ㄹㅋㅇㅈ 님";
        string chizz = "ㅊㅈ 님"; 
        string rcl = "ㄹㅊㄹ 님"; 
        string ollf = "ㅇㅍ 님"; 
        string dhgu = "ㄷㅎㄱㅇ 님";
        string spmh = "ㅅㅍㅁㅎ 님 (정확하지 않음)";

        private void save_Click(object sender, EventArgs e)
        {
            RegSave_keyboard();
            RegSave_Response();
            RegSave_ToggleKeys();
            MessageBox.Show("저장되었습니다.", "Save");
        }

        private void regChoice(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if(cb.SelectedIndex>-1)
            {
                if(comboBox1.Text==myset)
                {
                    RegReload_keyboard();
                    RegReload_Response();
                    RegReload_ToggleKeys();
                }
                if (comboBox1.Text ==LJD)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "300";
                    textBox5.Text = "300";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "2";
                    textBox10.Text = "0";
                    textBox11.Text = "300";
                    textBox12.Text = "300";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text ==LJS)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "1000";
                    textBox5.Text = "500";
                    textBox6.Text = "0";
                    textBox7.Text = "1000";
                    textBox8.Text = "126";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "1000";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text ==BIS)
                {
                    textBox1.Text = "2147483650";
                    textBox2.Text = "1";
                    textBox3.Text = "31";
                    textBox4.Text = "1000";
                    textBox5.Text = "500";
                    textBox6.Text = "0";
                    textBox7.Text = "1000";
                    textBox8.Text = "126";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "1000";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text ==BMS)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "300";
                    textBox5.Text = "300";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "2";
                    textBox10.Text = "0";
                    textBox11.Text = "300";
                    textBox12.Text = "300";
                    textBox13.Text = "0";
                    textBox9.Text = "58";
                }
                if (comboBox1.Text ==RMG )
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "31";
                    textBox4.Text = "0";
                    textBox5.Text = "1";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "26";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "1";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == SJM)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "500";
                    textBox4.Text = "200";
                    textBox5.Text = "6";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "59";
                    textBox10.Text = "0";
                    textBox11.Text = "200";
                    textBox12.Text = "6";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == KTH)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "300";
                    textBox5.Text = "300";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "2";
                    textBox10.Text = "0";
                    textBox11.Text = "300";
                    textBox12.Text = "300";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == neal)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "500";
                    textBox4.Text = "200";
                    textBox5.Text = "6";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "59";
                    textBox10.Text = "0";
                    textBox11.Text = "200";
                    textBox12.Text = "6";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == IHG)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "31";
                    textBox4.Text = "300";
                    textBox5.Text = "300";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "26";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "1000";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == Mschool)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "38";
                    textBox4.Text = "200";
                    textBox5.Text = "6";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "70";
                    textBox10.Text = "0";
                    textBox11.Text = "200";
                    textBox12.Text = "6";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == Rooki)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "38";
                    textBox4.Text = "1000";
                    textBox5.Text = "500";
                    textBox6.Text = "0";
                    textBox7.Text = "1000";
                    textBox8.Text = "62";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "1000";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == chizz)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "1000";
                    textBox5.Text = "500";
                    textBox6.Text = "0";
                    textBox7.Text = "1000";
                    textBox8.Text = "126";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "1000";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == rcl)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "200";
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "2";
                    textBox10.Text = "0";
                    textBox11.Text = "200";
                    textBox12.Text = "0";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == ollf)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "48";
                    textBox4.Text = "1";
                    textBox5.Text = "1";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "26";
                    textBox10.Text = "0";
                    textBox11.Text = "1";
                    textBox12.Text = "1";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == dhgu)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "70";
                    textBox4.Text = "200";
                    textBox5.Text = "1";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "26";
                    textBox10.Text = "0";
                    textBox11.Text = "300";
                    textBox12.Text = "300";
                    textBox13.Text = "0";
                    textBox9.Text = "62";
                }
                if (comboBox1.Text == spmh)
                {
                    textBox1.Text = "2";
                    textBox2.Text = "0";
                    textBox3.Text = "38";
                    textBox4.Text = "200";
                    textBox5.Text = "6";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "70";
                    textBox10.Text = "0";
                    textBox11.Text = "200";
                    textBox12.Text = "1";
                    textBox13.Text = "0";
                    textBox9.Text = "58";
                }
                if (comboBox1.Text != myset)
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    textBox11.Enabled = false;
                    textBox12.Enabled = false;
                    textBox13.Enabled = false;
                }
                else
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    textBox9.Enabled = true;
                    textBox10.Enabled = true;
                    textBox11.Enabled = true;
                    textBox12.Enabled = true;
                    textBox13.Enabled = true;
                }
            }
        }

        private void link_Click(object sender, EventArgs e)
        {
            Process.Start("https://gall.dcinside.com/kart/2128633");
        }

        //레지 불러오기
        private void RegReload_keyboard()
        {
            //CurrentUser 영역
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard");
            textBox1.Text = Convert.ToString(reg.GetValue("InitialKeyboardIndicators", ""));
            textBox2.Text = Convert.ToString(reg.GetValue("KeyboardDelay", ""));
            textBox3.Text = Convert.ToString(reg.GetValue("KeyboardSpeed", ""));
            reg.Close();
        }

        private void RegReload_Response()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response");
            textBox4.Text = Convert.ToString(reg.GetValue("AutoRepeatDelay", ""));
            textBox5.Text = Convert.ToString(reg.GetValue("AutoRepeatRate", ""));
            textBox6.Text = Convert.ToString(reg.GetValue("BounceTime", ""));
            textBox7.Text = Convert.ToString(reg.GetValue("DelayBeforeAcceptance", ""));
            textBox8.Text = Convert.ToString(reg.GetValue("Flags", ""));
            textBox10.Text = Convert.ToString(reg.GetValue("Last BounceKey Setting", ""));
            textBox11.Text = Convert.ToString(reg.GetValue("Last Valid Delay", ""));
            textBox12.Text = Convert.ToString(reg.GetValue("Last Valid Repeat", ""));
            textBox13.Text = Convert.ToString(reg.GetValue("Last Valid Wait", ""));
            reg.Close();
        }

        private void RegReload_ToggleKeys()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys");
            textBox9.Text = Convert.ToString(reg.GetValue("Flags", ""));
            reg.Close();
        }
        //레지 불러오기 끝

        //레지 저장
        private void RegSave_keyboard()
        {
            //CurrentUser
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard", true);

            reg.SetValue("InitialKeyboardIndicators", textBox1.Text);
            reg.SetValue("KeyboardDelay", textBox2.Text);
            reg.SetValue("KeyboardSpeed", textBox3.Text);

            reg.Close();
        }

        private void RegSave_Response()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response", true);
            reg.SetValue("AutoRepeatDelay", textBox4.Text);
            reg.SetValue("AutoRepeatRate", textBox5.Text);
            reg.SetValue("BounceTime", textBox6.Text);
            reg.SetValue("DelayBeforeAcceptance", textBox7.Text);
            reg.SetValue("Flags", textBox8.Text);
            reg.SetValue("Last BounceKey Setting", textBox10.Text,RegistryValueKind.DWord);
            reg.SetValue("Last Valid Delay", textBox11.Text, RegistryValueKind.DWord);
            reg.SetValue("Last Valid Repeat", textBox12.Text, RegistryValueKind.DWord);
            reg.SetValue("Last Valid Wait", textBox13.Text, RegistryValueKind.DWord);
            reg.Close();
        }

        private void RegSave_ToggleKeys()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys", true);

            reg.SetValue("Flags", textBox9.Text);
            reg.Close();
        }
        //레지 저장 끝
    }
}
