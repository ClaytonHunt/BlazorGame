using System;

namespace BlazorGame.Framework.Graphics
{
    public struct GraphicsMetrics
    {
        public long ClearCount { get; }
        public long DrawCount { get; }
        public long PixelShaderCount { get; }
        public long PrimitiveCount { get; }
        public long SpriteCount { get; }
        public long TargetCount { get; }
        public long TextureCount { get; }
        public long VertexShaderCount { get; }

        public static GraphicsMetrics operator +(GraphicsMetrics value1, GraphicsMetrics value2)
        {
            throw new NotImplementedException();
        }

        public static GraphicsMetrics operator -(GraphicsMetrics value1, GraphicsMetrics value2)
        {
            throw new NotImplementedException();
        }
    }
}
