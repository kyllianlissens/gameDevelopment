using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            var state = Keyboard.GetState();
            var direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left)) direction.X -= 1; 
            if (state.IsKeyDown(Keys.Right)) direction.X += 1;
            if (state.IsKeyDown(Keys.LeftControl)) direction.Y += 1;
            if (state.IsKeyDown(Keys.Space)) direction.Y -= 1;
            return direction;
        }
    }
}
