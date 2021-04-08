using System;

namespace BlazorGame.Framework.Extensions
{
    public class Fps
    {
        private int _framesPerSecond = 0;
        private int _framesPerSecondCount = 0;
        private float _elapsed = 0.0f;

        public bool ShowFps { get; set; } = false;

        public void Update(float timeElapsed)
        {
            _framesPerSecondCount++;
            _elapsed += timeElapsed;

            if (!(_elapsed > 1000)) return;

            _framesPerSecond = _framesPerSecondCount;
            _framesPerSecondCount = 0;
            _elapsed = 0;

            if (ShowFps)
            {
                Console.WriteLine($"FPS: {_framesPerSecond}");
            }
        }
    }
}
