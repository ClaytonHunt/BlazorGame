using BlazorGame.Framework.Graphics;
using System;

namespace BlazorGame.Framework.Graphics
{
    public class RasterizerState : GraphicsResource, IDisposable
    {
        public static readonly RasterizerState CullClockwise;
        public static readonly RasterizerState CullCounterClockwise;
        public static readonly RasterizerState CullNone;

        public CullMode CullMode { get; set; }
        public float DepthBias { get; set; }
        public bool DepthClipEnable { get; set; }
        public FillMode FillMode { get; set; }
        public bool MultiSampleAntiAlias { get; set; }
        public bool ScissorTestEnable { get; set; }
        public float SlopeScaleDepthBias { get; set; }

        public RasterizerState()
        {

        }

        protected override void GraphicsDeviceResetting()
        {
            base.GraphicsDeviceResetting();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
