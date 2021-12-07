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


            if (futurePosition.X < (800 - 64) && futurePosition.X > 0 && futurePosition.Y < 430 && futurePosition.Y > 0)
            {
                
                if (direction.Y == -1 )
                {
                    movable.State = IMovable.MovableState.Jumping;
                }

                if (movable.State == IMovable.MovableState.Jumping)
                {
                    if (futurePosition.Y >= 370)
                    {

                        futurePosition.Y -= 2;
                        movable.Position = futurePosition;
                    }
                    else movable.State = IMovable.MovableState.Falling;
                }

                else if (movable.State == IMovable.MovableState.Falling)
                {
                    if (movable.Position.Y < 418)
                    {
                        futurePosition.Y += 2;
                        movable.Position = futurePosition;
                    }
                    else
                    {
                        movable.State = IMovable.MovableState.Idle;
                    }

                }

                movable.Position = futurePosition;

            }



            /*if (movable.State == IMovable.MovableState.Falling)
            {
                if (movable.Position.Y < (480 - 64))
                {
                    futurePosition.Y += 2;
                    movable.Position = futurePosition;
                }
                else
                {
                    movable.State = IMovable.MovableState.Idle;
                }
            }*/
            

           

            /* if (futurePosition.Y < (480 - 64 - 64))
            {

                movable.State = IMovable.MovableState.Falling;
            }
           */
        }


    }
}
