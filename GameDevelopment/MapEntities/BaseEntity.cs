using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.MapEntities
{
    internal class BaseEntity : IGameObject, ICollidable
    {
        public bool Active { get; set; } = true;
        public virtual Vector2 Position { get; set; }
        public virtual Rectangle BoundingBox { get; set; }
        public Texture2D Texture { get; set; }

        public BaseEntity() { }

        public BaseEntity(int x, int y, Texture2D texture)
        {
            //TODO: Recode to replace 8 with current mapSize 
            BoundingBox = new Rectangle(x * (Configuration.viewportWidth / 23), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)), Configuration.viewportWidth / 23, texture.Bounds.Height);

            Position = new Vector2(x, y);
            Texture = texture;
        }

        public virtual void SetActive() => Active = true;
        public virtual void SetInactive() => Active = false;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;
            spriteBatch.Draw(Texture, BoundingBox, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckCollision(Rectangle rec)
        {
            return BoundingBox.Intersects(rec);
        }
    }
}
