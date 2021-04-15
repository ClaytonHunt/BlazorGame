namespace BlazorGame.Framework.Graphics
{
    public struct Rectangle
    {
        public float Top {get;set;}
        public float Left {get;set;}
        public float Bottom {get;set;}
        public float Right {get;set;}

        public Rectangle(float top, float left, float bottom, float right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }

    public struct ColorRectangle
    {
        public Color TopLeft {get;set;}
        public Color TopRight {get;set;}
        public Color BottomLeft {get;set;}
        public Color BottomRight {get;set;}

        public ColorRectangle(Color color): this(color, color, color ,color) { }

        public ColorRectangle(Color topLeft, Color topRight, Color bottomLeft, Color bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
    }
}
