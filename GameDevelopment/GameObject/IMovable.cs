using GameDevelopment.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameObject
{


    public interface IMovable : IGameObject
    {
        public enum MovableState { Idle, Running, Walking, Falling, Jumping, Dying };
        public void SetState(MovableState state);
        public MovableState State { get; set; }
        public Vector2 Speed { get; set; }

    }

}
