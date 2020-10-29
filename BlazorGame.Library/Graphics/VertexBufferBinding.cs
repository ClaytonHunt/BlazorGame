using System;

namespace BlazorGame.Framework.Graphics
{
    public struct VertexBufferBinding
    {
        public int InstanceFrequency { get; }
        public VertexBuffer VertexBuffer { get; }
        public int VertexOffset { get; }

        public VertexBufferBinding(VertexBuffer vertexBuffer)
        {
            throw new NotImplementedException();
        }

        public VertexBufferBinding(VertexBuffer vertexBuffer, int vertexOffset)
        {
            throw new NotImplementedException();
        }

        public VertexBufferBinding(VertexBuffer vertexBuffer, int vertexOffset, int instanceFrequency)
        {
            throw new NotImplementedException();
        }
    }
}
