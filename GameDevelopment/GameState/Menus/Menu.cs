using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class Menu : MenuState
    {
        private static Menu uniqueInstance;
        public static Menu getInstance()
        {
            if (uniqueInstance == null) uniqueInstance = new Menu();
            return uniqueInstance;
        }

        public void Initialise(SpriteFont _font, Texture2D playButtonTexture)
        {
            Button playButton = new Button(playButtonTexture, new Vector2(Configuration.viewportWidth / 2, Configuration.viewportHeight / 2));
            playButton.Click += (EventHandler)((_param1, _param2) => StateManager.getInstance().SetState(StateManager.GameState.Level1));
           
            base.Initialise(_font, playButton);
        }
    }
}
