using System;

namespace BlazorGame.Framework.Graphics
{
    public class ResourceDestroyedEventArgs : EventArgs
    {
        public string Name { get; }
        public object Tag { get; }
    }
}
