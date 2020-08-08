namespace netframework_guide
{
    partial class main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(285, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "기타";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.WinUpdate_other);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Windows 7 64 bit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.WinUpdate_x64);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Windows 7 32 bit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.WinUpdate_x86);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(150)));
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "혹시 Windows7 이며 .NET Framework 4.7.2 업데이트(설치)에 문제가 있습니까?\r\n아래 패치를 한 뒤에 .NET Framewo" +
    "rk 4.7.2 설치를 시도하세요.\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = ".NET Framework 4.8 설치";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Setup_new_ver);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "설치된 버전 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(150)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = ".NET Framework 의 버전이 낮습니다.\r\n.NET Framework의 버전을 업데이트 하지 않으면 프로그램을 정상적으로 실행할 수 없습니" +
    "다.\r\n";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "새로고침";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.netvercheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "PC에 설치된 bit : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "label6";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 261);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "main";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = ".NET Framework 설치 가이드";
            this.Load += new System.EventHandler(this.netvercheck);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

