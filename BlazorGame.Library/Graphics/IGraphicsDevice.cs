using System;

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
        PresentationParameters PresentationParameters { get; }
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

        event Action<GameTime> OnReady;
        event EventHandler<EventArgs> DeviceLost;
        event EventHandler<EventArgs> DeviceReset;
        event EventHandler<EventArgs> DeviceResetting;
        event EventHandler<EventArgs> Disposing;
        event EventHandler<ResourceCreatedEventArgs> ResourceCreated;
        event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed;

        void Initialize();
        void Clear(Color color);
        void Clear(ClearOptions options, Color color, float depth, int stencil);
        void Clear(ClearOptions options, Vector4 color, float depth, int stencil);
        void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount);
        void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int instanceCount);
        void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int baseInstance, int instanceCount);
        void DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount);
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void Flush();
        void GetBackBufferData<T>(T[] data) where T : struct;
        void GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct;
        void GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;
        RenderTargetBinding[] GetRenderTargets();
        void GetRenderTargets(RenderTargetBinding[] outTargets);
        void Present();
        void Reset();
        void Reset(PresentationParameters presentationParameters);
        void SetRenderTarget(RenderTarget2D renderTarget);
        void SetRenderTarget(RenderTarget2D renderTarget, int arraySlice);
        void SetRenderTarget(RenderTarget3D renderTarget, int arraySlice);
        void SetRenderTarget(RenderTargetCube renderTarget, CubeMapFace cubeMapFace);
        void SetRenderTargets(params RenderTargetBinding[] renderTargets);
        void SetVertexBuffer(VertexBuffer vertexBuffer);
        void SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset);
        void SetVertexBuffers(params VertexBufferBinding[] vertexBuffers);
        
        // Temporary to get the ball rolling
        // TODO: Replace with proper calls
        void DrawTexture(string name, float x, float y, Color color);
    }
}