using BlazorGame.Framework.Graphics;

namespace BlazorGame.Framework.Graphics
{
    public class TargetBlendState
    {
        public BlendFunction AlphaBlendFunction { get; set; }
        public Blend AlphaDestinationBlend { get; set; }
        public Blend AlphaSourceBlend { get; set; }
        public BlendFunction ColorBlendFunction { get; set; }
        public Blend ColorDestinationBlend { get; set; }
        public Blend ColorSourceBlend { get; set; }
        public ColorWriteChannels ColorWriteChannels { get; set; }
    }
}
