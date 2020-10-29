using System;
using System.Collections.Generic;

namespace BlazorGame.Framework
{
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        public const int CornerCount = 8;
        public Vector3 Max;
        public Vector3 Min;

        public BoundingBox(Vector3 min, Vector3 max)
        {
            throw new NotImplementedException();
        }

        public ContainmentType Contains(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public void Contains(ref BoundingBox box, out ContainmentType result)
        {
            throw new NotImplementedException();
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            throw new NotImplementedException();
        }

        public ContainmentType Contains(BoundingSphere sphere)
        {
            throw new NotImplementedException();
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result)
        {
            throw new NotImplementedException();
        }

        public ContainmentType Contains(Vector3 point)
        {
            throw new NotImplementedException();
        }

        public void Contains(ref Vector3 point, out ContainmentType result)
        {
            throw new NotImplementedException();
        }

        public static BoundingBox CreateFromPoints(Vector3[] points, int index = 0, int count = -1)
        {
            throw new NotImplementedException();
        }

        public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points)
        {
            throw new NotImplementedException();
        }

        public static BoundingBox CreateFromPoints(List<Vector3> points, int index = 0, int count = -1)
        {
            throw new NotImplementedException();
        }

        public static BoundingBox CreateFromSphere(BoundingSphere sphere)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromSphere(ref BoundingSphere sphere, out BoundingBox result)
        {
            throw new NotImplementedException();
        }

        public static BoundingBox CreateMerged(BoundingBox original, BoundingBox additional)
        {
            throw new NotImplementedException();
        }

        public static void CreateMerged(ref BoundingBox original, ref BoundingBox additional, out BoundingBox result)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out Vector3 min, out Vector3 max)
        {
            throw new NotImplementedException();
        }

        public bool Equals(BoundingBox other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public Vector3[] GetCorners()
        {
            throw new NotImplementedException();
        }

        public void GetCorners(Vector3[] corners)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool Intersects(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(BoundingSphere sphere)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            throw new NotImplementedException();
        }

        public PlaneIntersectionType Intersects(Plane plane)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref Plane plane, out PlaneIntersectionType result)
        {
            throw new NotImplementedException();
        }

        public float? Intersects(Ray ray)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref Ray ray, out float? result)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(BoundingBox a, BoundingBox b)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(BoundingBox a, BoundingBox b)
        {
            throw new NotImplementedException();
        }
    }
}
