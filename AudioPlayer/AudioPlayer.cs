using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class AudioPlayer: GenericPlayer<Song, GenresSong>
    {
        public AudioPlayer(Skin skin) : base(skin)
        {
        }
        public override void ItemData(Song item, ConsoleColor color)
        {

            var (title, minutes, seconds, artistName, album) = item;
            Skin.Render($"Title - {title.TrimString()}");
            Skin.Render($"Duration - {minutes}.{seconds}");
            Skin.Render($"Artist - {artistName}");
            Skin.Render($"Album - {album}");
            Console.WriteLine();
        }
        public override void Play(List<Song> items, bool loop)
        {
            foreach (Song song in items)
            {
                if (loop)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        song.Playing = true;
                        ItemList(items);
                    }
                }
                else
                {
                    song.Playing = true;
                    ItemList(items);
                    song.Playing = false;
                    System.Threading.Thread.Sleep(song.Duration + 2000);
                }
            }
        }
        public override void ItemList(List<Song> items)
        {
            foreach (Song song in items)
            {
                if (song.Playing)
                {
                    ItemData(song, ConsoleColor.Blue);
                }
                else
                {
                    if (song.like.HasValue)
                    {
                        if (song.like == true)
                        {
                            ItemData(song, ConsoleColor.Red);
                        }
                        else
                        {
                            ItemData(song, ConsoleColor.Green);
                        }
                    }
                    else ItemData(song, ConsoleColor.White);
                }
            }
        }
        public override List<Song> FilterByGenre(List<Song> items, GenresSong genre)
        {
            List<Song> filteredSongs = new List<Song>();
            foreach (Song song in items)
            {
                if (song.Genre == genre)
                {
                    filteredSongs.Add(song);
                }
            }
            return filteredSongs;
        }
        public void WriteLyrics(Song song)
        {
            song.Title = song.Title.TrimString();
            Skin.Render(song.Title);
            if (song.Lyries != null)
            {
                string[] massStringLyrics = song.Lyries.Split(';');
                for (int i = 0; i < massStringLyrics.Length; i++)
                {
                    Skin.Render(massStringLyrics[i]);
                }
            }

        }
    }
}
