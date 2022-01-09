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
            Level2,
            Victory
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

        public void SetState(GameState newState)
        {
            gameState = newState;
            switch (gameState)
            {
                case GameState.Dead:
                case GameState.Victory:
                    break;
                case GameState.Menu:
                case GameState.Level1:
                case GameState.Level2:
                    GetLevel().PrepareLevel();
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    Menu.getInstance().Draw(spriteBatch);
                    break;
                case GameState.Dead:
                    Dead.getInstance().Draw(spriteBatch);
                    break;
                case GameState.Victory:
                    Victory.getInstance().Draw(spriteBatch);
                    break;
                case GameState.Level1:
                    Level1.getInstance().Draw(spriteBatch);
                    break;
                case GameState.Level2:
                    Level2.getInstance().Draw(spriteBatch); 
                    break;   
                default: break;
            }
        }

        public Vector2 GetSpawnPosition()
        {
            switch (gameState)
            {
                case GameState.Level1:
                    return Level1.getInstance().map.SpawnPosition;
                case GameState.Level2:
                    return Level2.getInstance().map.SpawnPosition;
                default:
                    return Vector2.Zero;
            }
        }

        public List<Block> GetBlocks()
        {
            switch (gameState)
            {
       
                case GameState.Level1:
                    return Level1.getInstance().map.Blocks;
                case GameState.Level2:
                    return Level2.getInstance().map.Blocks;
                default:
                    return new List<Block>();
            }
        }

        public List<Coin> GetCoins()
        {
            switch (gameState)
            {
       
                case GameState.Level1:
                    return Level1.getInstance().map.Coins;
                case GameState.Level2:
                    return Level2.getInstance().map.Coins;
                default:
                    return new List<Coin>();
            }
        }

        public List<Trap> GetTraps()
        {
            switch (gameState)
            {
       
                case GameState.Level1:
                    return Level1.getInstance().map.Traps;
                case GameState.Level2:
                    return Level2.getInstance().map.Traps;
                default:
                    return new List<Trap>();
            }
        }
        public List<Enemy> GetEnemies()
        {
            switch (gameState)
            {
       
                case GameState.Level1:
                    return Level1.getInstance().map.Enemies;
                case GameState.Level2:
                    return Level2.getInstance().map.Enemies;
                default:
                    return new List<Enemy>();
            }
        }

        public LevelState GetLevel()
        {
            switch (gameState)
            {
                case GameState.Level1:
                    return Level1.getInstance();
                case GameState.Level2:
                    return Level2.getInstance();
                default:
                    return Level1.getInstance();
            }
        }

        public void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    Menu.getInstance().Update();
                    break;
                case GameState.Dead:
                    Dead.getInstance().Update();
                    break;
                case GameState.Victory:
                    Victory.getInstance().Update();
                    break;
                case GameState.Level1:
                    Level1.getInstance().Update(gameTime);
                    break;
                case GameState.Level2:
                    Level2.getInstance().Update(gameTime);
                    break;
                default: break;
            }
        }
    }
}
