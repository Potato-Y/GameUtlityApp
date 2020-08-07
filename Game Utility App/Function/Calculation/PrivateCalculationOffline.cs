using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp
{
    public partial class PrivateCalculationOffline : Form
    {
        int score;
        int match;
        int space;
        Stack<int> backscore = new Stack<int>();
        public PrivateCalculationOffline()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.g1st_click);
            this.button2.Click += new System.EventHandler(this.g2st_click);
            this.button3.Click += new System.EventHandler(this.g3st_click);
            this.button4.Click += new System.EventHandler(this.g4st_click);
            this.button5.Click += new System.EventHandler(this.g5st_click);
            this.button6.Click += new System.EventHandler(this.g6st_click);
            this.button7.Click += new System.EventHandler(this.g7st_click);
            this.button8.Click += new System.EventHandler(this.g8st_click);
            this.button9.Click += new System.EventHandler(this.g9st_click);
            this.button10.Click += new System.EventHandler(this.back_click);
        }

        private void PrivateCalculationOffline_Load(object sender,EventArgs e)
        {
            score = 0;
            match = 0;
            label2.Text = Convert.ToString(score);
            button1.Text = "1등";
            button2.Text = "2등";
            button3.Text = "3등";
            button4.Text = "4등";
            button5.Text = "5등";
            button6.Text = "6등";
            button7.Text = "7등";
            button8.Text = "8등";
            button9.Text = "리타";
            button10.Text = "←";

            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button2.Left = (this.ClientSize.Width - button1.Width) / 2;
            button3.Left = (this.ClientSize.Width - button1.Width) / 2;
            button4.Left = (this.ClientSize.Width - button1.Width) / 2;
            button5.Left = (this.ClientSize.Width - button1.Width) / 2;
            button6.Left = (this.ClientSize.Width - button1.Width) / 2;
            button7.Left = (this.ClientSize.Width - button1.Width) / 2;
            button8.Left = (this.ClientSize.Width - button1.Width) / 2;
            button9.Left = (this.ClientSize.Width - button1.Width) / 2;
            button10.Left = (this.ClientSize.Width - button1.Width) / 2;

            textBox1.ReadOnly = true;
            textBox1.BackColor = Color.White;

            loadtooltip();
        }

        private void loadtooltip()
        {
            toolTip1.SetToolTip(button1, "1등 점수 10점을 추가합니다.");
            toolTip1.SetToolTip(button2, "2등 점수 7점을 추가합니다.");
            toolTip1.SetToolTip(button3, "3등 점수 5점을 추가합니다.");
            toolTip1.SetToolTip(button4, "4등 점수 4점을 추가합니다.");
            toolTip1.SetToolTip(button5, "5등 점수 3점을 추가합니다.");
            toolTip1.SetToolTip(button6, "6등 점수 1점을 추가합니다.");
            toolTip1.SetToolTip(button7, "7등 점수 0점을 추가합니다.");
            toolTip1.SetToolTip(button8, "8등 점수 -1점을 추가합니다.");
            toolTip1.SetToolTip(button9, "리타 점수 -5점을 추가합니다.");
            toolTip1.SetToolTip(button10, "추가한 점수를 취소합니다.");

        }
        bool JustClick = true; //등수를 입력할 경우 true , 뒤로가기를 할 경우 false

        //등수별 점수 클릭
        private void g1st_click(object sender,EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 10;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 1등, 총점 : " + score;
            }else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 1등, 총점 : " + score;
            }
            
            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(1);
            space = 1;
        }

        private void g2st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 7;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 2등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 2등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(2);
            space = 1;
        }

        private void g3st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 5;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 3등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 3등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(3);
            space = 1;
        }

        private void g4st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 4;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 4등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 4등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(4);
            space = 1;
        }
        private void g5st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 3;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 5등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 5등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(5);
            space = 1;
        }

        private void g6st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score + 1;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 6등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 6등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(6);
            space = 1;
        }

        private void g7st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 7등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 7등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(7);
            space = 1;
        }

        private void g8st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score - 1;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 8등, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 8등, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(8);
            space = 1;
        }

        private void g9st_click(object sender, EventArgs e)
        {
            if (JustClick == false)
            {
                textBox1.Text += "\r\n";
            }
            JustClick = true;
            score = score - 5;
            match++;
            if (match == 1)
            {
                textBox1.Text += match + "째 판 리타이어, 총점 : " + score;
            }
            else if (match != 1)
            {
                textBox1.Text += "\r\n" + match + "째 판 리타이어, 총점 : " + score;
            }

            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            backscore.Push(9);
            space = 1;
        }

        //등수별 점수 클릭 끝

        //취소
        private void back_click(object sender,EventArgs e)
        {
            int back_st=10;
            if (backscore.Count==0)
            {
                back_st = 10;
                //match++;
            }else if (backscore.Count != 0)
            {
                back_st = backscore.Pop();
            }
            if (space == 1)
            {
                textBox1.Text += "\r\n";
                space = 2;
            }
            
            switch (back_st)
            {
                case 1:
                    score = score - 10;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 2:
                    score = score - 7;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 3:
                    score = score - 5;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 4:
                    score = score - 4;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score;
                    match--;
                    break;
                case 5:
                    score = score - 3;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 6:
                    score = score - 1;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 7:
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 8:
                    score = score + 1;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                case 9:
                    score = score + 5;
                    textBox1.Text += "\r\n" + match + "째 판 취소, 총점 : " + score ;
                    match--;
                    break;
                default:
                    textBox1.Text += "\r\n\r\n저장된 점수가 없습니다." + "\r\n\r\n"; ;
                    break;
            }
            label2.Text = Convert.ToString(score);
            this.textBox1.SelectionStart = textBox1.Text.Length;
            this.textBox1.ScrollToCaret();
            JustClick = false;
        }

    }
}
