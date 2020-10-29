using System;

namespace BlazorGame.Framework.Input.Touch
{
    public struct TouchLocation : IEquatable<TouchLocation>
    {
        public int Id { get; }
        public Vector2 Position { get; }
        public float Pressure { get; }
        public TouchLocationState State { get; }

        public TouchLocation(int id, TouchLocationState state, Vector2 position)
        {
            throw new NotImplementedException();
        }

        public TouchLocation(int id, TouchLocationState state, Vector2 position, TouchLocationState previousState, Vector2 previousPosition)
        {
            throw new NotImplementedException();
        }

        public bool Equals(TouchLocation other)
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

        public bool TryGetPreviousLocation(out TouchLocation aPreviousLocation)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(TouchLocation value1, TouchLocation value2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(TouchLocation value1, TouchLocation value2)
        {
            throw new NotImplementedException();
        }
    }
}
