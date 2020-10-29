using System;

namespace BlazorGame.Framework.Graphics
{
    public class RenderTarget3D : Texture3D, IDisposable, IRenderTarget
    {
        public DepthFormat DepthStencilFormat { get; }
        public bool IsContentLost { get; }
        public int MultiSampleCount { get; }
        public RenderTargetUsage RenderTargetUsage { get; }

        public event EventHandler<EventArgs> ContentLost;

        public RenderTarget3D(IGraphicsDevice graphicsDevice, int width, int height, int depth) : base(graphicsDevice, width, height, depth, false, SurfaceFormat.Alpha8)
        {
            throw new NotImplementedException();
        }

        public RenderTarget3D(IGraphicsDevice graphicsDevice, int width, int height, int depth, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat) : base(graphicsDevice, width, height, depth, mipMap, preferredFormat)
        {
            throw new NotImplementedException();
        }

        public RenderTarget3D(IGraphicsDevice graphicsDevice, int width, int height, int depth, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage) : base(graphicsDevice, width, height, depth, mipMap, preferredFormat)
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
