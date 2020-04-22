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
        public bool Previewing = false;
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

        #region methods to change buttons from threads
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

        private void SetLearnText(string text)
        {
            if (this.LearnSongBtn.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLearnText);
                LearnSongBtn.Invoke(d, new object[] { text });
            }
            else
            {
                this.LearnSongBtn.Text = text;
            }
        }
        #endregion

        #region Preview Song methods
        public void PreviewSong()
        {
             if (songlines != null) {
                Previewing = true;
                SetPreviewText("Stop Preview");
                Console.WriteLine("Scheduling notes");

                for (int i = 0; i < songlines.Length - 1; i++)
                {

                    string[] songinfo = songlines[i].Split(' ');  //[0] = Pitch, [1] = TimeStartStamp [2] = LengthOfNote
                    string[] songinfo2 = songlines[i + 1].Split(' ');
                    KeyToPlay = Convert.ToInt32(songinfo[0]) - 48;
                    Pitch pitch = (Pitch)Convert.ToInt32(songinfo[0]) + 5; //THE BROTHER JAKOB FILE IS IN THE WRONG KEY!!!!
                    
                    //Start note and visualize
                    keyBoard[KeyToPlay].SetKeyFill(KeyColor.YELLOW);
                    canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                    noteScheduler.NoteOn(pitch);
                    Thread.Sleep(Convert.ToInt32(songinfo[2])*3); //*3 for breathing room

                    //Stop note and visualize
                    noteScheduler.NoteOff(pitch);
                    keyBoard[KeyToPlay].Clear();
                    canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                    //Let some time between notes
                    Thread.Sleep(((Convert.ToInt32(songinfo2[1]) - Convert.ToInt32(songinfo[1])) - Convert.ToInt32(songinfo[2]))*3);
                    if (i == songlines.Length - 2)
                    {

                        KeyToPlay = Convert.ToInt32(songinfo2[0]) - 48;
                        pitch = (Pitch)Convert.ToInt32(songinfo2[0]) + 5;

                        keyBoard[KeyToPlay].SetKeyFill(KeyColor.YELLOW);
                        canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                        noteScheduler.NoteOn(pitch);
                        Thread.Sleep(Convert.ToInt32(songinfo2[2])*3);
                        noteScheduler.NoteOff(pitch);
                        keyBoard[KeyToPlay].Clear();
                        canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
                    }
                }
                SetPreviewText("Preview Song");
                    Previewing = false;
                }
                else { Console.WriteLine("No songlines found"); }

            Console.WriteLine("previewthread ended");
        }
        public void PreviewHandler()
        {
            if (Learning == true)
            {
                AbortThread(learnThread);
            }
            if (Previewing == false)
            {
                previewThread = new Thread(PreviewSong);
                previewThread.Start();
                Console.WriteLine("previewThread started");
            }
            else
            {
                AbortThread(previewThread);
            }
        }
        #endregion

        #region Learn-a-song methods
        public void LearnSong()
        {
            if (songlines != null)
            {
                Learning = true;
                SetLearnText("Stop Learning");
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
            SetLearnText("Learn Song");
        }
        public void LearnSongHandler()
        {
            if (Previewing == true)
            {
                AbortThread(previewThread);
            }
            if (Learning == false)
            {
                learnThread = new Thread(LearnSong);
                learnThread.Start();
                Console.WriteLine("LearnThread started");
            }
            else
            {
                AbortThread(learnThread);
            }
            
        }
        #endregion

        #region Abort Thread methods
        private void AbortThread(Thread thread)
        {
            thread.Abort();
            Console.WriteLine("Thread is stopped");
            thread = null;
            Learning = false; Previewing = false;
            PreviewSongBtn.Text = "Preview Song";
            LearnSongBtn.Text = "Learn Song";
            foreach (Key key in keyBoard)
            {
                key.Clear();
            }
            canvas.Invalidate(new Rectangle(keyBoard[KeyToPlay].X, keyBoard[KeyToPlay].Y, 12 * multiplier, 42 * multiplier));
            noteScheduler.StopAll();
        }

        public void AbortAllThreads()
        {
            if(learnThread != null) { AbortThread(learnThread); }
            if(previewThread != null) { AbortThread(previewThread); }
        }
        #endregion

    }

}
