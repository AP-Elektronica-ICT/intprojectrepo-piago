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
    public partial class StartScreen : Form
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
            pbLogo.Width = 623 / 3;
            pbLogo.Height = 252 / 3;
            pbLogo.Left = (this.ClientSize.Width - pbLogo.Width) / 2;
            pbLogo.Top = 10;
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
