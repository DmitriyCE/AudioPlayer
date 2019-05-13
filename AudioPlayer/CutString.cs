using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    static class CutString
    {
        public static string TrimString(this string str)
        {
            str = str.Length > 13 ? str.Remove(13) + " ..." : str;
            return str;
        }
    }
}
