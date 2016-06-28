using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win2d_village
{
    enum SPRITE_ANIMATION
    {
        SPELLCAST_UP,
        SPELLCAST_LEFT,
        SPELLCAST_DOWN,
        SPELLCAST_RIGHT,
        ATTACK_UP,
        ATTACK_LEFT,
        ATTACK_DOWN,
        ATTACK_RIGHT,
        WALK_UP,
        WALK_LEFT,
        WALK_DOWN,
        WALK_RIGHT,
        IDLE_UP,
        IDLE_LEFT,
        IDLE_DOWN,
        IDLE_RIGHT,
        SLASH_UP,
        SLASH_LEFT,
        SLASH_DOWN,
        SLASH_RIGHT,
        SHOOT_UP,
        SHOOT_LEFT,
        SHOOT_DOWN,
        SHOOT_RIGHT,
        KO
    }

    class SpriteAnimation
    {
        public List<SpriteAnimationFrame> Frames = new List<SpriteAnimationFrame>();

        private int _currentFrame;
        private bool _loops;
        private double _frameDurationInMilliseconds;
        private double _millisecondsSinceLastUpdate;
        
        public SpriteAnimationFrame CurrentFrame { get { return Frames[_currentFrame]; } }

        internal void Reset()
        {
            _currentFrame = 0;
        }

        public SpriteAnimation(bool loops = true, double frameDurationInMilliseconds = 100)
        {
            _loops = loops;
            _frameDurationInMilliseconds = frameDurationInMilliseconds;
            _millisecondsSinceLastUpdate = 0;
        }

        public void Update(CanvasAnimatedUpdateEventArgs args)
        {
            _millisecondsSinceLastUpdate += args.Timing.ElapsedTime.TotalMilliseconds;
            if (_millisecondsSinceLastUpdate >= _frameDurationInMilliseconds)
            {
                _currentFrame = _currentFrame + 1;
                if(_currentFrame >= Frames.Count)
                {
                    if(_loops) { _currentFrame %= Frames.Count; }
                    else { _currentFrame--; }
                }
                _millisecondsSinceLastUpdate -= _frameDurationInMilliseconds;
            }
        }
    }
}
