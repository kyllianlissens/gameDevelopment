using GameDevelopment.GameObject;
using GameDevelopment.MapEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class Map
    {
        public List<Block> Blocks;
        public List<Trap> Traps;
        public List<Enemy> Enemies;
        public List<Coin> Coins;

        private Texture2D BlockTexture;
        private Texture2D TrapTexture;
        private Texture2D EnemyGhost1Texture;
        private Texture2D EnemyGhost2Texture;
        private Texture2D CoinTexture;

        private int[,] InitTileMap;
        public int MapWidth;
        public int MapHeight;

        public Vector2 SpawnPosition;

        
        public Map(int[,] initTileMap, int mapWidth, int mapHeight, Vector2 spawnPosition, Texture2D blockTexture, Texture2D trapTexture, Texture2D ghost1Texture, Texture2D ghost2Texture, Texture2D coinTexture)
        {
            Blocks = new List<Block>();
            Traps = new List<Trap>();
            Enemies = new List<Enemy>();
            Coins = new List<Coin>();

            InitTileMap = initTileMap;
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            SpawnPosition = spawnPosition;
            BlockTexture = blockTexture;
            TrapTexture = trapTexture;
            EnemyGhost1Texture = ghost1Texture;
            EnemyGhost2Texture = ghost2Texture;
            CoinTexture = coinTexture;
        }

        public void ResetMap() => LoadMap(InitTileMap);

        public void LoadMap(int[,] mapArray)
        {
            Blocks.Clear();
            Traps.Clear();
            Enemies.Clear();
            Coins.Clear();

            for (int y = 0; y < mapArray.GetLength(0); y++)
            {
                for (int x = 0; x < mapArray.GetLength(1); x++)
                {
                    if (mapArray[y, x] == 1)
                    {
                        Blocks.Add(new Block(
                            x, mapArray.GetLength(0) - y,
                            BlockTexture
                            ));
                    }
                    else if(mapArray[y, x] == 2)
                    {
                        Traps.Add(new Trap(
                            x, mapArray.GetLength(0) - y,
                            TrapTexture
                            ));
                    }
                    else if(mapArray[y, x] == 3)
                    {
                        Enemies.Add(new Enemy(
                            x, mapArray.GetLength(0) - y,
                            EnemyGhost1Texture
                            ));
                    }
                    else if(mapArray[y, x] == 4)
                    {
                        Enemies.Add(new Enemy(
                            x, mapArray.GetLength(0) - y,
                            EnemyGhost2Texture,
                            baseSpeed: 2.5f
                            ));
                    }
                    else if(mapArray[y, x] == 5)
                    {
                        Coins.Add(new Coin(
                            x, mapArray.GetLength(0) - y,
                            CoinTexture
                            ));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var enemy in Enemies) enemy.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var block in Blocks) block.Draw(spriteBatch);
            foreach (var trap in Traps) trap.Draw(spriteBatch);
            foreach (var coin in Coins) coin.Draw(spriteBatch);
            foreach (var enemy in Enemies) enemy.Draw(spriteBatch);
        }
    }
}
