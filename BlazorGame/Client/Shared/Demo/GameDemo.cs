
using System;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;
using Microsoft.JSInterop;

namespace BlazorGame.Client.Shared.Demo
{
    public class GameDemo : Game
    {
        private float red, green, blue;
        private Color rectColor = Color.White;
        private float squareRotation = 0.0f;
        private int redDirection = 1;
        private int greenDirection = 1;
        private int blueDirection = 1;
        private Texture2D texture;
        private float yPosition = 10;
        private float xPosition = 10;
        private float xSpeed = 0.1f;
        private float ySpeed = 0.1f;

        public GameDemo()
        {
            FramesPerSecond.ShowFps = true;
            red = (float)new Random().NextDouble();
            green = (float)new Random().NextDouble();
            blue = (float)new Random().NextDouble();
        }

        protected override void Load()
        {
            _module.InvokeVoid("loadTexture", "flames.png", "Cube");
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

            xPosition += xSpeed * elapsedTime;
            yPosition += ySpeed * elapsedTime;

            if (xPosition >= 800 - 128)
            {
                xSpeed = -0.1f;
            }

            if (xPosition <= 0)
            {
                xSpeed = 0.1f;
            }

            if (yPosition >= 600 - 128)
            {
                ySpeed = -0.1f;
            }

            if (yPosition <= 0)
            {
                ySpeed = 0.1f;
            }
        }

        protected override void Draw()
        {
            Graphics.Clear(Color.CornFlowerBlue);

            _module.InvokeUnmarshalled<ValueTuple<Rectangle, ColorRectangle, string, float>, object>("drawRectangle", 
                new (new Rectangle(yPosition, xPosition, 128f, 128f),
                    new ColorRectangle(rectColor),
                    "Cube",
                    squareRotation)
            );
        }
    }
}
