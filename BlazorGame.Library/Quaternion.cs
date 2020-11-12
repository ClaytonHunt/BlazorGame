using System;

namespace BlazorGame.Framework
{
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public static Quaternion Identity { get; }

        public Quaternion(Vector3 value, float w)
        {
            throw new NotImplementedException();
        }

        public Quaternion(Vector4 value)
        {
            throw new NotImplementedException();
        }

        public Quaternion(float x, float y, float z, float w)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Add(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static void Add(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
        {
            throw new NotImplementedException();
        }

        public static void Concatenate(ref Quaternion value1, ref Quaternion value2, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Conjugate(Quaternion value)
        {
            throw new NotImplementedException();
        }

        public static void Conjugate(ref Quaternion value, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion CreateFromRotationMatrix(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromRotationMatrix(ref Matrix matrix, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Divide(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static float Dot(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static void Dot(ref Quaternion quaternion1, ref Quaternion quaternion2, out float result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Inverse(Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public static void Inverse(ref Quaternion quaternion, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Lerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Multiply(Quaternion quaternion1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Quaternion quaternion1, float scaleFactor, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Negate(Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public static void Negate(ref Quaternion quaternion, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Normalize(Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public static void Normalize(ref Quaternion quaternion, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion Subtract(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static void Subtract(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator *(Quaternion quaternion1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
        {
            throw new NotImplementedException();
        }

        public static Quaternion operator -(Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public void Conjugate()
        {
            throw new NotImplementedException();
        }

        public float Length()
        {
            throw new NotImplementedException();
        }

        public float LengthSquared()
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            throw new NotImplementedException();
        }

        public Vector4 ToVector4()
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out float x, out float y, out float z, out float w)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Quaternion other)
        {
            throw new NotImplementedException();
        }

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
    }
}
