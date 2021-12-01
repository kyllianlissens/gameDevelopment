using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    public class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();

            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;


            if (futurePosition.X < (800 - 64) && futurePosition.X > 0 && futurePosition.Y < (480 - 64) && futurePosition.Y > 0)
            {
                movable.Position = futurePosition;
            }


        }


    }
}
