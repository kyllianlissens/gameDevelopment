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
            this.rectangle = new Rectangle(0, 0, Configuration.viewportWidth, Configuration.viewportHeight);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }
    }
}
