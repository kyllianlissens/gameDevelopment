using GameDevelopment.GameObject;
using GameDevelopment.GameState;
using GameDevelopment.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.MapEntities
{
    internal class Enemy : BaseEntity, IMovable
    {
        private Vector2 size;
        private Vector2 position;
        private Vector2 speed;
        private SpriteEffects lastDirection;
        private IMovable.MovableState state;

        private MovementManager movementManager;

        private Dictionary<IMovable.MovableState, Animation> animations;

        public override Rectangle BoundingBox => new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

        public Enemy(int x, int y, Texture2D texture, float baseSpeed = 0.5f)
        {
            float scale = 2f;
            position = new Vector2(x * (Configuration.viewportWidth / 23), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)) - (int)(texture.Bounds.Height));
            size = new Vector2(Configuration.viewportWidth / 23 - 5, (int)(texture.Bounds.Height * scale * 1.5f));

            Texture = texture;

            movementManager = new MovementManager(800, 480, 32, 64, baseSpeed: baseSpeed);

            animations = new Dictionary<IMovable.MovableState, Animation>();
            State = IMovable.MovableState.Walking;

            ((IGameObject)this).Position = new Vector2(BoundingBox.X, BoundingBox.Y);
            speed = new Vector2(0, 0);

            animations[IMovable.MovableState.Idle] = new Animation();
            animations[IMovable.MovableState.Idle].AddFramesFromTextureProperties(16, 16, 1, 3);
            animations[IMovable.MovableState.Walking] = new Animation();
            animations[IMovable.MovableState.Walking].AddFramesFromTextureProperties(16, 16, 1, 3);
            animations[IMovable.MovableState.Falling] = new Animation();
            animations[IMovable.MovableState.Falling].AddFramesFromTextureProperties(16, 16, 1, 3);
            animations[IMovable.MovableState.Dying] = new Animation(_repeat: false);
            animations[IMovable.MovableState.Dying].AddFramesFromTextureProperties(16, 16, 1, 15, startSprite: 4, endSprite: 8);

        }
        public void Destroy()
        {
            movementManager = null;
            size = Vector2.Zero;
            ((IMovable)this).SetState(IMovable.MovableState.Dying);
        }
        void IMovable.SetState(IMovable.MovableState newState)
        {
            if (State == IMovable.MovableState.Dying)
                return;
            if (newState != State)
                animations[newState].ResetFrame();
            State = newState;
        }

        //public override bool CheckCollision(Rectangle rec)
        //{
        //    return BoundingBox.Intersects(rec);
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, ((IGameObject)this).Position, animations[State].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, lastDirection, 0);
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            animations[State].Update(gameTime);

            // Reverse direction on touching a block
            foreach (var block in StateManager.getInstance().GetBlocks())
            {
                Rectangle boundingBox = block.BoundingBox;
                boundingBox.Inflate(1, 0);
                if (this.BoundingBox.Intersects(boundingBox))
                {
                    if (this.BoundingBox.Left == block.BoundingBox.Right)
                    {
                        lastDirection = SpriteEffects.None;
                    }
                    else if (this.BoundingBox.Right == block.BoundingBox.Left)
                    {
                        lastDirection = SpriteEffects.FlipHorizontally;
                    }
                }
            }
        }
        private void Move()
        {
            if (movementManager == null)
                return;
            Vector2 direction = new Vector2(lastDirection == SpriteEffects.None ? 1 : -1, 0);

            movementManager.Update(this, direction);
        }

        public override Vector2 Position { get => position; set => position = value; }
        Vector2 IMovable.Speed { get => speed; set => speed = value; }
        public IMovable.MovableState State { get => state; set => state = value; }
    }
}
