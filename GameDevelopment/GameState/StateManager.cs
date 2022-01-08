using GameDevelopment.MapEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class StateManager
    {


        public enum GameState
        {
            Menu,
            Dead,
            Level1,
            Level2
        }

        private static StateManager uniqueInstance;

        public GameState gameState;

        private StateManager()
        {
            gameState = GameState.Menu;
        }

        public static StateManager getInstance()
        {
            if (uniqueInstance == null) uniqueInstance = new StateManager();
            return uniqueInstance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    Menu.Draw(spriteBatch);
                    break;
                case GameState.Dead: break;
                case GameState.Level1:
                    Level1.Draw(spriteBatch);
                    break;
                case GameState.Level2: break;   
                default: break;
            }
        }


        public List<Block> GetBlocks()
        {
            switch (gameState)
            {
       
                case GameState.Level1:
                    return Level1.map.Blocks;
                case GameState.Level2: 
                    return new List<Block>();
                default:
                    return new List<Block>();
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    Menu.Update();
                    break;
                case GameState.Dead: break;
                case GameState.Level1:
                    Level1.Update(gameTime);
                    break;
                case GameState.Level2: break;
                default: break;
            }

        }



    }
}
