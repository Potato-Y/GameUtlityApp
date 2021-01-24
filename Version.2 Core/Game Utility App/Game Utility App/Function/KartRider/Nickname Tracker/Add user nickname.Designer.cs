
namespace GameUtilityApp.Function.KartRider.Nickname_Tracker
{
    partial class Add_user_nickname
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_my_nickname));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonUserCheck = new System.Windows.Forms.Button();
            this.panelOkCancel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelOkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 21);
            this.textBox1.TabIndex = 0;
            // 
            // buttonUserCheck
            // 
            this.buttonUserCheck.Location = new System.Drawing.Point(176, 11);
            this.buttonUserCheck.Name = "buttonUserCheck";
            this.buttonUserCheck.Size = new System.Drawing.Size(93, 23);
            this.buttonUserCheck.TabIndex = 1;
            this.buttonUserCheck.Text = "User Check";
            this.buttonUserCheck.UseVisualStyleBackColor = true;
            // 
            // panelOkCancel
            // 
            this.panelOkCancel.Controls.Add(this.button2);
            this.panelOkCancel.Controls.Add(this.button1);
            this.panelOkCancel.Location = new System.Drawing.Point(59, 40);
            this.panelOkCancel.Name = "panelOkCancel";
            this.panelOkCancel.Size = new System.Drawing.Size(162, 30);
            this.panelOkCancel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Add_my_nickname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(281, 75);
            this.Controls.Add(this.panelOkCancel);
            this.Controls.Add(this.buttonUserCheck);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_my_nickname";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_my_nickname";
            this.panelOkCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonUserCheck;
        private System.Windows.Forms.Panel panelOkCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}