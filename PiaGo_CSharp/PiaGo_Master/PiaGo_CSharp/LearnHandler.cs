using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using Midi;
using System.Drawing;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace PiaGo_CSharp 
{
    class LearnHandler // WARNING THE SONGLINE READER IS COMPENSATING FOR THE KEY IN WHICH BROTHER JAKOB IS WRITTEN!
    {
        #region properties
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
        Thread previewThread;
        private MetroButton LearnSongBtn;
        private MetroButton PreviewSongBtn;
        delegate void SetTextCallback(string text);
        #endregion properties


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ns">Notescheduler handles all the code for playing music</param>
        /// <param name="_Keyboard">Keyboard to draw the keyboard</param>
        /// <param name="_canvas">Canvas needed to draw and fill in the colors</param>
        public LearnHandler(NoteScheduler ns, List<Key> _Keyboard, System.Windows.Forms.Panel _canvas, MetroButton _learnSongBtn, MetroButton _previewSongBtn)
        {
            noteScheduler = ns;
            MidiFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "MidiTextFiles");
            keyBoard = _Keyboard;
            canvas = _canvas;
            LearnSongBtn = _learnSongBtn;
            PreviewSongBtn = _previewSongBtn;
            //songlines = File.ReadAllLines(Path.Combine(MidiFileDirectory, "SimpleBrotherJabok.txt"));
        }

        /// <summary>
        ///             ///DUMMYSYSTEM, TO CHANGE
        /// Select the song to learn and preview
        /// </summary>
        /// <param name="song"></param>
        public void SelectSong(string song)
        {

            chosenSong = song;
            string songpath = Path.Combine(MidiFileDirectory, "SimpleBrotherJakob.txt"); //edit songpath
            songpath = new Uri(songpath).LocalPath;
            songlines = File.ReadAllLines(songpath);
            Console.WriteLine("Brother Jakob selected");
        }

        private void SetPreviewText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.PreviewSongBtn.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPreviewText);
                PreviewSongBtn.Invoke(d, new object[] { text });
            }
            else
            {
                this.PreviewSongBtn.Text = text;
            }
        }
        public void PreviewSong()
        {
            
            if (previewing)
            {
                noteScheduler.StopAll();
                previewing = false;
            }
            else
            {
                if (songlines != null)
                {
                    Console.WriteLine("Scheduling notes");
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
                    //buttontext = "Stop Preview";
                    SetPreviewText("Stop Preview");
                    //PreviewSongBtn.Text = "Stop Preview";
                }
                else { Console.WriteLine("No songlines found"); }
            }
            //SetPreviewText("Preview song");
            Console.WriteLine("previewthread ended");
        }
        public void PreviewHandler()
        {
            if (previewing == false)
            {
                previewThread = new Thread(PreviewSong);
                previewThread.Start();
                Console.WriteLine("previewThread started");
                //PreviewSongBtn.Text = "Stop Preview";
            }
            else
            {
                previewThread.Abort();
                previewThread = null;
                Learning = false;
                Console.WriteLine("previewThread stopped");
                PreviewSongBtn.Text = "Preview Song";
                foreach (Key key in keyBoard)
                {
                    key.Clear();
                }
                canvas.Invalidate(new Rectangle(keyBoard[1].X, keyBoard[1].Y, 12 * multiplier, 42 * multiplier));

            }
        }
        #region Learn-a-song methods
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

                }
                canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));

            }
        }
        #endregion
    }
}
