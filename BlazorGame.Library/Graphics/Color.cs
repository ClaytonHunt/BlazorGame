using System;

namespace BlazorGame.Framework.Graphics
{
    public struct Color
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color(float r, float g, float b) : this(r, g, b, 1) { }

        public Color(int r, int g, int b, int a) : this(r / 255f, g / 255f, b / 255f, a / 255f) { }

        public Color(int r, int g, int b) : this(r, g, b, 255)
        {
            Console.WriteLine($"Red: {r}, Green: {g}, Blue: {b}");
        }

        private Color(uint hexValue): this((int)(hexValue >> 16 & 255), (int)(hexValue >> 8 & 255), (int)(hexValue & 255)) { }

        public static Color Random()
        {
            var rand = new Random();
            return new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
        }

        public static Color CornFlowerBlue = new Color(0x6495ed);
        public static Color White = new Color(0xffffff);
        public static Color Red = new Color(0xff0000);
        public static Color Green = new Color(0x00ff00);
        public static Color Blue = new Color(0x0000ff);
    }
}
