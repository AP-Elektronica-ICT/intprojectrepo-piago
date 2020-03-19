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
            pbLogo.Width = 623 / 3;
            pbLogo.Height = 252 / 3;
            pbLogo.Left = (this.ClientSize.Width - pbLogo.Width) / 2;
            pbLogo.Top = 10;
            
            
        }       
        public void ChangeTheme(string input)
        {
            switch (input)
            {
                case "light":
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case "dark":
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                default:
                    metroSMUser.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }
        }
    }
}
