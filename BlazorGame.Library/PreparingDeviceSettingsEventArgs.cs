using System;

namespace BlazorGame.Framework
{
    public class PreparingDeviceSettingsEventArgs : EventArgs
    {
        public GraphicsDeviceInformation GraphicsDeviceInformation { get; }

        public PreparingDeviceSettingsEventArgs(GraphicsDeviceInformation graphicsDeviceInformation)
        {

        }
    }
}