using System;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Demo
{
    public class GameDemo : Game
    {
        public GameDemo()
        {
            // FramesPerSecond.ShowFps = true;
        }

        protected override void Update(float elapsedTime)
        {
        }

        protected override void Draw()
        {
            Graphics.Clear(Color.CornFlowerBlue);
            _module.InvokeUnmarshalled<Rectangle, object>("drawRectangle", new Rectangle(-2.0f, -1.0f, 1.0f, 1.0f));
            _module.InvokeUnmarshalled<object>("drawScene");
        }
    }
}
