using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.Calculation.broadcast
{
    public partial class BroadcastCalculation : Form
    {
        int speedMapCount; //스피드 맵 갯수
        int itemMapCount; //아이템 맵 갯수
        int myTeamScore;
        int rivalTeamScore;

        public BroadcastCalculation()
        {
            InitializeComponent();
        }

        private void BroadcastCalculation_Load(object sender, EventArgs e)
        {
            OnOff_Load();
            textBox1_Load();
            MapList_Load();
            setting_font();
            GameResults();
        }


        private void MapList_Load()
        {
            comboBox1.Items.Add("=== 스피드 맵 ===");
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourcceName = "GameUtilityApp.Function.Calculation.TeamGameCalculation.speedmaplist.txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourcceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    speedMapCount = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < speedMapCount; i++)
                    {
                        comboBox1.Items.Add(reader.ReadLine());
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("스피드 맵 로딩에 실패하였습니다.", "실행 오류");
                this.Close();
            }
            comboBox1.Items.Add("=== 아이템 맵 ===");
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourcceName = "GameUtilityApp.Function.Calculation.TeamGameCalculation.itemmaplist.txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourcceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    itemMapCount = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < itemMapCount; i++)
                    {
                        comboBox1.Items.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("아이템 맵 로딩에 실패하였습니다.", "실행 오류");
            }

        }



        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";


        private void textBox1_Load()
        {
            FileInfo file = new FileInfo(path + @"\calculation data.dat");
            if (file.Exists)
            {
                textBox1.Text = Convert.ToString(File.ReadAllText(path + @"\calculation data.dat"));
            }
            else
            {
                DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
                if (Documents_App_Directory.Exists == false)
                {
                    Documents_App_Directory.Create();
                }
                string reset_text = "⚔ 우리팀 [my] VS [rival] 상대팀 ⚔";
                System.IO.File.WriteAllText(path + @"\calculation data.dat", reset_text, Encoding.UTF8);
                textBox1.Text = reset_text;
            }
            myTeamScore = 0;
            rivalTeamScore = 0;
        }

        private void Fonts_Setting_Click(object sender, EventArgs e)
        {
            Font_Choice newForm = new Font_Choice();
            newForm.ShowDialog();
            setting_font();
            //MessageBox.Show("Name :" + Font_Name + "\nStyle :" + style_Name + "\nColor" + color_Name + "\nSize :" + size_Num + "\nRefresh :" + refresh_time);
            GameResults();
        }

        string Font_Name;
        string style_Name;
        string color_Name;
        string size_Num;
        string refresh_time;
        string style_result;
        public void setting_font()
        {
            int this_ver = 1;
            FileInfo file = new FileInfo(path + @"\fonts.dat");
            if (file.Exists)
            {
                try
                {
                    var set_Fonts = Convert.ToString(File.ReadAllText(path + @"\fonts.dat")); //폰트 파일 가져오기

                    string ver_result = (Regex.Match(set_Fonts, "ver=\".+?\"")).Value; //ver 관련내용 캡처
                    string file_ver = ver_result.Substring(5, ver_result.Length - 6);

                    if (this_ver > Convert.ToInt32(file_ver))
                    {
                        file_reset();
                    }

                    string Font_result = (Regex.Match(set_Fonts, "Font=\".+?\"")).Value; //폰트 이름 캡처
                    Font_Name = Font_result.Substring(6, Font_result.Length - 7);


                    string style_result = (Regex.Match(set_Fonts, "Style=\".+?\"")).Value; //폰트 스타일 캡처
                    style_Name = style_result.Substring(7, style_result.Length - 8);


                    string color_result = (Regex.Match(set_Fonts, "Color=\".+?\"")).Value; //폰트 색상 캡처
                    color_Name = color_result.Substring(7, color_result.Length - 8);


                    string size_result = (Regex.Match(set_Fonts, "Size=\".+?\"")).Value; //폰트 크기 캡처
                    size_Num = size_result.Substring(6, size_result.Length - 7);


                    string refresh_result = (Regex.Match(set_Fonts, "Refresh=\".+?\"")).Value; //폰트 크기 캡처
                    refresh_time = refresh_result.Substring(9, refresh_result.Length - 10);


                }
                catch (Exception)
                {
                    MessageBox.Show("설정 파일을 불러오는데 오류가 생겼습니다. 설정을 초기화 합니다.");
                    file_reset();
                }

            }
            else
            {
                file_reset();
            }

        }

        private void file_reset()
        {
            DirectoryInfo Documents_App_Directory = new DirectoryInfo(path);
            if (Documents_App_Directory.Exists == false)
            {
                Documents_App_Directory.Create();
            }
            string new_text = "ver=\"1\"\nFont=\"굴림\"\nStyle=\"보통\"\nColor=\"white\"\nSize=\"10\"\nRefresh=\"3000\"";
            System.IO.File.WriteAllText(path + @"\fonts.dat", new_text, Encoding.UTF8);
            Font_Name = "굴림";
            style_Name = "보통";
            color_Name = "white";
            size_Num = "10";
            refresh_time = "3000";

        }


        private void Save_Content_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(path + @"\calculation data.dat", textBox1.Text, Encoding.UTF8);
            GameResults();
        }

        private void Win_Button_Click(object sender, EventArgs e)
        {
            myTeamScore++;
            if (myTeamScore != 0 && rivalTeamScore != 0)
            {
                textBox2.Text += "\r\n";
            }
            textBox2.Text += DateTime.Now.ToString("[hh시mm분]") + comboBox1.Text + " '승리' " + myTeamScore + ":" + rivalTeamScore;
            this.textBox2.SelectionStart = textBox2.Text.Length;
            this.textBox2.ScrollToCaret();

            GameResults();
        }
        private void lose_Button_Click(object sender, EventArgs e)
        {
            rivalTeamScore++;
            if (myTeamScore != 0 && rivalTeamScore != 0)
            {
                textBox2.Text += "\r\n";
            }
            textBox2.Text += DateTime.Now.ToString("[hh시mm분]") + comboBox1.Text + " '패배' " + myTeamScore + ":" + rivalTeamScore;
            this.textBox2.SelectionStart = textBox2.Text.Length;
            this.textBox2.ScrollToCaret();

            GameResults();
        }

        private void GameResults() //1이 승리 2가 패배
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcceName = "GameUtilityApp.Function.Calculation.broadcast.HtmlFile.txt";
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourcceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            string CurrentStatus = textBox1.Text;
            CurrentStatus = CurrentStatus.Replace("[my]", Convert.ToString(myTeamScore));
            CurrentStatus = CurrentStatus.Replace("[rival]", Convert.ToString(rivalTeamScore));
            result = result.Replace("[Refresh]", refresh_time);
            switch (style_Name)
            {
                case "보통":
                    style_result = "a";
                    break;
                case "굵게":
                    style_result = "B";
                    break;
                case "기울이기":
                    style_result = "I";
                    break;
                case "취소선":
                    style_result = "STRIKE";
                    break;
                case "밑줄 긋기":
                    style_result = "U";
                    break;
            }
            result = result.Replace("[font_style]", style_result);
            result = result.Replace("[font_size]", size_Num);
            result = result.Replace("[font]", Font_Name);
            result = result.Replace("[font_color]", color_Name);
            if (checkBox1.Checked == false)
            {
                CurrentStatus = "";
            }
            result = result.Replace("[contents]", CurrentStatus);

            System.IO.File.WriteAllText(path + @"\Scoreboard.html", result, Encoding.UTF8);

        }

        private void URL_Copy_Button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(path + @"\Scoreboard.html");
            MessageBox.Show("복사하였습니다. 방송 프로그램에서 브라우저를 추가하고 링크에 붙여넣기 하세요.\r\n혹은 방송 프로그램에서 로컬파일 \r\n" + path + @"\Scoreboard.html" + "\r\n를 선택하세요", "복사");
        }

        private void Score_Reset_Click(object sender, EventArgs e)
        {
            myTeamScore = 0;
            rivalTeamScore = 0;
            textBox2.Text = "";
            GameResults();
        }

        private void OnOff_Check_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
                if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("broadcast onoff")) == "") // 0 off,1 on
                {
                    reg.CreateSubKey("setting").SetValue("broadcast onoff", 1);
                }

                if (checkBox1.Checked == true)
                {
                    reg.OpenSubKey("setting",true).SetValue("broadcast onoff", 1);
                }
                else
                {
                    reg.OpenSubKey("setting",true).SetValue("broadcast onoff", 0);
                }
                reg.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("저장 위치를 불러올 수 없습니다.", "불러오기 오류");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("설정값 초기화 오류"+ex, "불러오기 오류");
                this.Close();
            }
            GameResults();
        }
        private void OnOff_Load()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE").OpenSubKey("Game Utility App", true);
                if (reg.OpenSubKey("setting") == null || Convert.ToString(reg.OpenSubKey("setting").GetValue("broadcast onoff")) == "") // 0 off,1 on
                {
                    reg.CreateSubKey("setting").SetValue("broadcast onoff", 1);
                }

                if(Convert.ToInt32(reg.OpenSubKey("setting").GetValue("broadcast onoff", 1)) == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                reg.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("저장 위치를 불러올 수 없습니다.", "불러오기 오류");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("설정값 초기화 오류", "불러오기 오류");
                this.Close();
            }

        }
    }
}
