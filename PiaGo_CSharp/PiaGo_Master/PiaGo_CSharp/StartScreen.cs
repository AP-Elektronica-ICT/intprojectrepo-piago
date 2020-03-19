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
    public partial class StartScreen : MetroFramework.Forms.MetroForm
    {
        //--TO DO--
        //  FIREBASE Login implementatie NIET BELANGRIJK
        //---------
        //alles midi zodat 


        public StartScreen()
        {
            InitializeComponent();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroSMUser;
            foreach (frmMain oForm1 in Application.OpenForms.OfType<frmMain>())
            {
                if (oForm1.GetTheme() == ThemeType.DARK)
                {
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Dark;
                }
                else
                {
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Light;
                }
            }
        }

        public void UpdateTheme(ThemeType input)
        {
            switch (input)
            {
                case ThemeType.LIGHT:
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case ThemeType.DARK:
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                default:
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
