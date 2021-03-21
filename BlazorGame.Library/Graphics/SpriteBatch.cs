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

        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default(Matrix?))
        {
            _graphicsDevice.Reset();
        }

        public void End()
        {
            _graphicsDevice.Present();
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            _graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, new VertexPositionColor[]
            {
                new(new Vector3(destinationRectangle.X, destinationRectangle.Y, 0), color),
                new(new Vector3(destinationRectangle.Width, destinationRectangle.Y, 0), color),
                new(new Vector3(destinationRectangle.X, destinationRectangle.Height, 0), color),
                new(new Vector3(destinationRectangle.X, destinationRectangle.Height, 0), color),
                new(new Vector3(destinationRectangle.Width, destinationRectangle.Y, 0), color),
                new(new Vector3(destinationRectangle.Width, destinationRectangle.Height, 0), color)
            }, 0, 6);
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
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public Task Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public async Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            throw new NotImplementedException();
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
