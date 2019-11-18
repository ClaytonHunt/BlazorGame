using System.Drawing;
using System.Numerics;

namespace BlazorGame.Services
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
    }
}
