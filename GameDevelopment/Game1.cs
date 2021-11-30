using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopment
{



    public abstract class GameState
    {
        protected abstract void Initialize();
        protected abstract void Update(GameTime gameTime);
        protected abstract void Draw(GameTime gameTime);

    }

    public class MenuState : GameState
    {
        protected override void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        protected override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }



    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

      
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);




            base.Draw(gameTime);
        }
    }
}
