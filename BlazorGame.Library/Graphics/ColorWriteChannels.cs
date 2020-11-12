using System;

namespace BlazorGame.Framework.Graphics
{
    [Flags]
    public enum ColorWriteChannels
    {
        All,
        Alpha,
        Blue,
        Green,
        None,
        Red
    }
}
