using System;

namespace BlazorGame.Framework.Input
{
    public struct GamePadCapabilities
    {
        public string DisplayName { get; }
        public GamePadType GamePadType { get; }
        public bool HasAButton { get; }
        public bool HasBackButton { get; }
        public bool HasBButton { get; }
        public bool HasBigButton { get; }
        public bool HasDPadDownButton { get; }
        public bool HasDPadLeftButton { get; }
        public bool HasDPadRightButton { get; }
        public bool HasDPadUpButton { get; }
        public bool HasLeftShoulderButton { get; }
        public bool HasLeftStickButton { get; }
        public bool HasLeftTrigger { get; }
        public bool HasLeftVibrationMotor { get; }
        public bool HasLeftXThumbStick { get; }
        public bool HasLeftYThumbStick { get; }
        public bool HasRightShoulderButton { get; }
        public bool HasRightStickButton { get; }
        public bool HasRightTrigger { get; }
        public bool HasRightVibrationMotor { get; }
        public bool HasRightXThumbStick { get; }
        public bool HasRightYThumbStick { get; }
        public bool HasStartButton { get; }
        public bool HasVoiceSupport { get; }
        public bool HasXButton { get; }
        public bool HasYButton { get; }
        public string Identifier { get; }
        public bool IsConnected { get; }

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

        public static bool operator ==(GamePadCapabilities left, GamePadCapabilities right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(GamePadCapabilities left, GamePadCapabilities right)
        {
            throw new NotImplementedException();
        }
    }
}
