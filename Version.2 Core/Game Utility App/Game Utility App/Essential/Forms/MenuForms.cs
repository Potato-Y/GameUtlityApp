using GameUtilityApp.Essential.Language;
using GameUtilityApp.Function;
using GameUtilityApp.Function.Registry_Function;
using GameUtilityApp.Function.KartRider.Nickname_Tracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Function.Calculator.Team_Match_Score_Calculator;

namespace GameUtilityApp.Essential.Forms
{
    public partial class MenuForms : Form
    {
        public MenuForms()
        {
            InitializeComponent();
            this.ActiveControl = registryGroup;
            buttonNickNameTracker.Text = StringLib.Title_2;
            buttonTeamScoreCalculator.Text = StringLib.Title_1;
            buttonRegistryPreset.Text = StringLib.Title_3;
            buttonSetRecommended.Text = StringLib.Title_4;
            buttonAdditionalsettings.Text = StringLib.Title_5;
        }

        private void buttonRegistryPreset_Click(object sender, EventArgs e)
        {
            Registry_Preset nf = new Registry_Preset();
            nf.ShowDialog();
            this.Close();
        }

        private void buttonSetRecommended_Click(object sender, EventArgs e)
        {
            KeyBoardRegistry kbr = new KeyBoardRegistry();
            kbr.Keyboard_Registry_All_Apply(2, 0, 48, 300, 300, 0, 0, 26, 0, 0, 0, 1000, 62);
            MessageBox.Show(StringLib.Message_2, StringLib.Message);
            this.Close();
        }

        private void buttonAdditionalsettings_Click(object sender, EventArgs e)
        {
            Registry_Additional_Settings ras = new Registry_Additional_Settings();
            ras.ShowDialog();
            this.Close();
        }

        private void buttonNickNameTracker_Click(object sender, EventArgs e)
        {
            //이미 열려있는지 확인
            Form fc = Application.OpenForms["Nickname_Tracker"];
            if (fc != null)
            {
                fc.Activate();
            }
            else
            {
                Nickname_Tracker nt = new Nickname_Tracker();
                nt.Show();
            }
            //this.Close();
        }

        private void buttonTeamScoreCalculator_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["Team_Match_Score_Calculator"];
            if (fc != null)
            {
                fc.Activate();
            }
            else
            {
                Team_Match_Score_Calculator tmsc = new Team_Match_Score_Calculator();
                tmsc.Show();
            }
        }
    }
}
