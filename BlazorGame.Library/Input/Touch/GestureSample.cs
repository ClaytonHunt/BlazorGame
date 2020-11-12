using System;

namespace BlazorGame.Framework.Input.Touch
{
    public struct GestureSample
    {
        public Vector2 Delta { get; }
        public Vector2 Delta2 { get; }
        public GestureType GestureType { get; }
        public Vector2 Position { get; }
        public Vector2 Position2 { get; }
        public TimeSpan Timestamp { get; }

        public GestureSample(GestureType gestureType, TimeSpan timestamp, Vector2 position, Vector2 position2, Vector2 delta, Vector2 delta2)
        {
            throw new NotImplementedException();
        }
    }
}
