using System;

namespace BlazorGame.Framework.Input
{
    public struct GamePadButtons
    {
        public ButtonState A { get; }
        public ButtonState B { get; }
        public ButtonState Back { get; }
        public ButtonState BigButton { get; }
        public ButtonState LeftShoulder { get; }
        public ButtonState LeftStick { get; }
        public ButtonState RightShoulder { get; }
        public ButtonState RightStick { get; }
        public ButtonState Start { get; }
        public ButtonState X { get; }
        public ButtonState Y { get; }

        public GamePadButtons(Buttons buttons)
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

        public static bool operator ==(GamePadButtons left, GamePadButtons right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(GamePadButtons left, GamePadButtons right)
        {
            throw new NotImplementedException();
        }
    }
}
