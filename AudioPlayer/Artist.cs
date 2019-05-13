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
        public string Name { get;set; }
        private string Nickname { get; set; }
        private string Country { get; set; }
        
        public Artist()
        {
            Name = "unknown_artist";
        }
        public Artist(string name)
        {
            Name = name;
        }
    }
}
