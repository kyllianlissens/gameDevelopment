using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal static class Level1
    {

        public static Map map;
        private static Hero hero;

        public static void Initialize (Texture2D _blockTexture, Texture2D _spikeTexture, Hero _hero)
        {
            var tileMap = new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
            };

            map = new Map(tileMap.GetLength(1), tileMap.GetLength(0), _blockTexture, _spikeTexture);
            map.LoadMap(tileMap);
            hero = _hero;
        }

        public static void Draw (SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
        }

    }
}
