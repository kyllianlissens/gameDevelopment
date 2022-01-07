using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Map
{
    internal class Map
    {
        public List<Block> blocks = new List<Block>();
        public int mapWidth;
        public int mapHeight;

        public Map(int[,] mapArray, Texture2D mapTexture)
        {


            mapHeight = mapArray.GetLength(0);
            mapWidth = mapArray.GetLength(1);

            for (int y = 0; y < mapArray.GetLength(0); y++)
            {
                for (int x = 0; x < mapArray.GetLength(1); x++)
                {
                    if (mapArray[y, x] == 1)
                    {
                        blocks.Add(new Block(
                            x, mapArray.GetLength(0) - y,
                            mapTexture
                            ));
                    }
                }
            }
        }




        public void Draw(SpriteBatch spriteBatch)
        {
            

            foreach (var block in blocks) block.Draw(spriteBatch);
        }
    }
}
