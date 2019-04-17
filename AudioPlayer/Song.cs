using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Song
    {
        public int Duration;
        public string Title;
        public string Path;
        public string Lyries;
        public string Genre;

        public Artist Artist;
        Album[] Album;
        Playlist[] Playlist;
    }
}
