using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Texture
{
    internal class Background
    {
        private Texture2D texture;
        private Song song;
        private Rectangle rectangle;
        public Background(Texture2D texture, Song song)
        {
            this.texture = texture;
            this.song = song;

            MediaPlayer.Play(this.song);
            MediaPlayer.IsRepeating = true;
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
