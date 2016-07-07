﻿using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Effects;
using Windows.Foundation;
using Windows.System;
using Microsoft.Graphics.Canvas;

namespace win2d_village
{
    class Sprite
    {
        //public SpriteAnimationSet SpriteAnimationSet { get; set; }
        public Point Position;
        private SpriteSheet _spriteSheet;
        private SPRITE_ANIMATION _currentAnimationState;
        private SpriteAnimation _currentAnimation;
        //private int _frameIndex = 0;

        private Queue<SPRITE_ANIMATION> _stateQueue = new Queue<SPRITE_ANIMATION>();

        private Sprite() { }
        public Sprite(CanvasBitmap image, int imageResolution, Point position)
        {
            Position = position;
            _spriteSheet = new SpriteSheet(image, imageResolution);

            _currentAnimationState = SPRITE_ANIMATION.IDLE_DOWN;
            _currentAnimation = SpriteAnimationDefinitions.Copy(_currentAnimationState);
        }

        public void Draw(CanvasAnimatedDrawEventArgs args)
        {
            _currentAnimation.Draw(_spriteSheet, Position, args);
        }
        public void Update(CanvasAnimatedUpdateEventArgs args)
        {
            UpdatePosition();
            UpdateAnimation(args);
        }

        private void UpdatePosition()
        {
            switch (_currentAnimationState)
            {
                case SPRITE_ANIMATION.WALK_DOWN:
                    Position.Y += 1;
                    if (Position.Y % _spriteSheet.Resolution == 0) { SetNextState(); }
                    break;
                case SPRITE_ANIMATION.WALK_UP:
                    Position.Y -= 1;
                    if (Position.Y % _spriteSheet.Resolution == 0) { SetNextState(); }
                    break;
                case SPRITE_ANIMATION.WALK_LEFT:
                    Position.X -= 1;
                    if (Position.X % _spriteSheet.Resolution == 0) { SetNextState(); }
                    break;
                case SPRITE_ANIMATION.WALK_RIGHT:
                    Position.X += 1;
                    if (Position.X % _spriteSheet.Resolution == 0) { SetNextState(); }
                    break;
                case SPRITE_ANIMATION.IDLE_DOWN:
                case SPRITE_ANIMATION.IDLE_UP:
                case SPRITE_ANIMATION.IDLE_LEFT:
                case SPRITE_ANIMATION.IDLE_RIGHT:
                    if(_stateQueue.Count > 0) { SetNextState(); }
                    else if (Statics.Random.Next(100) == 0) { GenerateRandomQueue(); }
                    break;
            }
        }

        private void UpdateAnimation(CanvasAnimatedUpdateEventArgs args)
        {
            _currentAnimation.Update(args);
        }

        internal void HandleKeyboard(HashSet<VirtualKey> keysDown)
        {
            //if (keysDown.Contains(VirtualKey.Down)) { SetAnimation(SPRITE_ANIMATION.WALK_DOWN); }
            //else if (keysDown.Contains(VirtualKey.Up))
            //{
            //    if (Position.Y > 0) { SetAnimation(SPRITE_ANIMATION.WALK_UP); }
            //    else { SetAnimation(SPRITE_ANIMATION.IDLE_UP); }
            //}
            //else if (keysDown.Contains(VirtualKey.Left))
            //{
            //    if (Position.X > 0) { SetAnimation(SPRITE_ANIMATION.WALK_LEFT); }
            //    else { SetAnimation(SPRITE_ANIMATION.IDLE_LEFT); }
            //}
            //else if (keysDown.Contains(VirtualKey.Right)) { SetAnimation(SPRITE_ANIMATION.WALK_RIGHT); }
        }

        public void SetAnimation(SPRITE_ANIMATION animation)
        {
            _currentAnimationState = animation;
            _currentAnimation = SpriteAnimationDefinitions.Copy(_currentAnimationState);
        }

        private void GenerateRandomQueue()
        {
            for(int i = 0; i < 10; i++)
            {
                switch(Statics.Random.Next(4))
                {
                    case 0:
                        _stateQueue.Enqueue(SPRITE_ANIMATION.WALK_RIGHT);
                        break;
                    case 1:
                        _stateQueue.Enqueue(SPRITE_ANIMATION.WALK_LEFT);
                        break;
                    case 2:
                        _stateQueue.Enqueue(SPRITE_ANIMATION.WALK_DOWN);
                        break;
                    case 3:
                        _stateQueue.Enqueue(SPRITE_ANIMATION.WALK_UP);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetNextState()
        {
            if (_stateQueue.Count > 0)
            {
                SPRITE_ANIMATION nextState = _stateQueue.Dequeue();
                if (nextState != _currentAnimationState) { SetAnimation(nextState); }
            }
            else
            {
                switch (_currentAnimationState)
                {
                    case SPRITE_ANIMATION.WALK_DOWN:
                        SetAnimation(SPRITE_ANIMATION.IDLE_DOWN);
                        break;
                    case SPRITE_ANIMATION.WALK_UP:
                        SetAnimation(SPRITE_ANIMATION.IDLE_UP);
                        break;
                    case SPRITE_ANIMATION.WALK_LEFT:
                        SetAnimation(SPRITE_ANIMATION.IDLE_LEFT);
                        break;
                    case SPRITE_ANIMATION.WALK_RIGHT:
                        SetAnimation(SPRITE_ANIMATION.IDLE_RIGHT);
                        break;
                }
            }
        }
    }
}
