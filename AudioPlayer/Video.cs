using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Video : PlayingItem<Video>
    {
        public string Subtitels { get; set; }
        public Artist Producer { get; set; }
        public GenreVideo Genre { get; set; }



        public void Deconstruct(out string title, out int minutes, out int seconds, out string producerName)
        {
            title = Title;
            minutes = Duration / 60;
            seconds = Duration % 60;
            producerName = Producer.Name;
        } 
    }
    public enum GenreVideo
    {
        Science,
        Adventure,
        Documentary,
        Action,
        Drama
    }

}
