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
        bool Locked;
        private bool _playing;
        public bool Playing
        {
            get { return _playing; }
            private set
            {
                _playing = value;
            }
        }
        public Song[] Songs;

        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].Title);
                System.Threading.Thread.Sleep(3000);
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
        public void Add(params Song[] songs)
        {
        }
    }
}
