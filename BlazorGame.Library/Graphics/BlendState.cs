using System;

namespace BlazorGame.Framework.Graphics
{
    public partial class BlendState : GraphicsResource, IDisposable
    {
        public static readonly BlendState Additive;
        public static readonly BlendState AlphaBlend;
        public static readonly BlendState NonPremultiplied;
        public static readonly BlendState Opaque;

        public BlendFunction AlphaBlendFunction { get; set; }
        public Blend AlphaDestinationBlend { get; set; }
        public Blend AlphaSourceBlend { get; set; }
        public Color BlendFactor { get; set; }
        public BlendFunction ColorBlendFunction { get; set; }
        public Blend ColorDestinationBlend { get; set; }
        public Blend ColorSourceBlend { get; set; }
        public ColorWriteChannels ColorWriteChannels { get; set; }
        public ColorWriteChannels ColorWriteChannels1 { get; set; }
        public ColorWriteChannels ColorWriteChannels2 { get; set; }
        public ColorWriteChannels ColorWriteChannels3 { get; set; }
        public bool IndependentBlendEnable { get; set; }
        public TargetBlendState this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public int MultiSampleMask { get; set; }

        public BlendState()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {

        }

        protected override void GraphicsDeviceResetting()
        {

        }
    }
}
