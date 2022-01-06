using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Texture
{
    internal class Background
    {
        private Texture2D texture;
        private Rectangle rectangle;
        public Background(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Initialize()
        {
            this.rectangle = new Rectangle(0, 0, 816, 316);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 800; x += 16)
            {
                for (int y = 0; y < 480; y += 16)
                {
                    spriteBatch.Draw(texture, new Vector2(x, y), rectangle, Color.White);
                }
            }

        }
    }
}
