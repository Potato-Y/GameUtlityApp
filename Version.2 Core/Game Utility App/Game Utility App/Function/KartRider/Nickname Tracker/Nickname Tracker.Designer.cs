
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nickname_Tracker));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonGroupAdd = new System.Windows.Forms.Button();
            this.buttonFriendAdd = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(237, 274);
            this.treeView1.TabIndex = 0;
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
            // Nickname_Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(258, 344);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonFriendAdd);
            this.Controls.Add(this.buttonGroupAdd);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Nickname_Tracker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nickname_Tracker";
            this.Load += new System.EventHandler(this.Nickname_Tracker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonGroupAdd;
        private System.Windows.Forms.Button buttonFriendAdd;
        private System.Windows.Forms.Button buttonRefresh;
    }
}