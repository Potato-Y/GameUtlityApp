using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential;
using GameUtilityApp.Essential.Language;
using GameUtilityApp.Essential.Reset;
using GameUtilityApp.Essential.Class;

namespace Game_Utility_App.MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LanguageSetting();

            RegLoad();
            BasicCheck bc = new BasicCheck();
            if (bc.EssentialCheck()==false)
            {
                Application.Exit();
            }
        }

        private void LanguageSetting()
        {
            //메뉴
            SettingToolStripMenuItem.Text = StringLib.Setting;
            appSettingToolStripMenuItem.Text = StringLib.App_Setting;
            informationToolStripMenuItem.Text = StringLib.Information;

            //버튼
            saveButton.Text = StringLib.save;
        }

        private void RegLoad()
        {
            try
            {
                RegistryKey reg;
                reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard");
                textBox1.Text = Convert.ToString(reg.GetValue("InitialKeyboardIndicators", ""));
                textBox2.Text = Convert.ToString(reg.GetValue("KeyboardDelay", "")); 
                textBox3.Text = Convert.ToString(reg.GetValue("KeyboardSpeed", ""));
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
                reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys");
                textBox9.Text = Convert.ToString(reg.GetValue("Flags", ""));
                reg.Close();
            }catch(Exception)
            {
                MessageBox.Show("레지스트리를 불러오는데 오류가 발생하였습니다.");
            }
        }

        private void key_Down(object sender, KeyEventArgs e)
        {
            //엔터 누르면 다음칸으로 넘어가기
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == textBox1)
                {
                    textBox2.Focus();
                }
                else if (sender == textBox2)
                {
                    textBox3.Focus();
                }
                else if (sender == textBox3)
                {
                    textBox4.Focus();
                }
                else if (sender == textBox4)
                {
                    textBox5.Focus();
                }
                else if (sender == textBox5)
                {
                    textBox6.Focus();
                }
                else if (sender == textBox6)
                {
                    textBox7.Focus();
                }
                else if (sender == textBox7)
                {
                    textBox8.Focus();
                }
                else if (sender == textBox8)
                {
                    textBox9.Focus();
                }
                else if (sender == textBox9)
                {
                    textBox10.Focus();
                }
                else if (sender == textBox10)
                {
                    textBox11.Focus();
                }
                else if (sender == textBox11)
                {
                    textBox12.Focus();
                }
                else if (sender == textBox12)
                {
                    textBox13.Focus();
                }
                else if (sender == textBox13)
                {
                    saveButton.Focus();
                }

            }
        }



        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e) //색상 변경 및 숫자만 입력
        {

            if (sender == textBox1)
            {
                label1.ForeColor = Color.Blue;
            }
            else if(sender == textBox2)
            {
                label2.ForeColor = Color.Blue;
            }
            else if (sender == textBox3)
            {
                label3.ForeColor = Color.Blue;
            }
            else if (sender == textBox4)
            {
                label4.ForeColor = Color.Blue;
            }
            else if (sender == textBox5)
            {
                label5.ForeColor = Color.Blue;
            }
            else if (sender == textBox6)
            {
                label6.ForeColor = Color.Blue;
            }
            else if (sender == textBox7)
            {
                label7.ForeColor = Color.Blue;
            }
            else if (sender == textBox8)
            {
                label8.ForeColor = Color.Blue;
            }
            else if (sender == textBox9)
            {
                label9.ForeColor = Color.Blue;
            }
            else if (sender == textBox10)
            {
                label10.ForeColor = Color.Blue;
            }
            else if (sender == textBox11)
            {
                label11.ForeColor = Color.Blue;
            }
            else if (sender == textBox12)
            {
                label12.ForeColor = Color.Blue;
            }
            else if (sender == textBox13)
            {
                label13.ForeColor = Color.Blue;
            }


            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {


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

        int win10MessageCount = 0;
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            //windows 10에서 31이 넘으면 알림창을 표시하는 부분

            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            if (win10MessageCount == 0)
            {
                if (vs.Major == 10)
                {
                    try
                    {
                        if (win10MessageCount == 0)
                        {
                            keyboardspeed_Notice newForm =new keyboardspeed_Notice();
                            newForm.ShowDialog();
                            win10MessageCount++;
                        }
                    }
                    catch (FormatException)
                    {
                        win10MessageCount = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("레지스트리 알림 기능에 오류가 발생하였습니다." + ex, "오류");
                    }

                }
            }
        }


        private void toolStripSeparator1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (MessageBox.Show("Do you want App reset?", "?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AppReset nf = new AppReset();
                    nf.ShowDialog();
                }
            }
        
        }
    }
}
