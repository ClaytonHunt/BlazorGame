using System;
using System.Text;

namespace BlazorGame.Framework.Graphics
{
    public class SpriteBatch : GraphicsResource, IDisposable
    {
        private readonly IGraphicsDevice _graphicsDevice;

        public SpriteBatch(IGraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public SpriteBatch(IGraphicsDevice graphicsDevice, int capacity)
        {
            throw new NotImplementedException();
        }

        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default(Matrix?))
        {
            
        }

        public void End()
        {
            
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            _graphicsDevice.DrawTexture(texture.Name, position.X, position.Y, color);
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            throw new NotImplementedException();
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {                    
            _graphicsDevice.DrawTexture(texture.Name, position.X - origin.X, position.Y - origin.Y, color);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            throw new NotImplementedException();
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            throw new NotImplementedException();
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }

        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            throw new NotImplementedException();
        }
    }
}
