using System;

namespace BlazorGame.Framework
{
    public struct Plane : IEquatable<Plane>
    {
        public float D;
        public Vector3 Normal;

        public Plane(Vector3 pointOnPlane, Vector3 normal)
        {
            throw new NotImplementedException();
        }

        public Plane(Vector3 a, Vector3 b, Vector3 c)
        {
            throw new NotImplementedException();
        }

        public Plane(Vector3 normal, float d)
        {
            throw new NotImplementedException();
        }

        public Plane(Vector4 value)
        {
            throw new NotImplementedException();
        }

        public Plane(float a, float b, float c, float d)
        {
            throw new NotImplementedException();
        }

        public static void Normalize(ref Plane value, out Plane result)
        {
            throw new NotImplementedException();
        }

        public static Plane Normalize(Plane value)
        {
            throw new NotImplementedException();
        }

        public static Plane Transform(Plane plane, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static Plane Transform(Plane plane, Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Plane plane, ref Matrix matrix, out Plane result)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Plane plane, ref Quaternion rotation, out Plane result)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Plane plane1, Plane plane2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Plane plane1, Plane plane2)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out Vector3 normal, out float d)
        {
            throw new NotImplementedException();
        }

        public float Dot(Vector4 value)
        {
            throw new NotImplementedException();
        }

        public void Dot(ref Vector4 value, out float result)
        {
            throw new NotImplementedException();
        }

        public float DotCoordinate(Vector3 value)
        {
            throw new NotImplementedException();
        }

        public void DotCoordinate(ref Vector3 value, out float result)
        {
            throw new NotImplementedException();
        }

        public float DotNormal(Vector3 value)
        {
            throw new NotImplementedException();
        }

        public void DotNormal(ref Vector3 value, out float result)
        {
            throw new NotImplementedException();
        }

        public PlaneIntersectionType Intersects(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingBox box, out PlaneIntersectionType result)
        {
            throw new NotImplementedException();
        }

        public PlaneIntersectionType Intersects(BoundingFrustum frustum)
        {
            throw new NotImplementedException();
        }

        public PlaneIntersectionType Intersects(BoundingSphere sphere)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingSphere sphere, out PlaneIntersectionType result)
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Plane other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object other)
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
