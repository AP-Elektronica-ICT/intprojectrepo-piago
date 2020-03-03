using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.SetKeyFill(inputColor);
        }

        public override void Draw(Graphics g, int multiplier)
        {
            // Create a graphics path
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            // Add Rectangle
            Rectangle whitekey = new Rectangle(this.X, this.Y, 12 * multiplier, 42 * multiplier);
            path.AddRectangle(whitekey);

            // Create Region
            Region reg = new Region(path);
            // Fill region
            g.FillRegion(this.GetKeyFill(), reg);
            // Draw contour
            g.DrawPath(this.Color, path);      
        }
    }
}
