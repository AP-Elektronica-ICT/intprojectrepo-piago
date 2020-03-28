using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;

namespace PiaGo_CSharp
{
    class NoteScheduler
    {
        Clock clock;
        OutputDevice outputDevice;
        public NoteScheduler (Clock _clock, OutputDevice _outputDevice)
        {
            clock = _clock;
            outputDevice = _outputDevice;
        }

        public void Play (int key)
        {
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, (Pitch)(53 + key), 80, clock.Time));
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, (Pitch)(53 + key), 80, clock.Time + 1));
        }
        public void Play (PianoKey key)
        {
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, key.pitch, 80, clock.Time));
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, key.pitch, 80, clock.Time + 1));
        }

    }
}
