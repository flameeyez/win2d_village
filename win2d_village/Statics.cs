using Microsoft.Graphics.Canvas.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win2d_village
{
    static class Statics
    {
        public static Random Random;
        public static CanvasTextFormat MessageBoxTextFormat = new CanvasTextFormat();

        static Statics()
        {
            Random = new Random(DateTime.Now.Millisecond);

            MessageBoxTextFormat.FontFamily = "Arial";
            MessageBoxTextFormat.FontSize = 12;
            MessageBoxTextFormat.WordWrapping = CanvasWordWrapping.Wrap;
        }
    }
}
