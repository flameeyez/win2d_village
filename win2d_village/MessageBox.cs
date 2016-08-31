using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace win2d_village {
    class MessageBox {
        public Vector2 Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Color BackgroundColor { get; set; }

        public List<string> Strings = new List<string>();

        private Rect BackgroundRect;
        private Rect StringRect;
        private double StringPadding = 10;

        public MessageBox(Vector2 position, double width, double height, Color backgroundColor) {
            Position = position;
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;

            BackgroundRect = new Rect(position.X, position.Y, width, height);
            StringRect = new Rect(position.X + StringPadding, position.Y + StringPadding, width - StringPadding * 2, height - StringPadding * 2);
        }

        internal void Draw(CanvasAnimatedDrawEventArgs args) {
            DrawBackground(args);
            DrawBorder(args);
            DrawCurrentString(args);
        }

        private void DrawBackground(CanvasAnimatedDrawEventArgs args) {
            if (BackgroundRect != null) { args.DrawingSession.FillRectangle(BackgroundRect, BackgroundColor); }
        }

        private void DrawBorder(CanvasAnimatedDrawEventArgs args) {

        }

        private void DrawCurrentString(CanvasAnimatedDrawEventArgs args) {
            if (Strings.Count > 0) {
                args.DrawingSession.DrawText(Strings[0], StringRect, Colors.White, Statics.MessageBoxTextFormat);
            }
        }

        internal void Update(CanvasAnimatedUpdateEventArgs args) {

        }
    }
}
