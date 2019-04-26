using System;
using System.Collections;
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
            int total = 0;
            var player = new Player();
            Random rand = new Random();

            List<Song> songs = new List<Song>();
            for (int i = 1; i < 8; i++)
            {
                Song.Genres genre = Song.Genres.None;
                if (i == 1)
                {
                    genre = Song.Genres.Rock;
                }
                else if (i == 2)
                {
                    genre = Song.Genres.Pop;
                }
                else if (i == 3)
                {
                    genre = Song.Genres.Metall;
                }
                else if (i == 4)
                {
                    genre = Song.Genres.Post_Hardcore;
                }
                var song = CreateDefaultSong($"song {i}", 10+i*2, genre);
                
                songs.Add(song);
               
            }
            player.Add(songs);
            player.FilterByGenre(songs, Song.Genres.Post_Hardcore);

            //player.SortByTitle(songs);
            //player.Shuffle(songs);

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
                            player.Play(true);
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
            song.Genre = Song.Genres.Metall;
            return song;
        }

        public static Song CreateDefaultSong(string Name, bool like)
        {
            Random rand = new Random();
            var song = new Song();
            //CreateDefaultSong();
            song.Title = Name;
            song.Artist = new Artist();
            song.like = like;
            song.Duration = rand.Next(500);
            song.Genre = Song.Genres.Metall;
            return song;
        }

        public static Song CreateDefaultSong(string name, int duration, Song.Genres genre)
        {
            var song = new Song();
            song.Title = name;
            song.Duration = duration;
            song.Path = "path";
            song.Lyries = "lyries";
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

