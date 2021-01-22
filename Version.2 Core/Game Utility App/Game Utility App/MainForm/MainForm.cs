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
using System.Data.SQLite;
using GameUtilityApp.Essential.Forms;

namespace Game_Utility_App.MainForm
{
    public partial class MainForm : Form
    {
        int win10MessageCount = 0;  //win10 알림 메시지 카운터

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LanguageSetting(); //지역화된 문자열 적용

            RegLoad();
            BasicCheck bc = new BasicCheck();
            if (bc.EssentialCheck()==false)
            {
                Application.Exit();
            }
            LoadSetting();

        }

        private void LanguageSetting() //지역화된 문자열 적용
        {
            //메뉴
            SettingToolStripMenuItem.Text = StringLib.Setting;
            appSettingToolStripMenuItem.Text = StringLib.App_Setting;
            informationToolStripMenuItem.Text = StringLib.Information;

            //버튼
            saveButton.Text = StringLib.save;
        }

        private void LoadSetting()
        {
            string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\AppData\Local\Game Utility App";
            string strFile = path + @"\MainDB.db";
            string strConn = @"Data Source=" + strFile;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "SELECT * FROM `Main Setting`";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using(SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            win10MessageCount = Convert.ToInt32(rdr["Win10 RegMessage"].ToString()); 
                        }
                    }
                    //MessageBox.Show(win10MessageCount+""); //값 확인용
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("설정값을 불러오는 중 문제가 발생하였습니다.\n"+e);
                Application.Exit();
            }
            
        }

        private void RegLoad()
        {
            try
            {
                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard"))
                {
                    textBox1.Text = Convert.ToString(reg.GetValue("InitialKeyboardIndicators", ""));
                    textBox2.Text = Convert.ToString(reg.GetValue("KeyboardDelay", ""));
                    textBox3.Text = Convert.ToString(reg.GetValue("KeyboardSpeed", ""));
                    reg.Close();
                }

                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("Keyboard Response"))
                {
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
                
                using(RegistryKey reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys"))
                {
                    textBox9.Text = Convert.ToString(reg.GetValue("Flags", ""));
                    reg.Close();
                }

                
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
            KeyBoardRegistry kr = new KeyBoardRegistry();
            Int64 v1 = Convert.ToInt64(textBox1.Text);
            Int64 v2 = Convert.ToInt64(textBox2.Text);
            Int64 v3 = Convert.ToInt64(textBox3.Text);
            Int64 v4 = Convert.ToInt64(textBox4.Text);
            Int64 v5 = Convert.ToInt64(textBox5.Text);
            Int64 v6 = Convert.ToInt64(textBox6.Text);
            Int64 v7 = Convert.ToInt64(textBox7.Text);
            Int64 v8 = Convert.ToInt64(textBox8.Text);
            Int64 v9 = Convert.ToInt64(textBox9.Text);
            Int64 v10 = Convert.ToInt64(textBox10.Text);
            Int64 v11 = Convert.ToInt64(textBox11.Text);
            Int64 v12 = Convert.ToInt64(textBox12.Text);
            Int64 v13 = Convert.ToInt64(textBox13.Text);

            try
            {
                kr.Keyboard_Registry_All_Apply(v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,v11,v12,v13);
            }catch(Exception)
            {
                MessageBox.Show(StringLib.ERROR_3, StringLib.ERROR);
            }
            

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
                            keyboardspeed_Notice newForm = new keyboardspeed_Notice();
                            newForm.ShowDialog();
                            win10MessageCount++;
                            newForm = null;
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

        private void ico_pictureBox_Click(object sender, EventArgs e)
        {
            MenuForms nf = new MenuForms();
            nf.ShowDialog();
        }
    }
}
