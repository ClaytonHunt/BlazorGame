using System;

namespace BlazorGame.Framework.Input.Touch
{
    public class TouchPanelState
    {
        public int DisplayHeight { get; set; }
        public DisplayOrientation DisplayOrientation { get; set; }
        public int DisplayWidth { get; set; }
        public GestureType EnabledGestures { get; set; }
        public bool EnableMouseGestures { get; set; }
        public bool EnableMouseTouchPoint { get; set; }
        public bool IsGestureAvailable { get; }
        public IntPtr WindowHandle { get; set; }

        public TouchPanelCapabilities GetCapabilities()
        {
            throw new NotImplementedException();
        }

        public TouchCollection GetState()
        {
            throw new NotImplementedException();
        }

        public GestureSample ReadGesture()
        {
            throw new NotImplementedException();
        }
    }
}
