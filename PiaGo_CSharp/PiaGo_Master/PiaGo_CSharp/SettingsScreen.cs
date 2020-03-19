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
                }
                else
                {
                    metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Light;
                }
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {

            
            if (metroToggle1.Checked == true)
            {
                metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
                foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
                {
                    oForm1.SetTheme(ThemeType.DARK);

                }
                foreach (StartScreen oForm1 in Application.OpenForms.OfType<StartScreen>())
                {
                    oForm1.ChangeTheme("dark");
                }
            }
            else
            {
                metroSMSettings.Theme = MetroFramework.MetroThemeStyle.Light;
                foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
                {
                    oForm1.ChangeTheme("light");
                }
                foreach (StartScreen oForm1 in Application.OpenForms.OfType<StartScreen>())
                {
                    oForm1.ChangeTheme("light");
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
