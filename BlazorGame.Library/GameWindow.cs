using System;

namespace BlazorGame.Framework
{
    public abstract class GameWindow
    {
        public virtual bool AllowAltF4 { get; set; }
        public abstract bool AllowUserResizing { get; set; }
        public abstract Rectangle ClientBounds { get; }
        public abstract DisplayOrientation CurrentOrientation { get; }
        public abstract IntPtr Handle { get; }
        public virtual bool IsBorderless { get; set; }
        public abstract Point Position { get; set; }
        public abstract string ScreenDeviceName { get; }
        public string Title { get; set; }

        public event EventHandler<EventArgs> ClientSizeChanged;
        public event EventHandler<EventArgs> OrientationChanged;
        public event EventHandler<EventArgs> ScreenDeviceNameChanged;
        public event EventHandler<TextInputEventArgs> TextInput;
        public event EventHandler<InputKeyEventArgs> KeyDown;
        public event EventHandler<InputKeyEventArgs> KeyUp;
        
        protected GameWindow() { }        
        
        public static GameWindow Create(Game game, int width, int height)
        {
            return new CanvasGameWindow();        
        }

        public void EndScreenDeviceChange(string screenDeviceName) { }

        public abstract void BeginScreenDeviceChange(bool willBeFullScreen);        
        public abstract void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight);        

        protected abstract void SetTitle(string title);

        protected void OnActivated() { }
        protected void OnDeactivated() { }
        protected void OnOrientationChanged() { }
        protected void OnPaint() { }
        protected void OnScreenDeviceNameChanged() { }

        protected abstract void SetSupportedOrientations(DisplayOrientation orientations);
    }
}
