using GameDevelopment.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Map
{
    class Block : IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; set; }
        public Texture2D Texture { get; set; }


        public Block(int x, int y, Texture2D texture)
        {
            
            //TODO: Recode to replace 8 with current mapSize 
            BoundingBox = new Rectangle(x * (Configuration.viewportWidth / MapManager.getInstance().currentMap.MapWidth), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)), Configuration.viewportWidth / MapManager.getInstance().currentMap.MapWidth, texture.Bounds.Height);

            var width = MapManager.getInstance().currentMap.MapHeight;


            Position = new Vector2(x, y);
            Texture = texture;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Texture, BoundingBox, Color.White);

            //spriteBatch.Draw(_texture, new Vector2((BoundingBox.X * scale) * Texture.Width , (640 - Texture.Height) - (BoundingBox.Y *Texture.Height )), null, Color.Red, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public bool CheckCollision(Rectangle rec)
        {
            return BoundingBox.Intersects(rec);
        }
    }
}
