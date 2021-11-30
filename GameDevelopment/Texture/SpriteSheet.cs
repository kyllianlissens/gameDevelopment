using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameDevelopment.Texture
{
    public enum SpriteState
    {
        Idle,
        Walk,
        Run,
        Attack
    }
    public class SpriteSheet
    {
        private Texture2D _texture;
        private Dictionary<SpriteState, List<Sprite>> _sprites;

        public SpriteSheet(Texture2D texture, Dictionary<SpriteState, List<Sprite>> sprites)
        {
            _texture = texture;
            _sprites = sprites;
        }

        public Sprite GetSprite(SpriteState state, TimeSpan time)
        {
            int i = (int)time.TotalMilliseconds % 1000;
            i = i % _sprites[state].Count;
            Sprite sprite = _sprites[state][i];
            return sprite;
        }
        public Texture2D Texture => _texture;
    }
}
