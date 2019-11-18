using System;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace BlazorGame.Services
{
    public class GraphicsDeviceManager
    {
        private readonly Game _game;

        public IGraphicsDevice GraphicsDevice { get; set; }

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
            GraphicsDevice = _game.GraphicsDevice;
        }
    }

    public interface IGraphicsDevice
    {
        void Clear(in Color color);
        event Action OnReady;
        void DrawTexture(in int texturePosition, in float x, in float y, in Color color);
    }

    public class CanvasGraphicsDevice: IGraphicsDevice
    {
        private readonly IJSRuntime _jsRuntime;

        public event Action OnReady = () => { };
        
        public CanvasGraphicsDevice(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _jsRuntime.InvokeVoidAsync("BlazorGame.initialize", DotNetObjectReference.Create(this));
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
        public void Render(double timestamp)
        {
            OnReady();
        }
    }
}
