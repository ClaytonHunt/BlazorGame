using BlazorGame.Framework.Graphics;
using System;

namespace BlazorGame.Framework.Graphics
{
    public class SamplerState : GraphicsResource, IDisposable
    {
        public static readonly SamplerState AnisotropicClamp;
        public static readonly SamplerState AnisotropicWrap;
        public static readonly SamplerState LinearClamp;
        public static readonly SamplerState LinearWrap;
        public static readonly SamplerState PointClamp;
        public static readonly SamplerState PointWrap;

        public TextureAddressMode AddressU { get; set; }
        public TextureAddressMode AddressV { get; set; }
        public TextureAddressMode AddressW { get; set; }
        public Color BorderColor { get; set; }
        public CompareFunction ComparisonFunction { get; set; }
        public TextureFilter Filter { get; set; }
        public TextureFilterMode FilterMode { get; set; }
        public int MaxAnisotropy { get; set; }
        public int MaxMipLevel { get; set; }
        public float MipMapLevelOfDetailBias { get; set; }

        public SamplerState()
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
