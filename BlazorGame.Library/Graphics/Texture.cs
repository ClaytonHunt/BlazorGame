using System;

namespace BlazorGame.Framework.Graphics
{
    public abstract class Texture : GraphicsResource, IDisposable
    {
        public SurfaceFormat Format { get; }
        public int LevelCount { get; }

        public IntPtr GetSharedHandle()
        {
            throw new NotImplementedException();
        }

        protected override void GraphicsDeviceResetting()
        {
            base.GraphicsDeviceResetting();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
