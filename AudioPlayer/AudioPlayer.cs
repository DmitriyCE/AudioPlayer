using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TagLib;
using System.Xml.Serialization;
using System.Media;

namespace AudioPlayer
{
    class AudioPlayer : GenericPlayer<Song, GenresSong>, IDisposable
    {
        private bool disposed = false;
        public void Dispose()
        {

        }
        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                {
                    soundPlayer.Dispose();
                    soundPlayer = null;
                }
                disposed = true;
            }
        }
        private SoundPlayer soundPlayer = new SoundPlayer();
        public AudioPlayer(Skin skin) : base(skin)
        {
        }
        public override void ItemData(Song item, ConsoleColor color)
        {

            var (title, minutes, seconds, artistName, album, year) = item;
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
                if (Locked != true && items.Count>0)
                {
                    song.Playing = true;
                }
                if (song.Playing == true)
                {
                    soundPlayer.SoundLocation = song.Path;
                    soundPlayer.PlaySync();
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
                            soundPlayer.PlaySync();
                            //ItemData(song, ConsoleColor.Red);
                        }
                        else
                        {
                            soundPlayer.PlaySync();
                            //ItemData(song, ConsoleColor.Green);
                        }
                    }
                    else soundPlayer.PlaySync();//ItemData(song, ConsoleColor.White);
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
        public static void Clear()
        {
            Items = new List<Song>();
            Console.WriteLine("Список очищен");
        }
        public static void Load(string path)
        {
            var dirinfo = new DirectoryInfo(path);
            var filemass = dirinfo.GetFiles();
            for (int i = 0; i < filemass.Length; i++)
            {
                var audioFile = TagLib.File.Create(filemass[i].FullName);
                string title = filemass[i].Name;
                string nameArtist = null;
                foreach (var item in audioFile.Tag.Artists)
                {
                    nameArtist += $" {item}";
                }
                nameArtist = nameArtist is null ? "NoArtist" : nameArtist;
                int year = (int)audioFile.Tag.Year;
                int duration = (int)audioFile.Properties.Duration.TotalMinutes;
                string genre = audioFile.Tag.FirstGenre;
                genre = genre is null ? "None" : genre;
                string nameAlbum = audioFile.Tag.Album;
                nameAlbum = nameAlbum is null ? "NoAlbum" : nameAlbum;
                var song = CreateSong(title, nameArtist, duration, (GenresSong)Enum.Parse(typeof(GenresSong), genre), year, nameAlbum);
                song.Path = filemass[i].FullName;
                Add(song);
            }

        }
        public static Song CreateSong(string title, string nameArtist, int duration, GenresSong genresSong, int year, string nameAlbum)
        {
            var song = new Song();
            song.Title = title;
            song.Artist = Program.AddArtist(nameArtist);
            song.Duration = duration;
            song.Genre = genresSong;
            song.Album = Program.AddAlbum(year, nameAlbum);
            song.Year = year;
            return song;
        }
        public static void SaveAsPlaylist(List<Song> songs)
        {
            XmlSerializer formatter = new XmlSerializer(songs.GetType());
            using (FileStream fs = new FileStream("myPlaylist.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, songs);
            }
        Console.WriteLine("песни сериализованы");
        }
        public static void LoadPlaylist()
        {
            Console.WriteLine("Укажите путь к сохраненному плэйлисту");
            string path = Console.ReadLine();
            XmlSerializer formatter = new XmlSerializer(typeof(Song[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Song> songs = (List<Song>)formatter.Deserialize(fs);
                
                foreach (var song in songs)
                {
                    Add(song);
                }
            }
            Console.WriteLine("песни десериализованы");

        }
        ~AudioPlayer()
        {
            Dispose(false);
        }
}
}
