using System;

namespace BlazorGame.Framework.Graphics
{
    public class IndexBuffer : GraphicsResource, IDisposable
    {
        public BufferUsage BufferUsage { get; }
        public int IndexCount { get; }
        public IndexElementSize IndexElementSize { get; }

        public IndexBuffer(IGraphicsDevice graphicsDevice, IndexElementSize indexElementSize, int indexCount, BufferUsage bufferUsage)
        {
            throw new NotImplementedException();
        }

        protected IndexBuffer(IGraphicsDevice graphicsDevice, IndexElementSize indexElementSize, int indexCount, BufferUsage usage, bool dynamic)
        {
            throw new NotImplementedException();
        }

        public IndexBuffer(IGraphicsDevice graphicsDevice, Type indexType, int indexCount, BufferUsage usage)
        {
            throw new NotImplementedException();
        }

        protected IndexBuffer(IGraphicsDevice graphicsDevice, Type indexType, int indexCount, BufferUsage usage, bool dynamic)
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

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct
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

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        protected void SetDataInternal<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct
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
