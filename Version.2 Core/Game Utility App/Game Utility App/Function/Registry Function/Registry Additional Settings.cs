using GameUtilityApp.Essential.DB_Control;
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

namespace GameUtilityApp.Function.Registry_Function
{
    public partial class Registry_Additional_Settings : Form
    {
        public Registry_Additional_Settings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Main_DB_Setting msd = new Main_DB_Setting();
            string strConn = msd.GetstrConn();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(strConn))
                {
                    conn.Open(); //DB 연결

                    string sqlCommand="";
                    if (checkBox1.Checked)
                    {
                        sqlCommand = "UPDATE `Main Setting` SET `Apply registry at startup`=\"true\";";
                    }
                    else if(!checkBox1.Checked)
                    {
                        sqlCommand = "UPDATE `Main Setting` SET `Apply registry at startup`=\"false\";";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("설정값을 저장하는 중 문제가 발생하였습니다.\n" + ex);
                Application.Exit();
            }
        }

        private void Registry_Additional_Settings_Load(object sender, EventArgs e)
        {
            LoadStartingSave();
        }

        private void LoadStartingSave() //체크 여부 확인
        {
            bool value = false;
            Main_DB_Setting mds = new Main_DB_Setting();
            string strConn = mds.GetstrConn();
            using (SQLiteConnection conn = new SQLiteConnection(strConn)) 
            {
                conn.Open(); //DB 연결

                string sqlCommand = "SELECT * FROM `Main Setting`";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        if (rdr["Apply registry at startup"].ToString().Equals("true")) value = true;
                    }
                }
                conn.Close();
            }

            if (value == true) checkBox1.Checked = true;
        }
    }
}
