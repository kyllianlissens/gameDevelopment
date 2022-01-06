using GameDevelopment.Map;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{
    public class MovementManager
    {
        private int BoundsX;
        private int BoundsY;
        private int HeroSizeX;
        private int HeroSizeY;

        private static float JumpHeight = 5;
        private static float Friction = 0.99f;
        private static float Gravity = 0.10f;
        private static float BaseSpeed = 4f;
        public MovementManager(int boundsX, int boundsY, int sizeX, int sizeY)
        {
            BoundsX = boundsX;
            BoundsY = boundsY;
            HeroSizeX = sizeX;
            HeroSizeY = sizeY;
        }
        private bool IsGrounded(IMovable movable)
        {
            if (movable.Position.Y == (BoundsY - HeroSizeY))
                return true;
            return false;
        }
        public void Update(IMovable movable, Vector2 direction)
        {
            

            if (direction.Y == 1f && !IsGrounded(movable)) Accelerate(movable, 0, BaseSpeed); // Ctrl
            else if (direction.Y == -1f && IsGrounded(movable)) Accelerate(movable, 0, -JumpHeight); // Space
            if (direction.X == -1f) Move(movable, -BaseSpeed, 0); // Left
            else if (direction.X == 1f) Move(movable, BaseSpeed, 0); // Right

            Move(movable, movable.Speed.X, movable.Speed.Y);
            movable.Speed = new Vector2(movable.Speed.X * Friction, movable.Speed.Y * Friction);
            Accelerate(movable, 0, Gravity);
            ClampBounds(movable);
            UpdateState(movable, direction);
        }
        public void Accelerate(IMovable movable, float accelX, float accelY)
        {
            movable.Speed = new Vector2(movable.Speed.X + accelX, movable.Speed.Y + accelY);
        }
        public void Move(IMovable movable, float deltaX, float deltaY)
        {
            movable.Position = new Vector2(movable.Position.X + deltaX, movable.Position.Y + deltaY);




            bool touchingBounds = movable.Position.Y == 0f;
            if (touchingBounds)
            {
                movable.Speed = new Vector2(0, 0);
            }
        }
        public void ClampBounds(IMovable movable)
        {
            // TODO: Check Bounds and Grounds using Game1.gameboard
            if (movable.Position.X < 0 || movable.Position.Y < 0 || movable.Position.X > (BoundsX - HeroSizeX) || movable.Position.Y > (BoundsY - HeroSizeY))
            {
                if (movable.Position.X < 0) movable.Speed = new Vector2(Math.Min(0, movable.Speed.X), movable.Speed.Y);
                else if (movable.Position.X > (BoundsX - HeroSizeX)) movable.Speed = new Vector2(Math.Min(0, movable.Speed.X), movable.Speed.Y);
                if (movable.Position.Y < 0) movable.Speed = new Vector2(movable.Speed.X, Math.Min(0, movable.Speed.Y));
                else if (movable.Position.Y > (BoundsY - HeroSizeY)) movable.Speed = new Vector2(movable.Speed.X, Math.Min(0, movable.Speed.Y));
                movable.Position = new Vector2(Math.Clamp(movable.Position.X, 0, BoundsX - HeroSizeX), Math.Clamp(movable.Position.Y, 0, BoundsY - HeroSizeY));
            }
        }
        public void UpdateState(IMovable movable, Vector2 direction)
        {
            if (movable.Speed == Vector2.Zero)
                if (direction.Y == 1)
                    movable.State = IMovable.MovableState.Falling;
                else
                    movable.State = IMovable.MovableState.Idle;
            else if (movable.Speed.Y == 0)
                movable.State = IMovable.MovableState.Walking;
            else if (movable.Speed.Y < 0)
                movable.State = IMovable.MovableState.Jumping;
            else if (movable.Speed.Y > 0)
                movable.State = IMovable.MovableState.Falling;
        }
    }
}
