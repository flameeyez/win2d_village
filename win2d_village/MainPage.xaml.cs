using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win2d_village
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Sprite sprite;

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
            if(!KeysDown.Contains(args.VirtualKey))
            {
                KeysDown.Add(args.VirtualKey);
            }
        }

        private void gridMain_PointerReleased(object sender, PointerRoutedEventArgs e)
        {

        }

        private void gridMain_PointerMoved(object sender, PointerRoutedEventArgs e)
        {

        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            sprite.Draw(args);
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            sprite.Update(KeysDown, args);
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            CanvasBitmap characterSource;
            ChromaKeyEffect characterMap;

            characterSource = await CanvasBitmap.LoadAsync(sender, "img\\characters.png");
            characterMap = new ChromaKeyEffect();
            characterMap.Color = Color.FromArgb(255, 255, 0, 255);
            characterMap.Source = characterSource;

            SpriteAnimationSet spriteAnimationSet = new SpriteAnimationSet(characterMap, 64);

            SpriteAnimation spellcastUp = new SpriteAnimation();
            spellcastUp.Frames.Add(new SpriteAnimationFrame(0, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(1, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(2, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(3, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(4, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(5, 0));
            spellcastUp.Frames.Add(new SpriteAnimationFrame(6, 0));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SPELLCAST_UP, spellcastUp);

            SpriteAnimation spellcastLeft = new SpriteAnimation();
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(0, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(1, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(2, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(3, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(4, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(5, 1));
            spellcastLeft.Frames.Add(new SpriteAnimationFrame(6, 1));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SPELLCAST_LEFT, spellcastLeft);

            SpriteAnimation spellcastDown = new SpriteAnimation();
            spellcastDown.Frames.Add(new SpriteAnimationFrame(0, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(1, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(2, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(3, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(4, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(5, 2));
            spellcastDown.Frames.Add(new SpriteAnimationFrame(6, 2));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SPELLCAST_DOWN, spellcastDown);

            SpriteAnimation spellcastRight = new SpriteAnimation();
            spellcastRight.Frames.Add(new SpriteAnimationFrame(0, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(1, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(2, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(3, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(4, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(5, 3));
            spellcastRight.Frames.Add(new SpriteAnimationFrame(6, 3));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SPELLCAST_RIGHT, spellcastRight);

            SpriteAnimation attackUp = new SpriteAnimation();
            attackUp.Frames.Add(new SpriteAnimationFrame(0, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(1, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(2, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(3, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(4, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(5, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(6, 4));
            attackUp.Frames.Add(new SpriteAnimationFrame(7, 4));
            spriteAnimationSet.Add(SPRITE_ANIMATION.ATTACK_UP, attackUp);

            SpriteAnimation attackLeft = new SpriteAnimation();
            attackLeft.Frames.Add(new SpriteAnimationFrame(0, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(1, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(2, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(3, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(4, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(5, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(6, 5));
            attackLeft.Frames.Add(new SpriteAnimationFrame(7, 5));
            spriteAnimationSet.Add(SPRITE_ANIMATION.ATTACK_LEFT, attackLeft);

            SpriteAnimation attackDown = new SpriteAnimation();
            attackDown.Frames.Add(new SpriteAnimationFrame(0, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(1, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(2, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(3, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(4, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(5, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(6, 6));
            attackDown.Frames.Add(new SpriteAnimationFrame(7, 6));
            spriteAnimationSet.Add(SPRITE_ANIMATION.ATTACK_DOWN, attackDown);

            SpriteAnimation attackRight = new SpriteAnimation();
            attackRight.Frames.Add(new SpriteAnimationFrame(0, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(1, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(2, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(3, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(4, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(5, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(6, 7));
            attackRight.Frames.Add(new SpriteAnimationFrame(7, 7));
            spriteAnimationSet.Add(SPRITE_ANIMATION.ATTACK_RIGHT, attackRight);

            SpriteAnimation walkUp = new SpriteAnimation();
            walkUp.Frames.Add(new SpriteAnimationFrame(1, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(2, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(3, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(4, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(5, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(6, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(7, 8));
            walkUp.Frames.Add(new SpriteAnimationFrame(8, 8));
            spriteAnimationSet.Add(SPRITE_ANIMATION.WALK_UP, walkUp);

            SpriteAnimation walkLeft = new SpriteAnimation();
            walkLeft.Frames.Add(new SpriteAnimationFrame(1, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(2, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(3, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(4, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(5, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(6, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(7, 9));
            walkLeft.Frames.Add(new SpriteAnimationFrame(8, 9));
            spriteAnimationSet.Add(SPRITE_ANIMATION.WALK_LEFT, walkLeft);

            SpriteAnimation walkDown = new SpriteAnimation();
            walkDown.Frames.Add(new SpriteAnimationFrame(1, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(2, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(3, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(4, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(5, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(6, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(7, 10));
            walkDown.Frames.Add(new SpriteAnimationFrame(8, 10));
            spriteAnimationSet.Add(SPRITE_ANIMATION.WALK_DOWN, walkDown);

            SpriteAnimation walkRight = new SpriteAnimation();
            walkRight.Frames.Add(new SpriteAnimationFrame(1, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(2, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(3, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(4, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(5, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(6, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(7, 11));
            walkRight.Frames.Add(new SpriteAnimationFrame(8, 11));
            spriteAnimationSet.Add(SPRITE_ANIMATION.WALK_RIGHT, walkRight);

            SpriteAnimation idleUp = new SpriteAnimation(loops:false);
            idleUp.Frames.Add(new SpriteAnimationFrame(0, 8));
            spriteAnimationSet.Add(SPRITE_ANIMATION.IDLE_UP, idleUp);

            SpriteAnimation idleLeft = new SpriteAnimation(loops:false);
            idleLeft.Frames.Add(new SpriteAnimationFrame(0, 9));
            spriteAnimationSet.Add(SPRITE_ANIMATION.IDLE_LEFT, idleLeft);

            SpriteAnimation idleDown = new SpriteAnimation(loops:false);
            idleDown.Frames.Add(new SpriteAnimationFrame(0, 10));
            spriteAnimationSet.Add(SPRITE_ANIMATION.IDLE_DOWN, idleDown);

            SpriteAnimation idleRight = new SpriteAnimation(loops:false);
            idleRight.Frames.Add(new SpriteAnimationFrame(0, 11));
            spriteAnimationSet.Add(SPRITE_ANIMATION.IDLE_RIGHT, idleRight);

            SpriteAnimation slashUp = new SpriteAnimation();
            slashUp.Frames.Add(new SpriteAnimationFrame(0, 12));
            slashUp.Frames.Add(new SpriteAnimationFrame(1, 12));
            slashUp.Frames.Add(new SpriteAnimationFrame(2, 12));
            slashUp.Frames.Add(new SpriteAnimationFrame(3, 12));
            slashUp.Frames.Add(new SpriteAnimationFrame(4, 12));
            slashUp.Frames.Add(new SpriteAnimationFrame(5, 12));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SLASH_UP, slashUp);

            SpriteAnimation slashLeft = new SpriteAnimation();
            slashLeft.Frames.Add(new SpriteAnimationFrame(0, 13));
            slashLeft.Frames.Add(new SpriteAnimationFrame(1, 13));
            slashLeft.Frames.Add(new SpriteAnimationFrame(2, 13));
            slashLeft.Frames.Add(new SpriteAnimationFrame(3, 13));
            slashLeft.Frames.Add(new SpriteAnimationFrame(4, 13));
            slashLeft.Frames.Add(new SpriteAnimationFrame(5, 13));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SLASH_LEFT, slashLeft);

            SpriteAnimation slashDown = new SpriteAnimation();
            slashDown.Frames.Add(new SpriteAnimationFrame(0, 14));
            slashDown.Frames.Add(new SpriteAnimationFrame(1, 14));
            slashDown.Frames.Add(new SpriteAnimationFrame(2, 14));
            slashDown.Frames.Add(new SpriteAnimationFrame(3, 14));
            slashDown.Frames.Add(new SpriteAnimationFrame(4, 14));
            slashDown.Frames.Add(new SpriteAnimationFrame(5, 14));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SLASH_DOWN, slashDown);
            
            SpriteAnimation slashRight = new SpriteAnimation();
            slashRight.Frames.Add(new SpriteAnimationFrame(0, 15));
            slashRight.Frames.Add(new SpriteAnimationFrame(1, 15));
            slashRight.Frames.Add(new SpriteAnimationFrame(2, 15));
            slashRight.Frames.Add(new SpriteAnimationFrame(3, 15));
            slashRight.Frames.Add(new SpriteAnimationFrame(4, 15));
            slashRight.Frames.Add(new SpriteAnimationFrame(5, 15));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SLASH_RIGHT, slashRight);

            SpriteAnimation shootUp = new SpriteAnimation();
            shootUp.Frames.Add(new SpriteAnimationFrame(0, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(1, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(2, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(3, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(4, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(5, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(6, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(7, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(8, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(9, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(10, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(11, 16));
            shootUp.Frames.Add(new SpriteAnimationFrame(12, 16));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SHOOT_UP, shootUp);

            SpriteAnimation shootLeft = new SpriteAnimation();
            shootLeft.Frames.Add(new SpriteAnimationFrame(0, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(1, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(2, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(3, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(4, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(5, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(6, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(7, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(8, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(9, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(10, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(11, 17));
            shootLeft.Frames.Add(new SpriteAnimationFrame(12, 17));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SHOOT_LEFT, shootLeft);

            SpriteAnimation shootDown = new SpriteAnimation();
            shootDown.Frames.Add(new SpriteAnimationFrame(0, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(1, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(2, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(3, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(4, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(5, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(6, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(7, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(8, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(9, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(10, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(11, 18));
            shootDown.Frames.Add(new SpriteAnimationFrame(12, 18));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SHOOT_DOWN, shootDown);

            SpriteAnimation shootRight = new SpriteAnimation();
            shootRight.Frames.Add(new SpriteAnimationFrame(0, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(1, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(2, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(3, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(4, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(5, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(6, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(7, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(8, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(9, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(10, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(11, 19));
            shootRight.Frames.Add(new SpriteAnimationFrame(12, 19));
            spriteAnimationSet.Add(SPRITE_ANIMATION.SHOOT_RIGHT, shootRight);

            SpriteAnimation ko = new SpriteAnimation(loops:false, frameDurationInMilliseconds:50);
            ko.Frames.Add(new SpriteAnimationFrame(0, 20));
            ko.Frames.Add(new SpriteAnimationFrame(1, 20));
            ko.Frames.Add(new SpriteAnimationFrame(2, 20));
            ko.Frames.Add(new SpriteAnimationFrame(3, 20));
            ko.Frames.Add(new SpriteAnimationFrame(4, 20));
            ko.Frames.Add(new SpriteAnimationFrame(5, 20));
            spriteAnimationSet.Add(SPRITE_ANIMATION.KO, ko);

            sprite = new Sprite(new Point(128, 128), spriteAnimationSet);
            sprite.SetAnimation(SPRITE_ANIMATION.IDLE_DOWN);
        }
    }
}
