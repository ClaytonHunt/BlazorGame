using System;
using System.Data.Common;

namespace BlazorGame.Framework
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

        public static bool operator ==(Point first, Point second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Point first, Point second)
        {
            return !first.Equals(second);
        }

        public bool Equals(Point other)
        {
            throw new NotImplementedException();
        }
    }
}
