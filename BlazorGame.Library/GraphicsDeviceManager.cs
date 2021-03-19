using BlazorGame.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace BlazorGame.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        private readonly Game _game;

        public static readonly int DefaultBackBufferHeight = 800;
        public static readonly int DefaultBackBufferWidth = 600;

        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<PreparingDeviceSettingsEventArgs> PreparingDeviceSettings;

        public IGraphicsDevice GraphicsDevice { get; set; }
        public GraphicsProfile GraphicsProfile { get; set; }
        public bool HardwareModeSwitch { get; set; }
        public bool IsFullScreen { get; set; }
        public bool PreferHalfPixelOffset { get; set; }
        public bool PreferMultiSampling { get; set; }
        public SurfaceFormat PreferredBackBufferFormat { get; set; }
        public int PreferredBackBufferHeight {get; set; }
        public int PreferredBackBufferWidth { get; set; }
        public DepthFormat PreferredDepthStencilFormat { get;set; }
        public DisplayOrientation SupportedOrientations { get; set; }
        public bool SynchronizeWithVerticalRetrace { get;set; }

        IGraphicsDevice IGraphicsDeviceService.GraphicsDevice => throw new NotImplementedException();

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
            GraphicsDevice = _game.GraphicsDevice;

            PreferredBackBufferWidth = DefaultBackBufferWidth;
            PreferredBackBufferHeight = DefaultBackBufferHeight;
        }

        public async Task ApplyChanges()
        {
            GraphicsDevice.Viewport = new Viewport
            {
                TitleSafeArea = new Rectangle
                {
                    Height = PreferredBackBufferHeight,
                    Width = PreferredBackBufferWidth,
                    X = 0,
                    Y = 0
                }
            };

            GraphicsDevice.PresentationParameters = new PresentationParameters
            {
                BackBufferHeight = PreferredBackBufferHeight,
                BackBufferWidth = PreferredBackBufferWidth
            };

            await GraphicsDevice.Initialize();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<bool> BeginDraw()
        {
            return Task.FromResult(true);
        }

        Task IGraphicsDeviceManager.CreateDevice()
        {
            return Task.CompletedTask;
        }

        public Task EndDraw()
        {
            return Task.CompletedTask;
        }

        public Task ToggleFullScreen()
        {
            return Task.CompletedTask;
        }

        protected Task Finalize()
        {
            return Task.CompletedTask;
        }

        protected Task OnDeviceCreated(EventArgs e)
        {
            return Task.CompletedTask;
        }

        protected Task OnDeviceDisposing(EventArgs e)
        {
            return Task.CompletedTask;
        }

        protected Task OnDeviceReset(EventArgs e)
        {
            return Task.CompletedTask;
        }

        protected Task OnDeviceResetting(EventArgs e)
        {
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing) { }
    }
}
