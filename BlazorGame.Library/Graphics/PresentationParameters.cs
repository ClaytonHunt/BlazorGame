using System;

namespace BlazorGame.Framework.Graphics
{
    public class PresentationParameters
    {
        public const int DefaultPresentRate = 60;

        public SurfaceFormat BackBufferFormat { get; set; }
        public int BackBufferHeight { get; set; }
        public int BackBufferWidth { get; set; }
        public Rectangle Bounds { get; }
        public DepthFormat DepthStencilFormat { get; set; }
        public IntPtr DeviceWindowHandle { get; set; }
        public DisplayOrientation DisplayOrientation { get; set; }
        public bool HardwareModeSwitch { get; set; }
        public bool IsFullScreen { get; set; }
        public int MultiSampleCount { get; set; }
        public PresentInterval PresentationInterval { get; set; }
        public RenderTargetUsage RenderTargetUsage { get; set; }

        public PresentationParameters() { }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public PresentationParameters Clone()
        {
            throw new NotImplementedException();
        }
    }
}
