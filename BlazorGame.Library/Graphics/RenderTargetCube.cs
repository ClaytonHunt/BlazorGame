using System;

namespace BlazorGame.Framework.Graphics
{
    public class RenderTargetCube : TextureCube, IDisposable, IRenderTarget
    {
        public Guid Id { get; init; }

        public DepthFormat DepthStencilFormat { get; }
        public bool IsContentLost { get; }
        public int MultiSampleCount { get; }
        public RenderTargetUsage RenderTargetUsage { get; }

        public event EventHandler<EventArgs> ContentLost;

        public RenderTargetCube(IGraphicsDevice graphicsDevice, int size, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat) : base(graphicsDevice, size, mipMap, preferredFormat)
        {
            Id = Guid.NewGuid();
            throw new NotImplementedException();
        }

        public RenderTargetCube(IGraphicsDevice graphicsDevice, int size, bool mipMap, SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage) : base(graphicsDevice, size, mipMap, preferredFormat)
        {
            Id = Guid.NewGuid();
            throw new NotImplementedException();
        }

        public DepthStencilView GetDepthStencilView()
        {
            throw new NotImplementedException();
        }

        public RenderTargetView GetRenderTargetView(int arraySlice)
        {
            throw new NotImplementedException();
        }

        protected static SurfaceFormat QuerySelectedFormat(IGraphicsDevice graphicsDevice, SurfaceFormat preferredFormat)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}
