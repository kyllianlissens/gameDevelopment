using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    internal class Spike :  ICollidable, IGameObject
    {

        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; set; }

        public Texture2D Texture { get; set; }

        public Spike(int x, int y, Texture2D texture)
        {
            BoundingBox = new Rectangle(x * (Configuration.viewportWidth / 8), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)), Configuration.viewportWidth / 8, texture.Bounds.Height);
            Texture = texture;
            Position = new Vector2(x, y);
        }

        public bool CheckCollision(Rectangle rec)
        {
            return BoundingBox.Intersects(rec);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Color.Red);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
