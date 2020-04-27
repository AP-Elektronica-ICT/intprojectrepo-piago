using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiaGo_CSharp
{
    class L_Key : Key
    {

        public L_Key(int inputX, int inputY, KeyColor inputColor)
            : base(KeyType.T_KEY, inputX, inputY, inputColor)
        {
            this.SetKeyFill(inputColor);
        }
        public override void Draw(Graphics g, int multiplier)
        {
            // Create a graphics path
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            // Add lines
            path.AddLine(this.X, this.Y, this.X, this.Y + 42 * multiplier);
            path.AddLine(this.X, this.Y + 42 * multiplier, this.X + 12 * multiplier, this.Y + 42 * multiplier);
            path.AddLine(this.X + 12 * multiplier, this.Y + 42 * multiplier, this.X + 12 * multiplier, this.Y + 29 * multiplier);
            path.AddLine(this.X + 12 * multiplier, this.Y + 29 * multiplier, this.X + 7 * multiplier, this.Y + 29 * multiplier);
            path.AddLine(this.X + 7 * multiplier, this.Y + 29 * multiplier, this.X + 7 * multiplier, this.Y);
            path.AddLine(this.X + 7 * multiplier, this.Y, this.X, this.Y);

            // Create Region
            Region reg = new Region(path);
            // Fill region
            g.FillRegion(this.GetKeyFill(), reg);
            // Draw contour
            g.DrawPath(this.Color, path);
        }      
    }

}
