using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Song: PlayingItem<Song>
    {
        public Artist Artist;
        public Album Album { get; set; }
        public string Lyries;
        public GenresSong Genre;
        public int Year { get; set; }

        public void Deconstruct(out string title, out int minutes, out int seconds, out string artistName,
            out string album, out int year)
        {
            title = Title;
            minutes = Duration / 60;
            seconds = Duration % 60;
            artistName = Artist?.Name;
            album = Album?.Name;
            year = Year;

        }
    }
    public enum GenresSong
    {
        None = 0,
        Rock = 1,
        Pop = 2,
        Metal = 3,
        Post_Hardcore = 4
    }
}
