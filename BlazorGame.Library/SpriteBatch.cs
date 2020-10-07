using BlazorGame.Library.Graphics;
using System.Drawing;
using System.Numerics;

namespace BlazorGame.Library
{
    public class SpriteBatch
    {
        private readonly IGraphicsDevice _graphicsDevice;

        public SpriteBatch(IGraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void Begin()
        {

        }

        public void End()
        {

        }

        public void Draw(Texture2D texture, Vector2 location, in Color color)
        {
            _graphicsDevice.DrawTexture(texture.Position, location.X, location.Y, color);
        }

        public void Draw(Texture2D texture, Vector2 location, string a, in Color color, float b, Vector2 offset, float scale, SpriteEffects effect, float c)
        {
            _graphicsDevice.DrawTexture(texture.Position, location.X - offset.X, location.Y - offset.Y, color);
        }
    }
}
