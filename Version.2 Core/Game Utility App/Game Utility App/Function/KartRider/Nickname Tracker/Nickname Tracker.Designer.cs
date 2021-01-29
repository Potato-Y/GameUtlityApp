
namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    partial class Nickname_Tracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nickname_Tracker));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonGroupAdd = new System.Windows.Forms.Button();
            this.buttonFriendAdd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.textBoxFirstNickname = new System.Windows.Forms.TextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(237, 274);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // buttonGroupAdd
            // 
            this.buttonGroupAdd.BackColor = System.Drawing.Color.White;
            this.buttonGroupAdd.Location = new System.Drawing.Point(93, 309);
            this.buttonGroupAdd.Name = "buttonGroupAdd";
            this.buttonGroupAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonGroupAdd.TabIndex = 1;
            this.buttonGroupAdd.Text = "Group ➕";
            this.buttonGroupAdd.UseVisualStyleBackColor = false;
            // 
            // buttonFriendAdd
            // 
            this.buttonFriendAdd.BackColor = System.Drawing.Color.White;
            this.buttonFriendAdd.Location = new System.Drawing.Point(174, 309);
            this.buttonFriendAdd.Name = "buttonFriendAdd";
            this.buttonFriendAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonFriendAdd.TabIndex = 2;
            this.buttonFriendAdd.Text = "Friend ➕";
            this.buttonFriendAdd.UseVisualStyleBackColor = false;
            this.buttonFriendAdd.Click += new System.EventHandler(this.buttonFriendAdd_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(12, 309);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Enabled = false;
            this.textBoxMemo.Location = new System.Drawing.Point(255, 83);
            this.textBoxMemo.Multiline = true;
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(218, 220);
            this.textBoxMemo.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "+";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem1.Text = "Backup";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.White;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(398, 309);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(483, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.BackColor = System.Drawing.Color.White;
            this.textBoxNickname.Location = new System.Drawing.Point(255, 29);
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.ReadOnly = true;
            this.textBoxNickname.Size = new System.Drawing.Size(218, 21);
            this.textBoxNickname.TabIndex = 8;
            // 
            // textBoxFirstNickname
            // 
            this.textBoxFirstNickname.BackColor = System.Drawing.Color.White;
            this.textBoxFirstNickname.Location = new System.Drawing.Point(255, 56);
            this.textBoxFirstNickname.Name = "textBoxFirstNickname";
            this.textBoxFirstNickname.ReadOnly = true;
            this.textBoxFirstNickname.Size = new System.Drawing.Size(218, 21);
            this.textBoxFirstNickname.TabIndex = 9;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // Nickname_Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 361);
            this.Controls.Add(this.textBoxFirstNickname);
            this.Controls.Add(this.textBoxNickname);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonFriendAdd);
            this.Controls.Add(this.buttonGroupAdd);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Nickname_Tracker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nickname_Tracker";
            this.Load += new System.EventHandler(this.Nickname_Tracker_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonGroupAdd;
        private System.Windows.Forms.Button buttonFriendAdd;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.TextBox textBoxFirstNickname;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}