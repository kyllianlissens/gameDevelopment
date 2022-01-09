using GameDevelopment.GameObject;
using GameDevelopment.MapEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class Level2 : LevelState
    {
        private int[,] tileMap = new int[,]
        {
                { 0,0,0,0,0,0,0,0,2,2,1,2,2,1,2,2,1,0,0,4,1,0,0,0 },
                { 0,0,0,0,0,0,2,1,1,1,0,1,1,0,1,1,0,1,1,1,0,0,0,0 },
                { 0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,4,0,0,0,0,0,0,1,1 },
                { 1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,2,2,1,0,0,0,0,0,0,1,1,2,2,0,5,0,2,2,3,1,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };
        private Vector2 spawnPosition = new Vector2(300, 380);

        private static Level2 uniqueInstance;
        public static Level2 getInstance()
        {
            if (uniqueInstance == null) uniqueInstance = new Level2();
            return uniqueInstance;
        }

        public void Initialize(Texture2D _blockTexture, Texture2D _spikeTexture, Texture2D _ghost1Texture, Texture2D _ghost2Texture, SpriteFont _font, Texture2D _healthui, Texture2D _coin, Hero _hero)
        {
            base.Initialize(tileMap, spawnPosition, _blockTexture, _spikeTexture, _ghost1Texture, _ghost2Texture, _font, _healthui, _coin, _hero);
        }

        public override void PrepareLevel()
        {
            coinstaken = 0;
            // Don't reset score and health when progression to level 2
            map.ResetMap();
            hero.ResetPosition(map.SpawnPosition);
        }
        public override bool ProgressCoinTaken(Coin coin)
        {
            base.ProgressCoinTaken(coin);

            if (coinstaken >= map.Coins.Count)
            {
                StateManager.getInstance().SetState(StateManager.GameState.Victory);
                return true;
            }
            return false;
        }
    }
}
