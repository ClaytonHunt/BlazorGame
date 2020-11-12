using System;
using System.Collections.ObjectModel;

namespace BlazorGame.Framework.Graphics
{
    public class GraphicsAdapter : IDisposable
    {
        public static ReadOnlyCollection<GraphicsAdapter> Adapters { get; }
        public DisplayMode CurrentDisplayMode { get; }
        public static GraphicsAdapter DefaultAdapter { get; }
        public string Description { get; }
        public int DeviceId { get; }
        public string DeviceName { get; }
        public bool IsDefaultAdapter { get; }
        public bool IsWideScreen { get; }
        public IntPtr MonitorHandle { get; }
        public int Revision { get; }
        public int SubSystemId { get; }
        public DisplayModeCollection SupportedDisplayModes { get; }
        public int VendorId { get; }

        public static bool UseDebugLayers { get; set; }
        public static DriverType UseDriverType { get; set; }
        public static bool UseReferenceDevice { get; set; }

        public bool QueryRenderTargetFormat(GraphicsProfile graphicsProfile, SurfaceFormat format, DepthFormat depthFormat, int multiSampleCount, out SurfaceFormat selectedFormat, out DepthFormat selectedDepthFormat, out int selectedMultiSampleCount)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsProfileSupported(GraphicsProfile graphicsProfile)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        public enum DriverType
        {
            FastSoftware,
            Hardware,
            Reference
        }
    }
}
