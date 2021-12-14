using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Map
{
    class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public Color Color { get; set; }
        public bool Passable { get; set; }
        public Texture2D Texture { get; set; }

        private float scale = 3.12f;

        public Block(int x, int y, Texture2D texture)
        {
            BoundingBox = new Rectangle(x,y, (int)(32 * scale), (int)(32 * scale));
            Color = Color.White;
            Passable = false;
            Texture = texture;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, new Vector2((BoundingBox.X * scale) * Texture.Width , (640 - Texture.Height) - (BoundingBox.Y *Texture.Height )), null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
