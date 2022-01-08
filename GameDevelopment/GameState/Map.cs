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
        public List<Block> Blocks = new List<Block>();
        public List<Trap> Traps = new List<Trap>();
        public List<Enemy> Enemies = new List<Enemy>();

        private Texture2D BlockTexture;
        private Texture2D TrapTexture;
        private Texture2D EnemyGhost1Texture;
        private Texture2D EnemyGhost2Texture;

        public int MapWidth;
        public int MapHeight;

        public Vector2 SpawnPosition;

        
        public Map(int mapWidth, int mapHeight, Vector2 spawnPosition, Texture2D blockTexture, Texture2D trapTexture, Texture2D ghost1Texture, Texture2D ghost2Texture)
        {
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            SpawnPosition = spawnPosition;
            BlockTexture = blockTexture;
            TrapTexture = trapTexture;
            EnemyGhost1Texture = ghost1Texture;
            EnemyGhost2Texture = ghost2Texture;
        }

        public void LoadMap(int[,] mapArray)
        {
            Random random = new Random();
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
                            random.Next(1, 3) == 1 ? EnemyGhost1Texture : EnemyGhost2Texture
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
            foreach (var enemy in Enemies) enemy.Draw(spriteBatch);
        }
    }
}
