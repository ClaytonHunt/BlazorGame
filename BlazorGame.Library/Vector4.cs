using System;

namespace BlazorGame.Library
{
    public struct Vector4 : IEquatable<Vector4>
    {
        public float W;
        public float X;
        public float Y;
        public float Z;

        public Vector4(Vector2 value, float z, float w)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
            W = w;
        }

        public Vector4(Vector3 value, float w)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            W = w;
        }

        public Vector4(float value)
        {
            X = Y = Z = W = value;
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public bool Equals(Vector4 other)
        {
            throw new NotImplementedException();
        }
    }
}
