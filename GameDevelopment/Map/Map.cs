using GameDevelopment.GameObject;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Map
{
    internal class Map
    {
        public List<Block> Blocks = new List<Block>();
        public List<Trap> Traps = new List<Trap>();

        private Texture2D TrapTexture;
        private Texture2D BlockTexture;

        public int MapWidth;
        public int MapHeight;

        
        public Map(int mapWidth, int mapHeight,Texture2D blockTexture, Texture2D trapTexture)
        {
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            BlockTexture = blockTexture;
            TrapTexture = trapTexture;

        }

        public void LoadMap(int[,] mapArray)
        {
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
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var block in Blocks) block.Draw(spriteBatch);
            foreach (var trap in Traps) trap.Draw(spriteBatch);
        }
    }
}
