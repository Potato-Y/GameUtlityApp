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
            loadtooltip();
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

        private void loadtooltip()
        {
            toolTip1.SetToolTip(comboBox1, "프리셋을 선택할 수 있습니다.");
            toolTip1.SetToolTip(linkLabel1, "프리셋 출처로 이동합니다.");


            //textBox 영역
            toolTip1.SetToolTip(textBox1, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox2, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox3, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox4, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox5, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox6, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox7, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox8, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox9, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox10, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox11, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox12, "숫자를 입력하십시오");
            toolTip1.SetToolTip(textBox13, "숫자를 입력하십시오");

            toolTip1.SetToolTip(button8, "전체 저장합니다.");
        }

        //선수 이름 셋팅
        string myset = "내 설정";
        string LJD = "ㅇㅈㄷ 님"; //이중대
        string LJS = "ㅇㅈㅅ 님"; //이중선
        string BIS = "ㅂㅇㅅ 님"; //박인수
        string BMS = "ㅂㅁㅅ 님"; //박민수
        string RMG = "ㄹㅁㄱ 님"; //런민기
        string SJM = "ㅅㅈㅁ 님"; //신종민
        string KTH = "ㄱㅌㅎ 님"; //김택환
        string neal = "N-1 님"; //닐
        string IHG = "ㅇㅎㅈ 님  (정확하지 않음)"; //안혁진


        string Mschool = "ㅁㅇㅅㅋ 님"; //민영스쿨
        string Rooki = "ㄹㅋㅇㅈ 님"; //루키영재
        string chizz = "ㅊㅈ 님"; //치즈
        string rcl = "ㄹㅊㄹ 님"; //레츠리
        string ollf = "ㅇㅍ 님"; //울프
        string dhgu = "ㄷㅎㄱㅇ 님"; //대한건우
        string spmh = "ㅅㅍㅁㅎ 님 (정확하지 않음)"; //스펙마허

        private void save_Click(object sender, EventArgs e)
        {
            RegSave_keyboard();
            RegSave_Response();
            RegSave_ToggleKeys();
            MessageBox.Show("저장되었습니다.", "Save");
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
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
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;
                    label6.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                    label8.ForeColor = Color.Black;
                    label9.ForeColor = Color.Black;
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                    label12.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                }
                if (comboBox1.Text == LJD)
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
                if (comboBox1.Text == LJS)
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
                if (comboBox1.Text == BIS)
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
                if (comboBox1.Text == BMS)
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
                if (comboBox1.Text == RMG)
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

        //숫자만 입력되도록 하며 입력시 글자색이 파란색으로 변경
        private void txtInterval_KeyPress_box1(object sender, KeyPressEventArgs e)
        {
            label1.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box2(object sender, KeyPressEventArgs e)
        {
            label2.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box3(object sender, KeyPressEventArgs e)
        {
            label3.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box4(object sender, KeyPressEventArgs e)
        {
            label4.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box5(object sender, KeyPressEventArgs e)
        {
            label5.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box6(object sender, KeyPressEventArgs e)
        {
            label6.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box7(object sender, KeyPressEventArgs e)
        {
            label7.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box8(object sender, KeyPressEventArgs e)
        {
            label8.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box9(object sender, KeyPressEventArgs e)
        {
            label9.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box10(object sender, KeyPressEventArgs e)
        {
            label10.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box11(object sender, KeyPressEventArgs e)
        {
            label11.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box12(object sender, KeyPressEventArgs e)
        {
            label12.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void txtInterval_KeyPress_box13(object sender, KeyPressEventArgs e)
        {
            label13.ForeColor = Color.Blue;
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        // 색바꾸기, 숫자만 입력 코드 끝
        private void key_Enter1(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }
        private void key_Enter2(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }
        private void key_Enter3(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }
        private void key_Enter4(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }
        private void key_Enter5(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }
        private void key_Enter6(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }
        private void key_Enter7(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void key_Enter8(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }
        private void key_Enter10(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
        }
        private void key_Enter11(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
            }
        }
        private void key_Enter12(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
        }
        private void key_Enter13(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }
        private void key_Enter9(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                button8.Focus();
            }
        }


    }
}
