using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    public class MovementManager
    {
        public void Move(IMovable movable, Vector2 direction)
        {
            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;


            IMovable.MovableState newState = movable.State;
            if (newState == IMovable.MovableState.Idle || newState == IMovable.MovableState.Running || newState == IMovable.MovableState.Walking)
            {
                if (direction.X == 0f)
                {
                    newState = IMovable.MovableState.Idle;
                }
                else if (Math.Abs(direction.X) == 1f)
                {
                    newState = IMovable.MovableState.Walking;
                }
            }

            if (futurePosition.X < (800 - 64) && futurePosition.X > 0 && futurePosition.Y < 430 && futurePosition.Y > 0)
            {
                
                if (direction.Y == -1 )
                {
                    newState = IMovable.MovableState.Jumping;
                }

                if (newState == IMovable.MovableState.Jumping)
                {
                    if (futurePosition.Y >= 370)
                    {

                        futurePosition.Y -= 2;
                        movable.Position = futurePosition;
                    }
                    else newState = IMovable.MovableState.Falling;
                }

                else if (newState == IMovable.MovableState.Falling)
                {
                    if (movable.Position.Y < 418)
                    {
                        futurePosition.Y += 2;
                        movable.Position = futurePosition;
                    }
                    else
                    {
                        newState = IMovable.MovableState.Idle;
                    }

                }

                movable.Position = futurePosition;

            }

            movable.SetState(newState);



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
