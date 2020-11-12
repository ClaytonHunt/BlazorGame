using System;

namespace BlazorGame.Framework.Graphics
{
    [Flags]
    public enum ClearOptions
    {
        DepthBuffer,
        Stencil,
        Target
    }
}
