using GameDevelopment.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

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

        private SpriteSheet _player;

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
            // TODO: use this.Content to load your game content here
            List<Sprite> playerSpritesIdle = Enumerable.Range(0, 12).Select(i => new Sprite(0+i*32, 160, 32+i*32, 160+32, 0.1f)).ToList();

            _player = new SpriteSheet(
                Content.Load<Texture2D>("doctor"),
                new Dictionary<SpriteState, List<Sprite>>() {
                    [SpriteState.Idle] = playerSpritesIdle
                }
            );
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            Sprite currentSprite = _player.GetSprite(SpriteState.Idle, gameTime.TotalGameTime);
            Rectangle rectangle = new Rectangle(currentSprite.StartPosition.ToPoint(), new Point(32, 32));
            _spriteBatch.Draw(_player.Texture, new Vector2(128, 128), rectangle, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
