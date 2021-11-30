using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Texture
{
    public class Sprite
    {
        private Vector2 _startpos;
        private Vector2 _endpos;
        private float _duration;

        public Sprite(Vector2 startpos, Vector2 endpos, float duration)
        {
            _startpos = startpos;
            _endpos = endpos;
            _duration = duration;
        }
        public Sprite(float x1, float y1, float x2, float y2, float duration) : this(new Vector2(x1, y1), new Vector2(x2, y2), duration) { }

        public Vector2 StartPosition => _startpos;
        public Vector2 EndPosition => _endpos;
    }
}
