using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal static class Menu
    {

        private static Button _playButton; 


        public static void Initialise(Texture2D playButtonTexture)
        {
            _playButton = new Button(playButtonTexture, new Vector2(320, 200));
            _playButton.Click += (EventHandler)((_param1, _param2) => StateManager.getInstance().gameState = StateManager.GameState.Level1);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _playButton.Draw(spriteBatch);
        }

        public static void Update()
        {
            _playButton.Update();
        }

    }
}
