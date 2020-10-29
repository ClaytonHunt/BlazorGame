using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;
using System;

namespace BlazorGame.Client.Shared
{
    public class BreakoutPlayer
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
            BufferWidth = graphics.GraphicsDevice.Viewport.TitleSafeArea.Width;
            BufferHeight = graphics.GraphicsDevice.Viewport.TitleSafeArea.Height;
            Active = true;
            Health = 100;

            Console.WriteLine($"Buffer Width: {BufferWidth}, Height: {BufferHeight}");
            Console.WriteLine($"Texture Width: {Width}, Height: {Height}");
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
                Position.Y -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Down))
                Position.Y += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Left))
                Position.X -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Right))
                Position.X += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position.X = Math.Min(Math.Max(0, Position.X), BufferWidth - Width);
            Position.Y = Math.Min(Math.Max(0, Position.Y), BufferHeight - Height);

            Console.WriteLine($"Player Position X: {Position.X}, Y: {Position.Y}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
