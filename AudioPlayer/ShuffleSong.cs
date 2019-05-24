using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    static class ShuffleSong
    {
        public static List<T> Shuffle<T>(this List<T> items)
        {
            List<T> itemsNew = new List<T>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < items.Count; j += 3)
                {
                    itemsNew.Add(items[j]);
                }
            }
            return itemsNew;
        }
    }
}
