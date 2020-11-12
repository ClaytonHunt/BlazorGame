using System;

namespace BlazorGame.Framework.Graphics
{
    public abstract class GraphicsResource : IDisposable
    {
        public IGraphicsDevice GraphicsDevice { get; }
        public bool IsDisposed { get; }

        public virtual string Name { get; set; }  
        
        public object Tag { get; set; }

        public event EventHandler<EventArgs> Disposing;

        protected void Finalize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return string.Empty;
        }

        protected virtual void GraphicsDeviceResetting()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {

        }        
    }
}
