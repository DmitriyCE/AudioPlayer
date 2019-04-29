using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Song
    {
        public enum Genres
        {
            None = 0,
            Rock = 1,       
            Pop= 2,
            Metall = 3,
            Post_Hardcore = 4     
        }

        public int Duration;
        public string Title;
        public string Path;
        public string Lyries;
        public Genres Genre;
        public bool? like = null;
        public bool Playing { get; set; }
        public void Like()
        {
            like = true;
        }

        public void Dislike()
        {
            like = false;
        }
        public void Deconstruct(out string title, out int minutes, out int seconds, out string artistName,
            out string album, out int year)
        {
            title = Title;
            minutes = Duration / 60;
            seconds = Duration % 60;
            artistName = Artist.Name;
            album = Album.Name;
            year = Album.Year;
        }
        public Artist Artist;
        public Album Album { get; set; }
        private Playlist[] Playlist;

    }
}
