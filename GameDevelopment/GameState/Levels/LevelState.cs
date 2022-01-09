using GameDevelopment.GameObject;
using GameDevelopment.MapEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.GameState
{
    internal class LevelState
    {
        public Map map;
        protected int coinstaken;
        protected Hero hero;
        protected SpriteFont font;
        protected Texture2D healthui;
        protected Texture2D coinTexture;
        protected void Initialize(int[,] _tileMap, Vector2 _spawnPosition, Texture2D _blockTexture, Texture2D _spikeTexture, Texture2D _ghost1Texture, Texture2D _ghost2Texture, SpriteFont _font, Texture2D _healthui, Texture2D _coinTexture, Hero _hero)
        {
            map = new Map(_tileMap, _tileMap.GetLength(1), _tileMap.GetLength(0), _spawnPosition, _blockTexture, _spikeTexture, _ghost1Texture, _ghost2Texture, _coinTexture);
            map.ResetMap();
            hero = _hero;
            font = _font;
            healthui = _healthui;
            coinTexture = _coinTexture;
        }
        public void DrawUI(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthui, new Vector2(10, 10), new Rectangle(0, (3 - hero.health) * 2 * 11, 33, 11), Color.Red, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(coinTexture, new Vector2(16, 10 + 11 * 4), new Rectangle(0, 0, 32, 34), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, $"{hero.score}", new Vector2(16 + 32 + 8, 10 + 11 * 4 + 1), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            hero.Draw(spriteBatch);

            DrawUI(spriteBatch);
        }
        public virtual void Update(GameTime gameTime)
        {
            map.Update(gameTime);
            hero.Update(gameTime);
            if (hero.health <= 0)
                StateManager.getInstance().SetState(StateManager.GameState.Dead);
        }
        public virtual void PrepareLevel()
        {
            coinstaken = 0;
            map.ResetMap();
            hero.ResetHero();
            hero.ResetPosition(map.SpawnPosition);
        }
        public virtual bool ProgressCoinTaken(Coin coin)
        {
            coinstaken++;
            coin.SetInactive();
            return false;
        }
    }
}
