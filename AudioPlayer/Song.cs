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

        public void Like()
        {
            like = true;
        }

        public void Dislike()
        {
            like = false;
        }

        public Artist Artist;
        private Album[] Album;
        private Playlist[] Playlist;
    }
}
