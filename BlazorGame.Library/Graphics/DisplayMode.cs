using System;

namespace BlazorGame.Framework.Graphics
{
    public class DisplayMode
    {
        public float AspectRatio { get; }
        public SurfaceFormat Format { get; }
        public int Height { get; }
        public Rectangle TitleSafeArea { get; }
        public int Width { get; }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(DisplayMode left, DisplayMode right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(DisplayMode left, DisplayMode right)
        {
            throw new NotImplementedException();
        }
    }
}
