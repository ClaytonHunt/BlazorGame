namespace BlazorGame.Framework.Input.Touch
{
    public struct TouchPanelCapabilities
    {
        public bool HasPressure { get; }
        public bool IsConnected { get; }
        public int MaximumTouchCount { get; }
    }
}
