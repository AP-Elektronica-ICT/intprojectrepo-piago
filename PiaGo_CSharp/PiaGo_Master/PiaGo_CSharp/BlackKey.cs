using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaGo_CSharp
{
    class BlackKey : Key
    {

        public BlackKey(int inputX, int inputY, KeyColor inputColor)
            : base(KeyType.T_KEY, inputX, inputY, inputColor)
        {
            ChangeColor(inputColor);
        }

        public override void Draw(Graphics g, int multiplier)
        {
            g.FillRectangle(this.Fill, X, Y, 10 * multiplier, 29 * multiplier);
        }

        public override void ChangeColor(KeyColor color)
        {
            switch (color)
            {
                case KeyColor.BLACK:
                    this.Fill = new SolidBrush(System.Drawing.Color.Black);
                    break;
                case KeyColor.RED:
                    this.Fill = new SolidBrush(System.Drawing.Color.Red);
                    break;
                case KeyColor.GREEN:
                    this.Fill = new SolidBrush(System.Drawing.Color.Green);
                    break;
                case KeyColor.BLUE:
                    this.Fill = new SolidBrush(System.Drawing.Color.Blue);
                    break;
            }
        }
    }
}
