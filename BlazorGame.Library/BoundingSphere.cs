using System;
using System.Collections.Generic;

namespace BlazorGame.Framework
{
    public struct BoundingSphere : IEquatable<BoundingSphere>
    {
        public Vector3 Center;
        public float Radius;

        public BoundingSphere(Vector3 center, float radius)
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

        public void Contains(ref BoundingFrustum frustum, out ContainmentType result)
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

        public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result)
        {
            throw new NotImplementedException();
        }

        public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum)
        {
            throw new NotImplementedException();
        }

        public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points)
        {
            throw new NotImplementedException();
        }

        public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
        {
            throw new NotImplementedException();
        }

        public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out Vector3 center, out float radius)
        {
            throw new NotImplementedException();
        }

        public bool Equals(BoundingSphere other)
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

        public bool Intersects(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingBox box, out bool result)
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

        public BoundingSphere Transform(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public void Transform(ref Matrix matrix, out BoundingSphere result)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(BoundingSphere a, BoundingSphere b)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(BoundingSphere a, BoundingSphere b)
        {
            throw new NotImplementedException();
        }
    }
}
