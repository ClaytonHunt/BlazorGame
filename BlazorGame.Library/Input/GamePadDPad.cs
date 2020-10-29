using System;

namespace BlazorGame.Framework.Input
{
    public struct GamePadDPad
    {
        public ButtonState Down { get; }
        public ButtonState Left { get; }
        public ButtonState Right { get; }
        public ButtonState Up { get; }

        public GamePadDPad(ButtonState upValue, ButtonState downValue, ButtonState leftValue, ButtonState rightValue)
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

        public static bool operator ==(GamePadDPad left, GamePadDPad right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(GamePadDPad left, GamePadDPad right)
        {
            throw new NotImplementedException();
        }
    }
}
