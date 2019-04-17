using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AudioPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int min;
            int max;
            int total=0;
            var player = new Player();
            CreateDefaultSong();
            CreateDefaultSong("name");
            CreateDefaultSong("name", 300, "path", "lyries", "genre");
            player.Add(CreateDefaultSong());
            player.Add(CreateDefaultSong("name1"), CreateDefaultSong("name2"));
            Song[] songs = new Song[8];
            for (int i = 0; i < songs.Length; i++)
            {
                var song=CreateDefaultSong("name" + (i + 1));
                songs[i] = song;
            }
            player.Add(songs);
            AddArtist();
            AddArtist("name artist");
            AddAlbum();
            AddAlbum(2003, "name album");
            AddAlbum(name:"name album",year:2009);
            //var songs = CreateSongs(out min, out max, ref total);
            //player.Songs = songs;
            // WriteLine($"Total duration: {total}, max duration: {max}, min duration{min}");
            //player.Add(songs[1],songs[2]);
            while (true)
            {
                switch (ReadLine())
                {
                    case "Up":
                        {
                            player.VolumeUp();
                        }
                        break;

                    case "Down":
                        {
                            player.VolumeDown();
                        }
                        break;

                    case "P":
                        {
                            player.Play();
                            break;
                        }
                    case "Stop":
                        {
                            player.Stop();
                            break;
                        }
                    case "Start":
                        {
                            player.Start();
                            break;
                        }

                    case "L":
                        {
                            player.Lock();
                            break;
                        }
                    case "UnL":
                        {
                            player.UnLock();
                            break;
                        }
                    case "VolChang":
                        {
                            WriteLine("Введите значение громкости");
                            int step = Convert.ToInt32(ReadLine());
                            player.VolumeChange(step);
                            break;
                        }
                }
            }
        }
        private static Song[] CreateSongs(out int min, out int max, ref int total)
        {
            Random rand = new Random();
            Song[] songs = new Song[5];
            int MinDuration = 0;
            int MaxDuration = 0;
            int TotalDuration = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                var song1 = new Song();
                song1.Title = "Song" + (i+1);
                song1.Duration = rand.Next(501);
                song1.Artist = new Artist();
                songs[i] = song1;
                if (i == 0)
                {
                    MinDuration = song1.Duration;
                }
                TotalDuration += song1.Duration;
                MinDuration = song1.Duration < MinDuration? song1.Duration : MinDuration;
                MaxDuration = song1.Duration > MaxDuration? song1.Duration : MaxDuration; 
            }
            total = TotalDuration;
            min = MinDuration;
            max = MaxDuration;
            return songs;
        }

        public static Song CreateDefaultSong()
        {
            var song = new Song();
            song.Duration = 300;
            song.Title = "song";
            song.Path = "path";
            song.Lyries = "lyries";
            song.Genre = "genre";
            return song;
        }
        public static Song CreateDefaultSong(string Name)
        {
            var song = new Song();
            CreateDefaultSong();
            song.Title = Name;
            //song.Duration = 300;
            //song.Path = "path";
            //song.Lyries = "lyries";
            //song.Genre = "genre";
            return song;
        }
        public static Song CreateDefaultSong(string name, int duration, string path,string lyries, string genre)
        {
            var song = new Song();
            song.Title = name;
            song.Duration = duration;
            song.Path = path;
            song.Lyries = lyries;
            song.Genre = genre;
            return song;
        }
        public static Artist AddArtist(string name= "Unknown Artist")
        {
            var artist = new Artist();
            artist.Name = name;
            WriteLine(artist.Name);
            return artist;
        }
        public static Album AddAlbum(int year=0, string name = "Unknown Album")
        {
            var album = new Album();
            album.Name = name;
            album.Year = year;
            WriteLine($"Album name:{album.Name}, album year: {album.Year}");
            return album;
        }

    }
}

