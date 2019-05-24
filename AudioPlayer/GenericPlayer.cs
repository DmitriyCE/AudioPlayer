using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioPlayer
{
    public abstract class GenericPlayer<T,TGenre>
    {
        public delegate void PlayerMessageHandler(GenericPlayer<T, TGenre> player, PlayerEventsArgs args);
        public event PlayerMessageHandler VolumeChangedEvent;
        public event PlayerMessageHandler PlayerLockedEvent;
        public event PlayerMessageHandler PlayerUnLockedEvent;
        public event PlayerMessageHandler PlayerStoppedEvent;
        public Skin Skin { get; set; }
        public static List<T> Items { get; set; } = new List<T>();
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
                if (value > _maxVolume)
                {
                    _volume = _maxVolume;
                }
                else if (value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public bool Locked { get; set; }
        private bool _playing;

        public bool Playing
        {
            get { return _playing; }
            private set
            {
                _playing = value;
            }
        }

        public GenericPlayer(Skin skin)
        {
            Skin = skin;
        }

        public abstract void Play(List<T> items, bool loop = false);

        public abstract void ItemList(List<T> items);
        public abstract void ItemData(T item, ConsoleColor color);
        public abstract List<T> FilterByGenre(List<T> items, TGenre genre);

        public void VolumeUp()
        {
            Volume += 5;
            VolumeChangedEvent(this, new PlayerEventsArgs() { Message = "Volume is: " + Volume });
        }
        public void VolumeDown()
        {
            Volume -= 5;
            VolumeChangedEvent(this, new PlayerEventsArgs() { Message = "Volume is: " + Volume});
        }

        public void VolumeChange(int step)
        {
            Volume = step;
            VolumeChangedEvent(this, new PlayerEventsArgs() { Message = "Volume is: " + Volume });
        }

        public void Lock()
        {
            Locked = true;
            PlayerLockedEvent(this, new PlayerEventsArgs() { Message = "Player locked" });
        }

        public void UnLock()
        {
            Locked = false;
            PlayerUnLockedEvent(this, new PlayerEventsArgs() { Message = "Player unlocked" });
        }

        public bool Stop()
        {
            if (Locked == false)
            {
                Playing = false;
                PlayerStoppedEvent(this, new PlayerEventsArgs() { Message = "Player stopped" });
            }
            return Playing;
        }
        public static void Add(params T[] items)
        {
            foreach (T item in items)
            {
                Items.Add(item);
            }
        }

    }
}
