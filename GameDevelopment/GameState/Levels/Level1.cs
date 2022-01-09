using GameDevelopment.GameObject;
using GameDevelopment.MapEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class Level1 : LevelState
    {
        private int[,] tileMap = new int[,]
        {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,2,2,1,2,2,1,2,2,1,0,0,3,1,0,0,0 },
                { 0,0,0,5,0,0,2,1,1,1,0,1,1,0,1,1,0,1,1,1,0,0,0,0 },
                { 0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,5,0,0,0,0,1,1 },
                { 1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0 },
                { 0,1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,2,2,1,0,0,0,0,0,1,2,2,0,0,0,0,0,0,5,3,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };
        private Vector2 spawnPosition = new Vector2(300, 380);

        private static Level1 uniqueInstance;
        public static Level1 getInstance()
        {
            if (uniqueInstance == null) uniqueInstance = new Level1();
            return uniqueInstance;
        }

        public void Initialize(Texture2D _blockTexture, Texture2D _spikeTexture, Texture2D _ghost1Texture, Texture2D _ghost2Texture, SpriteFont _font, Texture2D _healthui, Texture2D _coin, Hero _hero)
        {
            base.Initialize(tileMap, spawnPosition, _blockTexture, _spikeTexture, _ghost1Texture, _ghost2Texture, _font, _healthui, _coin, _hero);
        }

        public override bool ProgressCoinTaken(Coin coin)
        {
            base.ProgressCoinTaken(coin);

            if (coinstaken >= map.Coins.Count)
            {
                StateManager.getInstance().SetState(StateManager.GameState.Level2);
                return true;
            }
            return false;
        }
    }
}
