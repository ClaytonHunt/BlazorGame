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
        private const float Border = 0;
        private int _screenWidth;
        private int _screenHeight;
        private Vector2 _startPosition;
        private Vector2 _moveSpeed = new(256, 256);
        private readonly Vector2 _maxSpeed = new(256, 256);
        
        public Rectangle Bounds { get; set; }
        public bool IsActive { get; set; } = true;
        public Vector2 Offset { get; private set; }
        public Texture2D Sprite { get; private set; }
        public Vector2 Position { get; private set; }
        
        public void Initialize(Texture2D sprite, Vector2 position, GraphicsDeviceManager graphics)
        {
            Sprite = sprite;
            _startPosition = position;
            Position = position;
            _screenWidth = graphics.GraphicsDevice.Viewport.TitleSafeArea.Width;
            _screenHeight = graphics.GraphicsDevice.Viewport.TitleSafeArea.Height;
            Offset = new Vector2(Sprite.Width / 2f, Sprite.Height / 2f);

            ((IPhysics2D)this).CalculateBounds();
        }

        public void Update(GameTime gameTime, KeyboardState keyState, List<IPhysics2D> colliders)
        {
            if (!IsActive) return;

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += _moveSpeed * new Vector2(delta, delta);

            const float lowerXBound = Border;
            const float lowerYBound = Border;
            var upperXBound = (_screenWidth - Border);
            var upperYBound = (_screenHeight - Border);

            CalculateScreenCollision(upperYBound, lowerXBound, lowerYBound, upperXBound);

            colliders.Where(x => x != this && 
                                 x.IsActive && 
                                 x.Bounds.Intersects(Bounds)).ToList().ForEach(HandleCollision);
        }

        private void CalculateCollision(float top, float right, float bottom, float left)
        {
            // TODO: Something not right with this method

            if((Position - Offset).X < right && (Position + Offset).X > left) { }
            else if ((Position - Offset).X < right)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X;
            }
            else if ((Position + Offset).X > left)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X * -1;
            }

            if ((Position - Offset).Y < bottom)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y;
            }

            if ((Position + Offset).Y > top)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y * -1;
            }

            ((IPhysics2D) this).CalculateBounds();
        }

        private void CalculateScreenCollision(float top, float right, float bottom, float left)
        {
            if ((Position - Offset).X < right)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X;
            }

            if ((Position + Offset).X > left)
            {
                _moveSpeed.X = ((float) new Random().NextDouble()) * _maxSpeed.X * -1;
            }

            if ((Position - Offset).Y < bottom)
            {
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y;
            }

            if ((Position + Offset).Y > top)
            {
                // IsActive = false;
                Position = _startPosition;
                _moveSpeed.Y = ((float) new Random().NextDouble()) * _maxSpeed.Y * -1;
            }

            ((IPhysics2D) this).CalculateBounds();
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            await spriteBatch.Draw(Sprite, Position - Offset, Color.White);
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
