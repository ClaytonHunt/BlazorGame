using System;

namespace BlazorGame.Framework.Graphics
{
    public interface IGraphicsDeviceService
    {
        IGraphicsDevice GraphicsDevice { get; }
        event EventHandler<EventArgs> DeviceCreated;
        event EventHandler<EventArgs> DeviceDisposing;
        event EventHandler<EventArgs> DeviceReset;
        event EventHandler<EventArgs> DeviceResetting;
    }
}
