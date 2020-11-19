using System;

namespace BlazorGame.Framework
{
    public class CanvasGameWindow : GameWindow
    {
        public override bool AllowUserResizing { get; set; }

        public override Rectangle ClientBounds { get; }

        public override DisplayOrientation CurrentOrientation { get; }

        public override IntPtr Handle { get; }

        public override Point Position { get; set; }

        public override string ScreenDeviceName { get; }

        public CanvasGameWindow()
        {
            CurrentOrientation = DisplayOrientation.Default;
        }

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
            throw new NotImplementedException();
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            throw new NotImplementedException();
        }

        protected override void SetSupportedOrientations(DisplayOrientation orientations)
        {
            throw new NotImplementedException();
        }

        protected override void SetTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
