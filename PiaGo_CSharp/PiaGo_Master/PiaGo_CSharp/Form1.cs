using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midi;
using System.IO.Ports;
using System.Management;
public enum ThemeType { LIGHT, DARK }
namespace PiaGo_CSharp
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        #region Properties
        //PROPERTIES FOR GRAPHICAL PIANO
        int multiplier = 4;
        int whiteKeySpace = 12;
        int blackKeySpace = 5;
        static int keyboardX = 35;
        static int keyboardY = 35;
        Brush blackBrush = new SolidBrush(Color.Black);
        Graphics g = null;
        List<Key> keyBoard = new List<Key>();
        KeyColor mainKeyColor = KeyColor.BLUE;

        //PROPERTIES FOR SOUND AND SOUNDFILES
        Instrument instrument = (Instrument)0;
        Clock clock;
        Random rnd = new Random();
        NoteScheduler noteScheduler;
        List<PianoKey> pianoKeys;
        LearnHandler learnHandler;
        OutputDevice outputDevice;
        MidiFileHandler MFH;
        List<string> songlist;

        //PROPERTIES FOR BLUETOOTH
        string macAddress = "B4E62DDF4B83"; //BE: "98D331FB1776";
        string comport = "";
        SerialPort sp1 = new SerialPort();
        int prevBTKey = -1;
        bool BTButtonPressed;
        #endregion

        #region Initializers
        public frmMain(OutputDevice _outputDevice)
        {
            InitializeComponent();
            outputDevice = _outputDevice;
            outputDevice.SendProgramChange(Channel.Channel1, instrument);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CODE FOR THEME
            this.StyleManager = metroSMMainForm;
            this.UpdateTheme();
            //CODE FOR LOGO
            pbLogo.Width = 623 / 4;
            pbLogo.Height = 252 / 4;
            
            //CODE FOR GRAPHICAL PIANO            
            whiteKeySpace *= multiplier;
            blackKeySpace *= multiplier;
            CreateKeyboard();
            
            //Initialize instrument-list
            for (int i = 0; i < 128; i++)
            {
                Instrument tempInstrument = (Instrument)i;
                string listItem = tempInstrument.Name();
                cbMetroInstruments.Items.Add(listItem);
            }
            cbMetroInstruments.SelectedIndex = 0;

            //Initialize song-list //TOEDIT
            MFH = new MidiFileHandler();
            songlist = MFH.GetSongNames();
            foreach(string name in songlist)
            {
                cbMetroSongs.Items.Add(name);
            }

            //Initialize Clock for piano
            clock = new Clock(120);
            clock.Start();
            noteScheduler = new NoteScheduler(clock, outputDevice);
            learnHandler = new LearnHandler(noteScheduler, keyBoard, canvas, LearnSongBtn, PreviewSongBtn, mainKeyColor, MFH);

            //Initialize pianokeys
            pianoKeys = new List<PianoKey>();
            for (int i = 0; i < 32; i++)
            {
                pianoKeys.Add(new PianoKey(i));
            }
            this.KeyPreview = true;
            BTButtonPressed = false;
            lblMetroConnection.BackColor = Color.Red;

            //Find correct COM port for BT MAC ADDRESS [MAKES APP LOAD SLOWER AT STARTUP!!!]
            ComPortInitialiser();
        }
        #endregion

        #region Bluetooth

        private void btnMetroConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp1.IsOpen)
                    sp1.Close();
                sp1.PortName = comport;
                sp1.BaudRate = 9600;
                try
                {
                    if (!sp1.IsOpen)
                        sp1.Open();
                    lblMetroConnection.Text = "Connected";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please reboot your piano","Piano connection error");
                }
                sp1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
            }
            catch (Exception)
            {

                DialogResult dialogResult = MessageBox.Show("Have you turned on Bluetooth? If not turn it on now and press OK","Device not found!",MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    dialogResult = MessageBox.Show("Searching device addresses...", "searching");
                    if (dialogResult == DialogResult.OK)

                    ComPortInitialiser();
                    MessageBox.Show("Please restart your piano now and try to connect", "Search complete!");
                }     
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string dataIn;
            try
            {
                SerialPort sp1 = (SerialPort)sender;
                dataIn = sp1.ReadLine(); //.Substring(0, 5);                
                SetText(dataIn);
                PlayBTNote(dataIn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        delegate void SetTextCallBack(string Text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtMetroDataIn.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtMetroDataIn.Text = text;
            }
        }

        private void PlayBTNote(string BTinput)
        {
            BTButtonPressed = true;
            switch (BTinput)
            {
                case "00000":                   
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(0);
                    prevBTKey = 0;
                    break;
                case "00001":                   
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(1);
                    prevBTKey = 1;
                    break;
                case "00010":                  
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(2);
                    prevBTKey = 2;
                    break;
                case "00011":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(3);
                    prevBTKey = 3;
                    break;
                case "00100":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(4);
                    prevBTKey = 4;
                    break;
                case "00101":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(5);
                    prevBTKey = 5;
                    break;
                case "00110":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(6);
                    prevBTKey = 6;
                    break;
                case "00111":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(7);
                    prevBTKey = 7;
                    break;
                case "01000":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(8);
                    prevBTKey = 8;
                    break;
                case "01001":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(9);
                    prevBTKey = 9;
                    break;
                case "01010":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(10);
                    prevBTKey = 10;
                    break;
                case "01011":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(11);
                    prevBTKey = 11;
                    break;
                case "01100":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(12);
                    prevBTKey = 12;
                    break;
                case "01101":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(13);
                    prevBTKey = 13;
                    break;
                case "01110":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(14);
                    prevBTKey = 14;
                    break;
                case "01111":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(15);
                    prevBTKey = 15;
                    break;
                case "10000":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(16);
                    prevBTKey = 16;
                    break;
                case "10001":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(17);
                    prevBTKey = 17;
                    break;
                case "10010":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(18);
                    prevBTKey = 18;
                    break;
                case "10011":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(19);
                    prevBTKey = 19;
                    break;
                case "10100":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(20);
                    prevBTKey = 20;
                    break;
                case "10101":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(21);
                    prevBTKey = 21;
                    break;
                case "10110":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(22);
                    prevBTKey = 22;
                    break;
                case "10111":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(23);
                    prevBTKey = 23;
                    break;
                case "11000":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(24);
                    prevBTKey = 24;
                    break;
                case "11001":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(25);
                    prevBTKey = 25;
                    break;
                case "11010":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(26);
                    prevBTKey = 26;
                    break;
                case "11011":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(27);
                    prevBTKey = 27;
                    break;
                case "11100":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(28);
                    prevBTKey = 28;
                    break;
                case "11101":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(29);
                    prevBTKey = 29;
                    break;
                case "11110":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(30);
                    prevBTKey = 30;
                    break;
                case "11111":
                    if (prevBTKey != -1)
                        DeActivateKey(prevBTKey);
                    ActivateKey(31);
                    prevBTKey = 31;
                    break;
            }
        }

        private void ComPortInitialiser()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_SerialPort");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string pnpDeviceID = queryObj["PNPDeviceID"].ToString();

                    if (pnpDeviceID.IndexOf(macAddress) == -1)
                    {
                        //no mac address found
                        //Console.WriteLine("no correct mac address");
                    }
                    else
                    {
                        //mac address found
                        //Console.WriteLine("----------------------------------");
                        //Console.WriteLine("Correct mac address found");
                        //Console.WriteLine(queryObj["DeviceID"].ToString());
                        //Console.WriteLine("----------------------------------");
                        comport = queryObj["DeviceID"].ToString();
                        break;
                    }

                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }
        }
        private void BTButtonCleaner()
        {
            if(BTButtonPressed == true)
            {
                learnHandler.CleanScreen();
                BTButtonPressed = false;
            }
        }
        
        #endregion

        #region Theme
        private ThemeType mainTheme = ThemeType.LIGHT;

        public ThemeType GetTheme()
        {
            return mainTheme;
        }

        public void SetTheme(ThemeType input)
        {
            mainTheme = input;
        }

        public void UpdateTheme()
        {
            switch (this.mainTheme)
            {
                case ThemeType.LIGHT:
                    metroSMMainForm.Theme = MetroFramework.MetroThemeStyle.Light;
                    canvas.BackColor = Color.White;
                    pbLogo.Image = Properties.Resources.piago_logo_BLACK;
                    break;
                case ThemeType.DARK:
                    metroSMMainForm.Theme = MetroFramework.MetroThemeStyle.Dark;
                    canvas.BackColor = Color.Black;
                    pbLogo.Image = Properties.Resources.piago_logo_WHITE;
                    break;
                default:
                    metroSMMainForm.Theme = MetroFramework.MetroThemeStyle.Light;
                    canvas.BackColor = Color.White;
                    pbLogo.Image = Properties.Resources.piago_logo_BLACK;
                    break;
            }
        }

        public void ChangeControlPanelBGImage(string strFileName)
        {
            try
            {
                pnlMainInfo.BackgroundImage = Image.FromFile(strFileName);
            }
            catch (Exception)
            {

                MessageBox.Show("Wrong image type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion

        #region Color  
        private MetroFramework.MetroColorStyle mainColor = MetroFramework.MetroColorStyle.Blue;

        public MetroFramework.MetroColorStyle GetColor()
        {
            return mainColor;
        }

        public void SetColor(MetroFramework.MetroColorStyle input)
        {
            mainColor = input;
            UpdateColor();
        }

        public void UpdateColor()
        {
            metroSMMainForm.Style = mainColor;
            switch (mainColor)
            {
                case MetroFramework.MetroColorStyle.Red:
                    mainKeyColor = KeyColor.RED;
                    learnHandler.mainKeyColor = KeyColor.RED;
                    break;
                case MetroFramework.MetroColorStyle.Green:
                    mainKeyColor = KeyColor.GREEN;
                    learnHandler.mainKeyColor = KeyColor.GREEN;
                    break;
                case MetroFramework.MetroColorStyle.Blue:
                    mainKeyColor = KeyColor.BLUE;
                    learnHandler.mainKeyColor = KeyColor.BLUE;
                    break;
                case MetroFramework.MetroColorStyle.Yellow:
                    mainKeyColor = KeyColor.YELLOW;
                    learnHandler.mainKeyColor = KeyColor.YELLOW;
                    break;
                default:
                    mainKeyColor = KeyColor.BLUE;
                    learnHandler.mainKeyColor = KeyColor.BLUE;
                    break;
            }
        }
        #endregion

        #region Piano
        private void ActivateKey(int key)
        {
            if (learnHandler.Learning == true)
            {
                if (key != learnHandler.KeyToPlay) keyBoard[key].SetKeyFill(KeyColor.RED);
                else keyBoard[key].SetKeyFill(KeyColor.GREEN);
            }
            else keyBoard[key].SetKeyFill(mainKeyColor);
            noteScheduler.NoteOn(pianoKeys[key]);
            canvas.Invalidate(new Rectangle(keyBoard[key].X, keyBoard[key].Y, 12 * multiplier, 42 * multiplier));
            learnHandler.LastKeyPlayed = key;
        }

        private void DeActivateKey(int key)
        {
            keyBoard[key].Clear();
            noteScheduler.NoteOff(pianoKeys[key]);
            if (learnHandler.Learning == true)
            {
                if (key == learnHandler.KeyToPlay) keyBoard[key].SetKeyFill(mainKeyColor);
            }
            canvas.Invalidate(new Rectangle(keyBoard[key].X, keyBoard[key].Y, 12 * multiplier, 42 * multiplier));
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

        void CreateKeyboard() //Creation of individual keys of piano
        {
            int whiteKeys = 0;
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
        #endregion

        #region Instruments
        private void tglMetroMode_CheckedChanged(object sender, EventArgs e)
        {
            learnHandler.CleanScreen(); //To Delete if bluetooth works with 64bits
            PreviewSongBtn.Visible = !PreviewSongBtn.Visible;
            LearnSongBtn.Visible = !LearnSongBtn.Visible;
            OctaveDownBtn.Visible = !OctaveDownBtn.Visible;
            OctaveUpBtn.Visible = !OctaveUpBtn.Visible;
            cbMetroSongs.Visible = !cbMetroSongs.Visible;
            foreach (var pianoKey in pianoKeys)
            {
                pianoKey.pitch = pianoKey.originalpitch;
            }
            if (!LearnSongBtn.Visible)
            {
                learnHandler.AbortAllThreads();
            }
        }

        private void OctaveUpBtn_Click_1(object sender, EventArgs e)
        {
            foreach (var pianokey in pianoKeys)
            {
                pianokey.pitch += 12;
            }
        }

        private void OctaveDownBtn_Click_1(object sender, EventArgs e)
        {
            foreach (var pianokey in pianoKeys)
            {
                pianokey.pitch -= 12;
            }
        }

        private void cbMetroInstruments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedInstrument = (string)cbMetroInstruments.SelectedItem;
            int resultIndex = cbMetroInstruments.FindStringExact(selectedInstrument);
            Instrument tempInstrument = (Instrument)resultIndex;
            outputDevice.SendProgramChange(Channel.Channel1, tempInstrument);
        }
        #endregion

        #region Learn Song
        private void cbMetroSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSong = (string)cbMetroSongs.SelectedItem;
            learnHandler.SelectSong(selectedSong);
        }



        private void PreviewSongBtn_Click(object sender, EventArgs e)
        {
            learnHandler.PreviewHandler();
        }


        private void LearnSongBtn_Click(object sender, EventArgs e)
        {
            learnHandler.LearnSongHandler();
        }
        #endregion

        #region ALL DEBUG KEYS (32)
        private void btnKey32_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(31);
        }
        private void btnKey32_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(31);
        }

        private void btnKey31_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(30);
        }
        private void btnKey31_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(30);
        }

        private void btnKey30_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(29);
        }
        private void btnKey30_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(29);
        }

        private void btnKey29_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(28);
        }
        private void btnKey29_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(28);
        }

        private void btnKey28_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(27);
        }
        private void btnKey28_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(27);
        }

        private void btnKey27_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(26);
        }
        private void btnKey27_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(26);
        }

        private void btnKey26_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(25);
        }
        private void btnKey26_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(25);
        }

        private void btnKey25_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(24);
        }
        private void btnKey25_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(24);
        }

        private void btnKey24_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(23);
        }
        private void btnKey24_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(23);
        }

        private void btnKey23_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(22);
        }
        private void btnKey23_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(22);
        }

        private void btnKey22_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(21);
        }
        private void btnKey22_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(21);
        }

        private void btnKey21_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(20);
        }
        private void btnKey21_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(20);
        }

        private void btnKey20_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(19);
        }
        private void btnKey20_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(19);
        }

        private void btnKey19_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(18);
        }
        private void btnKey19_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(18);
        }

        private void btnKey18_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(17);
        }
        private void btnKey18_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(17);
        }

        private void btnKey17_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(16);
        }
        private void btnKey17_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(16);
        }

        private void btnKey16_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(15);
        }
        private void btnKey16_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(15);
        }

        private void btnKey15_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(14);
        }
        private void btnKey15_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(14);
        }

        private void btnKey14_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(13);
        }
        private void btnKey14_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(13);
        }

        private void btnKey13_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(12);
        }
        private void btnKey13_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(12);
        }

        private void btnKey12_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(11);
        }
        private void btnKey12_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(11);
        }
        private void btnKey11_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(10);
        }
        private void btnKey11_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(10);
        }

        private void btnKey10_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(9);
        }
        private void btnKey10_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(9);
        }

        private void btnKey9_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(8);
        }
        private void btnKey9_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(8);
        }

        private void btnKey8_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(7);
        }
        private void btnKey8_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(7);
        }

        private void btnKey7_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(6);
        }
        private void btnKey7_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(6);
        }

        private void btnKey6_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(5);
        }
        private void btnKey6_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(5);
        }

        private void btnKey5_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(4);
        }
        private void btnKey5_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(4);
        }

        private void btnKey4_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(3);
        }
        private void btnKey4_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(3);
        }
        private void btnKey3_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(2);
        }
        private void btnKey3_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(2);
        }

        private void btnKey2_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(1);
        }
        private void btnKey2_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(1);
        }

        private void btnKey1_MouseDown(object sender, EventArgs e)
        {
            BTButtonCleaner();
            ActivateKey(0);
        }
        private void btnKey1_MouseUp(object sender, EventArgs e)
        {
            DeActivateKey(0);
        }
        #endregion]

        #region DebugPhysicalKeyboard
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue + " " + e.KeyData + " was pressed");
            switch (e.KeyValue)
            {
                case 81:
                    ActivateKey(0);
                    break;
                case 83:
                    ActivateKey(2);
                    break;
                case 68:
                    ActivateKey(4);
                    break;
                case 70:
                    ActivateKey(6);
                    break;
                case 71:
                    ActivateKey(7);
                    break;
                case 72:
                    ActivateKey(9);
                    break;
                case 74:
                    ActivateKey(11);
                    break;
                case 75:
                    ActivateKey(12);
                    break;
                case 76:
                    ActivateKey(14);
                    break;
                case 77:
                    ActivateKey(16);
                    break;
                case 90:
                    ActivateKey(1);
                    break;
                case 69:
                    ActivateKey(3);
                    break;
                case 82:
                    ActivateKey(5);
                    break;
                case 89:
                    ActivateKey(8);
                    break;
                case 85:
                    ActivateKey(10);
                    break;
                case 79:
                    ActivateKey(13);
                    break;
                case 80:
                    ActivateKey(15);
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue + " " + e.KeyData + " was released");
            switch (e.KeyValue)
            {
                case 81:
                    DeActivateKey(0);
                    break;
                case 83:
                    DeActivateKey(2);
                    break;
                case 68:
                    DeActivateKey(4);
                    break;
                case 70:
                    DeActivateKey(6);
                    break;
                case 71:
                    DeActivateKey(7);
                    break;
                case 72:
                    DeActivateKey(9);
                    break;
                case 74:
                    DeActivateKey(11);
                    break;
                case 75:
                    DeActivateKey(12);
                    break;
                case 76:
                    DeActivateKey(14);
                    break;
                case 77:
                    DeActivateKey(16);
                    break;
                case 90:
                    DeActivateKey(1);
                    break;
                case 69:
                    DeActivateKey(3);
                    break;
                case 82:
                    DeActivateKey(5);
                    break;
                case 89:
                    DeActivateKey(8);
                    break;
                case 85:
                    DeActivateKey(10);
                    break;
                case 79:
                    DeActivateKey(13);
                    break;
                case 80:
                    DeActivateKey(15);
                    break;
            }
        }
        #endregion

        #region Form Functionality
        private void btnMetroUser_Click(object sender, EventArgs e)
        {
            StartScreen strt = new StartScreen();
            strt.ShowDialog();
        }


        private void btnMetroSettings_Click(object sender, EventArgs e)
        {
            SettingsScreen settings = new SettingsScreen();
            settings.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnMetroDebugging_Click(object sender, EventArgs e)
        {
            if (btnMetroUser.Visible == false)
            {
                btnMetroUser.Visible = true;
                txtMetroDataIn.Visible = true;
                btnKey1.Visible = true;
                btnKey2.Visible = true;
                btnKey3.Visible = true;
                btnKey4.Visible = true;
                btnKey5.Visible = true;
                btnKey6.Visible = true;
                btnKey7.Visible = true;
                btnKey8.Visible = true;
                btnKey9.Visible = true;
                btnKey10.Visible = true;
                btnKey11.Visible = true;
                btnKey12.Visible = true;
                btnKey13.Visible = true;
                btnKey14.Visible = true;
                btnKey15.Visible = true;
                btnKey16.Visible = true;
                btnKey17.Visible = true;
                btnKey18.Visible = true;
                btnKey19.Visible = true;
                btnKey20.Visible = true;
                btnKey21.Visible = true;
                btnKey22.Visible = true;
                btnKey23.Visible = true;
                btnKey24.Visible = true;
                btnKey25.Visible = true;
                btnKey26.Visible = true;
                btnKey27.Visible = true;
                btnKey28.Visible = true;
                btnKey29.Visible = true;
                btnKey30.Visible = true;
                btnKey31.Visible = true;
                btnKey32.Visible = true;
            }
            else
            {
                btnMetroUser.Visible = false;
                txtMetroDataIn.Visible = false;
                btnKey1.Visible = false;
                btnKey2.Visible = false;
                btnKey3.Visible = false;
                btnKey4.Visible = false;
                btnKey5.Visible = false;
                btnKey6.Visible = false;
                btnKey7.Visible = false;
                btnKey8.Visible = false;
                btnKey9.Visible = false;
                btnKey10.Visible = false;
                btnKey11.Visible = false;
                btnKey12.Visible = false;
                btnKey13.Visible = false;
                btnKey14.Visible = false;
                btnKey15.Visible = false;
                btnKey16.Visible = false;
                btnKey17.Visible = false;
                btnKey18.Visible = false;
                btnKey19.Visible = false;
                btnKey20.Visible = false;
                btnKey21.Visible = false;
                btnKey22.Visible = false;
                btnKey23.Visible = false;
                btnKey24.Visible = false;
                btnKey25.Visible = false;
                btnKey26.Visible = false;
                btnKey27.Visible = false;
                btnKey28.Visible = false;
                btnKey29.Visible = false;
                btnKey30.Visible = false;
                btnKey31.Visible = false;
                btnKey32.Visible = false;
            }

        }

        #endregion

    }
}