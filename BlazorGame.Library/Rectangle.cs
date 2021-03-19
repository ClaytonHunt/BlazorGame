using System;

namespace BlazorGame.Framework
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public int Height;
        public int Width;
        public int X;
        public int Y;

        public int Bottom => Y + Height;
        public Point Center => new(X + (Width / 2), Y + (Height / 2));
        public static Rectangle Empty => new(0, 0, 0, 0);
        public bool IsEmpty => Height == 0 && Width == 0 && X == 0 && Y == 0;
        public int Left => X;
        public Point Location => new(X, Y);
        public int Right => X + Width;
        public Point Size => new(Width, Height);
        public int Top => Y;

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
            return X <= value.X && value.X <= (X + Width) && 
                   Y <= value.Y && value.Y <= (Y + Height);
        }

        public void Contains(ref Point value, out bool result)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Rectangle value)
        {
            return X <= value.X && value.X <= (X + Width) && 
                   Y <= value.Y && value.Y <= (Y + Height) &&
                   Width >= value.X + value.Width &&
                   Height >= value.Y + value.Height;
        }

        public void Contains(ref Rectangle value, out bool result)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public void Contains(ref Vector2 value, out bool result)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool Contains(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out int x, out int y, out int width, out int height)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Rectangle other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            throw new NotImplementedException();
        }

        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            throw new NotImplementedException();
        }

        public static Rectangle Intersect(Rectangle value1, Rectangle value2)
        {
            throw new NotImplementedException();
        }


        public static void Intersect(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(Rectangle value)
        {
            return !(X >= (value.X + value.Width) || value.X >= (X + Width)) &&
                   !(Y >= (value.Y + value.Height) || value.Y >= (Y + Height));
        }

        public void Intersects(ref Rectangle value, out bool result)
        {
            throw new NotImplementedException();
        }

        public void Offset(Point amount)
        {
            throw new NotImplementedException();
        }

        public void Offset(Vector2 amount)
        {
            throw new NotImplementedException();
        }

        public void Offset(int offsetX, int offsetY)
        {
            throw new NotImplementedException();
        }

        public void Offset(float offsetX, float offsetY)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static Rectangle Union(Rectangle value1, Rectangle value2)
        {
            throw new NotImplementedException();
        }

        public static void Union(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Rectangle a, Rectangle b)
        {
            return a.X == b.X && 
                   a.Y == b.Y && 
                   a.Width == b.Width && 
                   a.Height == b.Height;
        }

        public static bool operator !=(Rectangle a, Rectangle b)
        {
            throw new NotImplementedException();
        }
    }
}
