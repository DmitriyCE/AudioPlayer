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
            var song1 = new Song();
            song1.Title = "Дым сигарет с ментолом";
            song1.Duration = 300;
            song1.Artist = new Artist
            {
                Name = "Нэнси"
            };
            var song2 = new Song();
            song2.Title = "Anaconda";
            song2.Duration = 270;
            song2.Artist = new Artist
            {
                Name = "Nicki Minaj"
            };
            var player = new Player();
            player.Songs = new[] { song1, song2 };

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
            //player.Playing = true; //-- playing ptivate
            ReadLine();
        }
    }
}
