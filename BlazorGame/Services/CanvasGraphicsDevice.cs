using System;
using System.Drawing;
using Microsoft.JSInterop;

namespace BlazorGame.Services
{
    public class CanvasGraphicsDevice: IGraphicsDevice
    {
        private readonly IJSRuntime _jsRuntime;

        public int PreferredBackBufferWidth { get; set; }
        public int PreferredBackBufferHeight { get; set; }
        public Camera2D Viewport { get; set; }
        public event Action<GameTime> OnReady = gameTime => { };
        
        public CanvasGraphicsDevice(IJSRuntime jsRuntime, int width, int height)
        {
            _jsRuntime = jsRuntime;
            _jsRuntime.InvokeVoidAsync("BlazorGame.initialize", DotNetObjectReference.Create(this));
            
            PreferredBackBufferWidth = width;
            PreferredBackBufferHeight = height;

            Viewport = new Camera2D
            {
                TitleSafeArea = new Frame
                {
                    Height = height,
                    Width = width,
                    X = 0,
                    Y = 0
                }
            };
        }

        public void Clear(in Color color)
        {
            _jsRuntime.InvokeVoidAsync("BlazorGame.clear", color);
        }

        public void DrawTexture(in int position, in float x, in float y, in Color color)
        {
            _jsRuntime.InvokeVoidAsync("BlazorGame.drawSprite", position, x, y, color);
        }

        [JSInvokable]
        public void Render(float timestamp)
        {
            OnReady(new GameTime { ElapsedTime = new TimeSpan((long)(timestamp * 10000)) });
        }
    }
}