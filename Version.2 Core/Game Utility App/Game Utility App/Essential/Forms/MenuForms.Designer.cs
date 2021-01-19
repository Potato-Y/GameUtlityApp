
namespace GameUtilityApp.Essential.Forms
{
    partial class MenuForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForms));
            this.kartriderGroup = new System.Windows.Forms.GroupBox();
            this.registryGroup = new System.Windows.Forms.GroupBox();
            this.buttonRegistryPreset = new System.Windows.Forms.Button();
            this.registryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // kartriderGroup
            // 
            this.kartriderGroup.Location = new System.Drawing.Point(12, 73);
            this.kartriderGroup.Name = "kartriderGroup";
            this.kartriderGroup.Size = new System.Drawing.Size(200, 100);
            this.kartriderGroup.TabIndex = 0;
            this.kartriderGroup.TabStop = false;
            this.kartriderGroup.Text = "KartRider";
            // 
            // registryGroup
            // 
            this.registryGroup.Controls.Add(this.buttonRegistryPreset);
            this.registryGroup.Location = new System.Drawing.Point(12, 13);
            this.registryGroup.Name = "registryGroup";
            this.registryGroup.Size = new System.Drawing.Size(200, 54);
            this.registryGroup.TabIndex = 1;
            this.registryGroup.TabStop = false;
            this.registryGroup.Text = "Registry";
            // 
            // buttonRegistryPreset
            // 
            this.buttonRegistryPreset.Location = new System.Drawing.Point(7, 21);
            this.buttonRegistryPreset.Name = "buttonRegistryPreset";
            this.buttonRegistryPreset.Size = new System.Drawing.Size(187, 23);
            this.buttonRegistryPreset.TabIndex = 0;
            this.buttonRegistryPreset.Text = "Registry Preset";
            this.buttonRegistryPreset.UseVisualStyleBackColor = true;
            this.buttonRegistryPreset.Click += new System.EventHandler(this.buttonRegistryPreset_Click);
            // 
            // MenuForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 283);
            this.Controls.Add(this.registryGroup);
            this.Controls.Add(this.kartriderGroup);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForms";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.registryGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox kartriderGroup;
        private System.Windows.Forms.GroupBox registryGroup;
        private System.Windows.Forms.Button buttonRegistryPreset;
    }
}