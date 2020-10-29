using System;

namespace BlazorGame.Framework.Graphics
{
    public class VertexBuffer : GraphicsResource, IDisposable
    {
        public BufferUsage BufferUsage { get; }
        public int VertexCount { get; }
        public VertexDeclaration VertexDeclaration { get; }

        public VertexBuffer(IGraphicsDevice graphicsDevice, VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage bufferUsage)
        {
            throw new NotImplementedException();
        }

        protected VertexBuffer(IGraphicsDevice graphicsDevice, VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage bufferUsage, bool dynamic)
        {
            throw new NotImplementedException();
        }

        public VertexBuffer(IGraphicsDevice graphicsDevice, Type type, int vertexCount, BufferUsage bufferUsage)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride = 0) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) where T : struct
        {
            throw new NotImplementedException();
        }

        protected void SetDataInternal<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride, SetDataOptions options) where T : struct
        {
            throw new NotImplementedException();
        }

        protected override void GraphicsDeviceResetting()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}
