using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;

namespace PiaGo_CSharp
{
    class PianoKey
    {
        public Pitch pitch;
        public PianoKey(int _pitch)
        {
            pitch = (Pitch)(_pitch+53);
        }

    }
}
