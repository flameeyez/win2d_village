using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.UI;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win2d_village
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Sprite> Sprites = new List<Sprite>();
        int nCurrentSprite = 0;
        Stopwatch sDraw, sUpdate;

        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            KeysDown.Remove(args.VirtualKey);
        }

        HashSet<VirtualKey> KeysDown = new HashSet<VirtualKey>();

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (!KeysDown.Contains(args.VirtualKey))
            {
                KeysDown.Add(args.VirtualKey);
            }
        }

        private void gridMain_PointerReleased(object sender, PointerRoutedEventArgs e) { }
        private void gridMain_PointerMoved(object sender, PointerRoutedEventArgs e) { }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            sDraw = Stopwatch.StartNew();

            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(args);
            }

            sDraw.Stop();

            args.DrawingSession.FillRectangle(new Rect(1690, 0, 200, 60), Colors.CornflowerBlue);
            if (sDraw != null) { args.DrawingSession.DrawText("Draw: " + sDraw.ElapsedMilliseconds.ToString() + "ms", new Vector2(1700, 10), Colors.White); }
            if (sUpdate != null) { args.DrawingSession.DrawText("Update: " + sUpdate.ElapsedMilliseconds.ToString() + "ms", new Vector2(1700, 30), Colors.White); }
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            sUpdate = Stopwatch.StartNew();

            foreach (Sprite sprite in Sprites)
            {
                sprite.Update(args);
            }

            sUpdate.Stop();

            // Sprites[nCurrentSprite].HandleKeyboard(KeysDown);
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            CanvasBitmap characterMap = await CanvasBitmap.LoadAsync(sender, "img\\characters.png");

            for (int i = 0; i < 5000; i++)
            {
                int x = Statics.Random.Next(40) * 64;
                int y = Statics.Random.Next(20) * 64;
                Sprites.Add(new Sprite(characterMap, 64, new Point(x, y)));
            }
        }
    }
}
