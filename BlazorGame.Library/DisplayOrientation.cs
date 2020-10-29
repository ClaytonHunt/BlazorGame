using System;

namespace BlazorGame.Framework
{
    [Flags]
    public enum DisplayOrientation
    {
        Default,
        LandscapeLeft,
        LandscapeRight,
        Portrait,
        PortraitDown,
        Unknown
    }
}
