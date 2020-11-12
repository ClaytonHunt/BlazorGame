using System;

namespace BlazorGame.Framework.Graphics
{
    public struct VertexElement : IEquatable<VertexElement>
    {
        public int Offset { get; set; }
        public int UsageIndex { get; set; }
        public VertexElementFormat VertexElementFormat { get; set; }
        public VertexElementUsage VertexElementUsage { get; set; }

        public VertexElement(int offset, VertexElementFormat elementFormat, VertexElementUsage elementUsage, int usageIndex)
        {
            throw new NotImplementedException();
        }

        public bool Equals(VertexElement other)
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

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(VertexElement left, VertexElement right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(VertexElement left, VertexElement right)
        {
            throw new NotImplementedException();
        }
    }
}
