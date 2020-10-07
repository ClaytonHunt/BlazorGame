using System;

namespace BlazorGame.Library
{
    public struct Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int value)
        {
            X = Y = value;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            throw new NotImplementedException();
        }
    }
}
