using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class PlayerEventsArgs:EventArgs
    {
        public string Message { get; set; }
    }
}
