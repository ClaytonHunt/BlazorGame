using System;
using System.Linq;
using BlazorGame.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Breakout
{
    public class BreakerBall : IPhysics2D
    {
        private Texture2D _sprite;
        private Vector2 _position;
        private Vector2 _startPosition;
        private int _screenWidth;
        private int _screenHeight;
        private Vector2 _offset;
        private Vector2 _maxSpeed = new(256, 256);
        private Vector2 _moveSpeed = new(256, 256);
        private float _border = 0;

        public Texture2D Sprite => _sprite;
        public Rectangle Bounds { get; set; }
        public Vector2 Position => _position;
        public Vector2 Offset => _offset;
        public List<IPhysics2D> Colliders { get; } = new();

        public void Initialize(Texture2D sprite, Vector2 position, GraphicsDeviceManager graphics)
        {
            _sprite = sprite;
            _startPosition = position;
            _position = position;
            _screenWidth = graphics.GraphicsDevice.Viewport.TitleSafeArea.Width;
            _screenHeight = graphics.GraphicsDevice.Viewport.TitleSafeArea.Height;
            _offset = new Vector2(_sprite.Width / 2, _sprite.Height / 2);

            ((IPhysics2D)this).CalculateBounds();
        }

        public void AddCollider(IPhysics2D go)
        {
            Colliders.Add(go);
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _position += _moveSpeed * new Vector2(delta, delta);

            var lowerXBound = _border;
            var lowerYBound = _border;
            var upperXBound = (_screenWidth - _border);
            var upperYBound = (_screenHeight - _border);

            CalculateScreenCollision(upperYBound, lowerXBound, lowerYBound, upperXBound);

            Colliders.Where(x => x.Bounds.Intersects(Bounds)).ToList().ForEach(HandleCollision);
        }

        private void CalculateCollision(float top, float right, float bottom, float left)
        {
            // TODO: Something not right with this method

            if((_position - _offset).X < right && (_position + _offset).X > left) { }
            else if ((_position - _offset).X < right)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X;
            }
            else if ((_position + _offset).X > left)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X * -1;
            }

            if ((_position - _offset).Y < bottom)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y;
            }

            if ((_position + _offset).Y > top)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y * -1;
            }

            ((IPhysics2D) this).CalculateBounds();
        }

        private void CalculateScreenCollision(float top, float right, float bottom, float left)
        {
            if ((_position - _offset).X < right)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X;
            }

            if ((_position + _offset).X > left)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X * -1;
            }

            if ((_position - _offset).Y < bottom)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y;
            }

            if ((_position + _offset).Y > top)
            {
                _position = _startPosition;
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y * -1;
            }

            ((IPhysics2D) this).CalculateBounds();
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            await spriteBatch.Draw(_sprite, _position - _offset, Color.White);
        }

        public void HasCollided(IPhysics2D collider)
        {
            HandleCollision(collider);
        }

        private void HandleCollision(IPhysics2D collider)
        {
            CalculateCollision(collider.Bounds.Top, collider.Bounds.Right, collider.Bounds.Bottom, collider.Bounds.Left);

            collider.HasCollided(this);

            ((IPhysics2D)this).CalculateBounds();
        }
    }
}
