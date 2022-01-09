using GameDevelopment.GameObject;
using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class Dead : MenuState
    {
        private static Dead uniqueInstance;
        public static Dead getInstance()
        {
            if (uniqueInstance == null) uniqueInstance = new Dead();
            return uniqueInstance;
        }

        public void Initialise(SpriteFont _font, Texture2D menuButtonTexture)
        {
            Button menuButton = new Button(menuButtonTexture, new Vector2(Configuration.viewportWidth / 2, Configuration.viewportHeight / 2));
            menuButton.Click += (EventHandler)((_param1, _param2) =>
            {
                StateManager.getInstance().SetState(StateManager.GameState.Menu);
            });

            base.Initialise(_font, menuButton);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, "You lose!", new Vector2(Configuration.viewportWidth / 2, Configuration.viewportHeight / 2.5f), Color.PaleVioletRed, 0f, font.MeasureString("You lose!") / 2, 1.5f, SpriteEffects.None, 0f);

            StateManager.getInstance().GetLevel().DrawUI(spriteBatch);
        }
    }
}
