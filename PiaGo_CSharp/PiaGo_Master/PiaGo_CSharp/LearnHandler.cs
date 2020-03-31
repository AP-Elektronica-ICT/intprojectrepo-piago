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
        public Boolean previewing = false;
        List<Key> keyBoard;
        
        public LearnHandler(NoteScheduler ns, List<Key> _Keyboard)
        {
            noteScheduler = ns;
            MidiFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "MidiTextFiles");
            keyBoard = _Keyboard;
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
        
        public string HandlePreview()
        {
            string buttontext = "Preview Song";
            if (previewing)
            {
                noteScheduler.StopAll();
                previewing = false;
            }
            else
            {
                if (songlines != null)
                {
                    previewing = true;
                    noteScheduler.clock.Stop();
                    noteScheduler.clock.Reset();
                    foreach (string songline in songlines)
                    {
                        string[] songinfo = songline.Split(' ');
                        Pitch pitch = (Pitch)Convert.ToInt32(songinfo[0])+5;
                        float noteStart = float.Parse(songinfo[1]) / 128;
                        float noteEnd = float.Parse(songinfo[2]) / 128 + noteStart;
                        noteScheduler.Schedule(pitch, noteStart, noteEnd);
                    }
                    noteScheduler.clock.Start();
                    buttontext = "Stop Preview";
                }
            }
            return buttontext;
        }
        public void LearnSong()
        {
            foreach (string songline in songlines)
            {
                string[] songinfo = songline.Split(' ');
                int keyToPlay = Convert.ToInt32(songinfo[0])-48;
                bool correct = false;
                keyBoard[keyToPlay].SetKeyFill(KeyColor.GREEN);
                //canvas.Invalidate(new Rectangle(keyBoard[key].X, keyBoard[key].Y, 12 * multiplier, 42 * multiplier));
                while (!correct)
                {

                }

            }
        }
    }
}
