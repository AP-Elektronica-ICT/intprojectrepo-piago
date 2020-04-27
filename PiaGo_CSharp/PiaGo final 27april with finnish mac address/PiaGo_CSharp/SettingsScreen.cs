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
                this.UpdateColor(oForm1.GetColor());
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

        public void UpdateColor(MetroFramework.MetroColorStyle input)
        {
            metroSMSettings.Style = input;
            switch (input)
            {
                case MetroFramework.MetroColorStyle.Red:
                    cbmetroColor.SelectedIndex = 0;
                    break;
                case MetroFramework.MetroColorStyle.Green:
                    cbmetroColor.SelectedIndex = 1;
                    break;
                case MetroFramework.MetroColorStyle.Blue:
                    cbmetroColor.SelectedIndex = 2;
                    break;
                case MetroFramework.MetroColorStyle.Yellow:
                    cbmetroColor.SelectedIndex = 3;
                    break;
                default:
                    cbmetroColor.SelectedIndex = 2;
                    break;
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
            {
                if (tglMetroTheme.Checked == true)
                    oForm1.SetTheme(ThemeType.DARK);
                else
                    oForm1.SetTheme(ThemeType.LIGHT);

                oForm1.UpdateTheme();
                this.UpdateTheme(oForm1.GetTheme());
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

        private void cbmetroColor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
            {
                switch (cbmetroColor.SelectedIndex)
                {
                    case 0: //red
                        oForm1.SetColor(MetroFramework.MetroColorStyle.Red);
                        break;
                    case 1: //green
                        oForm1.SetColor(MetroFramework.MetroColorStyle.Green);
                        break;
                    case 2: //blue
                        oForm1.SetColor(MetroFramework.MetroColorStyle.Blue);
                        break;
                    case 3: //yellow
                        oForm1.SetColor(MetroFramework.MetroColorStyle.Yellow);
                        break;
                    default:
                        oForm1.SetColor(MetroFramework.MetroColorStyle.White);
                        break;
                }
                oForm1.UpdateColor();
                this.UpdateColor(oForm1.GetColor());
            }
        }
    }
}
