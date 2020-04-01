using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using Midi;
using System.Drawing;

namespace PiaGo_CSharp 
{
    class LearnHandler // WARNING THE SONGLINE READER IS COMPENSATING FOR THE KEY IN WHICH BROTHER JAKOB IS WRITTEN!
    {
        NoteScheduler noteScheduler;
        string MidiFileDirectory;
        string[] songlines; 
        string chosenSong;
        public Boolean previewing = false;
        List<Key> keyBoard;
        public int LastKeyPlayed = 0;
        System.Windows.Forms.Panel canvas;
        int multiplier = 4;
        public int KeyToPlay = 50;
        public Boolean Learning = false;
        public string LearnBtnText = "Learn Song";
        Thread learnThread;

        public LearnHandler(NoteScheduler ns, List<Key> _Keyboard, System.Windows.Forms.Panel _canvas)
        {
            noteScheduler = ns;
            MidiFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "MidiTextFiles");
            keyBoard = _Keyboard;
            canvas = _canvas;
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
                        Pitch pitch = (Pitch)Convert.ToInt32(songinfo[0])+5; //THE BROTHER JAKOB FILE IS IN THE WRONG KEY!!!!
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
            if (songlines != null)
            {
                Learning = true;
                foreach (string songline in songlines)
                {
                    LastKeyPlayed = 50;
                    string[] songinfo = songline.Split(' ');
                    KeyToPlay = Convert.ToInt32(songinfo[0]) - 48; //MODIFIED FOR BROTHER JAKOB IN WRONG KEY, IS NORMALLY 53
                    bool correct = false;
                    keyBoard[KeyToPlay].SetKeyFill(KeyColor.GREEN);
                    canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                    while (!correct)
                    {
                        if (LastKeyPlayed == KeyToPlay)
                        {
                            correct = true;
                        }
                    }

                }
            }
            Learning = false;
            LearnBtnText = "Learn Song";
            learnThread = null;
        }
        public void LearnSongHandler()
        {
            if (Learning == false)
            {
                learnThread = new Thread(LearnSong);
                learnThread.Start();
                Console.WriteLine("Thread started");
                Learning = true;
                LearnBtnText = "Stop Learning";
            }
            else
            {
                learnThread.Abort();
                learnThread = null;
                Learning = false;
                LearnBtnText = "Learn Song";
                foreach(Key key in keyBoard)
                {
                    key.Clear();
                    canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                }

            }
        }
    }
}
