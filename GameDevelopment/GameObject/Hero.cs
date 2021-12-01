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
        private Animation animation;

        private Vector2 position;
        private Vector2 speed;
        private IInputReader inputReader;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.inputReader = inputReader;
            movementManager = new MovementManager();
            animation = new Animation();

            position = new Vector2(32, 32);
            speed = new Vector2(1, 1);
            
            //TODO: Implement the GetFramesFromTextureProperties function animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 12, 6);


            for (int i = 0; i < 8; i++)
            {
                animation.AddFrame(new AnimationFrame(new Rectangle(0 + i * 32, 32, 32, 32)));
            }
        }

       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0,0), 2f, SpriteEffects.None, 0);

        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            
        }


        private void Move()
        {
            movementManager.Move(this);
           
        }

        Vector2 IMovable.Position { get => position; set => position = value; }
        Vector2 IMovable.Speed { get => speed; set => speed = value; }
        IInputReader IMovable.InputReader { get => inputReader; set => inputReader = value; }
    }
}
