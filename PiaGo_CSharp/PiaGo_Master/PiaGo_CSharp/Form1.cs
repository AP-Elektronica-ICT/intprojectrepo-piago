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
    enum KeyType { BLACK_KEY,WHITE_KEY,L_KEY,RL_KEY,T_KEY }
    public partial class Form1 : Form
    {
        //CODE FOR GRAPHICAL PIANO
        int multiplier = 4;
        int whiteKeySpace = 12;
        int blackKeySpace = 7;
        static int keyboardX = 35;
        static int keyboardY = 35;
        Pen blackPen = new Pen(Color.Black);
        Pen whitePen = new Pen(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Graphics g = null;
        //------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            whiteKeySpace *= multiplier;
            blackKeySpace *= multiplier;
            canvas.Refresh();
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int keyboardX = 35;
            
            DrawLNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX+blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawBLNote(keyboardX, keyboardY, blackPen);
            keyboardX += whiteKeySpace;
            //-----------------------------
            DrawLNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawBLNote(keyboardX, keyboardY, blackPen);
            keyboardX += whiteKeySpace;
            //-----------------------------
            DrawLNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawBLNote(keyboardX, keyboardY, blackPen);
            keyboardX += whiteKeySpace;
            //-----------------------------
            DrawLNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawBLNote(keyboardX, keyboardY, blackPen);
            keyboardX += whiteKeySpace;
            //-----------------------------
            DrawLNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawTNote(keyboardX, keyboardY, blackPen);
            DrawBlackNote(keyboardX + blackKeySpace, keyboardY, blackBrush);
            keyboardX += whiteKeySpace;

            DrawBLNote(keyboardX, keyboardY, blackPen);
            keyboardX += whiteKeySpace;
            //-----------------------------
            DrawWhiteNote(keyboardX, keyboardY, blackPen);



        }

        private void DrawBlackNote(int X, int Y, Brush color)
        {
            g.FillRectangle(color, X, Y, 10 * multiplier, 29 * multiplier);
        }
        private void DrawWhiteNote(int X, int Y, Pen color)
        {
            g.DrawRectangle(color, X, Y, 12 * multiplier, 42 * multiplier);
        }
        private void DrawLNote(int X, int Y, Pen color)
        {
            g.DrawLine(color, X      , Y     , X     , Y + 42 * multiplier);
            g.DrawLine(color, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(color, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 12 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 7 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y);
            g.DrawLine(color, X + 7 * multiplier, Y     , X     , Y);
        }
        private void DrawBLNote(int X, int Y, Pen color)
        {
            g.DrawLine(color, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(color, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y);
            g.DrawLine(color, X + 12 * multiplier, Y     , X + 5 * multiplier, Y);
            g.DrawLine(color, X + 5 * multiplier, Y     , X + 5 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 5 * multiplier, Y + 29 * multiplier, X     , Y + 29 * multiplier);
            g.DrawLine(color, X      , Y + 29 * multiplier, X     , Y + 42 * multiplier);

        }
        private void DrawTNote(int X, int Y, Pen color)
        {
            g.DrawLine(color, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(color, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 12 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 7 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y);
            g.DrawLine(color, X + 7 * multiplier, Y     , X + 5 * multiplier, Y);
            g.DrawLine(color, X + 5 * multiplier, Y     , X + 5 * multiplier, Y + 29 * multiplier);
            g.DrawLine(color, X + 5 * multiplier, Y + 29 * multiplier, X     , Y + 29 * multiplier);
            g.DrawLine(color, X      , Y + 29 * multiplier, X     , Y + 42 * multiplier);

        }
    }
}
