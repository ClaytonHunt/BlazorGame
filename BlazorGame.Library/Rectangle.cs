using System;

namespace BlazorGame.Framework
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public int Height;
        public int Width;
        public int X;
        public int Y;

        public int Top { get => Y; }
        public int Bottom { get => Y + Height; }
        public int Left { get => X; }
        public int Right { get => X + Width; }
        public Point Center { get => new Point(X + (Width / 2), Y + (Height / 2)); }

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

        public bool Contains(Point value)
        {
            return X >= value.X && value.X <= (X + Width) && Y >= value.Y && value.Y <= (Y + Height);
        }

        public bool Intersects(Rectangle value)
        {
            return !(X >= (value.X + value.Width) || value.X >= (X + Width)) && 
                   !(Y >= (value.Y + value.Height) || value.Y >= (Y + Height));
        }

        public bool Equals(Rectangle other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }
    }
}
