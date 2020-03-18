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
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
        }



        private void btnChangeControlPanelBGImage_Click(object sender, EventArgs e)
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

        private void btnChangePianoBGImage_Click(object sender, EventArgs e)
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
    }
}
