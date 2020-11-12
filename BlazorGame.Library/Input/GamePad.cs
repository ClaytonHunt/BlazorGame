using System;

namespace BlazorGame.Framework.Input
{
    public static class GamePad
    {
        public static int MaximumGamePadCount { get; }

        public static GamePadCapabilities GetCapabilities(PlayerIndex playerIndex)
        {
            throw new NotImplementedException();
        }

        public static GamePadCapabilities GetCapabilities(int index)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(PlayerIndex playerIndex)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(PlayerIndex playerIndex, GamePadDeadZone deadZoneMode)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(PlayerIndex playerIndex, GamePadDeadZone leftDeadZoneMode, GamePadDeadZone rightDeadZoneMode)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(int index)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(int index, GamePadDeadZone deadZoneMode)
        {
            throw new NotImplementedException();
        }

        public static GamePadState GetState(int index, GamePadDeadZone leftDeadZoneMode, GamePadDeadZone rightDeadZoneMode)
        {
            throw new NotImplementedException();
        }

        public static bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            throw new NotImplementedException();
        }

        public static bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor, float leftTrigger, float rightTrigger)
        {
            throw new NotImplementedException();
        }

        public static bool SetVibration(int index, float leftMotor, float rightMotor)
        {
            throw new NotImplementedException();
        }

        public static bool SetVibration(int index, float leftMotor, float rightMotor, float leftTrigger, float rightTrigger)
        {
            throw new NotImplementedException();
        }
    }
}
