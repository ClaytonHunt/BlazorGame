using System;

namespace BlazorGame.Framework.Input
{
    public struct GamePadState
    {
        public static readonly GamePadState Default;

        public GamePadButtons Buttons { get; }
        public GamePadDPad DPad { get; }
        public bool IsConnected { get; }
        public int PacketNumber { get; }
        public GamePadThumbSticks ThumbSticks { get; }
        public GamePadTriggers Triggers { get; }

        public GamePadState(GamePadThumbSticks thumbSticks, GamePadTriggers triggers, GamePadButtons buttons, GamePadDPad dPad)
        {
            throw new NotImplementedException();
        }

        public GamePadState(Vector2 leftThumbStick, Vector2 rightThumbStick, float leftTrigger, float rightTrigger, Buttons button)
        {
            throw new NotImplementedException();
        }

        public GamePadState(Vector2 leftThumbStick, Vector2 rightThumbStick, float leftTrigger, float rightTrigger, Buttons[] buttons)
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

        public bool IsButtonDown(Buttons button)
        {
            throw new NotImplementedException();
        }

        public bool IsButtonUp(Buttons button)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(GamePadState left, GamePadState right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(GamePadState left, GamePadState right)
        {
            throw new NotImplementedException();
        }
    }
}
