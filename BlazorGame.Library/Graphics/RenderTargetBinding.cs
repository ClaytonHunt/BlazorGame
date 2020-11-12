using System;

namespace BlazorGame.Framework.Graphics
{
    public struct RenderTargetBinding
    {
        public int ArraySlice { get; }
        public Texture RenderTarget { get; }

        public RenderTargetBinding(RenderTarget2D renderTarget)
        {
            throw new NotImplementedException();
        }

        public RenderTargetBinding(RenderTarget2D renderTarget, int arraySlice)
        {
            throw new NotImplementedException();
        }

        public RenderTargetBinding(RenderTarget3D renderTarget)
        {
            throw new NotImplementedException();
        }

        public RenderTargetBinding(RenderTarget3D renderTarget, int arraySlice)
        {
            throw new NotImplementedException();
        }

        public RenderTargetBinding(RenderTargetCube renderTarget, CubeMapFace cubeMapFace)
        {
            throw new NotImplementedException();
        }

        public static implicit operator RenderTargetBinding(RenderTarget2D renderTarget)
        {
            throw new NotImplementedException();
        }

        public static implicit operator RenderTargetBinding(RenderTarget3D renderTarget)
        {
            throw new NotImplementedException();
        }
    }
}
