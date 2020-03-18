using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midi;

namespace PiaGo_CSharp
{
    //      - To-Do List
    public partial class frmMain : Form
    {
        int test = 0;
        OutputDevice outputDevice;
        //CODE FOR GRAPHICAL PIANO
        int multiplier = 4;
        Key prevKey;
        int whiteKeySpace = 12;
        int blackKeySpace = 5;
        static int keyboardX = 35;
        static int keyboardY = 35;
        Brush blackBrush = new SolidBrush(Color.Black);
        Graphics g = null;
        List<Key> keyBoard = new List<Key>();
        //------------------------
        Instrument instrument = (Instrument)0;
        int NoteNumber = 60;
        Clock clock;
        Random rnd = new Random();

        public frmMain(OutputDevice _outputDevice)
        {
            InitializeComponent();
            outputDevice = _outputDevice;
            outputDevice.SendProgramChange(Channel.Channel1, instrument);
        }

        private void btnBT_Click(object sender, EventArgs e)
        {
            
            
            
            if (prevKey == null)
            {
                keyBoard[test].SetKeyFill(KeyColor.BLUE);
                prevKey = keyBoard[test];
            }
            else
            {
                prevKey.Clear();
                canvas.Invalidate(new Rectangle(prevKey.X, prevKey.Y, 12 * multiplier, 42 * multiplier));
                keyBoard[test].SetKeyFill(KeyColor.BLUE);
                prevKey = keyBoard[test];
                
            }
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, (Pitch)(53+test), 80, clock.Time));
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, (Pitch)(53+test), 80, clock.Time + 1));

            keyBoard[test].MakeSound(37+test*37,100);            
            canvas.Invalidate(new Rectangle(keyBoard[test].X, keyBoard[test].Y, 12 * multiplier, 42 * multiplier));
            test++;
            if (test >= 32)
                test = 0;      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //CODE FOR LOGO
            pbLogo.Width = 623 / 4;
            pbLogo.Height = 252 / 4;
            //------------------------
            //CODE FOR GRAPHICAL PIANO            
            whiteKeySpace *= multiplier;
            blackKeySpace *= multiplier;
            CreateKeyboard();          
            //------------------------
            //Initialize instrument-list
            for (int i = 0; i < 128; i++)
            {
                Instrument tempInstrument = (Instrument)i;
                string listItem = tempInstrument.Name();
                comboBox1.Items.Add(listItem);
            }
            comboBox1.SelectedIndex = 0;
            //Initialize Clock for piano
            clock = new Clock(120);
            clock.Start();
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DrawKeyboard();
        }
        private void DrawKeyboard()
        {
            for (int i = 0; i < keyBoard.Count; i++)
            {
                keyBoard[i].Draw(g, multiplier);
            }
        }
        void CreateKeyboard()
        {
            int whiteKeys = 0;
            keyBoard.Add(new L_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys)-blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new RL_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;

            keyBoard.Add(new L_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new RL_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;

            keyBoard.Add(new L_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new RL_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;

            keyBoard.Add(new L_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new RL_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;

            keyBoard.Add(new L_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new T_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;
                keyBoard.Add(new BlackKey(keyboardX + (whiteKeySpace * whiteKeys) - blackKeySpace, keyboardY, KeyColor.BLACK));
            keyBoard.Add(new RL_Key(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE)); whiteKeys++;

            keyBoard.Add(new WhiteKey(keyboardX + (whiteKeySpace * whiteKeys), keyboardY, KeyColor.WHITE));            
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            StartScreen strt = new StartScreen();
            strt.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedInstrument = (string)comboBox1.SelectedItem;
            int resultIndex;
            resultIndex = comboBox1.FindStringExact(selectedInstrument);
            Instrument tempInstrument = (Instrument)resultIndex;
            outputDevice.SendProgramChange(Channel.Channel1, tempInstrument);
        }

       
        private void btnKey32_Click(object sender, EventArgs e)
        {
            ActivateKey(31);        
        }

        private void btnKey31_Click(object sender, EventArgs e)
        {
            ActivateKey(30);
        }

        private void btnKey30_Click(object sender, EventArgs e)
        {
            ActivateKey(29);
        }

        private void btnKey29_Click(object sender, EventArgs e)
        {
            ActivateKey(28);
        }

        private void btnKey28_Click(object sender, EventArgs e)
        {
            ActivateKey(27);
        }

        private void btnKey27_Click(object sender, EventArgs e)
        {
            ActivateKey(26);
        }

        private void btnKey26_Click(object sender, EventArgs e)
        {
            ActivateKey(25);
        }

        private void btnKey25_Click(object sender, EventArgs e)
        {
            ActivateKey(24);
        }

        private void btnKey24_Click(object sender, EventArgs e)
        {
            ActivateKey(23);
        }

        private void btnKey23_Click(object sender, EventArgs e)
        {
            ActivateKey(22);
        }

        private void btnKey22_Click(object sender, EventArgs e)
        {
            ActivateKey(21);
        }

        private void btnKey21_Click(object sender, EventArgs e)
        {
            ActivateKey(20);
        }

        private void btnKey20_Click(object sender, EventArgs e)
        {
            ActivateKey(19);
        }

        private void btnKey19_Click(object sender, EventArgs e)
        {
            ActivateKey(18);
        }

        private void btnKey18_Click(object sender, EventArgs e)
        {
            ActivateKey(17);
        }

        private void btnKey17_Click(object sender, EventArgs e)
        {
            ActivateKey(16);
        }

        private void btnKey16_Click(object sender, EventArgs e)
        {
            ActivateKey(15);
        }

        private void btnKey15_Click(object sender, EventArgs e)
        {
            ActivateKey(14);
        }

        private void btnKey14_Click(object sender, EventArgs e)
        {
            ActivateKey(13);
        }

        private void btnKey13_Click(object sender, EventArgs e)
        {
            ActivateKey(12);
        }

        private void btnKey12_Click(object sender, EventArgs e)
        {
            ActivateKey(11);
        }
        private void btnKey11_Click(object sender, EventArgs e)
        {
            ActivateKey(10);
        }

        private void btnKey10_Click(object sender, EventArgs e)
        {
            ActivateKey(9);
        }

        private void btnKey9_Click(object sender, EventArgs e)
        {
            ActivateKey(8);
        }

        private void btnKey8_Click(object sender, EventArgs e)
        {
            ActivateKey(7);
        }

        private void btnKey7_Click(object sender, EventArgs e)
        {
            ActivateKey(6);
        }

        private void btnKey6_Click(object sender, EventArgs e)
        {
            ActivateKey(5);
        }

        private void btnKey5_Click(object sender, EventArgs e)
        {
            ActivateKey(4);
        }

        private void btnKey4_Click(object sender, EventArgs e)
        {
            ActivateKey(3);
        }
        private void btnKey3_Click(object sender, EventArgs e)
        {
            ActivateKey(2);
        }

        private void btnKey2_Click(object sender, EventArgs e)
        {
            ActivateKey(1);
        }

        private void btnKey1_Click(object sender, EventArgs e)
        {
            ActivateKey(0);
        }

        private void ActivateKey(int key)
        {
            if (prevKey == null)
            {
                keyBoard[key].SetKeyFill(KeyColor.BLUE);
                prevKey = keyBoard[key];
            }
            else
            {
                prevKey.Clear();
                canvas.Invalidate(new Rectangle(prevKey.X, prevKey.Y, 12 * multiplier, 42 * multiplier));
                keyBoard[key].SetKeyFill(KeyColor.BLUE);
                prevKey = keyBoard[key];

            }
            //clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, (Pitch)(53 + test), 80, clock.Time));
            //clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, (Pitch)(53 + test), 80, clock.Time + 1));

            keyBoard[key].MakeSound(37 + key * 37, 100);
            canvas.Invalidate(new Rectangle(keyBoard[key].X, keyBoard[key].Y, 12 * multiplier, 42 * multiplier));
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsScreen settings = new SettingsScreen();
            settings.ShowDialog();            
        }

        public void ChangeControlPanelBGImage(string strFileName)
        {
            try
            {
                pnlMainInfo.BackgroundImage = Image.FromFile(strFileName);
            }
            catch (Exception)
            {

                MessageBox.Show("Wrong image type", "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        public void ChangePianoBGImage(string strFileName)
        {
            try
            {
                canvas.BackgroundImage = Image.FromFile(strFileName);
            }
            catch (Exception)
            {

                MessageBox.Show("Wrong image type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }    
}