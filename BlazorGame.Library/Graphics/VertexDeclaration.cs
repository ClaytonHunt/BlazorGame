using System;

namespace BlazorGame.Framework.Graphics
{
    public class VertexDeclaration : GraphicsResource, IDisposable, IEquatable<VertexDeclaration>
    {
        public int VertexStride { get; }

        public VertexDeclaration(params VertexElement[] elements)
        {
            
        }

        public VertexDeclaration(int vertexStride, params VertexElement[] elements)
        {
            throw new NotImplementedException();
        }

        public VertexElement[] GetVertexElements()
        {
            throw new NotImplementedException();
        }

        public bool Equals(VertexDeclaration other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(VertexDeclaration left, VertexDeclaration right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(VertexDeclaration left, VertexDeclaration right)
        {
            throw new NotImplementedException();
        }
    }
}
