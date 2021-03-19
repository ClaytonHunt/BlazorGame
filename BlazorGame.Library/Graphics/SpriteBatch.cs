using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorGame.Framework.Graphics
{
    public class SpriteBatch : GraphicsResource, IDisposable
    {
        private readonly IGraphicsDevice _graphicsDevice;
        private readonly IJSRuntime _jsRuntime;

        public SpriteBatch(IGraphicsDevice graphicsDevice, IJSRuntime jsRuntime)
        {
            _graphicsDevice = graphicsDevice;
            _jsRuntime = jsRuntime;
        }

        public SpriteBatch(IGraphicsDevice graphicsDevice, int capacity)
        {
            throw new NotImplementedException();
        }

        public Task Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default(Matrix?))
        {
            return Task.CompletedTask;
        }

        public Task End()
        {
            return Task.CompletedTask;
        }

        public Task Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Vector2 position, Color color)
        {
            return _graphicsDevice.DrawTexture(texture.Name, position.X, position.Y, color);
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            if (sourceRectangle.HasValue)
            {
                return _graphicsDevice.DrawSprite(texture.Name, position.X - origin.X, position.Y - origin.Y, sourceRectangle.Value.Top, sourceRectangle.Value.Left, sourceRectangle.Value.Bottom, sourceRectangle.Value.Right, effects == SpriteEffects.FlipHorizontally, effects == SpriteEffects.FlipVertically, color);
            }

            return _graphicsDevice.DrawTexture(texture.Name, position.X - origin.X, position.Y - origin.Y, color);
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            if (sourceRectangle.HasValue)
            {
                return _graphicsDevice.DrawSprite(texture.Name, position.X - origin.X, position.Y - origin.Y, sourceRectangle.Value.Top, sourceRectangle.Value.Left, sourceRectangle.Value.Bottom, sourceRectangle.Value.Right, effects == SpriteEffects.FlipHorizontally, effects == SpriteEffects.FlipVertically, color);
            }

            return _graphicsDevice.DrawTexture(texture.Name, position.X - origin.X, position.Y - origin.Y, color);
        }

        public async Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            await _graphicsDevice.DrawString(spriteFont, text, position, color);
        }

        public Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public Task DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            throw new NotImplementedException();
        }

        public Task DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public Task DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }
    }
}
