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

namespace GameUtilityApp.Function.후원
{
    public partial class Sponsor : Form
    {
        public Sponsor()
        {
            InitializeComponent();
        }

        private void Sponsor_Load(object sender, EventArgs e)
        {
            button2.Text = "트위치 방송 후원";
            button4.Text = "닫기";
            button2.Left = (this.ClientSize.Width - button2.Width) / 2;
            button4.Left = (this.ClientSize.Width - button4.Width) / 2;
        }

        private void twitch_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitch.tv/jh2358");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
