using System.Collections.Generic;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;
using System.Threading.Tasks;

namespace BlazorGame.Client.Shared.Breakout
{
    public class Paddle : IPhysics2D
    {
        private Texture2D _sprite;
        private Vector2 _position;
        private int _screenWidth;
        private Vector2 _offset;
        private float _moveSpeedX = 512;
        private float _border = 10;

        public Texture2D Sprite => _sprite;
        public Rectangle Bounds { get; set; }
        public Vector2 Position => _position;
        public Vector2 Offset => _offset;
        public bool IsActive { get; set; } = true;

        public void Initialize(Texture2D sprite, Vector2 position, GraphicsDeviceManager graphics)
        {
            _sprite = sprite;
            _position = position;
            _screenWidth = graphics.GraphicsDevice.Viewport.TitleSafeArea.Width;
            _offset = new Vector2(_sprite.Width / 2f, _sprite.Height / 2f);

            ((IPhysics2D)this).CalculateBounds();
        }

        public void Update(GameTime gameTime, KeyboardState keyState, List<IPhysics2D> colliders)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(keyState.IsKeyDown(Keys.A) && (_position - _offset).X > _border)
            {
                _position.X -= _moveSpeedX * delta;
            }

            if(keyState.IsKeyDown(Keys.D) && (_position + _offset).X < (_screenWidth - _border))
            {
                _position.X += _moveSpeedX * delta;
            }

            ((IPhysics2D)this).CalculateBounds();
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {            
            await spriteBatch.Draw(_sprite, _position - _offset, Color.White);
        }

        public void HasCollided(IPhysics2D collider) { }
    }
}
