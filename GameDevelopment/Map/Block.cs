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
        public Rectangle BoundingBox { get; set; }
        public Color Color { get; set; }
        public bool Passable { get; set; }
        public Texture2D Texture { get; set; }

        private float scale = 3.12f;

        public Block(int x, int y, Texture2D texture)
        {
            
            //TODO: Recode to replace 8 with current mapSize 
            BoundingBox = new Rectangle(x * (Configuration.viewportWidth / 8), (Configuration.viewportHeight - (Configuration.defaultTileSize * y)), Configuration.viewportWidth / 8, texture.Bounds.Height);
            Color = Color.White;
            Passable = false;
            Texture = texture;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            

            Texture2D _texture;

            _texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.DarkSlateGray });

          
            spriteBatch.Draw(_texture, BoundingBox, Color.Red);

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
