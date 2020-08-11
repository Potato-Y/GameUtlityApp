using GameUtilityApp.Function.Calculation;
using GameUtilityApp.Function.Calculation.broadcast;
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
    public partial class UtilityChoice : Form
    {
        public UtilityChoice()
        {
            InitializeComponent();
            this.button4.Click += new System.EventHandler(this.eixt_Click);
            this.button1.Click += new System.EventHandler(this.PrivateCalculationOffline_Click);
            this.button2.Click += new System.EventHandler(this.TeamGameCaculationOffline_Click);
            this.button3.Click += new System.EventHandler(this.AdditionSeeting_Click);
        }

        public void UtilityChoice_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "점수 기록";
            button1.Text = "개인전 점수 기록";
            button2.Text = "팀전 점수 기록";
            groupBox2.Text = "기타";
            button3.Text = "(Beta) PC 부가 설정";
            button4.Text = "닫기";
            button5.Text = "스크린샷 폴더 열기";
            button6.Text = "라이더데이터 폴더 열기";
            button7.Text = "방송용 계산기";
        }

        public void PrivateCalculationOffline_Click(object sender, EventArgs e)
        {
            this.Close();
            PrivateCalculationOffline newForm = new PrivateCalculationOffline();
            newForm.Show();
        }

        public void TeamGameCaculationOffline_Click(object sender, EventArgs e)
        {
            TeamGameCalculationOffline newForm = new TeamGameCalculationOffline();
            newForm.Show();
            this.Close();
        }

        public void AdditionSeeting_Click(object sender, EventArgs e)
        {
            this.Close();
            AdditionSetting newForm = new AdditionSetting();
            newForm.ShowDialog();
        }


        private void ScreenCapture_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\"+((System.Security.Principal.WindowsIdentity.GetCurrent().Name).Split('\\')[1])+ @"\Documents\카트라이더\스크린샷";
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

        public void eixt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BroadcastCalculation_Click(object sender, EventArgs e)
        {
            this.Close();
            BroadcastCalculation newForm = new BroadcastCalculation();
            newForm.Show();
        }
    }
}
