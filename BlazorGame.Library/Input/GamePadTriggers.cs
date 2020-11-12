using System;

namespace BlazorGame.Framework.Input
{
    public struct GamePadTriggers
    {
        public float Left { get; }
        public float Right { get; }

        public GamePadTriggers(float leftTrigger, float rightTrigger)
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

        public static bool operator ==(GamePadTriggers left, GamePadTriggers right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(GamePadTriggers left, GamePadTriggers right)
        {
            throw new NotImplementedException();
        }
    }
}
