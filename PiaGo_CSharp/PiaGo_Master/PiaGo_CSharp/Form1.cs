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
    public partial class Form1 : Form
    {
        //CODE FOR GRAPHICAL PIANO
        int multiplier = 5;
        Pen blackPen = new Pen(Color.Black);
        Pen whitePen = new Pen(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);
        Graphics g = null;
        static int centerX, centerY;
        static int startX, startY;
        static int endX, endY;
        static int angle;
        //------------------------
        public Form1()
        {
            InitializeComponent();
            startX = canvas.Width / 2;
            startY = canvas.Height / 2;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

        }
        private void btnBT_Click(object sender, EventArgs e)
        {
            Console.Beep(500, 500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startX = canvas.Width / 2;
            startY = canvas.Height / 2;
            canvas.Refresh();
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int var = 70;
            //DrawWhiteNote(10, 10);
            DrawLNote(var, 10);
            var += 60;
            //DrawBlackNote(105, 10);
            DrawTNote(var, 10);
            var += 60;
            //DrawBlackNote(165, 10);
            DrawTNote(var, 10);
            var += 60;
            //DrawBlackNote(165, 10);
            DrawBLNote(var, 10);
            var += 60;
            DrawLNote(var, 10);
            var += 60;
            //DrawBlackNote(105, 10);
            DrawTNote(var, 10);
            var += 60;
            //DrawBlackNote(165, 10);
            DrawBLNote(var, 10);
            var += 60;





        }

        private void DrawBlackNote(int X, int Y)
        {
            g.FillRectangle(blackBrush, X, Y, 10 * multiplier, 29 * multiplier);
        }
        private void DrawWhiteNote(int X, int Y)
        {
            g.DrawRectangle(blackPen, X, Y, 12 * multiplier, 42 * multiplier);
        }
        private void DrawLNote(int X, int Y)
        {
            g.DrawLine(blackPen, X      , Y     , X     , Y + 42 * multiplier);
            g.DrawLine(blackPen, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(blackPen, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 12 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 7 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y);
            g.DrawLine(blackPen, X + 7 * multiplier, Y     , X     , Y);
        }
        private void DrawBLNote(int X, int Y)
        {
            g.DrawLine(blackPen, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(blackPen, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y);
            g.DrawLine(blackPen, X + 12 * multiplier, Y     , X + 5 * multiplier, Y);
            g.DrawLine(blackPen, X + 5 * multiplier, Y     , X + 5 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 5 * multiplier, Y + 29 * multiplier, X     , Y + 29 * multiplier);
            g.DrawLine(blackPen, X      , Y + 29 * multiplier, X     , Y + 42 * multiplier);

        }
        private void DrawTNote(int X, int Y)
        {
            g.DrawLine(blackPen, X      , Y + 42 * multiplier, X + 12 * multiplier, Y + 42 * multiplier);
            g.DrawLine(blackPen, X + 12 * multiplier, Y + 42 * multiplier, X + 12 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 12 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 7 * multiplier, Y + 29 * multiplier, X + 7 * multiplier, Y);
            g.DrawLine(blackPen, X + 7 * multiplier, Y     , X + 5 * multiplier, Y);
            g.DrawLine(blackPen, X + 5 * multiplier, Y     , X + 5 * multiplier, Y + 29 * multiplier);
            g.DrawLine(blackPen, X + 5 * multiplier, Y + 29 * multiplier, X     , Y + 29 * multiplier);
            g.DrawLine(blackPen, X      , Y + 29 * multiplier, X     , Y + 42 * multiplier);

        }
    }
}
