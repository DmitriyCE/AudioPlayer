using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class VideoPlayer : GenericPlayer<Video, GenreVideo>
    {
        public VideoPlayer(Skin skin) : base(skin)
        {
        }
        public override void Play(List<Video> items, bool loop)
        {
            foreach (Video video in items)
            {
                if (loop)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        video.Playing = true;
                        ItemList(items);
                    }
                }
                else
                {
                    video.Playing = true;
                    ItemList(items);
                    video.Playing = false;
                    System.Threading.Thread.Sleep(video.Duration + 2000);
                }
            }
        }
        public override void ItemList(List<Video> items)
        {
            foreach (Video video in items)
            {
                if (video.Playing)
                {
                    ItemData(video, ConsoleColor.Blue);
                }
                else
                {
                    if (video.like.HasValue)
                    {
                        if (video.like == true)
                        {
                            ItemData(video, ConsoleColor.Red);
                        }
                        else
                        {
                            ItemData(video, ConsoleColor.Green);
                        }
                    }
                    else ItemData(video, ConsoleColor.White);
                }
            }
        }
        public override void ItemData(Video item, ConsoleColor color)
        {
            var (title, minutes, seconds, producerName) = item;
            Skin.Render($"Title - {title.TrimString()}");
            Console.ResetColor();
            Skin.Render($"Duration - {minutes}.{seconds}");
            Skin.Render($"Artist - {producerName}");
            Console.WriteLine();
        }
        public override List<Video> FilterByGenre(List<Video> items, GenreVideo fiterGenre)
        {
            List<Video> filterVideo = new List<Video>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Genre == fiterGenre)
                {
                    filterVideo.Add(items[i]);
                }
            }
            return filterVideo;
        }
    }
}

