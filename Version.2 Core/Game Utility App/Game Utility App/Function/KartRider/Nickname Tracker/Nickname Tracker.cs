using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    public partial class Nickname_Tracker : Form
    {
        public Nickname_Tracker()
        {
            InitializeComponent();
        }

        private void Nickname_Tracker_Load(object sender, EventArgs e)
        {
            DB_Load();
            MyNameCheck();
        }

        private void DB_Load()
        {
            NickName_Tracker_DB_set ntds = new NickName_Tracker_DB_set();
            if (!ntds.DB_Check()) //만약에 false 라면~
            {
                MessageBox.Show("DB를 설정하는 도중 오류가 발생하였습니다.");
                this.Close(); //닫아버리기
            }

        }

        private void MyNameCheck()
        {
            Add_my_nickname amn = new Add_my_nickname();
            amn.DataSendEvent += new DataGetEventHandler(this.DataGet);

        }

        private void DataGet(string type,string value)
        {

        }
    }
}
