using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Input
{
    internal class Button
    {
        private Texture2D _texture;
        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        private bool _hovering;

        private Vector2 _position;

        private Rectangle _boundingBox { get {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public event EventHandler Click;

        public Button(Texture2D texture, Vector2 position)
        {
            _texture = texture; 
            _position = position;
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(_texture, _boundingBox, _hovering ? Color.White : Color.Gray);
        }

        public void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
            _hovering = false;
            if (!mouseRectangle.Intersects(_boundingBox)) return;
            _hovering = true;
            if (this._currentMouseState.LeftButton != ButtonState.Released || this._previousMouseState.LeftButton != ButtonState.Pressed) return;
            if (Click == null) return;
            Click((object)this, EventArgs.Empty);


        }
       
    }
}
