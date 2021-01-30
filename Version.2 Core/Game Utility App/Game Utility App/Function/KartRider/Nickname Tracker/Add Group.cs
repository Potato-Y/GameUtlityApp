using GameUtilityApp.Essential.Language;
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

namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    public partial class Add_Group : Form
    {
        public Add_Group()
        {
            InitializeComponent();
        }

        private void Add_Group_Load(object sender, EventArgs e)
        {
            buttonSave.Left = (this.ClientSize.Width - buttonSave.Width) / 2;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show(StringLib.Message_6, StringLib.Message);
                return;
            }
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new NickName_Tracker_DB_set().GetstrConn())) //중복 저장 확인
                {
                    conn.Open(); //DB 연결

                    string sqlCommand = "";

                    sqlCommand += "SELECT COUNT(*) FROM `Friend nickname group` WHERE `group name`=\"" + textBox1.Text + "\"";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            rdr.Read();
                            int count = Convert.ToInt32(rdr["COUNT(*)"].ToString());

                            if (count > 0)
                            {
                                MessageBox.Show(StringLib.Message_5, StringLib.Message);
                                return;
                            }
                        }
                    }


                    sqlCommand = "INSERT INTO `Friend nickname group` (`group name`) VALUES (\"" + textBox1.Text + "\");";

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }


                    conn.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show(StringLib.ERROR, StringLib.ERROR);
            }
            this.Close();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                Save();
            }
        }
    }
}
