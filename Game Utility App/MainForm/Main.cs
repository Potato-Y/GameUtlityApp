using System;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Forms;
using GameUtilityApp.Function.reg_;
using GameUtilityApp.Function.후원;
using System.Diagnostics;
using GameUtilityApp.Properties;
using GameUtilityApp.Notice;

namespace GameUtilityApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void UpdateCheck()
        {
            Basic_Check newCheck = new Basic_Check();
            newCheck.DotNetverCheck();  //업데이트 확인 전 .net 버전 먼저 확인한다.
            newCheck.NetworkCheck();
            
            try
            {
                String path = "http://potatoystudio.pe.kr/"; //사이트 접속
                webBrowser2.Navigate(path);
            }
            catch (Exception)
            {
                MessageBox.Show("인터넷 오류", "오류");
                Application.Exit();
                this.Close();
            }

            //서버 페이지 연결 만약 0이면 업데이트가 없는 상태, 1이면 업데이트가 있는 상태

            int updateState = newCheck.UpdateCheck();
            if (updateState == 1)
            {
                button10.Text += " 💬";
                업데이트ToolStripMenuItem.Enabled = true;
                toolTip1.SetToolTip(button10, "업데이트가 있습니다.");
            }
            if (updateState == 0)
            {
                toolTip1.SetToolTip(button10, "프로그램을 설정합니다.");
            }
            if (updateState == 3)
            {
                MessageBox.Show("오류가 발생하였습니다. 수동 패치가 필요할 수 있습니다.");
                System.Diagnostics.Process.Start("https://cafe.naver.com/checkmateclub");
                Application.Exit();
            }

            newCheck.NewUserCheck();
        }



        private void Form1_Load(object sender, EventArgs e)  //프로그램 로딩
        {
            label11.Text = "0";
            label14.Text = "0";
            label15.Text = "0";
            //필수 시작점

            this.ActiveControl = button5;
            //그룹 영역
            groupBox1.Text = "Keyboard Registry";
            groupBox2.Text = "Keyboard Response Registry";
            groupBox3.Text = "ToggleKeys Registry";
            groupBox4.Text = "Utility+";
            groupBox5.Text = "Registry";
            //그룹 영역 끝

            //버튼 영역
            button1.Text = "저장";
            button2.Text = "저장";
            button3.Text = "저장";
            button4.Text = "사용방법";
            button5.Text = "권장 레지";
            button6.Text = "reg reload";
            button7.Text = "부가기능";
            button8.Text = "전체 저장";
            button9.Text = "Reg +";
            button10.Text = "설정";
            button11.Text = "후원을 통해 앱 서버 유지";
            button12.Text = "공식 홈";
            //버튼 영역 끝

            //레이블 영역
            label1.Text = "InitialKeyboardIndicators";
            label2.Text = "KeyboardDelay";
            label3.Text = "KeyboardSpeed";

            label4.Text = "AutoRepeatDelay";
            label5.Text = "AutoRepeatRate";
            label6.Text = "BounceTime";
            label7.Text = "DelayBeforeAcceptance";
            label8.Text = "Flags";

            label9.Text = "Flags";
            //레이블 영역 끝

            UpdateCheck();
            UserCount();
            //레지 불러오기
            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();

            loadtooltip();

            FontCheck Check = new FontCheck();
            Check.FontFileCheck();
            notifyIcon1.Visible = true;
        }

        //툴팁 영역
        private void loadtooltip()
        {
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

            //saveButton 영역
            toolTip1.SetToolTip(button1, "Keyboard 부분을 저장합니다.");
            toolTip1.SetToolTip(button2, "Keyboard Response 부분을 저장합니다.");
            toolTip1.SetToolTip(button3, "ToggleKeys 부분을 저장합니다.");
            toolTip1.SetToolTip(button8, "전체 저장합니다.");

            //utility+ 영역
            toolTip1.SetToolTip(button4, "사용방법이 설명되어있는 페이지로 연결합니다.");
            toolTip1.SetToolTip(button5, "권장하는 레지스트리로 전체 초기화합니다.");
            toolTip1.SetToolTip(button6, "레지스트리를 다시 불러옵니다.");
            toolTip1.SetToolTip(button9, "레지스트리를 상세 설정합니다.");
            toolTip1.SetToolTip(button7, "추가 기능을 봅니다.");
            toolTip1.SetToolTip(button11, "후원 안내창을 띄웁니다.");
            toolTip1.SetToolTip(button12, "공식 개발 카페로 연결합니다.");
        }

        //사용자 파악
        private void UserCount()
        {
            try
            {
                String path = "http://potatoystudio.pe.kr/";
                webBrowser2.Navigate(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                Application.Exit();
                this.Close();
            }

            try
            {
                Basic_Check userCheck = new Basic_Check();
                label11.Text = userCheck.GetNowUserCountData();
                label14.Text = userCheck.GetTodayCountData();
                label15.Text = userCheck.GetTotalCountData();
            }
            catch (Exception)
            {
                if (MessageBox.Show("서비스 점검중입니다. \n보통 00~06시까지 점검하나 몇일간 이 메시지가 보인다면 홈페이지 공지를 확인해주세요.\n\n홈페이지로 연결하시겠습니까?", "서버에 연결할 수 없습니다.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("https://cafe.naver.com/checkmateclub");
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
        
        
        

        //세이브 버튼
        private void KeyboardClick(object sender, EventArgs e)
        {
            RegSave_keyboard();
            MessageBox.Show("Keyboard 부분을 저장하였습니다.", "Save");
            RegReload_keyboard();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void ResponseClick(object sender, EventArgs e)
        {
            RegSave_Response();
            MessageBox.Show("Keyboard Response 부분을 저장하였습니다.", "Save");
            RegReload_Response();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void ToggleKeysClick(object sender, EventArgs e)
        {
            RegSave_ToggleKeys();
            MessageBox.Show("ToggleKeys 부분을 저장하였습니다.", "Save");
            RegReload_ToggleKeys();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void SaveAll(object sender, EventArgs e) //전체 세이브
        {
            RegSave_keyboard();
            RegSave_Response();
            RegSave_ToggleKeys();
            MessageBox.Show("모두 저장하였습니다.", "Save");
            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }
        //세이브 버튼 끝

        private void ReloadClick(object sender, EventArgs e) //레지 새로고침
        {
            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();
            MessageBox.Show("모두 저장 전으로 새로고침 되었습니다.", "Reload");
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void RecommendReg_Click(object sender, EventArgs e)  //권장 레지로 설정
        {
            label1.ForeColor = Color.Blue;
            label2.ForeColor = Color.Blue;
            label3.ForeColor = Color.Blue;
            label4.ForeColor = Color.Blue;
            label5.ForeColor = Color.Blue;
            label6.ForeColor = Color.Blue;
            label7.ForeColor = Color.Blue;
            label8.ForeColor = Color.Blue;
            label9.ForeColor = Color.Blue;

            textBox1.Text = "2";
            textBox2.Text = "0";
            textBox3.Text = "48";
            textBox4.Text = "300";
            textBox5.Text = "300";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "26";
            textBox9.Text = "62";
            RegSave_keyboard();
            RegSave_Response();
            RegSave_ToggleKeys();
            MessageBox.Show("권장 값으로 저장하였습니다.", "Save");
            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            MainSetting newForm = new MainSetting();
            newForm.ShowDialog();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void Utility_Click(object sender, EventArgs e)
        {
            UtilityChoice newForm = new UtilityChoice();
            newForm.ShowDialog();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void Sponsor_Click(object sender, EventArgs e)
        {
            Sponsor newForm = new Sponsor();
            newForm.ShowDialog();
            UserCount();
        }

        private void UseHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://repotato.tistory.com/138");
            UserCount();
        }

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
        int win10_message_count = 0;
        private void textbox3_keyup(object sender, KeyEventArgs e)
        {
            //windows 10에서 31이 넘으면 알림창을 표시하는 부분

            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            if (win10_message_count == 0)
            {
                if (vs.Major == 10)
                {
                    try
                    {
                        if (win10_message_count == 0)
                        {
                            if (Convert.ToInt32(textBox3.Text) >= 32)
                            {
                                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
                                if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("keyboardspeed win10")) == "")
                                {
                                    reg.CreateSubKey("setting").SetValue("keyboardspeed win10", 0);
                                }
                                reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App").OpenSubKey("setting");
                                if (Convert.ToInt32(reg.GetValue("keyboardspeed win10")) == 0)
                                {
                                    KeyboardSpeed_win10 newForm = new KeyboardSpeed_win10();
                                    newForm.ShowDialog();
                                    win10_message_count++;
                                }
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        win10_message_count = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Windows10 경고 관련 시스템에 문제가 발생했습니다." + ex, "오류");
                    }

                }
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

        private void RegPluse_Click(object sender, EventArgs e)
        {
            RegPlus newForm = new RegPlus();
            newForm.ShowDialog();
            RegReload_keyboard();
            RegReload_Response();
            RegReload_ToggleKeys();
            UserCount(); //버튼 누를 때마다 사용자 수 재설정
        }

        private void Homepage_Click(object sender, EventArgs e)
        {
            Process.Start("https://cafe.naver.com/checkmateclub");
        }

        //레지 불러오기 영역
        private void RegReload_keyboard()
        {
            //CurrentUser 영역
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("KeyBoard");
            textBox1.Text = Convert.ToString(reg.GetValue("InitialKeyboardIndicators", ""));
            textBox2.Text = Convert.ToString(reg.GetValue("KeyboardDelay", ""));
            textBox3.Text = Convert.ToString(reg.GetValue("KeyboardSpeed", ""));
            reg.Close();
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
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
            reg.Close();
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            reg.Close();
        }

        private void RegReload_ToggleKeys()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys");
            textBox9.Text = Convert.ToString(reg.GetValue("Flags", ""));
            reg.Close();
            label9.ForeColor = Color.Black;
        }
        //레지 불러오기 끝
        //레지 저장하기
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
            reg.SetValue("Last BounceKey Setting", "0", RegistryValueKind.DWord);
            reg.SetValue("Last Valid Delay", "0", RegistryValueKind.DWord);
            reg.SetValue("Last Valid Repeat", "0", RegistryValueKind.DWord);
            reg.SetValue("Last Valid Wait", "1000", RegistryValueKind.DWord);
            reg.Close();

        }

        private void RegSave_ToggleKeys()
        {
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Accessibility").OpenSubKey("ToggleKeys", true);

            reg.SetValue("Flags", textBox9.Text);
            reg.Close();

        }
        //레지 저장하기 끝

        //프로그램 트레이 아이콘
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            System.Reflection.MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            methodInfo.Invoke(notifyIcon1, null);
        }

        private void App_Closing_Click(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                this.ShowIcon = false;
                notifyIcon1.Visible = true;
                e.Cancel = true;
            }
        }

        /* 최소화 할 때 트레이 아이콘으로 가게 하기
        private void Notify_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowIcon = false;
                notifyIcon1.Visible = true;
            }
        }
        */

        private void notify_Double_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowIcon = true;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }


        private void StripExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        //트레이 아이콘에서 바로가기 영역
        //점수 부분
        private void PrivateCalculation_Click(object sender, EventArgs e)
        {
            PrivateCalculationOffline newForm = new PrivateCalculationOffline();
            newForm.Show();
        }
        private void TeamGameCalculation_Click(object sender, EventArgs e)
        {
            TeamGameCalculationOffline newForm = new TeamGameCalculationOffline();
            newForm.Show();
        }
        private void ScreenCapture_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\카트라이더\스크린샷";
                System.Diagnostics.Process.Start(path);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("폴더를 찾을 수 없습니다.", "폴더 오류");
            }
        }
        private void Riderdata_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\카트라이더\라이더데이터";
                System.Diagnostics.Process.Start(path);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("폴더를 찾을 수 없습니다.", "폴더 오류");
            }
        }

        private void noti_update_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("업데이트를 하시겠습니까?", "업데이트", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Show();
                AppUpadateForm newForm = new AppUpadateForm();
                newForm.ShowDialog();
            }
        }

        private void noti_UtilityPlus_Click(object sender, EventArgs e)
        {
            this.Show();
            UtilityChoice newForm = new UtilityChoice();
            newForm.ShowDialog();
        }

        private void Icon_Show(object sender, EventArgs e)
        {
            this.ShowIcon = true;

        }
    }
}
