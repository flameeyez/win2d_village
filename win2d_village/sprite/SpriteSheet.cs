using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win2d_village
{
    class SpriteSheet
    {
        private CanvasBitmap _image;
        public CanvasBitmap Image { get { return _image; } }

        private int _resolution;
        public int Resolution { get { return _resolution; } }

        private SpriteSheet() { }
        public SpriteSheet(CanvasBitmap image, int resolution)
        {
            _image = image;
            _resolution = resolution;
        }
    }
}
