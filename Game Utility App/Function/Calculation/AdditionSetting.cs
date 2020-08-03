using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Function.Calculation
{
    public partial class AdditionSetting : Form
    {
        string screenWidth;
        string screenHeigth;
        public AdditionSetting()
        {
            InitializeComponent();
            checkBox1.CheckStateChanged += screenSetting;
        }

        private void AdditionSetting_Load(object sender, EventArgs e)
        {
            checkBox1.Text = "1600 * 900 해상도로 변경";
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            LoadScreen();
            label3.Text = screenWidth + " * " + screenHeigth;
            if (screenWidth == "1600")
            {
                if (screenHeigth == "900")
                {
                    checkBox1.Checked = true;
                }
            }
            checkBox1.Enabled = false;

        }

        private void screenSetting(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                /*
                System.IO.File.WriteAllText(@".\setting\screenwidth.dat", screenWidth, Encoding.Default);
                System.IO.File.WriteAllText(@".\setting\screenheigth.dat", screenHeigth, Encoding.Default);
                */
                MessageBox.Show("아직 준비중 입니다.");

            }
            
        }
        
        private void LoadScreen()
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            screenHeigth = Screen.PrimaryScreen.Bounds.Height.ToString();
        }
    }
}
