using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiaGo_CSharp
{
    public partial class SettingsScreen : MetroFramework.Forms.MetroForm
    {
        public SettingsScreen()
        {
            InitializeComponent();
        }

        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroSMSettings;
            foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
            {
                if (oForm1.GetTheme() == ThemeType.DARK)
                {
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
                    tglMetroTheme.Checked = true;
                }
                else
                {
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Light;
                }
            }
        }

        public void UpdateTheme(ThemeType input)
        {
            switch (input)
            {
                case ThemeType.LIGHT:
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case ThemeType.DARK:
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                default:
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
                foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
                {
                    if (tglMetroTheme.Checked == true)
                    {
                        oForm1.SetTheme(ThemeType.DARK);
                        oForm1.UpdateTheme();
                        this.UpdateTheme(oForm1.GetTheme());
                }
                    else
                    {
                        oForm1.SetTheme(ThemeType.LIGHT);
                        oForm1.UpdateTheme();
                        this.UpdateTheme(oForm1.GetTheme());
                    }
                }
        }

        private void btnMetroPiaonoBG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = openFileDialog1.FileName;
                foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
                {
                    oForm1.ChangePianoBGImage(strFileName);
                }

            }
        }

        private void btnMetroCPBG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = openFileDialog1.FileName;
                foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
                {
                    oForm1.ChangeControlPanelBGImage(strFileName);
                }

            }
        }
    }
}
