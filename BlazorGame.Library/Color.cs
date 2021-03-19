using System;

namespace BlazorGame.Framework
{
    public struct Color : IEquatable<Color>
    {
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public static Color Black => new(0, 0, 0, 255);
        public static Color CornflowerBlue => new(100, 149, 237, 255);
        public static Color LightSlateGray => new(119, 136, 153, 255);
        public static Color Red => new(255, 0, 0, 255);
        public static Color White => new(255, 255, 255, 255);
        public static Color Yellow => new(255, 255, 0, 255);
        public static Color Transparent => new(0, 0, 0, 0);

        public Color(Color color, int alpha)
        {
            R = color.R;
            B = color.B;
            G = color.G;
            A = (byte)alpha;
        }

        public Color(Color color, float alpha)
        {
            R = color.R;
            B = color.B;
            G = color.G;
            A = (byte)(255 * alpha);
        }

        public Color(Vector3 color)
        {
            R = (byte)color.X;
            B = (byte)color.Y;
            G = (byte)color.Z;
            A = 255;
        }

        public Color(Vector4 color)
        {
            R = (byte)color.X;
            B = (byte)color.Y;
            G = (byte)color.Z;
            A = (byte)color.W;
        }

        public Color(byte r, byte g, byte b, byte alpha)
        {
            R = r;
            B = b;
            G = g;
            A = alpha;
        }

        public Color(int r, int g, int b)
        {
            R = (byte)r;
            B = (byte)b;
            G = (byte)g;
            A = 255;
        }

        public Color(int r, int g, int b, int alpha)
        {
            R = (byte)r;
            B = (byte)b;
            G = (byte)g;
            A = (byte)alpha;
        }

        public Color(float r, float g, float b)
        {
            R = (byte)(255 * r);
            B = (byte)(255 * b);
            G = (byte)(255 * g);
            A = 255;
        }

        public Color(float r, float g, float b, float alpha)
        {
            R = (byte)(255 * r);
            G = (byte)(255 * g);
            B = (byte)(255 * b);
            A = (byte)(255 * alpha);
        }

        public Color(uint packedValue)
        {
            R = (byte)(packedValue & 255);
            G = (byte)(packedValue & (255 << 8));
            B = (byte)(packedValue & (255 << 16));
            A = (byte)(packedValue & (255 << 24));
        }

        public void Deconstruct(out byte r, out byte g, out byte b)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out byte r, out byte g, out byte b, out byte a)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out float r, out float g, out float b)
        {
            throw new NotImplementedException();
        }

        public void Deconstruct(out float r, out float g, out float b, out float a)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Color other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public static Color FromNonPremultiplied(Vector4 vector)
        {
            throw new NotImplementedException();
        }

        public static Color FromNonPremultiplied(int r, int g, int b, int a)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static Color Lerp(Color value1, Color value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static Color Multiply(Color value, float scale)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Vector3 ToVector3()
        {
            throw new NotImplementedException();
        }

        public Vector4 ToVector4()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Color a, Color b)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Color a, Color b)
        {
            throw new NotImplementedException();
        }

        public static Color operator *(Color value, float scale)
        {
            return new Color(Math.Min(value.R * scale, 255), Math.Min(value.G * scale, 255),
                Math.Min(value.B * scale, 255), Math.Min(value.A * scale, 255));
        }

        public static Color operator *(float scale, Color value)
        {
            throw new NotImplementedException();
        }
    }
}
