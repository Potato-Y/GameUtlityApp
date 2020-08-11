using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.Calculation.broadcast
{
    public partial class Font_Choice : Form
    {
        public Font_Choice()
        {
            InitializeComponent();
        }
        private void FontForm_Load(object sender, EventArgs e)
        {
            fonts_Load();
        }
        static string path = @"C:\Users\" + ((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1]) + @"\Documents\Game Utility App";

        private void fonts_Load()
        {
            //폰트 불러오기
            FontFamily[] fonts = FontFamily.Families;
            foreach (FontFamily font in fonts)
                comboBox1.Items.Add(font.Name);

            comboBox2.Items.AddRange(new string[] { "보통", "굵게", "기울이기", "취소선", "밑줄 긋기" });
            comboBox3.Items.AddRange(new String[] { "white", "yellow", "red", "black", "blue", "orange", "silver", "purple", "fuchsia", "gray", "green", "lime", "maroon", "navy", "olive", "aqua", "teal" });

            int this_ver = 1;
            //폰트 파일이 있는지 확인
            FileInfo file = new FileInfo(path + @"\fonts.dat"); 
            if (file.Exists)
            {
                try
                {
                    var set_Fonts = Convert.ToString(File.ReadAllText(path + @"\fonts.dat")); //폰트 파일 가져오기

                    string ver_result = (Regex.Match(set_Fonts, "ver=\".+?\"")).Value; //ver 관련내용 캡처
                    string file_ver = ver_result.Substring(5, ver_result.Length-6);

                    if (this_ver > Convert.ToInt32(file_ver))
                    {
                        file_reset();
                    }

                    string Font_result = (Regex.Match(set_Fonts, "Font=\".+?\"")).Value; //폰트 이름 캡처
                    string Font_Name = Font_result.Substring(6, Font_result.Length - 7);
                    comboBox1.Text = Font_Name;

                    string style_result= (Regex.Match(set_Fonts, "Style=\".+?\"")).Value; //폰트 스타일 캡처
                    string style_Name = style_result.Substring(7, style_result.Length - 8);
                    comboBox2.Text = style_Name;

                    string color_result = (Regex.Match(set_Fonts, "Color=\".+?\"")).Value; //폰트 색상 캡처
                    string color_Name = color_result.Substring(7, color_result.Length - 8);
                    comboBox3.Text = color_Name;

                    string size_result = (Regex.Match(set_Fonts, "Size=\".+?\"")).Value; //폰트 크기 캡처
                    string size_Num = size_result.Substring(6, size_result.Length - 7);
                    comboBox4.Text = size_Num;

                    string refresh_result = (Regex.Match(set_Fonts, "Refresh=\".+?\"")).Value; //폰트 크기 캡처
                    string refresh_time = refresh_result.Substring(9, refresh_result.Length - 10);
                    textBox1.Text =Convert.ToString(Convert.ToInt64(refresh_time)/1000);

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
            comboBox1.Text = "굴림";
            comboBox2.Text = "보통";
            comboBox3.Text = "white";
            comboBox4.Text = "10";
            textBox1.Text = "3";

        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                string save_text = "ver=\"1\"\nFont=\"" + comboBox1.Text + "\"\nStyle=\"" + comboBox2.Text + "\"\nColor=\"" + comboBox3.Text + "\"\nSize=\"" + comboBox4.Text + "\"\nRefresh=\"" + textBox1.Text + "000\"";
                System.IO.File.WriteAllText(path + @"\fonts.dat", save_text, Encoding.UTF8);
                MessageBox.Show("저장되었습니다.", "Save");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("저장중 오류가 발생했습니다.", "오류");
                this.Close();
            }
        }

        private void txtInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
