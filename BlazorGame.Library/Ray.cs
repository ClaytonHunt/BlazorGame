using System;

namespace BlazorGame.Framework
{
    public struct Ray : IEquatable<Ray>
    {
        public Vector3 Direction;
        public Vector3 Position;

        public Ray(Vector3 position, Vector3 direction)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out Vector3 position, out Vector3 direction)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Ray other)
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

        public float? Intersects(BoundingBox box)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingBox box, out float? result)
        {
            throw new NotImplementedException();
        }

        public float? Intersects(BoundingSphere sphere)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref BoundingSphere sphere, out float? result)
        {
            throw new NotImplementedException();
        }

        public float? Intersects(Plane plane)
        {
            throw new NotImplementedException();
        }

        public void Intersects(ref Plane plane, out float? result)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Ray a, Ray b)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Ray a, Ray b)
        {
            throw new NotImplementedException();
        }
    }
}
