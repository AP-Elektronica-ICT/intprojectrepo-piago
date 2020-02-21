using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaGo_CSharp
{
    class WhiteKey : Key
    {
        public WhiteKey(int inputX, int inputY, KeyColor inputColor)
            : base(KeyType.T_KEY, inputX, inputY, inputColor)
        {
            ChangeColor(inputColor);
        }

        public override void Draw(Graphics g, int multiplier)
        {
            g.DrawRectangle(this.Color, X, Y, 12 * multiplier, 42 * multiplier);
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
