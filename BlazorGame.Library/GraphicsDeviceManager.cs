using BlazorGame.Framework.Graphics;
using System;

namespace BlazorGame.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        private readonly Game _game;

        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;

        public IGraphicsDevice GraphicsDevice { get; set; }
        public bool IsFullScreen { get; set; }
        public DisplayOrientation SupportedOrientations { get; set; }

        IGraphicsDevice IGraphicsDeviceService.GraphicsDevice => throw new NotImplementedException();

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
            GraphicsDevice = _game.GraphicsDevice;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool BeginDraw()
        {
            throw new NotImplementedException();
        }

        public void CreateDevice()
        {
            throw new NotImplementedException();
        }

        public void EndDraw()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing) { }
    }
}
