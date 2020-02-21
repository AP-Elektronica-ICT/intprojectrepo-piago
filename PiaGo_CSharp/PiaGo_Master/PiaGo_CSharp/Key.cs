using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PiaGo_CSharp
{
    enum KeyType    { BLACK_KEY, WHITE_KEY, L_KEY, RL_KEY, T_KEY }
    enum KeyColor   { BLACK, RED, GREEN, BLUE }
    abstract class Key
    {
        public Pen Color { get; set; }
        public Brush Fill { get; set; }
        public KeyType Type { get; }
        public int X { get; }
        public int Y { get; }

        public Key(KeyType inputType,int inputX,int inputY,KeyColor inputColor)
         {
            this.Type = inputType;
            this.X = inputX;
            this.Y = inputY;
         }
        public abstract void Draw(Graphics g,int multiplier);
        public abstract void ChangeColor(KeyColor color);
    }
}
