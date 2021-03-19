using System;
using System.Threading.Tasks;

namespace BlazorGame.Framework.Graphics
{
    public interface IGraphicsDevice : IDisposable
    {
        GraphicsAdapter Adapter { get; }
        Color BlendFactor { get; set; }
        BlendState BlendState { get; set; }
        DepthStencilState DepthStencilState { get; set; }
        static Color DiscardColor { get; set; }
        DisplayMode DisplayMode { get; }
        GraphicsDebug GraphicsDebug { get; set; }
        GraphicsDeviceStatus GraphicsDeviceStatus { get; }
        GraphicsProfile GraphicsProfile { get; }
        object Handle { get; }
        IndexBuffer Indices { get; set; }
        bool IsContentLost { get; }
        bool IsDisposed { get; }
        GraphicsMetrics Metrics { get; set; }
        PresentationParameters PresentationParameters { get; set; }
        RasterizerState RasterizerState { get; set; }
        int RenderTargetCount { get; }
        bool ResourcesLost { get; set; }
        SamplerStateCollection SamplerStates { get; }
        Rectangle ScissorRectangle { get; set; }
        TextureCollection Textures { get; }
        bool UseHalfPixelOffset { get; }
        SamplerStateCollection VertexSamplerStates { get; }
        TextureCollection VertexTextures { get; }
        Viewport Viewport { get; set; }

        event Func<GameTime, Task> OnReady;
        event EventHandler<EventArgs> DeviceLost;
        event EventHandler<EventArgs> DeviceReset;
        event EventHandler<EventArgs> DeviceResetting;
        event EventHandler<EventArgs> Disposing;
        event EventHandler<ResourceCreatedEventArgs> ResourceCreated;
        event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed;

        Task Initialize();
        Task Clear(Color color);
        Task Clear(ClearOptions options, Color color, float depth, int stencil);
        Task Clear(ClearOptions options, Vector4 color, float depth, int stencil);
        Task DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount);
        Task DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int instanceCount);
        Task DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int baseInstance, int instanceCount);
        Task DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount);
        Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        Task DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        Task DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount) where T : struct, IVertexType;
        Task DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        Task Flush();
        Task GetBackBufferData<T>(T[] data) where T : struct;
        Task GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct;
        Task GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;
        Task<RenderTargetBinding[]> GetRenderTargets();
        Task GetRenderTargets(RenderTargetBinding[] outTargets);
        Task Present();
        Task Reset();
        Task Reset(PresentationParameters presentationParameters);
        Task SetRenderTarget(RenderTarget2D renderTarget);
        Task SetRenderTarget(RenderTarget2D renderTarget, int arraySlice);
        Task SetRenderTarget(RenderTarget3D renderTarget, int arraySlice);
        Task SetRenderTarget(RenderTargetCube renderTarget, CubeMapFace cubeMapFace);
        Task SetRenderTargets(params RenderTargetBinding[] renderTargets);
        Task SetVertexBuffer(VertexBuffer vertexBuffer);
        Task SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset);
        Task SetVertexBuffers(params VertexBufferBinding[] vertexBuffers);
        
        // Temporary to get the ball rolling
        // TODO: Replace with proper calls
        Task DrawTexture(string name, float x, float y, Color color);
        Task DrawSprite(string name, float x, float y, float sourceTop, float sourceLeft, float sourceBottom, float sourceRight, bool flipHorizontal, bool flipVertical, Color color);
        Task DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color);
    }
}