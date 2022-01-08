using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Map
{
    internal class MapManager
    {


        private List<Map> maps = new List<Map>();
        private static MapManager uniqueInstance;
        public Map currentMap;

        private MapManager()
        {

        }

        public static MapManager getInstance()
        {
            if (uniqueInstance == null)  uniqueInstance = new MapManager();
            return uniqueInstance; 
        }

        public void addMap(int[,] mapArray, Texture2D blockTexture, Texture2D trapTexture)
        {
            var map = new Map(mapArray.GetLength(1), mapArray.GetLength(0), blockTexture, trapTexture);
            currentMap = map;
            map.LoadMap(mapArray);
            maps.Add(map);
        }

        public void selectMap(int index)
        {
            currentMap = maps[index];
        }


    }
}
