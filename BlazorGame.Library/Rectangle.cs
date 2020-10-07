using System;

namespace BlazorGame.Library
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public int Height;
        public int Width;
        public int X;
        public int Y;

        public Rectangle(Point location, Point size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.X;
            Height = size.Y;
        }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Equals(Rectangle other)
        {
            throw new NotImplementedException();
        }
    }
}
