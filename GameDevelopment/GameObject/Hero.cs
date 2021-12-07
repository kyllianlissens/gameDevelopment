using GameDevelopment.Input;
using GameDevelopment.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameDevelopment.GameObject
{
    public class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        private MovementManager movementManager;
        private Dictionary<IMovable.MovableState, Animation> animations;

        private Vector2 position;
        private Vector2 speed;
        private SpriteEffects lastDirection;
        private IInputReader inputReader;

        private IMovable.MovableState state;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.inputReader = inputReader;
            movementManager = new MovementManager();
            animations = new Dictionary<IMovable.MovableState, Animation>();
            State = IMovable.MovableState.Idle;

            position = new Vector2(300, 300);
            speed = new Vector2(1, 1);

            animations[IMovable.MovableState.Idle] = new Animation();
            animations[IMovable.MovableState.Idle].AddFramesFromTextureProperties(32, 32, 1, 12);
            animations[IMovable.MovableState.Running] = new Animation();
            animations[IMovable.MovableState.Running].AddFramesFromTextureProperties(32, 32, 2, 8);
            animations[IMovable.MovableState.Walking] = new Animation();
            animations[IMovable.MovableState.Walking].AddFramesFromTextureProperties(32, 32, 2, 8);
            animations[IMovable.MovableState.Falling] = new Animation();
            animations[IMovable.MovableState.Falling].AddFramesFromTextureProperties(32, 32, 5, 4, 2, 2);
            animations[IMovable.MovableState.Jumping] = new Animation();
            animations[IMovable.MovableState.Jumping].AddFramesFromTextureProperties(32, 32, 2, 2, 2, 2);
        }

        void IMovable.SetState(IMovable.MovableState newState)
        {
            if (newState != State)
                animations[newState].ResetFrame();
            State = newState;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[State].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0,0), 2f, this.lastDirection, 0);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animations[State].Update(gameTime);
        }

        private void Move()
        {
            Vector2 direction = ((IMovable)this).InputReader.ReadInput();

            if (direction.X == 1)
                lastDirection = SpriteEffects.None;
            else if (direction.X == -1)
                lastDirection = SpriteEffects.FlipHorizontally;
            
            //if (direction.X == 0f)
            //    ChangeState(IMovable.MovableState.Idle);
            //else if (Math.Abs(direction.X) == 1f)
            //    ChangeState(IMovable.MovableState.Walking);
            //else
            //    ChangeState(IMovable.MovableState.Running);

            movementManager.Move(this, direction);
        }

        Vector2 IMovable.Position { get => position; set => position = value; }
        Vector2 IMovable.Speed { get => speed; set => speed = value; }
        IInputReader IMovable.InputReader { get => inputReader; set => inputReader = value; }
        public IMovable.MovableState State { get => state; set => state = value; }
    }
}
