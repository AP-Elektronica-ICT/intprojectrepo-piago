using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Midi;

namespace PiaGo_CSharp
{
    class LearnHandler
    {
        NoteScheduler noteScheduler;
        string MidiFileDirectory;
        string[] songlines; 
        string chosenSong;
        public LearnHandler(NoteScheduler ns)
        {
            noteScheduler = ns;
            MidiFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "MidiTextFiles");
            //songlines = File.ReadAllLines(Path.Combine(MidiFileDirectory, "SimpleBrotherJabok.txt"));
        }
        public void SelectSong(string song)
        {
            ///DUMMYSYSTEM, TO CHANGE
            chosenSong = song;
            string songpath = Path.Combine(MidiFileDirectory, "SimpleBrotherJakob.txt");
            songpath = new Uri(songpath).LocalPath;
            songlines = File.ReadAllLines(songpath);
        }
        public void PreviewSong()
        {
            noteScheduler.clock.Stop();
            foreach (string songline in songlines)
            {
                string[] songinfo = songline.Split(' ');
                Pitch pitch = (Pitch)Convert.ToInt32(songinfo[0]);
                float noteStart = float.Parse(songinfo[1])/128;
                float noteEnd = float.Parse(songinfo[2])/128+noteStart;
                noteScheduler.Schedule(pitch, noteStart, noteEnd);
            }
            noteScheduler.clock.Start();
        }
    }
}
