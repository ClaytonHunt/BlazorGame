using System;

namespace BlazorGame.Framework.Graphics
{
    public class DepthStencilState : GraphicsResource, IDisposable
    {
        public static readonly DepthStencilState Default;
        public static readonly DepthStencilState DepthRead;
        public static readonly DepthStencilState None;

        public StencilOperation CounterClockwiseStencilDepthBufferFail { get; set; }
        public StencilOperation CounterClockwiseStencilFail { get; set; }
        public CompareFunction CounterClockwiseStencilFunction { get; set; }
        public StencilOperation CounterClockwiseStencilPass { get; set; }
        public bool DepthBufferEnable { get; set; }
        public CompareFunction DepthBufferFunction { get; set; }
        public bool DepthBufferWriteEnable { get; set; }
        public int ReferenceStencil { get; set; }
        public StencilOperation StencilDepthBufferFail { get; set; }
        public bool StencilEnable { get; set; }
        public StencilOperation StencilFail { get; set; }
        public CompareFunction StencilFunction { get; set; }
        public int StencilMask { get; set; }
        public StencilOperation StencilPass { get; set; }
        public int StencilWriteMask { get; set; }
        public bool TwoSidedStencilMode { get; set; }

        public DepthStencilState()
        {

        }        

        protected override void GraphicsDeviceResetting()
        {

        }

        protected override void Dispose(bool disposing)
        {

        }
    }
}
