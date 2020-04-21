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
        public Clock clock;
        OutputDevice outputDevice;
        public NoteScheduler (Clock _clock, OutputDevice _outputDevice)
        {
            clock = _clock;
            outputDevice = _outputDevice;
        }
        public void Schedule(Pitch pitch, float noteStart, float noteEnd)
        {
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, pitch, 80, noteStart));
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, pitch, 80, noteEnd));
        }
        public void StopAll()
        {
            clock.Stop();
            clock.Reset();
            outputDevice.SilenceAllNotes();
            clock.Start();
        }
        public void NoteOn(PianoKey key)
        {
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, key.pitch, 80, clock.Time));
        }
        public void NoteOn(Pitch pitch)
        {
            clock.Schedule(new NoteOnMessage(outputDevice, Channel.Channel1, pitch, 80, clock.Time));
        }
        public void NoteOff(PianoKey key)
        {
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, key.pitch, 80, clock.Time));
        }
        public void NoteOff(Pitch pitch)
        {
            clock.Schedule(new NoteOffMessage(outputDevice, Channel.Channel1, pitch, 80, clock.Time));
        }

    }
}
