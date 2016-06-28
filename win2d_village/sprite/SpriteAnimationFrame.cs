using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win2d_village
{
    class SpriteAnimationFrame
    {
        public int X { get; set; }
        public int Y { get; set; }

        private SpriteAnimationFrame() { }
        public SpriteAnimationFrame(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
