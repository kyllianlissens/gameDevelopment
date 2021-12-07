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
    public enum HeroState
    {
        Idle,
        Walking,
        Running,
        Attacking
    }
    public class Hero : IGameObject, IMovable
    {
        private Texture2D texture;
        private MovementManager movementManager;
        private Dictionary<HeroState, Animation> animations;
        private HeroState state;

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
            animations = new Dictionary<HeroState, Animation>();
            foreach (HeroState heroState in Enum.GetValues(typeof(HeroState)))
            {
                animations.Add(heroState, new Animation());
            }
            state = HeroState.Idle;

            position = new Vector2(300, 300);
            speed = new Vector2(1, 1);

            animations[HeroState.Idle].AddFramesFromTextureProperties(32, 32, 1, 12);
            animations[HeroState.Walking].AddFramesFromTextureProperties(32, 32, 2, 8);
        }

        private void ChangeState(HeroState newState)
        {
            if (newState != state)
                animations[newState].ResetFrame();
            state = newState;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animations[state].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0,0), 2f, this.lastDirection, 0);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animations[state].Update(gameTime);
        }

        private void Move()
        {
            Vector2 direction = ((IMovable)this).InputReader.ReadInput();

            if (direction.X == 1)
                lastDirection = SpriteEffects.None;
            else if (direction.X == -1)
                lastDirection = SpriteEffects.FlipHorizontally;
            
            if (direction.X == 0f)
                ChangeState(HeroState.Idle);
            else if (Math.Abs(direction.X) == 1f)
                ChangeState(HeroState.Walking);
            else
                ChangeState(HeroState.Running);

            movementManager.Move(this, direction);
        }

        Vector2 IMovable.Position { get => position; set => position = value; }
        Vector2 IMovable.Speed { get => speed; set => speed = value; }
        IInputReader IMovable.InputReader { get => inputReader; set => inputReader = value; }
        public IMovable.MovableState State { get => state; set => state = value; }
    }
}
