using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential.DB_Control;
using GameUtilityApp.Essential.Language;

namespace GameUtilityApp.Essential
{
    public partial class keyboardspeed_Notice : Form
    {
        public keyboardspeed_Notice()
        {
            InitializeComponent();
            label1.Text = StringLib.keyboardspeed_notic;
            okButton.Text = StringLib.ok;
            checkBox1.Text = StringLib.notSeeAgain;

            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            okButton.Left = (this.ClientSize.Width - okButton.Width) / 2;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Main_Setting_DB msd = new Main_Setting_DB();
                string strConn = msd.GetstrConn();

                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection(strConn))
                    {
                        conn.Open(); //DB 연결

                        string sqlCommand = "UPDATE `MainSetting` SET `Win10 RegMessage`=1;";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("설정값을 저장하는 중 문제가 발생하였습니다.\n"+ex);
                    Application.Exit();
                }
            }
            this.Close();
        }
    }
}
