using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public abstract class PlayingItem<T>
    {
        public int Duration;
        public string Title;
        public string Path;
        public bool? like = null;
        public bool Playing { get; set; }

        public static void Like(PlayingItem<T> item)
        {
            item.like = true;
        }
        public static void Dislike(PlayingItem<T> item)
        {
            item.like = false;
        }
    }
}
