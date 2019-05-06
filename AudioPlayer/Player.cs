using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        private const int _maxVolume = 300;
        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if(value > _maxVolume)
                {
                    _volume = _maxVolume;
                }
                else if(value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        private bool Locked;
        private bool _playing;

        public bool Playing
        {
            get { return _playing; }
            private set
            {
                _playing = value;
            }
        }

        public Skin skin;
        public Player(Skin skin )
        {
            this.skin = skin;
        }
        private List<Song> songs = new List<Song>();
        public void Play(bool loop =false)
        {
            int repeat;
            repeat = loop == false ? 1 : songs.Count;
            for (int i = 0; i < repeat; i++)
            {
                if (songs[i].like == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (songs[i].like == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                //Console.WriteLine(songs[i].Title + " Genre-" + songs[i].Genre);
                skin.Clear();
                skin.Render(songs[i].Title + " Genre-" + songs[i].Genre);
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void VolumeUp()
        {
            Volume += 5;
            Console.WriteLine("Volume is: " + Volume);
        }

        public void VolumeDown()
        {
            Volume -= 5;
            Console.WriteLine("Volume is: " + Volume);
        }

        public void VolumeChange(int step)
        {
            Volume = step;
            Console.WriteLine("Volume is: " + Volume);
        }

        public void Lock()
        {
            Locked = true;
            Console.WriteLine("Плеер заблокирован");
        }

        public void UnLock()
        {
            Locked = false;
            Console.WriteLine("Плеер разблокирован");
        }

        public bool Stop()
        {
            if (Locked == false)
            {
                Playing = false;
                Console.WriteLine("Плеер остановлен");
            }
            return Playing;
        }

        public bool Start()
        {
            if(Locked == false)
            {
                Playing = true;
                Console.WriteLine("Плеер запущен");
            }
            return Playing;
        }

        public void Add(List<Song> songs)
        {
            this.songs = songs;
        }

        public void WriteLyrics(Song song)
        {
            song.Title = song.Title.Length > 13 ? song.Title.Remove(13)+" ..." : song.Title;
            //Console.WriteLine(song.Title);
            skin.Render(song.Title);
            if (song.Lyries!= null)
            {
                string[] massStringLyrics = song.Lyries.Split(';');
                for (int i = 0; i < massStringLyrics.Length; i++)
                {
                    //Console.WriteLine(massStringLyrics[i]);
                    skin.Render(massStringLyrics[i]);
                }
            }
            
        }

        public void GetSongData(Song song, ConsoleColor color)
        {
            var (title, minutes, seconds, artistName, album, year) = song;
            //Console.WriteLine($"Title - {title.TrimString()}");
            //Console.WriteLine($"Duration - {minutes}.{seconds}");
            //Console.WriteLine($"Artist - {artistName}");
            //Console.WriteLine($"Album - {album}");
            //Console.WriteLine($"Year - {year}");
            skin.Render($"Title - {title.TrimString()}");
            skin.Render($"Duration - {minutes}.{seconds}");
            skin.Render($"Artist - {artistName}");
            skin.Render($"Album - {album}");
            skin.Render($"Year - {year}");
        }

        public void FilterByGenre(List<Song> songs, Song.Genres fiterGenre)
        {
            var filterSongs = new List<Song>();
            for (int i = 0; i < songs.Count; i++)
            {
                Song.Genres genreSong = songs[i].Genre;
                if (fiterGenre == genreSong)
                {
                    filterSongs.Add(songs[i]);
                }
            }
            this.songs = filterSongs;
        }
    }
    static class MetodsSongs
    {
        public static List<Song> Shuffle(this List<Song> songs)
        {
            List<Song> songsNew = new List<Song>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < songs.Count; j += 3)
                {
                    songsNew.Add(songs[j]);
                }
            }
            return songs = songsNew;
        }

        public static List<Song> SortByTitle(this List<Song> songs)
        {
            var songsTitle = new List<string>();
            foreach (Song sng in songs)
            {
                string title = sng.Title;
                songsTitle.Add(title);
            }
            songsTitle.Sort();
            var sortedSongs = new List<Song>();
            for (int i = 0; i < songsTitle.Count; i++)
            {
                foreach (Song sng in songs)
                {
                    if (songsTitle[i] == sng.Title)
                    {
                        sortedSongs.Add(sng);
                    }
                }
            }
            return songs = sortedSongs;
        }

        public static string TrimString(this string str)
        {
            str = str.Length > 13 ? str.Remove(13) + " ..." : str;
            return str;
        }
    }
    abstract class Skin
    {
      public abstract void Clear();
      public abstract void Render(string text);
    }
    class ClassicSkin: Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }
        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
    class ColorSkin:Skin
    {
        public ConsoleColor colorText;
        public ColorSkin(ConsoleColor color)
        {
            this.colorText = color;
        }
        public override void Clear()
        {
            Console.Clear();
        }
        public override void Render(string text)
        {
            Console.ForegroundColor = colorText;
            Console.WriteLine(text);
        }
    }
    class RandomSkin:Skin
    {
        public override void Clear()
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                Console.Write((char)058D);
            }
            Console.WriteLine();
        }
        public override void Render(string text)
        {
            Random rand = new Random();
            Console.ForegroundColor =(ConsoleColor)rand.Next(0, 15);
            Console.WriteLine(text);

        }
    }
}
