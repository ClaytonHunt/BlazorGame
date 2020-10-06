using System;
using System.Drawing;

namespace BlazorGame.Library
{
    public interface IGraphicsDevice
    {
        int PreferredBackBufferWidth { get; set; }
        int PreferredBackBufferHeight { get; set; }
        Camera2D Viewport { get; set; }
        event Action<GameTime> OnReady;
        void Clear(in Color color);
        void DrawTexture(in int texturePosition, in float x, in float y, in Color color);
    }
}