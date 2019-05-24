using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Album
    {
        public Song Song;
        public string Name { get; set; }
        private string Path;
        public int Year { get; set; }

        public Album()
        {
            this.Name = "Unknown Album";
        }
        public Album(string  name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
