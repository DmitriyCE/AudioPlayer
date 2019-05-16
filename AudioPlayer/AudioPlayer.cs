using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TagLib;
using System.Xml.Serialization;

namespace AudioPlayer
{
    class AudioPlayer : GenericPlayer<Song, GenresSong>
    {
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
            foreach (var song in songs)
            {
                using (FileStream fs = new FileStream("i:/CS/song/myPlaylist.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, song);
                }
            }
            Console.WriteLine("песни сериализованы");
        }
        public static void LoadPlaylist()
        {
            Console.WriteLine("Укажите путь к сохраненному плэйлисту");
            string path = Console.ReadLine();
            XmlSerializer formatter = new XmlSerializer(typeof(Song[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Song[] songs = (Song[])formatter.Deserialize(fs);
                foreach (var song in songs)
                {
                    Add(song);
                }
            }
            Console.WriteLine("песни десериализованы");

        }
    }
}
