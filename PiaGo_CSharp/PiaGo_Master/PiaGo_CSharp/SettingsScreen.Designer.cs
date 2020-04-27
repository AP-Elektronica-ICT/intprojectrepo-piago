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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsScreen));
            this.metroSMSettings = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tglMetroTheme = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnMetroCPBG = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnMetroPiaonoBG = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cbmetroColor = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroSMSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // metroSMSettings
            // 
            this.metroSMSettings.Owner = this;
            // 
            // tglMetroTheme
            // 
            resources.ApplyResources(this.tglMetroTheme, "tglMetroTheme");
            this.tglMetroTheme.Name = "tglMetroTheme";
            this.tglMetroTheme.UseSelectable = true;
            this.tglMetroTheme.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // btnMetroCPBG
            // 
            resources.ApplyResources(this.btnMetroCPBG, "btnMetroCPBG");
            this.btnMetroCPBG.Name = "btnMetroCPBG";
            this.btnMetroCPBG.UseSelectable = true;
            this.btnMetroCPBG.Click += new System.EventHandler(this.btnMetroCPBG_Click);
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // btnMetroPiaonoBG
            // 
            resources.ApplyResources(this.btnMetroPiaonoBG, "btnMetroPiaonoBG");
            this.btnMetroPiaonoBG.Name = "btnMetroPiaonoBG";
            this.btnMetroPiaonoBG.UseSelectable = true;
            this.btnMetroPiaonoBG.Click += new System.EventHandler(this.btnMetroPiaonoBG_Click);
            // 
            // metroLabel4
            // 
            resources.ApplyResources(this.metroLabel4, "metroLabel4");
            this.metroLabel4.Name = "metroLabel4";
            // 
            // cbmetroColor
            // 
            this.cbmetroColor.FormattingEnabled = true;
            resources.ApplyResources(this.cbmetroColor, "cbmetroColor");
            this.cbmetroColor.Items.AddRange(new object[] {
            resources.GetString("cbmetroColor.Items"),
            resources.GetString("cbmetroColor.Items1"),
            resources.GetString("cbmetroColor.Items2"),
            resources.GetString("cbmetroColor.Items3")});
            this.cbmetroColor.Name = "cbmetroColor";
            this.cbmetroColor.UseSelectable = true;
            this.cbmetroColor.SelectedIndexChanged += new System.EventHandler(this.cbmetroColor_SelectedIndexChanged_1);
            // 
            // SettingsScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbmetroColor);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.btnMetroPiaonoBG);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnMetroCPBG);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tglMetroTheme);
            this.Name = "SettingsScreen";
            this.Resizable = false;
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
        private MetroFramework.Controls.MetroComboBox cbmetroColor;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}