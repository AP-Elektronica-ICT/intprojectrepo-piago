using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

namespace PiaGo_CSharp
{
    public class MidiFileHandler
    {
        public Dictionary<string, string> songlist;
        string MidiFileDirectory;
        string FileList;
        string songlistpath;
        string[] songlistlines;
        public MidiFileHandler()
        {
            MidiFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "MidiTextFiles");
            FileList = Path.Combine(MidiFileDirectory, "FileList.txt");
            songlistpath = new Uri(FileList).LocalPath;
            songlistlines = File.ReadAllLines(songlistpath);
            songlist = new Dictionary<string, string>();
            foreach (string song in songlistlines)
            {
                string[] songinfo = song.Split(';');
                songlist.Add(songinfo[0], songinfo[1]);
            }
        }
        public List<string> GetSongNames()
        {
            List<string> SongNames = new List<string>();
            foreach (KeyValuePair<string,string> item in songlist) 
            {
                SongNames.Add(item.Key);
            }
            return SongNames;
        }
        public string[] GetSongFile(string songName)
        {
            string[] songlines;
            string songFile = songlist[songName];
            string songFilePath = Path.Combine(MidiFileDirectory, songFile);
            songFilePath = new Uri(songFilePath).LocalPath;
            songlines = File.ReadAllLines(songFilePath);
            return songlines;
        }
    }
}
