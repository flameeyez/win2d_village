using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace win2d_village
{
    class SpriteAnimationSet
    {
        public ChromaKeyEffect CharacterMap;
        public Dictionary<SPRITE_ANIMATION, SpriteAnimation> SpriteAnimations = new Dictionary<SPRITE_ANIMATION, SpriteAnimation>();
        public SPRITE_ANIMATION CurrentAnimation { get; internal set; }
        public int Resolution { get; set; }

        public SpriteAnimationSet(ChromaKeyEffect characterMap, int resolution)
        {
            CharacterMap = characterMap;
            Resolution = resolution;
        }

        internal void SetAnimation(SPRITE_ANIMATION animation)
        {
            if (animation != CurrentAnimation)
            {
                CurrentAnimation = animation;
                SpriteAnimations[CurrentAnimation].Reset();
            }
        }

        public void Draw(Point position, CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.DrawImage(CharacterMap, (float)position.X, (float)position.Y, new Rect(SpriteAnimations[CurrentAnimation].CurrentFrame.X * Resolution, SpriteAnimations[CurrentAnimation].CurrentFrame.Y * Resolution, Resolution, Resolution));
        }

        public void Update(CanvasAnimatedUpdateEventArgs args)
        {
            SpriteAnimations[CurrentAnimation].Update(args);
        }

        internal void Add(SPRITE_ANIMATION animationType, SpriteAnimation animation)
        {
            SpriteAnimations.Add(animationType, animation);
        }
    }
}
