using BlazorGame.Library;
using BlazorGame.Library.Graphics;
using System;
using System.Drawing;
using System.Numerics;

namespace BlazorGame.Client.Shared
{
    public class Player
    {
        private float _ballSpeed = 200;
        private Texture2D PlayerTexture;
        private Vector2 Position;
        private int BufferWidth;
        private int BufferHeight;
        private bool Active;
        private int Health;
        private int Width => PlayerTexture.Width;
        private int Height => PlayerTexture.Height;

        public void Initialize(Texture2D texture, Vector2 position, GraphicsDeviceManager graphics)
        {
            PlayerTexture = texture;
            Position = position;
            BufferWidth = graphics.GraphicsDevice.PreferredBackBufferWidth;
            BufferHeight = graphics.GraphicsDevice.PreferredBackBufferHeight;
            Active = true;
            Health = 100;
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
                Position.Y -= _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Down))
                Position.Y += _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Left))
                Position.X -= _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Right))
                Position.X += _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            Position.X = Math.Min(Math.Max(Width / 2.0f, Position.X), BufferWidth - Width / 2);
            Position.Y = Math.Min(Math.Max(Height / 2.0f, Position.Y), BufferHeight - Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
