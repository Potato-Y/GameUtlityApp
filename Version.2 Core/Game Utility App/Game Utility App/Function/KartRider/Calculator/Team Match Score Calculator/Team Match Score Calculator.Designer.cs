
namespace GameUtilityApp.Function.Calculator.Team_Match_Score_Calculator
{
    partial class Team_Match_Score_Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Team_Match_Score_Calculator));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNickname = new System.Windows.Forms.TextBox();
            this.buttonTrackingStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelMyScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRelativeScore = new System.Windows.Forms.Label();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMyScoreP = new System.Windows.Forms.Button();
            this.buttonRelativeScoreP = new System.Windows.Forms.Button();
            this.buttonMyScoreM = new System.Windows.Forms.Button();
            this.buttonRelativeM = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "닉네임";
            // 
            // textBoxNickname
            // 
            this.textBoxNickname.Location = new System.Drawing.Point(59, 10);
            this.textBoxNickname.Name = "textBoxNickname";
            this.textBoxNickname.Size = new System.Drawing.Size(100, 21);
            this.textBoxNickname.TabIndex = 1;
            // 
            // buttonTrackingStart
            // 
            this.buttonTrackingStart.Location = new System.Drawing.Point(165, 9);
            this.buttonTrackingStart.Name = "buttonTrackingStart";
            this.buttonTrackingStart.Size = new System.Drawing.Size(75, 23);
            this.buttonTrackingStart.TabIndex = 2;
            this.buttonTrackingStart.Text = "점수 추적";
            this.buttonTrackingStart.UseVisualStyleBackColor = true;
            this.buttonTrackingStart.Click += new System.EventHandler(this.buttonTracking_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(246, 9);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "종료";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelMyScore
            // 
            this.labelMyScore.AutoSize = true;
            this.labelMyScore.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMyScore.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMyScore.Location = new System.Drawing.Point(74, 0);
            this.labelMyScore.Name = "labelMyScore";
            this.labelMyScore.Size = new System.Drawing.Size(53, 100);
            this.labelMyScore.TabIndex = 0;
            this.labelMyScore.Text = "0";
            this.labelMyScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(133, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 100);
            this.label3.TabIndex = 1;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRelativeScore
            // 
            this.labelRelativeScore.AutoSize = true;
            this.labelRelativeScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelRelativeScore.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelRelativeScore.Location = new System.Drawing.Point(185, 0);
            this.labelRelativeScore.Name = "labelRelativeScore";
            this.labelRelativeScore.Size = new System.Drawing.Size(53, 100);
            this.labelRelativeScore.TabIndex = 2;
            this.labelRelativeScore.Text = "0";
            this.labelRelativeScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxState
            // 
            this.textBoxState.BackColor = System.Drawing.Color.White;
            this.textBoxState.Location = new System.Drawing.Point(13, 178);
            this.textBoxState.Multiline = true;
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.ReadOnly = true;
            this.textBoxState.Size = new System.Drawing.Size(313, 85);
            this.textBoxState.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.tableLayoutPanel1.Controls.Add(this.labelMyScore, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelRelativeScore, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "지금 동기화";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonMyScoreP
            // 
            this.buttonMyScoreP.Location = new System.Drawing.Point(92, 270);
            this.buttonMyScoreP.Name = "buttonMyScoreP";
            this.buttonMyScoreP.Size = new System.Drawing.Size(80, 23);
            this.buttonMyScoreP.TabIndex = 7;
            this.buttonMyScoreP.Text = "내 점수 +1";
            this.buttonMyScoreP.UseVisualStyleBackColor = true;
            this.buttonMyScoreP.Click += new System.EventHandler(this.buttonMyScoreP_Click);
            // 
            // buttonRelativeScoreP
            // 
            this.buttonRelativeScoreP.Location = new System.Drawing.Point(178, 270);
            this.buttonRelativeScoreP.Name = "buttonRelativeScoreP";
            this.buttonRelativeScoreP.Size = new System.Drawing.Size(80, 23);
            this.buttonRelativeScoreP.TabIndex = 8;
            this.buttonRelativeScoreP.Text = "상대 점수 +1";
            this.buttonRelativeScoreP.UseVisualStyleBackColor = true;
            this.buttonRelativeScoreP.Click += new System.EventHandler(this.buttonRelativeScoreP_Click);
            // 
            // buttonMyScoreM
            // 
            this.buttonMyScoreM.Location = new System.Drawing.Point(92, 299);
            this.buttonMyScoreM.Name = "buttonMyScoreM";
            this.buttonMyScoreM.Size = new System.Drawing.Size(80, 23);
            this.buttonMyScoreM.TabIndex = 9;
            this.buttonMyScoreM.Text = "내 점수 -1";
            this.buttonMyScoreM.UseVisualStyleBackColor = true;
            this.buttonMyScoreM.Click += new System.EventHandler(this.buttonMyScoreM_Click);
            // 
            // buttonRelativeM
            // 
            this.buttonRelativeM.Location = new System.Drawing.Point(178, 299);
            this.buttonRelativeM.Name = "buttonRelativeM";
            this.buttonRelativeM.Size = new System.Drawing.Size(80, 23);
            this.buttonRelativeM.TabIndex = 10;
            this.buttonRelativeM.Text = "상대 점수 -1";
            this.buttonRelativeM.UseVisualStyleBackColor = true;
            this.buttonRelativeM.Click += new System.EventHandler(this.buttonRelativeM_Click);
            // 
            // Team_Match_Score_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 338);
            this.Controls.Add(this.buttonRelativeM);
            this.Controls.Add(this.buttonMyScoreM);
            this.Controls.Add(this.buttonRelativeScoreP);
            this.Controls.Add(this.buttonMyScoreP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonTrackingStart);
            this.Controls.Add(this.textBoxNickname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Team_Match_Score_Calculator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Team Match Score Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNickname;
        private System.Windows.Forms.Button buttonTrackingStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelMyScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRelativeScore;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonMyScoreP;
        private System.Windows.Forms.Button buttonRelativeScoreP;
        private System.Windows.Forms.Button buttonMyScoreM;
        private System.Windows.Forms.Button buttonRelativeM;
    }
}