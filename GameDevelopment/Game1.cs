using GameDevelopment.GameObject;
using GameDevelopment.GameState;
using GameDevelopment.Input;
using GameDevelopment.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace GameDevelopment
{



 

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private RenderTarget2D _scene;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _blockTexture;
        private Texture2D _spikeTexture;

        private Texture2D _backgroundTexture;
        private SpriteFont _font;

        private Hero hero;
        private Background background;
        private int score = 0;

        public Game1()
        {

            //_scene = new RenderTarget2D(_graphics.GraphicsDevice, 1366, 768, false, SurfaceFormat.Color, DepthFormat.None, 4, RenderTargetUsage.DiscardContents);
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

           

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic 

            base.Initialize();

            hero = new Hero(_heroTexture, new KeyboardReader());
            background = new Background(_backgroundTexture);
            background.Initialize();

            Level1.Initialize(_blockTexture, _spikeTexture, hero);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            _heroTexture = Content.Load<Texture2D>("doctor");
            _blockTexture = Content.Load<Texture2D>("block");
            _spikeTexture = Content.Load<Texture2D>("spiketrap");
            _backgroundTexture = Content.Load<Texture2D>("background");
            _font = Content.Load<SpriteFont>("scoreFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            StateManager.getInstance().Update(gameTime);
            base.Update(gameTime);

            score++;
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            background.Draw(_spriteBatch);

            StateManager.getInstance().Draw(_spriteBatch);
           

            //Draw collisions for debugging

           //bool debugCollisions = true;
           // if (debugCollisions)
           //     {
           //         var t = new Texture2D(GraphicsDevice, 1, 1);
           //         t.SetData(new[] { Color.Red });
           //         foreach (Rectangle boundingBox in _mapManager.currentMap.Blocks.Select(x => x.BoundingBox).Concat(new List<Rectangle>() { hero.BoundingBox }))
           //         {
           //             int bw = 2; // Border width

           //             _spriteBatch.Draw(t, new Rectangle(boundingBox.Left, boundingBox.Top, bw, boundingBox.Height), Color.Black); // Left
           //             _spriteBatch.Draw(t, new Rectangle(boundingBox.Right, boundingBox.Top, bw, boundingBox.Height), Color.Black); // Right
           //             _spriteBatch.Draw(t, new Rectangle(boundingBox.Left, boundingBox.Top, boundingBox.Width, bw), Color.Black); // Top
           //             _spriteBatch.Draw(t, new Rectangle(boundingBox.Left, boundingBox.Bottom, boundingBox.Width, bw), Color.Black); // Bottom
           //         }
           //     }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

       
    }
}
