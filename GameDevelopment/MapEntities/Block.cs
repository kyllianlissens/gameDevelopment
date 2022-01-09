using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.MapEntities
{
    class Block : BaseEntity
    {
        public Block(int x, int y, Texture2D texture) : base(x, y, texture)
        { }
    }
}
