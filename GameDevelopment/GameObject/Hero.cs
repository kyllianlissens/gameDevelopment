using GameDevelopment.GameState;
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
        private int scale;
        private MovementManager movementManager;
        private Dictionary<IMovable.MovableState, Animation> animations;
        public int health;
        public int score;
        private Vector2 position;
        private Vector2 speed;
        private SpriteEffects lastDirection;
        private IInputReader inputReader;

        private IMovable.MovableState state;

        public Rectangle BoundingBox => new Rectangle((int)position.X, (int)position.Y, (int)(24 * scale), (int)(30 * scale));
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            health = 3;
            this.texture = texture;
            scale = 2;
            this.inputReader = inputReader;
            movementManager = new MovementManager(800, 480, 64, 64);
            animations = new Dictionary<IMovable.MovableState, Animation>();
            State = IMovable.MovableState.Idle;

            position = new Vector2(300, 300);
            speed = new Vector2(0, 0);

            animations[IMovable.MovableState.Idle] = new Animation(_fps: 8);
            animations[IMovable.MovableState.Idle].AddFramesFromTextureProperties(32, 32, 1, 12);
            animations[IMovable.MovableState.Walking] = new Animation(_fps: 15);
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
            float boundingBoxOffsetWidth = (32f - BoundingBox.Width/scale) / scale;
            if (lastDirection == SpriteEffects.None) boundingBoxOffsetWidth -= 3.5f;
            else boundingBoxOffsetWidth += 2f;

            float boundingBoxOffsetHeight = (32f - BoundingBox.Height/scale);

            spriteBatch.Draw(texture, position, animations[State].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(boundingBoxOffsetWidth, boundingBoxOffsetHeight), scale, lastDirection, 0);
        }

        public void ResetPosition(Vector2 newPosition)
        {
            State = IMovable.MovableState.Idle;
            speed = new Vector2(0, 0);
            position = newPosition;
        }

        public void ResetHero()
        {
            health = 3;
            score = 0;
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animations[State].Update(gameTime);

            foreach (var coin in StateManager.getInstance().GetCoins())
            {
                if (!coin.Active)
                    continue;
                if (coin.CheckCollision(BoundingBox))
                {
                    score++;
                    // Do level progression in Level class itself
                    if (StateManager.getInstance().GetLevel().ProgressCoinTaken(coin))
                        return; // Return if GameState has been changed to cancel the Update()
                }
            }

            foreach (var trap in StateManager.getInstance().GetTraps())
            {
                if (!trap.Active)
                    continue;
                if (trap.CheckCollision(BoundingBox))
                {
                    --health;
                    ResetPosition(StateManager.getInstance().GetSpawnPosition());
                    return;
                }
            }

            foreach (var enemy in StateManager.getInstance().GetEnemies())
            {
                if (!enemy.Active)
                    continue;
                if (enemy.State == IMovable.MovableState.Dying)
                    continue;
                if (enemy.CheckCollision(BoundingBox))
                {
                    Rectangle collision = Rectangle.Intersect(this.BoundingBox, enemy.BoundingBox);

                    if (collision.Width > collision.Height && this.BoundingBox.Bottom > enemy.BoundingBox.Top && this.BoundingBox.Bottom < enemy.BoundingBox.Bottom)
                    {
                        enemy.Destroy();
                    }
                    else
                    {
                        --health;
                        ResetPosition(StateManager.getInstance().GetSpawnPosition());
                        return;
                    }
                }
            }
        }

        private void Move()
        {
            Vector2 direction = this.InputReader.ReadInput();

            if (direction.X == 1)
                lastDirection = SpriteEffects.None;
            else if (direction.X == -1)
                lastDirection = SpriteEffects.FlipHorizontally;

            movementManager.Update(this, direction);
        }

        IInputReader InputReader { get => inputReader; set => inputReader = value; }
        Vector2 IGameObject.Position { get => position; set => position = value; }
        Vector2 IMovable.Speed { get => speed; set => speed = value; }
        public IMovable.MovableState State { get => state; set => state = value; }
    }
}
