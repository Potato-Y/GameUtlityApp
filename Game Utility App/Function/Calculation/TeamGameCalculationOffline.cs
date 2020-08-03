using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp
{
    public partial class TeamGameCalculationOffline : Form
    {
        int myscore;
        int yourscore;
        int match;
        string savepath;
        string savedata;
        public TeamGameCalculationOffline()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(win_Click);
            this.button2.Click += new System.EventHandler(lose_Click);
            this.button5.Click += new System.EventHandler(path_Click);
            this.button3.Click += new System.EventHandler(save_Click);
            this.button4.Click += new System.EventHandler(reset_Click);
        }

        private void TeamGameCalculationOffline_Load(object sneder,EventArgs e)
        {
            this.ActiveControl = comboBox1;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            label3.Text = " 0"; label5.Text = "0";
            button3.Text = "저장"; button4.Text = "초기화";
            button1.Text = "승리"; button2.Text = "패배";
            textBox1.ReadOnly = true;
            textBox1.BackColor = Color.White;
            textBox2.ReadOnly = true;
            textBox2.BackColor = Color.White;
            match = 0;
            label8.Text = "0";
            savedata = "";
            try
            {
                string[] speedmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_speedmaplist.dat");
                comboBox1.Items.AddRange(speedmaplist);
                savepath = System.IO.File.ReadAllText(@".\otherFile\map_savesetting.dat");
            }catch(Exception)
            {
                MessageBox.Show("맵 파일을 찾을 수 없습니다.","실행 오류");
                this.Close();
            }
        }

        private void allmap_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                comboBox1.Items.Clear();

                try
                {
                    string[] speedmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_speedmaplist.dat");
                    string[] itemmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_itemmaplist.dat");
                    comboBox1.Items.Add("=== 스피드 맵 ===");
                    comboBox1.Items.AddRange(speedmaplist);
                    comboBox1.Items.Add("=== 아이템 맵 ===");
                    comboBox1.Items.AddRange(itemmaplist);
                }
                catch (Exception)
                {
                    MessageBox.Show("맵 파일을 찾을 수 없습니다.", "실행 오류");
                    this.Close();
                }


            }
            else
            {
                comboBox1.Items.Clear();
            }
        }

        private void speedmap_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox1.Text = "";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                comboBox1.Items.Clear();
                try
                {
                    string[] speedmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_speedmaplist.dat");
                    comboBox1.Items.AddRange(speedmaplist);
                }
                catch (Exception)
                {
                    MessageBox.Show("맵 파일을 찾을 수 없습니다.", "실행 오류");
                    this.Close();
                }
            }
            else
            {
                comboBox1.Items.Clear();
            }
        }
        private void itemmap_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                comboBox1.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                comboBox1.Items.Clear();
                try
                {
                    string[] itemmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_itemmaplist.dat");
                    comboBox1.Items.AddRange(itemmaplist);
                }
                catch (Exception)
                {
                    MessageBox.Show("맵 파일을 찾을 수 없습니다.", "실행 오류");
                    this.Close();
                }
            }
            else
            {
                comboBox1.Items.Clear();
            }
        }

        private void win_Click(object sender, EventArgs e)
        {
            if (myscore < 100 && yourscore<100)
            {
                if (myscore != 0)
                {
                    textBox1.Text += "\r\n";
                    
                }
                if (match != 0)
                {
                    savedata += "\r\n";
                }
                match++;
                textBox1.Text += match + "번째 판, " + comboBox1.Text + " 승리";
                myscore++;
                if (myscore >= 10)
                {
                    label3.Location = new System.Drawing.Point(298, 43);
                }
                label3.Text = Convert.ToString(myscore);
                label3.Text = Convert.ToString(myscore);
                label8.Text = Convert.ToString(match);
                savedata+= match + "번째 판, " + comboBox1.Text + " 승리";
            }
            else
            {
                MessageBox.Show("허용 점수를 초과하였습니다.","경고");
            }
            
        }

        private void lose_Click(object sender, EventArgs e)
        {
            if (myscore < 100 && yourscore < 100)
            {
                if (yourscore != 0)
                {
                    textBox2.Text += "\r\n";
                }
                if (match != 0)
                {
                    savedata += "\r\n";
                }
                match++;
                textBox2.Text += match + "번째 판, " + comboBox1.Text + " '승리'";
                yourscore++;
                label5.Text = Convert.ToString(yourscore);
                label8.Text = Convert.ToString(match);
                savedata += match + "번째 판, " + comboBox1.Text + " '패배'";
            }
            else
            {
                MessageBox.Show("허용 점수를 초과하였습니다.", "경고");
            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            match = 0;
            myscore = 0;
            yourscore = 0;
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            this.ActiveControl = comboBox1;
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
            string[] speedmaplist = System.IO.File.ReadAllLines(@".\otherFile\map_speedmaplist.dat");
            comboBox1.Items.AddRange(speedmaplist);
            textBox1.Text = "";
            textBox2.Text = "";
            label8.Text = "0";
            savedata = "";

        }

        private void path_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    savepath = dialog.FileName;
                    System.IO.File.WriteAllText(@".\otherFile\map_savesetting.dat", savepath, Encoding.Default);
                    MessageBox.Show("저장 버튼을 누르면 ' " + savepath + " ' 에 저장됩니다.", "Save");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Microsoft.WindowsAPICodePack.dll, Microsoft.WindowsAPICodePack.Shell.dll 를 찾을 수 없습니다.", "Error");
                this.Close();
            }

        }
        private void save_Click(object sender, EventArgs e)
        {
            if (savepath != "null")
            {
                System.IO.File.WriteAllText(savepath+@"\"+DateTime.Now.ToString("yyyyMMddHHmmss")+" "+textBox3.Text+".txt", savedata, Encoding.Default);
                MessageBox.Show("선택한 폴더에 저장하였습니다.", "Save");
            }
            else if(savepath=="null")
            {
                MessageBox.Show("저장할 위치를 좌측 ... 버튼을 눌러 지정하세요.", "오류");
            }
            else
            {
                MessageBox.Show("Error", "Error");
            }
        }
    }
}
