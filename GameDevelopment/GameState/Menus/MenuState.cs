using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class MenuState
    {
        protected Button button1;
        protected SpriteFont font;

        public void Initialise(SpriteFont _font, Button _button1)
        {
            font = _font;
            button1 = _button1;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Configuration.gameTitle, new Vector2(Configuration.viewportWidth / 2, Configuration.viewportHeight / 3.5f), Color.BlueViolet, 0f, font.MeasureString(Configuration.gameTitle) / 2, 4f, SpriteEffects.None, 0f);
            button1.Draw(spriteBatch);
        }
        public virtual void Update()
        {
            button1.Update();
        }
    }
}
