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

        public static void Initialize (Texture2D _blockTexture, Texture2D _spikeTexture, Texture2D _ghost1Texture, Texture2D _ghost2Texture, Hero _hero)
        {
            var tileMap = new int[,]
            {
                { 0,0,0,0,0,0,0,0,2,2,1,2,2,1,2,2,1,0,0,3,1,0,0,0 },
                { 0,0,0,0,0,0,2,1,1,1,0,1,1,0,1,1,0,1,1,1,0,0,0,0 },
                { 0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,1,1 },
                { 1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1,1,1,0,0,0,0,0 },
                { 0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,2,2,1,0,0,0,0,0,0,2,2,1,1,0,0,0,1,0,3,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
            };

            Vector2 spawnPosition = new Vector2(300, 380);

            map = new Map(tileMap.GetLength(1), tileMap.GetLength(0), spawnPosition, _blockTexture, _spikeTexture, _ghost1Texture, _ghost2Texture);
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
            map.Update(gameTime);
            hero.Update(gameTime);
        }

    }
}
