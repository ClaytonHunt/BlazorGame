using System;

namespace BlazorGame.Framework
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

        public float LengthSquared()
        {
            return (float)Math.Pow(Math.Abs(X - Y), 2);
        }

        public static Vector2 Add(Vector2 value1, Vector2 value2) => new Vector2(value1.X + value2.X, value1.Y + value2.Y);

        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        }

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            throw new NotImplementedException();
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public void Ceiling()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Ceiling(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public static void Ceiling(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            throw new NotImplementedException();
        }

        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out float x, out float y)
        {
            throw new NotImplementedException();
        }

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Divide(Vector2 value1, float divider)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public void Floor()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Floor(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public static void Floor(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public float Length()
        {
            throw new NotImplementedException();
        }        

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 LerpPrecise(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void LerpPrecise(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Multiply(Vector2 value1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Negate(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Normalize(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            throw new NotImplementedException();
        }

        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public void Round()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Round(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public static void Round(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public Point ToPoint()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Transform(Vector2 value, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector2 value, ref Quaternion rotation, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static void Transform(Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
        {
            throw new NotImplementedException();
        }

        public static void Transform(Vector2[] sourceArray, ref Quaternion rotation, Vector2[] destinationArray)
        {
            throw new NotImplementedException();
        }

        public static void Transform(Vector2[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2[] destinationArray, int destinationIndex, int length)
        {
            throw new NotImplementedException();
        }

        public static void Transform(Vector2[] sourceArray, int sourceIndex, ref Quaternion rotation, Vector2[] destinationArray, int destinationIndex, int length)
        {
            throw new NotImplementedException();
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static void TransformNormal(ref Vector2 normal, ref Matrix matrix, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static void TransformNormal(Vector2[] sourceArray, ref Matrix matrix, Vector2[] destinationArray)
        {
            throw new NotImplementedException();
        }

        public static void TransformNormal(Vector2[] sourceArray, int sourceIndex, ref Matrix matrix, Vector2[] destinationArray, int destinationIndex, int length)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        }

        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator /(Vector2 value1, float divider)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X - value2.X, value1.Y - value2.Y);
        }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.X * value2.X, value1.Y * value2.Y);
        }

        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            return new Vector2(value.X * scaleFactor, value.Y * scaleFactor);
        }

        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            return new Vector2(value.X * scaleFactor, value.Y * scaleFactor);
        }

        public static bool operator ==(Vector2 vector, Vector2 value)
        {
            return vector.Equals(value);
        }

        public static bool operator !=(Vector2 vector, Vector2 value)
        {
            return !vector.Equals(value);
        }

        public static Vector2 operator -(Vector2 value)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
