using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal static class Dead
    {

        private static Button _menuButton;


        public static void Initialise(Texture2D menuButtonTexture)
        {
            //TODO: Add a gameover sprite image

            _menuButton = new Button(menuButtonTexture, new Vector2(320, 200));
            _menuButton.Click += (EventHandler)((_param1, _param2) =>
            {
                StateManager.getInstance().gameState = StateManager.GameState.Menu;
                //TODO: Reset hero (function already coded)
            });
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _menuButton.Draw(spriteBatch);
        }

        public static void Update()
        {
            _menuButton.Update();
        }

    }
}
