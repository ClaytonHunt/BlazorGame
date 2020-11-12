using System;

namespace BlazorGame.Framework.Input.Touch
{
    [Flags]
public enum GestureType
    {
        DoubleTap,
        DragComplete,
        Flick,
        FreeDrag,
        Hold,
        HorizontalDrag,
        None,
        Pinch,
        PinchComplete,
        Tap,
        VerticalDrag
    }
}
