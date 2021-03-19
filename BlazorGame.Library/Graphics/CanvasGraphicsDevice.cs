using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorGame.Framework.Graphics
{
    public class CanvasGraphicsDevice : IGraphicsDevice
    {
        private readonly IJSRuntime _jsRuntime;
        private TimeSpan totalGameTime = new TimeSpan();

        public GraphicsAdapter Adapter { get; }
        public Color BlendFactor { get; set; }
        public BlendState BlendState { get; set; }
        public DepthStencilState DepthStencilState { get; set; }
        public DisplayMode DisplayMode { get; }
        public GraphicsDebug GraphicsDebug { get; set; }
        public GraphicsDeviceStatus GraphicsDeviceStatus { get; }
        public GraphicsProfile GraphicsProfile { get; }
        public object Handle { get; }
        public IndexBuffer Indices { get; set; }
        public bool IsContentLost { get; }
        public bool IsDisposed { get; }
        public GraphicsMetrics Metrics { get; set; }
        public PresentationParameters PresentationParameters { get; set; }
        public RasterizerState RasterizerState { get; set; }
        public int RenderTargetCount { get; }
        public bool ResourcesLost { get; set; }
        public SamplerStateCollection SamplerStates { get; }
        public Rectangle ScissorRectangle { get; set; }
        public TextureCollection Textures { get; }
        public bool UseHalfPixelOffset { get; }
        public SamplerStateCollection VertexSamplerStates { get; }
        public TextureCollection VertexTextures { get; }
        public Viewport Viewport { get; set; }
        public string CanvasId  { get; }

        public event Func<GameTime, Task> OnReady = gameTime => Task.CompletedTask;
        public event EventHandler<EventArgs> DeviceLost = (sender, args) => { };
        public event EventHandler<EventArgs> DeviceReset = (sender, args) => { };
        public event EventHandler<EventArgs> DeviceResetting = (sender, args) => { };
        public event EventHandler<EventArgs> Disposing = (sender, args) => { };
        public event EventHandler<ResourceCreatedEventArgs> ResourceCreated = (sender, args) => { };
        public event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed = (sender, args) => { };

        public CanvasGraphicsDevice(IJSRuntime jsRuntime, string id, int width, int height)
        {
            _jsRuntime = jsRuntime;

            CanvasId = id;

            Viewport = new Viewport
            {
                TitleSafeArea = new Rectangle
                {
                    Height = height,
                    Width = width,
                    X = 0,
                    Y = 0
                }
            };

            PresentationParameters = new PresentationParameters()
            {
                BackBufferHeight = height,
                BackBufferWidth = width
            };
        }

        public async Task Initialize()
        {
            await _jsRuntime.InvokeVoidAsync("BlazorGame.initialize", DotNetObjectReference.Create(this), CanvasId, PresentationParameters);
        }

        public async Task Clear(Color color)
        {
            await _jsRuntime.InvokeVoidAsync("BlazorGame.clear", color);
        }

        public async Task DrawTexture(string name, float x, float y, Color color)
        {
            await _jsRuntime.InvokeVoidAsync("BlazorGame.drawTexture", name, x, y, color);
        }

        public async Task DrawSprite(string name, float x, float y, float sourceTop, float sourceLeft, float sourceBottom, float sourceRight, bool flipHorizontal, bool flipVertical, Color color)
        {            
            await _jsRuntime.InvokeVoidAsync("BlazorGame.drawSprite", name, x, y, sourceTop, sourceLeft, sourceBottom, sourceRight, flipHorizontal, flipVertical, color);
        }

        public async Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            await _jsRuntime.InvokeVoidAsync("BlazorGame.drawString", spriteFont, text, position, color);
        }

        [JSInvokable]
        public async Task Render(float timestamp)
        {
            var elapsed = new TimeSpan((long)(timestamp * 10000));
            totalGameTime = totalGameTime.Add(elapsed);

            await OnReady(new GameTime { ElapsedGameTime = elapsed, TotalGameTime = totalGameTime });
        }

        public async Task Clear(ClearOptions options, Color color, float depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public async Task Clear(ClearOptions options, Vector4 color, float depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public async Task DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public async Task DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int instanceCount)
        {
            throw new NotImplementedException();
        }

        public async Task DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int baseInstance, int instanceCount)
        {
            throw new NotImplementedException();
        }

        public async Task DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount) where T : struct, IVertexType
        {
            throw new NotImplementedException();
        }

        public async Task DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
        {
            throw new NotImplementedException();
        }

        public async Task Flush()
        {
            throw new NotImplementedException();
        }

        public async Task GetBackBufferData<T>(T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public async Task GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public async Task GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public Task<RenderTargetBinding[]> GetRenderTargets()
        {
            throw new NotImplementedException();
        }

        public async Task GetRenderTargets(RenderTargetBinding[] outTargets)
        {
            throw new NotImplementedException();
        }

        public async Task Present()
        {
            throw new NotImplementedException();
        }

        public async Task Reset()
        {
            throw new NotImplementedException();
        }

        public async Task Reset(PresentationParameters presentationParameters)
        {
            throw new NotImplementedException();
        }

        public async Task SetRenderTarget(RenderTarget2D renderTarget)
        {
            await _jsRuntime.InvokeVoidAsync("BlazorGame.setRenderTarget", renderTarget);
        }

        public async Task SetRenderTarget(RenderTarget2D renderTarget, int arraySlice)
        {
            throw new NotImplementedException();
        }

        public async Task SetRenderTarget(RenderTarget3D renderTarget, int arraySlice)
        {
            throw new NotImplementedException();
        }

        public async Task SetRenderTarget(RenderTargetCube renderTarget, CubeMapFace cubeMapFace)
        {
            throw new NotImplementedException();
        }

        public async Task SetRenderTargets(params RenderTargetBinding[] renderTargets)
        {
            throw new NotImplementedException();
        }

        public async Task SetVertexBuffer(VertexBuffer vertexBuffer)
        {
            throw new NotImplementedException();
        }

        public async Task SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset)
        {
            throw new NotImplementedException();
        }

        public async Task SetVertexBuffers(params VertexBufferBinding[] vertexBuffers)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {

        }
    }
}