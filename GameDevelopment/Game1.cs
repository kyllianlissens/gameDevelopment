using GameDevelopment.GameObject;
using GameDevelopment.GameState;
using GameDevelopment.Input;
using GameDevelopment.Texture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private Texture2D _block2Texture;
        private Texture2D _spikeTexture;
        private Texture2D _ghost1Texture;
        private Texture2D _ghost2Texture;
        private Texture2D _playButtonTexture;
        private Texture2D _menuButtonTexture;
        private Texture2D _backgroundTexture;
        private Texture2D _healthicons;
        private Texture2D _coin;
        private SpriteFont _font;

        private Hero hero;
        private Song _backgroundAudio;
        private Background background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = Configuration.gameTitle;
        }

        protected override void Initialize()
        {
            base.Initialize();

            hero = new Hero(_heroTexture, new KeyboardReader());
            background = new Background(_backgroundTexture, _backgroundAudio);
            background.Initialize();

            Menu.getInstance().Initialise(_font, _playButtonTexture);
            Dead.getInstance().Initialise(_font, _menuButtonTexture);
            Victory.getInstance().Initialise(_font, _menuButtonTexture);

            Level1.getInstance().Initialize(_blockTexture, _spikeTexture, _ghost1Texture, _ghost2Texture, _font, _healthicons, _coin, hero);
            Level2.getInstance().Initialize(_block2Texture, _spikeTexture, _ghost1Texture, _ghost2Texture, _font, _healthicons, _coin, hero);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _heroTexture = Content.Load<Texture2D>("doctor");
            _blockTexture = Content.Load<Texture2D>("block");
            _block2Texture = Content.Load<Texture2D>("block2");
            _spikeTexture = Content.Load<Texture2D>("spiketrap");
            _backgroundTexture = Content.Load<Texture2D>("background");
            _playButtonTexture = Content.Load<Texture2D>("play");
            _menuButtonTexture = Content.Load<Texture2D>("menu");
            _ghost1Texture = Content.Load<Texture2D>("ghostchloe");
            _ghost2Texture = Content.Load<Texture2D>("ghostwilly");
            _font = Content.Load<SpriteFont>("scoreFont");
            _healthicons = Content.Load<Texture2D>("healthui");
            _coin = Content.Load<Texture2D>("coin");

            _backgroundAudio = Content.Load<Song>("bgmusic");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            StateManager.getInstance().Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            background.Draw(_spriteBatch);

            StateManager.getInstance().Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

       
    }
}
