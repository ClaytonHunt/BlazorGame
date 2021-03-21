using System;
using System.Runtime.Serialization;

namespace BlazorGame.Framework.Graphics
{
    [DataContract]
    public struct VertexPositionColor : IVertexType
    {
        [DataMember] public Color Color;
        [DataMember] public Vector3 Position;

        public VertexDeclaration VertexDeclaration { get; }

        public VertexPositionColor(Vector3 position, Color color)
        {
            Position = position;
            Color = color;
            VertexDeclaration = new VertexDeclaration(null);
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

        public static bool operator ==(VertexPositionColor left, VertexPositionColor right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(VertexPositionColor left, VertexPositionColor right)
        {
            return !(left == right);
        }
    }
}