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
    //      ------------
    //      - use picturebox instead of canvas
    public partial class Form1 : Form
    {

        int test = 0;
        OutputDevice outputDevice;
        //CODE FOR GRAPHICAL PIANO
        int multiplier = 4;
        int whiteKeySpace = 12;
        int blackKeySpace = 5;
        Instrument instrument = (Instrument)0 ;
        int NoteNumber = 60;
        Clock clock;

        static int keyboardX = 35;
        static int keyboardY = 35;
        Brush blackBrush = new SolidBrush(Color.Black);
        Graphics g = null;
        List<Key> keyBoard = new List<Key>();
        //------------------------
        Random rnd = new Random();
        public Form1(OutputDevice _outputDevice)
        {
            InitializeComponent();
            outputDevice = _outputDevice;
            outputDevice.SendProgramChange(Channel.Channel1, instrument);
        }

        private void btnBT_Click(object sender, EventArgs e)
        {
            //LOTS OF TESTCODE
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, (Pitch)NoteNumber, 80, clock.Time));
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, (Pitch)NoteNumber, 80, clock.Time+1));
            //outputDevice.SendNoteOn(Channel.Channel1, (Pitch) NoteNumber, 80);
            //outputDevice.SendNoteOff(Channel.Channel1, (Pitch)NoteNumber, 80);
            keyBoard[test].SetKeyFill(KeyColor.BLUE);
            canvas.Invalidate(new Rectangle(keyBoard[test].X, keyBoard[test].Y, 12 * multiplier, 42 * multiplier));
            test++;
            NoteNumber++;
            if (test >= 32)
                test = 0;      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //CODE FOR GRAPHICAL PIANO
            whiteKeySpace *= multiplier;
            blackKeySpace *= multiplier;
            CreateKeyboard();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedInstrument = (string)comboBox1.SelectedItem;
            int resultIndex;
            resultIndex = comboBox1.FindStringExact(selectedInstrument);
            Instrument tempInstrument = (Instrument)resultIndex;
            outputDevice.SendProgramChange(Channel.Channel1, tempInstrument);
        }
    }    
}