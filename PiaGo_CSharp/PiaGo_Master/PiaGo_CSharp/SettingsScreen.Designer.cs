namespace PiaGo_CSharp
{
    partial class SettingsScreen
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
            this.metroSMSettings = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tglMetroTheme = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnMetroCPBG = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnMetroPiaonoBG = new MetroFramework.Controls.MetroButton();
            this.cbmetroColor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroSMSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // metroSMSettings
            // 
            this.metroSMSettings.Owner = this;
            // 
            // tglMetroTheme
            // 
            this.tglMetroTheme.AutoSize = true;
            this.tglMetroTheme.Location = new System.Drawing.Point(227, 130);
            this.tglMetroTheme.Name = "tglMetroTheme";
            this.tglMetroTheme.Size = new System.Drawing.Size(80, 17);
            this.tglMetroTheme.TabIndex = 7;
            this.tglMetroTheme.Text = "Off";
            this.tglMetroTheme.UseSelectable = true;
            this.tglMetroTheme.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 128);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(80, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Dark theme:";
            // 
            // btnMetroCPBG
            // 
            this.btnMetroCPBG.Location = new System.Drawing.Point(232, 68);
            this.btnMetroCPBG.Name = "btnMetroCPBG";
            this.btnMetroCPBG.Size = new System.Drawing.Size(75, 23);
            this.btnMetroCPBG.TabIndex = 9;
            this.btnMetroCPBG.Text = "Open File";
            this.btnMetroCPBG.UseSelectable = true;
            this.btnMetroCPBG.Click += new System.EventHandler(this.btnMetroCPBG_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(15, 68);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(212, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Change control panel background:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(15, 94);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(168, 19);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Change piano background:";
            // 
            // btnMetroPiaonoBG
            // 
            this.btnMetroPiaonoBG.Location = new System.Drawing.Point(232, 94);
            this.btnMetroPiaonoBG.Name = "btnMetroPiaonoBG";
            this.btnMetroPiaonoBG.Size = new System.Drawing.Size(75, 23);
            this.btnMetroPiaonoBG.TabIndex = 12;
            this.btnMetroPiaonoBG.Text = "Open File";
            this.btnMetroPiaonoBG.UseSelectable = true;
            this.btnMetroPiaonoBG.Click += new System.EventHandler(this.btnMetroPiaonoBG_Click);
            // 
            // cbmetroColor
            // 
            this.cbmetroColor.FormattingEnabled = true;
            this.cbmetroColor.ItemHeight = 23;
            this.cbmetroColor.Items.AddRange(new object[] {
            "RED",
            "GREEN",
            "BLUE",
            "YELLOW"});
            this.cbmetroColor.Location = new System.Drawing.Point(186, 163);
            this.cbmetroColor.Name = "cbmetroColor";
            this.cbmetroColor.Size = new System.Drawing.Size(121, 29);
            this.cbmetroColor.TabIndex = 13;
            this.cbmetroColor.UseSelectable = true;
            this.cbmetroColor.SelectedIndexChanged += new System.EventHandler(this.cbmetroColor_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(15, 163);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Theme Color:";
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 230);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.cbmetroColor);
            this.Controls.Add(this.btnMetroPiaonoBG);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnMetroCPBG);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tglMetroTheme);
            this.Name = "SettingsScreen";
            this.Text = "SettingsScreen";
            this.Load += new System.EventHandler(this.SettingsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroSMSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroSMSettings;
        private MetroFramework.Controls.MetroToggle tglMetroTheme;
        private MetroFramework.Controls.MetroButton btnMetroCPBG;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnMetroPiaonoBG;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cbmetroColor;
    }
}