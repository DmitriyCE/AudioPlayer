﻿using System;
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
            var songs = CreateSongs(out min, out max, ref total);
            player.Songs = songs;
            WriteLine($"Total duration: {total}, max duration: {max}, min duration{min}");
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
    }
}

