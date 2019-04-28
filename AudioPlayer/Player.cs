﻿using System;
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
                Console.WriteLine(songs[i].Title + " Genre-" + songs[i].Genre);
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
            Console.WriteLine(song.Title);
            if (song.Lyries!= null)
            {
                string[] massStringLyrics = song.Lyries.Split(';');
                for (int i = 0; i < massStringLyrics.Length; i++)
                {
                    Console.WriteLine(massStringLyrics[i]);
                }
            }
            
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

}
