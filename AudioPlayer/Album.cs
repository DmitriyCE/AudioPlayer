﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Album
    {
        public Song Song;
        public string Name;
        private string Path;
        public int Year;

        public Album()
        {
            this.Name = "Unknown Album";
        }
        public Album(string Name)
        {

        }
    }
}
