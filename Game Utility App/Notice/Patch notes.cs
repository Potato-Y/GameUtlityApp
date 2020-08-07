using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUtilityApp.Notice
{
    public partial class Patch_notes : Form
    {
        public Patch_notes()
        {
            InitializeComponent();
        }

        private void Patch_note_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
