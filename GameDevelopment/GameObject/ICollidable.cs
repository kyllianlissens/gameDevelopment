using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    internal interface ICollidable
    {
        bool CheckCollision(Rectangle rec);
        void Draw(SpriteBatch spriteBatch);
    }
}
