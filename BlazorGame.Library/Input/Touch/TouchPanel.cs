using System;

namespace BlazorGame.Framework.Input.Touch
{
    public static class TouchPanel
    {
        public static int DisplayHeight { get; set; }
        public static DisplayOrientation DisplayOrientation { get; set; }
        public static int DisplayWidth { get; set; }
        public static GestureType EnabledGestures { get; set; }
        public static bool EnableMouseGestures { get; set; }
        public static bool EnableMouseTouchPoint { get; set; }
        public static bool IsGestureAvailable { get; }
        public static IntPtr WindowHandle { get; set; }

        public static TouchPanelCapabilities GetCapabilities()
        {
            throw new NotImplementedException();
        }

        public static TouchCollection GetState()
        {
            throw new NotImplementedException();            
        }

        public static TouchPanelState GetState(GameWindow window)
        {
            throw new NotImplementedException();
        }

        public static GestureSample ReadGesture()
        {
            throw new NotImplementedException();
        }
    }
}
