using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    static class Sorted
    {
        public static List<T> SortByTitle<T>(this List<T> items) where T:PlayingItem<T>
        {
            List<string> itemTitle = new List<string>();
            List<T> sortetItems = new List<T>();
            foreach (T item  in items)
            {
                string title = item.Title;
                itemTitle.Add(title);
            }
            itemTitle.Sort();
            var sortedSongs = new List<Song>();
            for (int i = 0; i < itemTitle.Count; i++)
            {
                foreach (T item in items)
                {
                    if (itemTitle[i] == item.Title)
                    {
                        sortetItems.Add(item);
                    }
                }
            }
            return sortetItems;
        }
    }
}
