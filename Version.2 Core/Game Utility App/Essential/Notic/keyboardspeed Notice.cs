using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameUtilityApp.Essential.Language;

namespace GameUtilityApp.Essential
{
    public partial class keyboardspeed_Notice : Form
    {
        public keyboardspeed_Notice()
        {
            InitializeComponent();
            label1.Text = StringLib.keyboardspeed_notic;
            button1.Text = StringLib.ok;
            checkBox1.Text = StringLib.notSeeAgain;

            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            checkBox1.Left = (this.ClientSize.Width - checkBox1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }
    }
}
