using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class ColorSkin : Skin
    {
        public ConsoleColor colorText;
        public ColorSkin(ConsoleColor color)
        {
            this.colorText = color;
        }
        public override void Clear()
        {
            Console.Clear();
        }
        public override void Render(string text)
        {
            Console.ForegroundColor = colorText;
            Console.WriteLine(text);
        }
    }
}
