using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{


    public interface IMovable
    {
        public enum MovableState { Idle, Running, Walking, Falling, Jumping };
        public MovableState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }

    }

}
