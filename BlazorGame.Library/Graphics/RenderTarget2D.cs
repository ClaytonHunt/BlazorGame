using System;

namespace BlazorGame.Framework.Graphics
{
    public class RenderTarget2D : Texture2D, IDisposable, IRenderTarget
    {
        public DepthFormat DepthStencilFormat { get; }
        public bool IsContentLost { get; }
        public int MultiSampleCount { get; }
        public RenderTargetUsage RenderTargetUsage { get; }   
        
        public event EventHandler<EventArgs> ContentLost;

        public RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height) : base(graphicsDevice, width, height) { }

        public RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat) : base(graphicsDevice, width, height) { }        

        public RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage) : base(graphicsDevice, width, height) { }
        
        protected RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipMap, SurfaceFormat format, DepthFormat depthFormat, int preferredMultiSampleCount, RenderTargetUsage usage, Texture2D.SurfaceType surfaceType) : base(graphicsDevice, width, height) { }
        
        public RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage, bool shared) : base(graphicsDevice, width, height) { }
        
        public RenderTarget2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage, bool shared, int arraySize)  : base(graphicsDevice, width, height) { }
        
        protected override Texture2DDescription GetTexture2DDescription()
        {
            throw new NotImplementedException();
        }

        protected override void GraphicsDeviceResetting()
        {
            throw new NotImplementedException();
        }

        protected static SurfaceFormat QuerySelectedFormat(IGraphicsDevice graphicsDevice, SurfaceFormat preferredFormat)
        {
            throw new NotImplementedException();
        }
        
        protected override void Dispose(bool disposing)
        {

        }
    }
}
