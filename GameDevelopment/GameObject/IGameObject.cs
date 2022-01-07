using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    public interface IGameObject
    {
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
