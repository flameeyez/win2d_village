using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Effects;
using Windows.Foundation;
using Windows.System;

namespace win2d_village
{
    class Sprite
    {
        public Point Position;
        public SpriteAnimationSet SpriteAnimationSet { get; set; }

        private Sprite() { }
        public Sprite(Point position, SpriteAnimationSet spriteAnimationSet)
        {
            Position = position;
            SpriteAnimationSet = spriteAnimationSet;
        }

        public void Draw(CanvasAnimatedDrawEventArgs args)
        {
            SpriteAnimationSet.Draw(Position, args);
        }
        public void Update(HashSet<VirtualKey> keysDown, CanvasAnimatedUpdateEventArgs args)
        {
            switch (SpriteAnimationSet.CurrentAnimation)
            {
                case SPRITE_ANIMATION.WALK_DOWN:
                    Position.Y += 1;
                    if (Position.Y % 64 == 0 && !keysDown.Contains(VirtualKey.Down)) { SetAnimation(SPRITE_ANIMATION.IDLE_DOWN); }
                    break;
                case SPRITE_ANIMATION.WALK_UP:
                    Position.Y -= 1;
                    if (Position.Y % 64 == 0 && (!keysDown.Contains(VirtualKey.Up) || Position.Y == 0)) { SetAnimation(SPRITE_ANIMATION.IDLE_UP); }
                    break;
                case SPRITE_ANIMATION.WALK_LEFT:
                    Position.X -= 1;
                    if (Position.X % 64 == 0 && (!keysDown.Contains(VirtualKey.Left) || Position.X == 0)) { SetAnimation(SPRITE_ANIMATION.IDLE_LEFT); }
                    break;
                case SPRITE_ANIMATION.WALK_RIGHT:
                    Position.X += 1;
                    if (Position.X % 64 == 0 && !keysDown.Contains(VirtualKey.Right)) { SetAnimation(SPRITE_ANIMATION.IDLE_RIGHT); }
                    break;
                case SPRITE_ANIMATION.IDLE_DOWN:
                case SPRITE_ANIMATION.IDLE_UP:
                case SPRITE_ANIMATION.IDLE_LEFT:
                case SPRITE_ANIMATION.IDLE_RIGHT:
                    if (keysDown.Contains(VirtualKey.Down)) { SetAnimation(SPRITE_ANIMATION.WALK_DOWN); }
                    else if (keysDown.Contains(VirtualKey.Up))
                    {
                        if (Position.Y > 0) { SetAnimation(SPRITE_ANIMATION.WALK_UP); }
                        else { SetAnimation(SPRITE_ANIMATION.IDLE_UP); }
                    }
                    else if (keysDown.Contains(VirtualKey.Left))
                    {
                        if (Position.X > 0) { SetAnimation(SPRITE_ANIMATION.WALK_LEFT); }
                        else { SetAnimation(SPRITE_ANIMATION.IDLE_LEFT); }
                    }
                    else if (keysDown.Contains(VirtualKey.Right)) { SetAnimation(SPRITE_ANIMATION.WALK_RIGHT); }
                    break;
            }
            SpriteAnimationSet.Update(args);
        }
        public void SetAnimation(SPRITE_ANIMATION animation)
        {
            SpriteAnimationSet.SetAnimation(animation);
        }

        internal void MoveDown()
        {
            SetAnimation(SPRITE_ANIMATION.WALK_DOWN);

        }
    }
}
