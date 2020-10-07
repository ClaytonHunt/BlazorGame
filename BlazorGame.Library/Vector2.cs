using System;

namespace BlazorGame.Library
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X;
        public float Y;

        public static Vector2 One { get; } = new Vector2(1, 1);
        public static Vector2 UnitX { get; } = new Vector2(1, 0);
        public static Vector2 UnitY { get; } = new Vector2(0, 1);
        public static Vector2 Zero { get; } = new Vector2(0, 0);

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 Add(Vector2 value1, Vector2 value2) => new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        
        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        }

        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
