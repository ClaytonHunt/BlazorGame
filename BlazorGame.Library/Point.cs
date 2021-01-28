using System;

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
            return (X == other.X) && (Y == other.Y);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
