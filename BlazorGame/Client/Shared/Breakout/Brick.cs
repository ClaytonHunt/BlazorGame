using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Breakout
{
    public class Brick : IPhysics2D
    {
        private Texture2D _sprite;
        private Vector2 _position;
        private Vector2 _offset;

        public Texture2D Sprite => _sprite;
        public Rectangle Bounds { get; set; }
        public Vector2 Position => _position;
        public Vector2 Offset => _offset;
        public void HasCollided(IPhysics2D collider)
        {
            HandleCollision();
        }

        public List<IPhysics2D> Colliders { get; }= new();
        public bool IsAlive { get; set; } = true;

        public void Initialize(Texture2D sprite, Vector2 position, GraphicsDeviceManager graphics)
        {
            _sprite = sprite;
            _position = position;
            _offset = new Vector2(_sprite.Width / 2, _sprite.Height / 2);

            ((IPhysics2D)this).CalculateBounds();
        }

        public void AddCollider(IPhysics2D go)
        {
            Colliders.Add(go);
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            if(IsAlive)
            {
                if (Colliders.Any(x => x.Bounds.Intersects(Bounds)))
                {
                    HandleCollision();
                }

                ((IPhysics2D)this).CalculateBounds();
            }
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                await spriteBatch.Draw(_sprite, _position - _offset, Color.White);
            }
        }

        private void HandleCollision()
        {
            IsAlive = false;
            _position = Vector2.Zero - _position;
        }
    }
}
