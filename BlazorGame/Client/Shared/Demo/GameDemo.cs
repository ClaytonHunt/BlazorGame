
using System;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Demo
{
    public class GameDemo : Game
    {
        private float red, green, blue;
        private Color rectColor = Color.Red;
        private float squareRotation = 0.0f;
        private int redDirection = 1;
        private int greenDirection = 1;
        private int blueDirection = 1;

        public GameDemo()
        {
            FramesPerSecond.ShowFps = true;
            red = (float)new Random().NextDouble();
            green = (float)new Random().NextDouble();
            blue = (float)new Random().NextDouble();
        }

        protected override void Update(float elapsedTime)
        {
            squareRotation += 0.5f / elapsedTime;

            red += redDirection * 0.025f / elapsedTime;
            green += greenDirection * 0.035f / elapsedTime;
            blue += blueDirection * 0.015f / elapsedTime;

            if (red > 1.0f || red < 0.0f)
            {
                red -= redDirection * 0.025f / elapsedTime;
                redDirection *= -1;
            }

            if (green > 1.0f || green < 0.0f)
            {
                green -= greenDirection * 0.035f / elapsedTime;
                greenDirection *= -1;
            }

            if (blue > 1.0f || blue < 0.0f)
            {
                blue -= blueDirection * 0.015f / elapsedTime;
                blueDirection *= -1;
            }

            rectColor = new Color(red, green, blue);
        }

        protected override void Draw()
        {
            Graphics.Clear(Color.CornFlowerBlue);

            _module.InvokeUnmarshalled<ValueTuple<Rectangle, ColorRectangle, float>, object>("drawRectangle", 
                new (new Rectangle(-1.0f, -1.0f, 1.0f, 1.0f),
                    new ColorRectangle(rectColor),
                    squareRotation)
            );
        }
    }
}
