using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Artist
    {
        public Band[] Bands;
        public Song Song;
        public string Name;
        string Nickname;
        string Country;
        
        public Artist()
        {
            this.Name = "unknown_artist";
        }
        public Artist(string name)
        {
           
        }
    }
}
