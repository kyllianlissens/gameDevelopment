using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.MapEntities
{
    internal class Trap :  BaseEntity
    {
        public Trap(int x, int y, Texture2D texture)
        {
            int trapHeight = 14;
            BoundingBox = new Rectangle(x * (Configuration.viewportWidth / 23), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)) + (texture.Height - trapHeight), Configuration.viewportWidth / 23, trapHeight);
            Texture = texture;
            Position = new Vector2(x, y);
        }
    }
}
