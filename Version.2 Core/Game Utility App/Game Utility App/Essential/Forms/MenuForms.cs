using GameUtilityApp.Function;
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

namespace GameUtilityApp.Essential.Forms
{
    public partial class MenuForms : Form
    {
        public MenuForms()
        {
            InitializeComponent();
        }

        private void buttonRegistryPreset_Click(object sender, EventArgs e)
        {
            Registry_Preset nf = new Registry_Preset();
            nf.ShowDialog();
            this.Close();
        }
    }
}
