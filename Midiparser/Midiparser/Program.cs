using System;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System.Linq;

namespace Midiparser
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var midiFile = MidiFile.Read("jacob.midi");

            File.WriteAllLines("testmidifilewii.txt",
                      midiFile.GetNotes()
                              .Select(n => $"{n.NoteNumber} {n.Time} {n.Length}"));
            



        }
    }
}
