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
            DrawBlackNote(20, 10);          
            DrawLNote(30,10);
            //DrawBLNote(30, 10);
            //DrawTNote(20,70);

        }

        private void DrawBlackNote(int X,int Y)
        {
            g.FillRectangle(blackBrush,X, Y, 10, 60);
        }
        private void DrawLNote(int X, int Y)
        {
            g.DrawLine(whitePen, X, Y, X, 69);
            //g.DrawLine(blackPen, X+60,Y,X+60,Y+10);
            //g.DrawLine(blackPen, X + 60, Y + 10, X + 40, Y + 10);
            //g.DrawLine(blackPen, X+40,Y+10,X+40,Y+5);
            //g.DrawLine(blackPen, X + 40, Y + 5, X, Y + 5);
            //g.DrawLine(blackPen, X, Y + 5, X, Y);
        }
        private void DrawBLNote(int X, int Y)
        {

        }
        private void DrawTNote(int X, int Y)
        {

        }
    }
}
