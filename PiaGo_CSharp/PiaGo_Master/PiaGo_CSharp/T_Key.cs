using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaGo_CSharp
{
    
    class T_Key:Key
    {
        public T_Key(int inputX, int inputY, KeyColor inputColor)
            : base(KeyType.T_KEY, inputX, inputY, inputColor)
        {
            ChangeColor(inputColor);
        }

        public override void Draw(Graphics g,int multiplier)
        {
            g.DrawLine(this.Color, this.X, this.Y + 42 * multiplier, this.X + 12 * multiplier, this.Y + 42 * multiplier);
            g.DrawLine(this.Color, this.X + 12 * multiplier, this.Y + 42 * multiplier, this.X + 12 * multiplier, this.Y + 29 * multiplier);
            g.DrawLine(this.Color, this.X + 12 * multiplier, this.Y + 29 * multiplier, this.X + 7 * multiplier, this.Y + 29 * multiplier);
            g.DrawLine(this.Color, this.X + 7 * multiplier, this.Y + 29 * multiplier, this.X + 7 * multiplier, this.Y);
            g.DrawLine(this.Color, this.X + 7 * multiplier, this.Y, this.X + 5 * multiplier, this.Y);
            g.DrawLine(this.Color, this.X + 5 * multiplier, this.Y, this.X + 5 * multiplier, this.Y + 29 * multiplier);
            g.DrawLine(this.Color, this.X + 5 * multiplier, this.Y + 29 * multiplier, this.X, this.Y + 29 * multiplier);
            g.DrawLine(this.Color, this.X, this.Y + 29 * multiplier, this.X, this.Y + 42 * multiplier);
        }

        public override void ChangeColor(KeyColor color)
        {
            switch (color)
            {
                case KeyColor.BLACK:
                    this.Color = new Pen(System.Drawing.Color.Black);
                    break;
                case KeyColor.RED:
                    this.Color = new Pen(System.Drawing.Color.Red);
                    break;
                case KeyColor.GREEN:
                    this.Color = new Pen(System.Drawing.Color.Green);
                    break;
                case KeyColor.BLUE:
                    this.Color = new Pen(System.Drawing.Color.Blue);
                    break;
            }
        }
    }
}
